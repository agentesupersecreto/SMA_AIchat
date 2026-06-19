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
    public class GeminiClient : IApiClient
    {
        private DialogBehaviour _behaviour;

        public GeminiClient(DialogBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public IEnumerator SendMessage(string mensajeUsuario)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-lite-latest:generateContent?key={_behaviour.ApiKey}";
            string systemPromptStr = PromptBuilder.GenerateSystemPrompt();

            // Include summary in system prompt if available
            if (!string.IsNullOrEmpty(_behaviour.ChatSummary))
            {
                systemPromptStr = $"[PAST EVENTS SUMMARY]\n{_behaviour.ChatSummary}\n[END SUMMARY]\n\n{systemPromptStr}";
            }

            StringBuilder contentsJson = new StringBuilder();
            contentsJson.Append("[");

            bool primero = true;
            foreach (var msg in _behaviour.ChatHistory)
            {
                if (msg.IsSystem) continue; // Skip system feedback messages
                if (!primero) contentsJson.Append(",");
                primero = false;
                string role = msg.IsUser ? "user" : "model";
                string textoEscapado = EscapeJson(msg.IsUser ? msg.Text : $"{{\"dialogo\": \"{msg.Text}\", \"comando\": null}}");
                contentsJson.Append($"{{\"role\":\"{role}\",\"parts\":[{{\"text\":\"{textoEscapado}\"}}]}}");
            }
            contentsJson.Append("]");

            string systemEscapado = EscapeJson(systemPromptStr);
            string body = $"{{\"system_instruction\":{{\"parts\":[{{\"text\":\"{systemEscapado}\"}}]}},\"contents\":{contentsJson.ToString()},\"generationConfig\":{{\"maxOutputTokens\":512}}}}";

            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                string error = request.error;
                string responseBody = request.downloadHandler?.text ?? "";
                Plugin.Log.LogError($"Error de Gemini: {error} | Body: {responseBody}");
                
                string errorMsg = ExtractErrorMessage(responseBody);
                if (!string.IsNullOrEmpty(errorMsg))
                    _behaviour.Window.SetStatus($"[ERROR] API Error: {errorMsg}", true);
                else
                    _behaviour.Window.SetStatus($"[ERROR] {error}", true);

                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            string respuesta = request.downloadHandler.text;
            string textoIA = ExtractResponseText(respuesta);

            if (string.IsNullOrEmpty(textoIA))
            {
                _behaviour.Window.SetStatus("[ERROR] Could not parse JSON response.", true);
                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            ProcessAIResponse(textoIA);
            _behaviour.Window.AwaitingResponse = false;
        }

        private void ProcessAIResponse(string respuestaJson)
        {
            try
            {
                string dialogo = JsonHelper.ExtractJsonValue(respuestaJson, "dialogo");
                string comandoRaw = JsonHelper.ExtractJsonValueFromEnd(respuestaJson, "comando");

                if (string.IsNullOrEmpty(dialogo))
                {
                    dialogo = respuestaJson;
                }

                // Support comma-separated commands: e.g. "give_consent, pose:kneel"
                var comandosEncontrados = new System.Collections.Generic.List<string>();
                if (!string.IsNullOrEmpty(comandoRaw) && comandoRaw.ToLower() != "null")
                {
                    string[] subCmds = comandoRaw.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var sub in subCmds)
                    {
                        string c = sub.Trim();
                        if (!string.IsNullOrEmpty(c) && c.ToLower() != "null")
                            comandosEncontrados.Add(c);
                    }
                }

                _behaviour.ChatHistory.Add(new ChatMessage(false, dialogo));
                _behaviour.Window.ScrollToBottom();
                _behaviour.Window.SetStatus("[OK] Response received.", false);

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

                // Gemini uses summarization for memory
                if (_behaviour.ChatHistory.Count > 10)
                {
                    _behaviour.StartCoroutine(GenerateSummaryAndClean());
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error procesando respuesta IA: {ex.Message}");
                _behaviour.Window.SetStatus("[ERROR] Error procesando el JSON devuelto por Gemini.", true);
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

        private IEnumerator GenerateSummaryAndClean()
        {
            int mensajesAResumirCount = 6;
            if (_behaviour.ChatHistory.Count <= mensajesAResumirCount) yield break;

            StringBuilder textoAResumir = new StringBuilder();
            int counted = 0;
            for (int i = 0; i < _behaviour.ChatHistory.Count && counted < mensajesAResumirCount; i++)
            {
                var msg = _behaviour.ChatHistory[i];
                if (msg.IsSystem) continue;
                textoAResumir.AppendLine((msg.IsUser ? "Player: " : "Model: ") + msg.Text);
                counted++;
            }

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-lite-latest:generateContent?key={_behaviour.ApiKey}";
            string currentSummary = _behaviour.ChatSummary;
            
            string sysPrompt = "Summarize the key events and context of this conversation briefly in English. Combine it with the previous summary if provided.";
            string prompt = (string.IsNullOrEmpty(currentSummary) ? "" : $"Previous Summary: {currentSummary}\n\n") + $"New Chat Messages to summarize:\n{textoAResumir.ToString()}";

            string bodyStr = $"{{\"system_instruction\":{{\"parts\":[{{\"text\":\"{EscapeJson(sysPrompt)}\"}}]}},\"contents\":[{{\"role\":\"user\",\"parts\":[{{\"text\":\"{EscapeJson(prompt)}\"}}]}}],\"generationConfig\":{{\"maxOutputTokens\":512}}}}";

            byte[] bodyBytes = Encoding.UTF8.GetBytes(bodyStr);
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            request.uploadHandler = new UploadHandlerRaw(bodyBytes);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Plugin.Log.LogWarning($"No se pudo generar el resumen: {request.error}");
                yield break;
            }

            string respuesta = request.downloadHandler.text;
            string textoIA = ExtractResponseText(respuesta);

            if (!string.IsNullOrEmpty(textoIA))
            {
                _behaviour.ChatSummary = textoIA;
                // Remove the oldest non-system messages
                int removed = 0;
                while (removed < mensajesAResumirCount && _behaviour.ChatHistory.Count > 0)
                {
                    if (!_behaviour.ChatHistory[0].IsSystem)
                    {
                        _behaviour.ChatHistory.RemoveAt(0);
                        removed++;
                    }
                    else
                    {
                        _behaviour.ChatHistory.RemoveAt(0);
                    }
                }
                Plugin.Log.LogInfo($"Resumen actualizado. Mensajes restantes: {_behaviour.ChatHistory.Count}");
            }
        }

        private string ExtractErrorMessage(string errorJson)
        {
            string msg = JsonHelper.ExtractJsonValue(errorJson, "message");
            if (string.IsNullOrEmpty(msg)) return null;
            if (msg.Length > 80) return msg.Substring(0, 77) + "...";
            return msg;
        }

        private string ExtractResponseText(string json)
        {
            int partsIdx = json.IndexOf("\"parts\"");
            if (partsIdx < 0) return null;
            int textKeyIdx = json.IndexOf("\"text\"", partsIdx);
            if (textKeyIdx < 0) return null;
            int colonIdx = json.IndexOf(':', textKeyIdx + 6);
            if (colonIdx < 0) return null;
            int startQuote = json.IndexOf('"', colonIdx + 1);
            if (startQuote < 0) return null;

            StringBuilder result = new StringBuilder();
            int i = startQuote + 1;
            while (i < json.Length)
            {
                char c = json[i];
                if (c == '\\' && i + 1 < json.Length)
                {
                    char next = json[i + 1];
                    switch (next)
                    {
                        case '"': result.Append('"'); break;
                        case '\\': result.Append('\\'); break;
                        case 'n': result.Append('\n'); break;
                        case 'r': break;
                        case 't': result.Append('\t'); break;
                        default: result.Append(next); break;
                    }
                    i += 2;
                }
                else if (c == '"') break;
                else { result.Append(c); i++; }
            }
            
            string clean = result.ToString().Trim();
            if (clean.StartsWith("```json")) clean = clean.Substring(7);
            if (clean.StartsWith("```")) clean = clean.Substring(3);
            if (clean.EndsWith("```")) clean = clean.Substring(0, clean.Length - 3);
            
            return clean.Trim();
        }

        public static string EscapeJson(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }
    }
}
