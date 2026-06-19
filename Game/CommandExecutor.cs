using System;
using System.Collections.Generic;
using UnityEngine;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using DialogInterceptorMod.Core;

namespace DialogInterceptorMod.Game
{
    public static class CommandExecutor
    {
        /// <summary>
        /// Executes a command and returns a human-readable description of what happened.
        /// </summary>
        public static string ExecuteCommand(string comando, Action<string, bool> setStatus, Action<string> onEmotionFeedback = null)
        {
            Plugin.Log.LogInfo($"Ejecutando comando de la IA: {comando}");
            setStatus($"[CMD] {comando}", false);
            string feedback = null;

            try
            {
                ControlladorDeBarkDePersonalidad controlador = UnityEngine.Object.FindObjectOfType<ControlladorDeBarkDePersonalidad>();
                if (controlador != null)
                {
                    Transform root = controlador.GetComponentInParent<Transform>().root;
                    IRopaManager ropaManager = root.GetComponentInChildren<IRopaManager>();
                    
                    if (comando.StartsWith("pose:"))
                    {
                        if (DialogBehaviour.Instance.AllowPoseChangeCommand)
                        {
                            string poseName = comando.Substring(5).Trim();
                            var interacciones = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.IInteraccionesDeCharacter>();
                            
                            if (poseName == "dePieRigida")
                            {
                                var poseLoader = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.Controllers.AnimController>();
                                if (poseLoader != null)
                                {
                                    poseLoader.currentPose = Assets._ReusableScripts.CuchiCuchi.Controllers.TipoDePose.dePieRigida;
                                    poseLoader.UpdatePoseConfig(true);
                                    poseLoader.SetDefaultPose();
                                }
                                if (interacciones != null)
                                {
                                    var ejecutandose = interacciones.ObtenerFirstEjecutandosePrimaria();
                                    if (ejecutandose != null && ejecutandose.instancia != null)
                                    {
                                        ejecutandose.instancia.Detener(false);
                                    }
                                }
                                feedback = "Changed pose to standing position.";
                            }
                            else
                            {
                                // Fix common hallucinated names
                                if (poseName.ToLower() == "bend_forward" || poseName.ToLower() == "bendforward") poseName = "forwardBend";
                                if (poseName.ToLower() == "doggy") poseName = "doggyA";
                                if (poseName.ToLower() == "sit" || poseName.ToLower() == "sit_on_ground") poseName = "sitOnGround";
                                if (poseName.ToLower() == "lay" || poseName.ToLower() == "lay_on_ground") poseName = "layOnGround";
                                if (poseName.ToLower() == "lean" || poseName.ToLower() == "inclinar_hacia_adelante_de_pie_sacando_cola") poseName = "inclinarHaciaAdelanteDePieSacandoCola";
                                if (poseName.ToLower() == "kneel" || poseName.ToLower() == "kneel") poseName = "kneel";


                                if (Enum.TryParse(poseName, true, out Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.InteraccionPrimariaName priName))
                                {
                                    if (interacciones != null)
                                    {
                                        int idVal = Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.IInteraccionesDeCharacterFemeninoEXT.GetInteractionID(priName);
                                        if (interacciones.TryObtenerSiEsValida(idVal, out Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.Interaccion inter))
                                        {
                                            var primaryBase = inter as Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.InteraccionPrimariaBase;
                                            if (primaryBase != null)
                                            {
                                                primaryBase.EjecutarMaxPrioridadTiempoIndefinido();
                                                feedback = $"Changed pose to {poseName}.";
                                            }
                                        }
                                        else
                                        {
                                            feedback = $"Pose '{poseName}' not available for this character.";
                                        }
                                    }
                                }
                                else
                                {
                                    feedback = $"Unknown pose: '{poseName}'.";
                                }
                            }
                        }
                        else
                        {
                            feedback = "Action denied. Pose changes are disabled by the user.";
                        }
                    }
                    else if (comando.StartsWith("modify_trait:"))
                    {
                        string[] parts = comando.Split(':');
                        if (parts.Length >= 3)
                        {
                            string traitName = parts[1].Trim();
                            if (float.TryParse(parts[2].Trim(), out float value))
                            {
                                bool emotionModified = false;
                                
                                // 1. Check Core Emotions First
                                var emocionesFemeninas = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.AI.EmocionesFemeninas>(true);
                                if (emocionesFemeninas != null)
                                {
                                    string tLower = traitName.ToLower();
                                    Assets._ReusableScripts.CuchiCuchi.AI.Emocion targetEmo = null;
                                    
                                    if (tLower.Contains("arousal")) targetEmo = emocionesFemeninas.arousal;
                                    else if (tLower.Contains("rage") || tLower.Contains("anger")) targetEmo = emocionesFemeninas.rage;
                                    else if (tLower.Contains("pleasure") || tLower.Contains("placer")) targetEmo = emocionesFemeninas.placer;
                                    else if (tLower.Contains("pain") || tLower.Contains("dolor")) targetEmo = emocionesFemeninas.dolor;
                                    else if (tLower.Contains("consent") || tLower.Contains("consenttohero")) targetEmo = emocionesFemeninas.consentToHero;
                                    else if (tLower.Contains("joy") || tLower.Contains("alegria")) targetEmo = emocionesFemeninas.alegria;
                                    else if (tLower.Contains("fear") || tLower.Contains("miedo")) targetEmo = emocionesFemeninas.fear;
                                    else if (tLower.Contains("disappointment") || tLower.Contains("decepcion")) targetEmo = emocionesFemeninas.decepcion;

                                    if (targetEmo != null)
                                    {
                                        targetEmo.SetValueNextUpdate(value);
                                        feedback = $"Modified core emotion '{traitName}' to {value}.";
                                        emotionModified = true;
                                    }
                                }

                                // 2. If not a core emotion, check Alteradores (Traits/Kinks)
                                if (!emotionModified)
                                {
                                    var alteradores = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.AlteradoresDePersonalidadFemenina>(true);
                                    if (alteradores != null)
                                    {
                                        var traverse = HarmonyLib.Traverse.Create(alteradores);
                                        var mapaTraverse = traverse.Field<Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Abstracts.MapaDeValoresDeAlteradoresBase>("m_mapaDeValoresUsando");
                                        if (mapaTraverse != null && mapaTraverse.Value != null)
                                        {
                                            var modificadores = mapaTraverse.Value.ObtenerAlteradorModificadores();
                                            bool modified = false;
                                            foreach (var modif in modificadores)
                                            {
                                                if (modif.alteradorName == traitName)
                                                {
                                                    for(int i = 0; i < modif.modificadores.Length; i++) {
                                                         modif.modificadores[i] = value;
                                                    }
                                                    modified = true;
                                                    break;
                                                }
                                            }
                                            if (modified)
                                            {
                                                alteradores.flagToForceUpdateValores = true;
                                                feedback = $"Modified trait '{traitName}' to {value}.";
                                            }
                                            else
                                            {
                                                feedback = $"Trait '{traitName}' not found.";
                                            }
                                        }
                                        else
                                        {
                                            feedback = $"Trait '{traitName}' not found (Map missing).";
                                        }
                                    }
                                    else
                                    {
                                        feedback = $"Trait '{traitName}' not found (Alteradores missing).";
                                    }
                                }
                            }
                            else
                            {
                                feedback = $"Invalid value for trait '{traitName}'.";
                            }
                        }
                    }
                    else if (comando.ToLower() == "give_consent")
                    {
                        var emocionesFemeninas = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.AI.EmocionesFemeninas>(true);
                        if (emocionesFemeninas != null)
                        {
                            if (emocionesFemeninas.consentToHero != null) emocionesFemeninas.consentToHero.SetValueNextUpdate(100f);
                            if (emocionesFemeninas.arousal != null) emocionesFemeninas.arousal.SetValueNextUpdate(Mathf.Max(emocionesFemeninas.arousal.value.total, 60f));
                            if (emocionesFemeninas.rage != null) emocionesFemeninas.rage.SetValueNextUpdate(0f);
                            if (emocionesFemeninas.fear != null) emocionesFemeninas.fear.SetValueNextUpdate(0f);
                            if (emocionesFemeninas.dolor != null) emocionesFemeninas.dolor.SetValueNextUpdate(0f);
                            
                            feedback = "Given consent.";
                        }
                        else
                        {
                            feedback = "Failed to give consent (EmocionesFemeninas not found).";
                        }
                    }
                    else if (comando.ToLower() == "sluttify")
                    {
                        if (DialogBehaviour.Instance.AllowSluttifyCommand)
                        {
                            try
                            {
                                SluttifyHandler.Sluttify(root);
                                feedback = "All desires and thresholds maximized.";
                            }
                            catch (Exception e)
                            {
                                Plugin.Log.LogError($"Error en Sluttify: {e.Message}");
                                feedback = "Sluttify failed.";
                            }
                        }
                        else
                        {
                            feedback = "Action denied. Sluttify is disabled by the user.";
                        }
                    }
                    else if (comando.StartsWith("go_to:"))
                    {
                        string targetId = comando.Substring(6).Trim();
                        feedback = MovementHelper.GoTo(root, targetId);
                    }
                    else if (comando.StartsWith("can_i:"))
                    {
                        if (DialogBehaviour.Instance.AllowCanICommand)
                        {
                            string[] parts = comando.Split(':');
                            if (parts.Length >= 3)
                            {
                                string bodyPartName = parts[1].Trim();
                                string actionName = parts[2].Trim();
                                feedback = ExecuteCanI(root, bodyPartName, actionName);
                                if (onEmotionFeedback != null && feedback != null)
                                    onEmotionFeedback(feedback);
                            }
                            else
                            {
                                feedback = "Invalid can_i format.";
                            }
                        }
                        else
                        {
                            feedback = "Action denied. Can I? command is disabled by the user.";
                        }
                    }
                    else if (comando.ToLower() == "dispatch")
                    {
                        if (DialogBehaviour.Instance.AllowDispatchCommand)
                        {
                            try
                            {
                                // Try the Interview panel (PanelDeEntrevistaCalificacion is a MonoBehaviour)
                                var interviewPanel = UnityEngine.Object.FindObjectOfType<Assets.Productos.Juegos.Reception.Scripts.Entrevistas.PanelDeEntrevistaCalificacion>();
                                if (interviewPanel != null)
                                {
                                    interviewPanel.mainModel.DispatchHer();
                                    feedback = "Model dispatched (interview).";
                                }
                                else
                                {
                                    // Try the Meeting Hired panel
                                    var meetingPanel = UnityEngine.Object.FindObjectOfType<Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.PanelDeMeetingHiredModel>();
                                    if (meetingPanel != null)
                                    {
                                        // PanelDeMeetingHiredModel uses m_a (MeetingHiredModelModelo) but it's private.
                                        // Use reflection to access it.
                                        var fieldA = typeof(Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.PanelDeMeetingHiredModel)
                                            .GetField("m_a", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                                        if (fieldA != null)
                                        {
                                            var modelo = fieldA.GetValue(meetingPanel) as Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos.MeetingHiredModelModelo;
                                            if (modelo != null)
                                            {
                                                modelo.DispatchHer();
                                                feedback = "Model dispatched (meeting).";
                                            }
                                            else
                                            {
                                                feedback = "Could not access meeting model to dispatch.";
                                            }
                                        }
                                        else
                                        {
                                            feedback = "Could not find meeting model field.";
                                        }
                                    }
                                    else
                                    {
                                        feedback = "No dispatch panel found. Cannot dispatch right now.";
                                    }
                                }
                            }
                            catch (Exception dispEx)
                            {
                                Plugin.Log.LogError($"Dispatch error: {dispEx.Message}");
                                feedback = $"Dispatch failed: {dispEx.Message}";
                            }
                        }
                        else
                        {
                            feedback = "Action denied. Dispatch is disabled by the user.";
                        }
                    }
                    else if (comando.StartsWith("undress_piece:"))
                    {
                        string pieceName = comando.Substring("undress_piece:".Length).Trim();
                        if (ropaManager != null && ropaManager.piezasPuestasPorId != null)
                        {
                            // Try exact match first
                            bool found = false;
                            foreach (var kvp in ropaManager.piezasPuestasPorId)
                            {
                                if (string.Equals(kvp.Key, pieceName, StringComparison.OrdinalIgnoreCase))
                                {
                                    ropaManager.OcultarPieza(kvp.Key, true, null);
                                    feedback = $"Removed clothing piece: {kvp.Key}.";
                                    found = true;
                                    break;
                                }
                            }
                            // Try partial/contains match if exact didn't work
                            if (!found)
                            {
                                foreach (var kvp in ropaManager.piezasPuestasPorId)
                                {
                                    if (kvp.Key.IndexOf(pieceName, StringComparison.OrdinalIgnoreCase) >= 0)
                                    {
                                        ropaManager.OcultarPieza(kvp.Key, true, null);
                                        feedback = $"Removed clothing piece: {kvp.Key} (matched from '{pieceName}').";
                                        found = true;
                                        break;
                                    }
                                }
                            }
                            if (!found)
                            {
                                feedback = $"Clothing piece '{pieceName}' not found. Currently wearing: {string.Join(", ", ropaManager.piezasPuestasPorId.Keys)}.";
                            }
                        }
                        else
                        {
                            feedback = "No clothing manager found.";
                        }
                    }
                    else if (ropaManager != null)
                    {
                        switch (comando.ToLower())
                        {
                            case "undress_all":
                                ropaManager.RemoverTodo();
                                feedback = "Removed all clothing.";
                                break;
                            case "undress_top":
                                ropaManager.OcultarPiezasCubriendo(
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.pectorales | 
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.pezones | 
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.torzo | 
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.espalda |
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.brazos |
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.anteBrazos, 
                                    true, null);
                                feedback = "Removed top clothing.";
                                break;
                            case "undress_bottom":
                                ropaManager.OcultarPiezasCubriendo(
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.labiosVaginales | 
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.nalgas | 
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.piernas |
                                    Assets._ReusableScripts.CuchiCuchi.Ropa.RopaCubre.vientreBajo, 
                                    true, null);
                                feedback = "Removed bottom clothing.";
                                break;
                            default:
                                feedback = $"Unknown command: '{comando}'.";
                                break;
                        }
                    }
                }
                else
                {
                    feedback = "No character found to execute command on.";
                }
            }
            catch(Exception ex)
            {
                Plugin.Log.LogError($"Error ejecutando comando: {ex.Message}");
                feedback = $"Command error: {ex.Message}";
            }

            return feedback ?? $"Executed: {comando}";
        }

        private static string ExecuteCanI(Transform root, string bodyPartName, string actionName)
        {
            string[] validActions = { "caricia", "beso", "lambida", "slapping", "poking" };

            int partId = -1;
            foreach (var kvp in OpcionesDeTHSDonaDeCanIDisponibles.opciones)
            {
                if (string.Equals(kvp.Value, bodyPartName, StringComparison.OrdinalIgnoreCase))
                {
                    partId = kvp.Key;
                    break;
                }
            }

            if (partId < 0)
                return $"Unknown body part '{bodyPartName}'. Available: Face, Mouth, Shoulders, Arms, Hands, Back, Waist, Neck, Hips, Thighs, Calves, Feet, Tits, Ass, Asshole, Pussy.";

            if (!System.Enum.TryParse<TipoDeEstimuloTactil>(actionName, true, out var action))
                return $"Unknown action '{actionName}'. Available: {string.Join(", ", validActions)}.";

            var emociones = root.GetComponentInChildren<EmocionesFemeninas>(true);
            if (emociones == null) return "Emotions not found.";

            bool isIntimate = partId >= 12;
            bool isPleasurable = action == TipoDeEstimuloTactil.caricia || action == TipoDeEstimuloTactil.beso || action == TipoDeEstimuloTactil.lambida;
            bool isPainful = action == TipoDeEstimuloTactil.slapping || action == TipoDeEstimuloTactil.poking;

            float arousalDelta = 0f, pleasureDelta = 0f, rageDelta = 0f;

            if (isPleasurable)
            {
                arousalDelta = 10f + (isIntimate ? 15f : 5f);
                pleasureDelta = 5f + (isIntimate ? 10f : 3f);
                rageDelta = -5f;

                var personalidad = root.GetComponentInChildren<Personalidad>(true);
                if (personalidad != null)
                {
                    if (personalidad.pervertido) { arousalDelta *= 1.5f; pleasureDelta *= 1.5f; }
                    if (personalidad.exhibicionista) { arousalDelta *= 1.3f; pleasureDelta *= 1.3f; }
                }
            }
            else if (isPainful)
            {
                arousalDelta = 5f;
                rageDelta = 15f;
                pleasureDelta = -5f;
                var personalidad = root.GetComponentInChildren<Personalidad>(true);
                if (personalidad != null && personalidad.sumiso) { rageDelta *= 0.5f; arousalDelta += 10f; }
            }

            float consentThreshold = 30f;
            if (isIntimate && emociones.consentToHero != null && emociones.consentToHero.value.total < consentThreshold)
            {
                rageDelta = Mathf.Max(rageDelta, 20f);
                pleasureDelta = Mathf.Min(pleasureDelta, -10f);
                if (emociones.rage != null) emociones.rage.SetValueNextUpdate(Mathf.Clamp(emociones.rage.value.total + rageDelta, 0f, 100f));
                return $"{bodyPartName} touched with {actionName}: too intimate for current consent. Rage increased.";
            }

            if (emociones.arousal != null) emociones.arousal.SetValueNextUpdate(Mathf.Clamp(emociones.arousal.value.total + arousalDelta, 0f, 100f));
            if (emociones.placer != null) emociones.placer.SetValueNextUpdate(Mathf.Clamp(emociones.placer.value.total + pleasureDelta, 0f, 100f));
            if (emociones.rage != null) emociones.rage.SetValueNextUpdate(Mathf.Clamp(emociones.rage.value.total + rageDelta, 0f, 100f));

            return $"{bodyPartName} touched with {actionName}. Arousal {(arousalDelta >= 0 ? "+" : "")}{arousalDelta:F0}, Pleasure {(pleasureDelta >= 0 ? "+" : "")}{pleasureDelta:F0}.";
        }
    }
}
