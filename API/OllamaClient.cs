using System;
using System.Collections;
using System.Collections.Generic;
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

            // Normalize URL: if user has /api/generate, switch to /api/chat
            if (url.EndsWith("/api/generate"))
                url = url.Replace("/api/generate", "/api/chat");
            else if (!url.EndsWith("/api/chat"))
                url = url.TrimEnd('/') + "/api/chat";

            // Build the messages array for the /api/chat endpoint
            string systemPrompt = PromptBuilder.GenerateSystemPrompt();
            string messagesJson = BuildChatMessages(systemPrompt, mensajeUsuario);

            int approxTokens = (systemPrompt.Length + mensajeUsuario.Length) / 4;
            Plugin.Log.LogInfo($"Ollama /api/chat — system prompt: {systemPrompt.Length} chars (~{systemPrompt.Length/4} tokens), {_behaviour.ChatHistory.Count} history msgs");

            string body = $"{{\"model\":\"{JsonHelper.EscapeJson(model)}\",\"messages\":{messagesJson},\"stream\":false,\"options\":{{\"num_ctx\":8192,\"num_predict\":2048}}}}";

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
            Plugin.Log.LogInfo($"Ollama raw response: {(respuesta.Length > 300 ? respuesta.Substring(0, 300) + "..." : respuesta)}");

            // /api/chat returns {"message": {"role": "assistant", "content": "...", "thinking": "..."}, ...}
            string textoIA = ExtractChatContent(respuesta);

            // Thinking models (Gemma 4, etc.) may put all output in "thinking" with empty "content".
            // If content is empty, try to extract from thinking field.
            if (string.IsNullOrEmpty(textoIA))
            {
                string thinking = ExtractJsonField(respuesta, "thinking");
                if (!string.IsNullOrEmpty(thinking))
                {
                    Plugin.Log.LogInfo($"Ollama thinking model detected. Thinking length: {thinking.Length} chars");
                    // Try to find the actual dialogue in the thinking output.
                    // Thinking models often end their reasoning with the actual response.
                    textoIA = ExtractDialogueFromThinking(thinking);
                }
            }

            if (string.IsNullOrEmpty(textoIA))
            {
                string doneReason = JsonHelper.ExtractJsonValue(respuesta, "done_reason");
                if (doneReason == "length")
                {
                    string thinking = ExtractJsonField(respuesta, "thinking");
                    if (!string.IsNullOrEmpty(thinking))
                        _behaviour.Window.SetStatus("[ERROR] Thinking model ran out of tokens before producing a response. Try increasing context or use a non-thinking model.", true);
                    else
                        _behaviour.Window.SetStatus("[ERROR] Ollama: prompt too long for this model's context window.", true);
                }
                else
                    _behaviour.Window.SetStatus("[ERROR] Empty response from Ollama.", true);

                _behaviour.Window.AwaitingResponse = false;
                yield break;
            }

            AIResponseProcessor.ProcessResponse(textoIA, _behaviour, "Ollama");
            _behaviour.Window.AwaitingResponse = false;
        }

        /// <summary>
        /// Builds a JSON array of messages for the /api/chat endpoint.
        /// Format: [{"role":"system","content":"..."},{"role":"user","content":"..."},{"role":"assistant","content":"..."},...]
        /// </summary>
        private string BuildChatMessages(string systemPrompt, string currentMessage)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");

            // 1. System message
            sb.Append($"{{\"role\":\"system\",\"content\":\"{JsonHelper.EscapeJson(systemPrompt)}\"}}");

            // 2. Sliding window of conversation history
            int windowMessages = SLIDING_WINDOW_SIZE * 2; // 5 exchanges = 10 messages
            int startIdx = 0;
            int nonSystemCount = 0;

            // Count non-system messages from the end to find the window start
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

            // Add history messages with proper roles
            for (int i = startIdx; i < _behaviour.ChatHistory.Count; i++)
            {
                var msg = _behaviour.ChatHistory[i];
                if (msg.IsSystem) continue;

                string role = msg.IsUser ? "user" : "assistant";
                sb.Append($",{{\"role\":\"{role}\",\"content\":\"{JsonHelper.EscapeJson(msg.Text)}\"}}");
            }

            // 3. Current user message
            sb.Append($",{{\"role\":\"user\",\"content\":\"{JsonHelper.EscapeJson(currentMessage)}\"}}");

            sb.Append("]");
            return sb.ToString();
        }

        /// <summary>
        /// Extracts the assistant's content from an /api/chat response.
        /// Response format: {"message": {"role": "assistant", "content": "..."}, "done": true, ...}
        /// </summary>
        private string ExtractChatContent(string json)
        {
            // Find "message" object, then extract "content" from within it
            // Simple approach: find "content":" after "message":{
            int msgIdx = json.IndexOf("\"message\"");
            if (msgIdx < 0) return null;

            int contentIdx = json.IndexOf("\"content\":", msgIdx);
            if (contentIdx < 0) return null;

            // Find the opening quote of the content value
            int valueStart = json.IndexOf('"', contentIdx + 10);
            if (valueStart < 0) return null;
            valueStart++; // skip the quote

            // Find the closing quote (handle escaped quotes)
            StringBuilder result = new StringBuilder();
            for (int i = valueStart; i < json.Length; i++)
            {
                if (json[i] == '\\' && i + 1 < json.Length)
                {
                    char next = json[i + 1];
                    if (next == '"') { result.Append('"'); i++; }
                    else if (next == 'n') { result.Append('\n'); i++; }
                    else if (next == 'r') { result.Append('\r'); i++; }
                    else if (next == 't') { result.Append('\t'); i++; }
                    else if (next == '\\') { result.Append('\\'); i++; }
                    else { result.Append(json[i]); }
                }
                else if (json[i] == '"')
                {
                    break;
                }
                else
                {
                    result.Append(json[i]);
                }
            }

            string content = result.ToString().Trim();
            return string.IsNullOrEmpty(content) ? null : content;
        }

        /// <summary>
        /// Generic JSON string field extractor. Finds "fieldName":"value" and returns the unescaped value.
        /// </summary>
        private string ExtractJsonField(string json, string fieldName)
        {
            string searchKey = $"\"{fieldName}\":\"";
            int idx = json.IndexOf(searchKey);
            if (idx < 0) return null;

            int valueStart = idx + searchKey.Length;
            StringBuilder result = new StringBuilder();
            for (int i = valueStart; i < json.Length; i++)
            {
                if (json[i] == '\\' && i + 1 < json.Length)
                {
                    char next = json[i + 1];
                    if (next == '"') { result.Append('"'); i++; }
                    else if (next == 'n') { result.Append('\n'); i++; }
                    else if (next == 'r') { result.Append('\r'); i++; }
                    else if (next == 't') { result.Append('\t'); i++; }
                    else if (next == '\\') { result.Append('\\'); i++; }
                    else { result.Append(json[i]); }
                }
                else if (json[i] == '"')
                {
                    break;
                }
                else
                {
                    result.Append(json[i]);
                }
            }
            string val = result.ToString().Trim();
            return string.IsNullOrEmpty(val) ? null : val;
        }

        /// <summary>
        /// Attempts to extract the actual dialogue from a thinking model's reasoning output.
        /// Thinking models often structure their output as reasoning followed by the actual response.
        /// </summary>
        private string ExtractDialogueFromThinking(string thinking)
        {
            // Strategy 1: Look for explicit markers like "Response:", "Reply:", "My response:", "Output:"
            string[] markers = { "Response:", "Reply:", "My response:", "Output:", "Final response:", "I'll say:" };
            foreach (string marker in markers)
            {
                int idx = thinking.LastIndexOf(marker, StringComparison.OrdinalIgnoreCase);
                if (idx >= 0)
                {
                    string afterMarker = thinking.Substring(idx + marker.Length).Trim();
                    // Clean up: remove quotes if wrapped
                    afterMarker = afterMarker.Trim('"', '\'', '*');
                    if (afterMarker.Length > 5)
                    {
                        Plugin.Log.LogInfo($"Extracted dialogue from thinking (marker: {marker}): {afterMarker.Substring(0, Math.Min(100, afterMarker.Length))}...");
                        return afterMarker;
                    }
                }
            }

            // Strategy 2: Take the last non-empty paragraph (usually the actual response)
            string[] paragraphs = thinking.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (paragraphs.Length > 1)
            {
                // Find the last paragraph that looks like dialogue (not reasoning)
                for (int i = paragraphs.Length - 1; i >= 0; i--)
                {
                    string p = paragraphs[i].Trim();
                    // Skip paragraphs that look like reasoning (numbered lists, bullets, short lines)
                    if (p.StartsWith("1.") || p.StartsWith("- ") || p.StartsWith("*") || p.Length < 10)
                        continue;
                    // Skip paragraphs that look like meta-reasoning
                    if (p.StartsWith("I need to") || p.StartsWith("I should") || p.StartsWith("Let me") || p.StartsWith("Thinking"))
                        continue;

                    Plugin.Log.LogInfo($"Extracted dialogue from thinking (last paragraph): {p.Substring(0, Math.Min(100, p.Length))}...");
                    return p.Trim('"', '\'');
                }
            }

            // Strategy 3: If all else fails, take the last line
            string[] lines = thinking.Split('\n');
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                string line = lines[i].Trim();
                if (line.Length > 5 && !line.StartsWith("*") && !line.StartsWith("-") && !line.StartsWith("#"))
                {
                    Plugin.Log.LogInfo($"Extracted dialogue from thinking (last line): {line}");
                    return line.Trim('"', '\'');
                }
            }

            return null;
        }
    }
}
