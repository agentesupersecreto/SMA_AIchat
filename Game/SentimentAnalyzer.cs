using System;
using System.Collections.Generic;
using UnityEngine;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;
using DialogInterceptorMod.Core;

namespace DialogInterceptorMod.Game
{
    /// <summary>
    /// Keyword-based sentiment classifier that nudges in-game emotions
    /// based on what the player says.  Categories: compliment, romantic, insult.
    /// Precedence: insult &gt; romantic &gt; compliment (first match wins).
    /// </summary>
    public static class SentimentAnalyzer
    {
        // English keyword sets (lower-case)
        private static readonly HashSet<string> ComplimentWords = new HashSet<string>
        {
            "beautiful", "gorgeous", "pretty", "lovely", "cute", "stunning",
            "amazing", "wonderful", "perfect", "attractive", "handsome",
            "sexy", "hot", "elegant", "charming", "sweet", "nice",
            "good girl", "well done", "great job", "great work", "good job"
        };

        private static readonly HashSet<string> RomanticWords = new HashSet<string>
        {
            "love", "kiss", "hug", "cuddle", "romantic", "date",
            "boyfriend", "girlfriend", "relationship", "heart", "darling",
            "baby", "honey", "sweetheart", "dear", "passion", "passionate",
            "together", "forever", "marry", "wedding", "desire", "seduce"
        };

        private static readonly HashSet<string> InsultWords = new HashSet<string>
        {
            "ugly", "stupid", "idiot", "dumb", "fat", "whore", "slut",
            "bitch", "trash", "worthless", "disgusting", "gross", "nasty",
            "loser", "pathetic", "cunt", "fuck you", "shut up", "freak",
            "ugly", "pig", "disgusting", "disgust", "hate", "loathe"
        };

        // Spanish keyword sets
        private static readonly HashSet<string> ComplimentWordsEs = new HashSet<string>
        {
            "hermosa", "bonita", "linda", "preciosa", "guapa", "bella",
            "espectacular", "maravillosa", "perfecta", "atractiva", "sexy",
            "elegante", "encantadora", "dulce", "buena chica", "bien hecho"
        };

        private static readonly HashSet<string> RomanticWordsEs = new HashSet<string>
        {
            "amor", "beso", "abrazo", "romantico", "romántica", "cita",
            "novio", "novia", "relacion", "relación", "corazon", "corazón",
            "cariño", "bebé", "passion", "pasión", "juntos", "para siempre",
            "casar", "boda", "deseo", "seducir"
        };

        private static readonly HashSet<string> InsultWordsEs = new HashSet<string>
        {
            "fea", "estupida", "estúpida", "tonta", "gorda", "puta", "zorra",
            "perra", "basura", "inutil", "inútil", "asquerosa", "cerda",
            "perdedora", "patetica", "patética", "callate", "cállate",
            "monstruo", "asco", "odio", "detesto", "fea"
        };

