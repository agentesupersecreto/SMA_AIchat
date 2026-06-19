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
    public class OllamaClient : IApiClient
    {
        private DialogBehaviour _behaviour;
        private const int SLIDING_WINDOW_SIZE = 5; // Keep last 5 exchanges (10 messages)

        public OllamaClient(DialogBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public IEnumerator SendMessage(string mensajeUsuario)
        {
            string url = _behaviour.OllamaUrl;
            string model = _behaviour.OllamaModel;

            // Build the full prompt with system instructions + sliding window history
            string systemPrompt = PromptBuilder.GenerateSystemPrompt();
            string fullPrompt = BuildPromptWithHistory(systemPrompt, mensajeUsuario);

            // Ollama API body — stream: false for a single response
            string promptEscapado = JsonHelper.EscapeJson(fullPrompt);
            string body = $"{{\"model\":\"{JsonHelper.EscapeJson(model)}\",\"prompt\":\"{promptEscapado}\",\"stream\":false,\"options\":{{\"num_predict\":150}}}}";

            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            request.timeout = 120; // Local models can be slow

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                string error = request.error;
                string responseBody = request.downloadHandler?.text ?? "";
                Plugin.Log.LogError($"Error de Ollama: {error} | Body: {responseBody}");

                if (error != null && error.Contains("Cannot connect"))
                    _behaviour.Window.SetStatus("[ERROR] Cannot connect to Ollama. Is it running? (ollama serve)", true);
                else
                    _behaviour.Window.SetStatus($"[ERROR] Ollama: {error}", true);

                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            string respuesta = request.downloadHandler.text;
            Plugin.Log.LogInfo($"Ollama raw response: {(respuesta.Length > 200 ? respuesta.Substring(0, 200) + "..." : respuesta)}");

            // Ollama returns {"response": "...", ...} — extract the "response" field
            string textoIA = JsonHelper.ExtractJsonValue(respuesta, "response");

            if (string.IsNullOrEmpty(textoIA))
            {
                _behaviour.Window.SetStatus("[ERROR] Empty response from Ollama.", true);
                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            ProcessAIResponse(textoIA);
            _behaviour.Window.AwaitingResponse = false;
        }

        private string BuildPromptWithHistory(string systemPrompt, string currentMessage)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[SYSTEM INSTRUCTIONS]");
            sb.AppendLine(systemPrompt);
            sb.AppendLine("[END SYSTEM INSTRUCTIONS]");
            sb.AppendLine();

            // Sliding window: include only the last N exchanges
            int windowMessages = SLIDING_WINDOW_SIZE * 2; // 5 exchanges = 10 messages
            int startIdx = 0;
            int nonSystemCount = 0;

            // Count non-system messages
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

            if (nonSystemCount > 0)
            {
                sb.AppendLine("[CONVERSATION HISTORY]");
                for (int i = startIdx; i < _behaviour.ChatHistory.Count; i++)
                {
                    var msg = _behaviour.ChatHistory[i];
                    if (msg.IsSystem) continue;
                    sb.AppendLine(msg.IsUser ? $"Player: {msg.Text}" : $"You: {msg.Text}");
                }
                sb.AppendLine("[END HISTORY]");
                sb.AppendLine();
            }

            sb.AppendLine($"Player: {currentMessage}");
            sb.AppendLine();
            sb.AppendLine("Respond now with your dialogue in plain text. If you need to act, append [CMD: command_name] anywhere in your response.");

            return sb.ToString();
        }

        private void ProcessAIResponse(string respuestaJson)
        {
            try
            {
                // Strip markdown if the model wrapped it
                respuestaJson = JsonHelper.StripMarkdownCodeBlocks(respuestaJson);

                string dialogo = respuestaJson;
                // Extract ALL [CMD: command_name]
                var matches = System.Text.RegularExpressions.Regex.Matches(dialogo, @"\[CMD:\s*([^\]]+)\]", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Collections.Generic.List<string> comandosEncontrados = new System.Collections.Generic.List<string>();

                foreach (System.Text.RegularExpressions.Match m in matches)
                {
                    string contenido = m.Groups[1].Value.Trim();
                    // Remove the command tag from the dialogue
                    dialogo = dialogo.Replace(m.Value, "");

                    // Support comma-separated commands like [CMD: give_consent, pose:kneel]
                    string[] subCmds = contenido.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var sub in subCmds)
                    {
                        string c = sub.Trim();
                        if (!string.IsNullOrEmpty(c) && c.ToLower() != "null")
                        {
                            comandosEncontrados.Add(c);
                        }
                    }
                }
                dialogo = dialogo.Trim();

                // Small models might sometimes try to output JSON anyway
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
                                {
                                    comandosEncontrados.Add(c);
                                }
                            }
                        }
                        dialogo = innerDialogo;
                    }
                }

                _behaviour.ChatHistory.Add(new ChatMessage(false, dialogo));
                _behaviour.Window.ScrollToBottom();
                _behaviour.Window.SetStatus("[OK] Response received (Ollama).", false);

                ShowInBark(dialogo);

                foreach (string cmd in comandosEncontrados)
                {
                    string feedback = CommandExecutor.ExecuteCommand(cmd, _behaviour.Window.SetStatus, _behaviour.Window.ShowEmotionFeedback);
                    _behaviour.ChatHistory.Add(ChatMessage.SystemMessage($"⚡ {feedback}"));
                }

                if (comandosEncontrados.Count > 0)
                {
                    _behaviour.Window.ScrollToBottom();
                }

                // Sliding window: trim old messages beyond the window
                int maxMessages = (SLIDING_WINDOW_SIZE * 2) + 4; // A bit of buffer
                while (_behaviour.ChatHistory.Count > maxMessages)
                {
                    _behaviour.ChatHistory.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error procesando respuesta Ollama: {ex.Message}");
                _behaviour.Window.SetStatus("[ERROR] Error procesando respuesta de Ollama.", true);
            }
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
