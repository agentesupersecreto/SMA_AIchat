using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DialogInterceptorMod.Core;
using DialogInterceptorMod.Game;
using DialogInterceptorMod.Models;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;

namespace DialogInterceptorMod.API
{
    public static class AIResponseProcessor
    {
        public static void ProcessResponse(string respuesta, DialogBehaviour behaviour, string clientName)
        {
            try
            {
                respuesta = JsonHelper.StripMarkdownCodeBlocks(respuesta);
                string dialogo = respuesta;
                var comandosEncontrados = new List<string>();

                // Extract [CMD:]
                var matches = Regex.Matches(dialogo, @"\[CMD:\s*([^\]]+)\]", RegexOptions.IgnoreCase);
                foreach (Match m in matches)
                {
                    string contenido = m.Groups[1].Value.Trim();
                    dialogo = dialogo.Replace(m.Value, "");

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

                // Extract [STYLE: estilo]
                string estiloDetectado = null;
                var styleMatches = Regex.Matches(dialogo, @"\[STYLE:\s*([^\]]+)\]", RegexOptions.IgnoreCase);
                foreach (Match m in styleMatches)
                {
                    estiloDetectado = m.Groups[1].Value.Trim();
                    dialogo = dialogo.Replace(m.Value, "");
                }

                dialogo = dialogo.Trim();

                if (string.IsNullOrEmpty(dialogo) && comandosEncontrados.Count == 0)
                {
                    behaviour.Window.SetStatus($"[ERROR] Empty or invalid response from {clientName}.", true);
                    return;
                }

                if (!string.IsNullOrEmpty(dialogo))
                {
                    behaviour.ChatHistory.Add(new ChatMessage(false, dialogo));
                    behaviour.Memory.TotalExchangeCount++;
                    behaviour.Memory.AutoTag(dialogo, true);
                    behaviour.Window.ScrollToBottom();
                    behaviour.Window.SetStatus($"[OK] Response received ({clientName}).", false);

                    ShowInBark(dialogo);

                    // Process AI response through PsychologyEngine
                    behaviour.PsychEngine.ProcessAIResponse(dialogo);

                    // Style-based sentiment (native scoring)
                    if (behaviour.UseNativeDialogueScoring && !string.IsNullOrEmpty(estiloDetectado))
                    {
                        string sentimentFeedback = SentimentAnalyzer.ApplySentimentFromStyle(estiloDetectado);
                        if (!string.IsNullOrEmpty(sentimentFeedback))
                        {
                            AddSystemMessage(behaviour, $"⚡ {sentimentFeedback}");
                        }
                    }
                    else if (behaviour.AllowSentimentReactions)
                    {
                        string sentimentFeedback = SentimentAnalyzer.ApplySentiment(dialogo);
                        if (!string.IsNullOrEmpty(sentimentFeedback))
                        {
                            AddSystemMessage(behaviour, $"⚡ {sentimentFeedback}");
                        }
                    }
                }
                else
                {
                    behaviour.Window.SetStatus($"[OK] Silent command execution ({clientName}).", false);
                }

                foreach (string cmd in comandosEncontrados)
                {
                    string feedback = CommandExecutor.ExecuteCommand(cmd, behaviour.Window.SetStatus, behaviour.Window.ShowEmotionFeedback);
                    AddSystemMessage(behaviour, $"⚡ {feedback}");
                }

                if (comandosEncontrados.Count > 0)
                    behaviour.Window.ScrollToBottom();

                // Save history after AI response
                behaviour.Window.SaveChatHistory();
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error processing {clientName} response: {ex.Message}");
                behaviour.Window.SetStatus($"[ERROR] Processing {clientName} response.", true);
            }
        }

        /// <summary>
        /// Adds a system message, respecting the spam filter.
        /// </summary>
        private static void AddSystemMessage(DialogBehaviour behaviour, string message)
        {
            if (behaviour.SpamFilter.ShouldShow(message))
            {
                behaviour.ChatHistory.Add(ChatMessage.SystemMessage(message));
            }
            // If filtered, it goes into the batch queue inside SpamFilter
        }

        private static void ShowInBark(string texto)
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