        /// <summary>
        /// Reads the exact AI style (e.g. "pervertida") and checks the character's matching
        /// "gustoPor..." trait (Taste Ceiling).
        /// Re-implements Personalidad.CalcularModificadorDeRespuestaV2 math cleanly.
        /// </summary>
        public static string ApplySentimentFromStyle(string estilo)
        {
            if (string.IsNullOrEmpty(estilo)) return null;

            ControlladorDeBarkDePersonalidad controlador = DialogBehaviour.Instance.CachedBarkController
                ?? UnityEngine.Object.FindObjectOfType<ControlladorDeBarkDePersonalidad>();
            if (controlador == null) return null;

            Transform root = controlador.GetComponentInParent<Transform>().root;
            var personalidad = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.AI.Personalidad>();
            if (personalidad == null) return null;

            string estiloLower = estilo.ToLowerInvariant().Trim();
            
            // Map AI style to Trait string
            string traitToFind = "";
            switch (estiloLower)
            {
                case "normal": traitToFind = "Personalidad_TraitHumano_gustoPorNormales"; break;
                case "timida": traitToFind = "Personalidad_TraitHumano_gustoPorTimidos"; break;
                case "humilde": traitToFind = "Personalidad_TraitHumano_gustoPorHumildad"; break;
                case "intelectual": traitToFind = "Personalidad_TraitHumano_gustoPorIntelectuales"; break;
                case "confiada": traitToFind = "Personalidad_TraitHumano_gustoPorConfiados"; break;
                case "pedante": traitToFind = "Personalidad_TraitHumano_gustoPorPatanes"; break;
                case "pervertida": traitToFind = "Personalidad_TraitHumano_gustoPorPervertidos"; break;
                case "mlady": traitToFind = "Personalidad_TraitHumano_gustoPorAutistas"; break;
                case "lujosa": traitToFind = "Personalidad_TraitHumano_gustoPorDinero"; break;
                default: return null; // Unknown style
            }

            // Get trait value. It will be 0-100 float usually.
            // If the key is slightly off we will assume a neutral tier (50)
            float tasteValue = 50f; 
            try
            {
                var alteradores = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.AlteradoresDePersonalidadFemenina>(true);
                if (alteradores != null)
                {
                    var traverse = HarmonyLib.Traverse.Create(alteradores);
                    var mapaTraverse = traverse.Field<Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Abstracts.MapaDeValoresDeAlteradoresBase>("m_mapaDeValoresUsando");
                    if (mapaTraverse != null && mapaTraverse.Value != null)
                    {
                        var modificadores = mapaTraverse.Value.ObtenerAlteradorModificadores();
                        foreach (var modif in modificadores)
                        {
                            if (modif.alteradorName == traitToFind && modif.modificadores != null && modif.modificadores.Length > 0)
                            {
                                tasteValue = modif.modificadores[0]; // Just take the first array value (usually float percentage)
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"Failed to read taste trait {traitToFind}: {ex.Message}");
            }

            // We determine how much she likes it based on the taste ceiling (0-100).
            // Doc says: "muyAlto loves it 100, alto likes it 55, normal neutral 25, bajo dislikes 12, muyBajo hates 5"
            // So if tasteValue is high (>= 75), it's alto/muyAlto. If low (<= 25), it's bajo/muyBajo.
            float favorability = 0f;
            float rageGain = 0f;

            if (tasteValue >= 80f)
            {
                favorability = 5f; // She really likes it
            }
            else if (tasteValue >= 60f)
            {
                favorability = 3f;  // She likes it
            }
            else if (tasteValue >= 40f)
            {
                favorability = 1f;  // Neutral / slight bump
            }
            else if (tasteValue >= 20f)
            {
                rageGain = 2f;      // She dislikes it
            }
            else
            {
                rageGain = 4f;     // She hates it
            }

            NudgeEmotions(rageDelta: rageGain, joyDelta: favorability, consentDelta: favorability * 0.8f, arousalDelta: 0f);

            if (favorability > 0)
            {
                return $"Style Score [{estilo}]: Matches Taste ({tasteValue:F0}%) → Joy +{favorability:F0}";
            }
            else if (rageGain > 0)
            {
                return $"Style Score [{estilo}]: Disliked Taste ({tasteValue:F0}%) → Rage +{rageGain:F0}";
            }
            else
            {
                return $"Style Score [{estilo}]: Neutral Taste ({tasteValue:F0}%)";
            }
        }

        /// <summary>
        /// Scans the user message for sentiment keywords and applies emotion
        /// nudges via <see cref="EmocionesFemeninas"/>. Returns a short
        /// human-readable description (or null if no sentiment matched).
        /// </summary>
        public static string ApplySentiment(string userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage))
                return null;

            string lower = userMessage.ToLowerInvariant();

            // Check insult first (highest precedence)
            if (ContainsAny(lower, InsultWords) || ContainsAny(lower, InsultWordsEs))
            {
                NudgeEmotions(
                    rageDelta: 20f,
                    joyDelta: -5f,
                    consentDelta: -5f,
                    arousalDelta: 0f
                );
                return "Sentiment: Insult detected → Rage +20, Joy -5, Consent -5";
            }

            // Romantic second
            if (ContainsAny(lower, RomanticWords) || ContainsAny(lower, RomanticWordsEs))
            {
                NudgeEmotions(
                    rageDelta: 0f,
                    joyDelta: 0f,
                    consentDelta: 0f,
                    arousalDelta: 8f
                );
                return "Sentiment: Romantic detected → Arousal +8";
            }

            // Compliment last
            if (ContainsAny(lower, ComplimentWords) || ContainsAny(lower, ComplimentWordsEs))
            {
                NudgeEmotions(
                    rageDelta: 0f,
                    joyDelta: 5f,
                    consentDelta: 5f,
                    arousalDelta: 0f
                );
                return "Sentiment: Compliment detected → Joy +5, Consent +5";
            }

            return null;
        }

        /// <summary>
        /// Returns true if <paramref name="text"/> contains any phrase from
        /// <paramref name="phrases"/> as a substring.
        /// </summary>
        private static bool ContainsAny(string text, HashSet<string> phrases)
        {
            foreach (string phrase in phrases)
            {
                if (text.Contains(phrase))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Applies emotion deltas to the current character via the cached
        /// bark controller, matching the pattern used by CommandExecutor.
        /// Each delta is clamped to [0, 100].
        /// </summary>
        private static void NudgeEmotions(float rageDelta, float joyDelta, float consentDelta, float arousalDelta)
        {
            try
            {
                ControlladorDeBarkDePersonalidad controlador = DialogBehaviour.Instance.CachedBarkController
                    ?? UnityEngine.Object.FindObjectOfType<ControlladorDeBarkDePersonalidad>();
                if (controlador == null) return;

                Transform root = controlador.GetComponentInParent<Transform>().root;
                var emociones = root.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.AI.EmocionesFemeninas>(true);
                if (emociones == null) return;

                if (emociones.rage != null)
                    emociones.rage.SetValueNextUpdate(Mathf.Clamp(emociones.rage.value.total + rageDelta, 0f, 100f));
                if (emociones.alegria != null)
                    emociones.alegria.SetValueNextUpdate(Mathf.Clamp(emociones.alegria.value.total + joyDelta, 0f, 100f));
                if (emociones.consentToHero != null)
                    emociones.consentToHero.SetValueNextUpdate(Mathf.Clamp(emociones.consentToHero.value.total + consentDelta, 0f, 100f));
                if (emociones.arousal != null)
                    emociones.arousal.SetValueNextUpdate(Mathf.Clamp(emociones.arousal.value.total + arousalDelta, 0f, 100f));
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"SentimentAnalyzer nudge failed: {ex.Message}");
            }
        }
    }
}
