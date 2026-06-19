using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using DialogInterceptorMod.Core;
using DialogInterceptorMod.Models;
using DialogInterceptorMod.Game;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;

namespace DialogInterceptorMod.API
{
    /// <summary>
    /// Local Gemma provider (e.g. gemma-the-writer-n-restless-quill-10b-uncensored)
    /// served via an Ollama-style /api/generate endpoint.
    ///
    /// Gemma requires its STRICT chat template using control tokens:
    ///   <start_of_turn>user\n{...}<end_of_turn>
    ///   <start_of_turn>model\n{...}<end_of_turn>
    /// The final <start_of_turn>model turn is left open so the model continues it.
    /// System instructions are prepended before the turns (Gemma has no dedicated
    /// system role in the base template).
    /// </summary>
    public class GemmaClient : IApiClient
    {
        // Control tokens — written as literal strings; the Gemma tokenizer
        // recognizes them as special tokens.
        private const string START_OF_TURN = "<start_of_turn>";
        private const string END_OF_TURN = "<end_of_turn>";

        private const int SLIDING_WINDOW_SIZE = 5; // Keep last 5 exchanges (10 messages)
        private const int MAX_OUTPUT_TOKENS = 150;

        private readonly DialogBehaviour _behaviour;

        public GemmaClient(DialogBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public IEnumerator SendMessage(string mensajeUsuario)
        {
            string url = _behaviour.GemmaUrl;
            string model = _behaviour.GemmaModel;

            string systemPrompt = PromptBuilder.GenerateSystemPrompt();
            string fullPrompt = BuildGemmaPrompt(systemPrompt, mensajeUsuario);

            string promptEscapado = JsonHelper.EscapeJson(fullPrompt);
            string body = $"{{\"model\":\"{JsonHelper.EscapeJson(model)}\",\"prompt\":\"{promptEscapado}\",\"stream\":false,\"options\":{{\"num_predict\":{MAX_OUTPUT_TOKENS}}}}}";

            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.timeout = 180; // 10B model can be slow on CPU/constrained GPUs

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                string error = request.error;
                string responseBody = request.downloadHandler?.text ?? "";
                Plugin.Log.LogError($"Error de Gemma: {error} | Body: {responseBody}");

                if (error != null && error.Contains("Cannot connect"))
                    _behaviour.Window.SetStatus("[ERROR] Cannot connect to Gemma server. Is Ollama running? (ollama serve)", true);
                else
                    _behaviour.Window.SetStatus($"[ERROR] Gemma: {error}", true);

                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            string respuesta = request.downloadHandler.text;
            Plugin.Log.LogInfo($"Gemma raw response: {(respuesta.Length > 200 ? respuesta.Substring(0, 200) + "..." : respuesta)}");

            // Ollama-style response: extract the "response" field.
            string textoIA = JsonHelper.ExtractJsonValue(respuesta, "response");

            if (string.IsNullOrEmpty(textoIA))
            {
                _behaviour.Window.SetStatus("[ERROR] Empty response from Gemma.", true);
                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            // Stop at the model's own <end_of_turn> / next <start_of_turn> if it kept going.
            textoIA = TruncateAtTurnBoundary(textoIA);

            ProcessAIResponse(textoIA);
            _behaviour.Window.AwaitingResponse = false;
        }

        /// <summary>
        /// Builds the strict Gemma chat template:
        ///   {system prompt}
        ///   <start_of_turn>user\n{msg}<end_of_turn>
        ///   <start_of_turn>model\n{msg}<end_of_turn>
        ///   ...
        ///   <start_of_turn>user\n{current}<end_of_turn>
        ///   <start_of_turn>model\n   <- left open for generation
        /// </summary>
        private string BuildGemmaPrompt(string systemPrompt, string currentMessage)
        {
            StringBuilder sb = new StringBuilder();

            // System instructions go first (Gemma has no system role in the base template).
            if (!string.IsNullOrEmpty(systemPrompt))
            {
                sb.Append(systemPrompt.Trim());
                sb.Append("\n\n");
            }

            // Sliding window: include only the last N exchanges (non-system messages).
            int windowMessages = SLIDING_WINDOW_SIZE * 2;
            int startIdx = 0;
            int nonSystemCount = 0;
            for (int i = _behaviour.ChatHistory.Count - 1; i >= 0; i--)
            {
                if (!_behaviour.ChatHistory[i].IsSystem)
                {
                    nonSystemCount++;
                    if (nonSystemCount >= windowMessages)
                    {
                        startIdx = i;
                        break;
                    }
                }
            }

            for (int i = startIdx; i < _behaviour.ChatHistory.Count; i++)
            {
                var msg = _behaviour.ChatHistory[i];
                if (msg.IsSystem) continue;
                string role = msg.IsUser ? "user" : "model";
                sb.Append(START_OF_TURN).Append(role).Append('\n')
                  .Append(msg.Text).Append('\n')
                  .Append(END_OF_TURN).Append('\n');
            }

            // Current user turn, then open the model turn.
            sb.Append(START_OF_TURN).Append("user\n")
              .Append(currentMessage).Append('\n')
              .Append(END_OF_TURN).Append('\n');
            sb.Append(START_OF_TURN).Append("model\n");

            return sb.ToString();
        }

        /// <summary>
        /// Extracts [CMD: ...] tags from the model's free-text reply and applies them,
        /// then trims the history to the sliding window.
        /// </summary>
        private void ProcessAIResponse(string respuesta)
        {
            try
            {
                respuesta = JsonHelper.StripMarkdownCodeBlocks(respuesta);

                string dialogo = respuesta;
                var matches = System.Text.RegularExpressions.Regex.Matches(
                    dialogo, @"\[CMD:\s*([^\]]+)\]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                var comandosEncontrados = new System.Collections.Generic.List<string>();

                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    string contenido = m.Groups[1].Value.Trim();
                    dialogo = dialogo.Replace(m.Value, "");

                    // Support comma-separated commands like [CMD: give_consent, pose:kneel]
                    string[] subCmds = contenido.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var sub in subCmds)
                    {
                        string c = sub.Trim();
                        if (!string.IsNullOrEmpty(c) && c.ToLower() != "null")
                            comandosEncontrados.Add(c);
                    }
                }
                dialogo = dialogo.Trim();

                // Small models sometimes emit JSON despite plain-text instructions.
                if (dialogo.StartsWith("{") && dialogo.Contains("\"dialogo\""))
                {
                    string innerDialogo = JsonHelper.ExtractJsonValue(dialogo, "dialogo");
                    if (!string.IsNullOrEmpty(innerDialogo))
                    {
                        string innerComando = JsonHelper.ExtractJsonValue(dialogo, "comando");
                        if (!string.IsNullOrEmpty(innerComando))
                        {
                            string[] subCmds = innerComando.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (var sub in subCmds)
                            {
                                string c = sub.Trim();
                                if (!string.IsNullOrEmpty(c) && c.ToLower() != "null" && !comandosEncontrados.Contains(c))
                                    comandosEncontrados.Add(c);
                            }
                        }
                        dialogo = innerDialogo;
                    }
                }

                _behaviour.ChatHistory.Add(new ChatMessage(false, dialogo));
                _behaviour.Window.ScrollToBottom();
                _behaviour.Window.SetStatus("[OK] Response received (Gemma).", false);

                ShowInBark(dialogo);

                foreach (string cmd in comandosEncontrados)
                {
                    string feedback = CommandExecutor.ExecuteCommand(cmd, _behaviour.Window.SetStatus, _behaviour.Window.ShowEmotionFeedback);
                    _behaviour.ChatHistory.Add(ChatMessage.SystemMessage($"⚡ {feedback}"));
                }

                if (comandosEncontrados.Count > 0)
                    _behaviour.Window.ScrollToBottom();

                // Sliding window: trim old messages beyond the window.
                int maxMessages = (SLIDING_WINDOW_SIZE * 2) + 4; // small buffer
                while (_behaviour.ChatHistory.Count > maxMessages)
                    _behaviour.ChatHistory.RemoveAt(0);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error proccesing Gemma response: {ex.Message}");
                _behaviour.Window.SetStatus("[ERROR] Error proccesing Gemma response.", true);
            }
        }

        /// <summary>
        /// If the model continues past its own turn (emitting a new control token),
        /// cut the reply at that boundary so we only keep the model's actual line.
        /// </summary>
        private string TruncateAtTurnBoundary(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            int cut = text.Length;
            int nextStart = text.IndexOf(START_OF_TURN, StringComparison.Ordinal);
            if (nextStart >= 0) cut = Math.Min(cut, nextStart);
            int nextEnd = text.IndexOf(END_OF_TURN, StringComparison.Ordinal);
            if (nextEnd >= 0) cut = Math.Min(cut, nextEnd);
            return text.Substring(0, cut).Trim();
        }

        private void ShowInBark(string texto)
        {
            ControlladorDeBarkDePersonalidad[] controladores = UnityEngine.Object.FindObjectsOfType<ControlladorDeBarkDePersonalidad>(true);
            if (controladores != null && controladores.Length > 0)
            {
                foreach (var c in controladores)
                {
                    c.Bark(texto, true, 100, ControllerPrioridadConfig.interrumpir, 1f, 1f);
                }
            }
        }
    }
}
