using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;
using DialogInterceptorMod.API;

namespace DialogInterceptorMod.Core
{
    /// <summary>
    /// Central "Stream of Consciousness" engine.  On character bind it reads the
    /// 16 base-game personality modifiers, performs dice-rolls to set an initial
    /// psychological state, and on every exchange it evaluates keyword strengths
    /// across 10 categories — their intensity feeds back into mood shifts.
    /// Permanent personality traits act as *accelerators* for behavioral changes.
    /// </summary>
    public class PsychologyEngine
    {
        // ── 10 keyword categories (0-100 intensity) ──
        public float Flattery;
        public float Intimidation;
        public float Seduction;
        public float Professionalism;
        public float Humor;
        public float Empathy;
        public float Dominance;
        public float Vulnerability;
        public float Negotiation;
        public float Provocation;

        // ── Extended mood parameters (mod-only, not in base game) ──
        public float Boredom = 20f;
        public float Relief;
        public float Thawing;
        public float Disgust;

        // ── Atmosphere (0-100, cold→intimate) ──
        public float Atmosphere = 25f;

        // ── Personality accelerators (read once from game) ──
        public float AccPervertido;
        public float AccExhibicionista;
        public float AccSumiso;
        public float AccTimido;
        public float AccExtrovertido;
        public float AccGrosero;
        public float AccDominancia;

        // ── Modeling stage progression ──
        public ModelingStage CurrentStage = ModelingStage.Discuss;

        // ── Dice-roll variance applied to initial state ──
        private System.Random _rng = new System.Random();
        private bool _initialized;

        // ── Keyword dictionaries ──
        private static readonly Dictionary<string, string[]> KeywordBank = new Dictionary<string, string[]>
        {
            ["Flattery"] = new[] {
                "beautiful", "gorgeous", "pretty", "stunning", "amazing", "wonderful",
                "perfect", "attractive", "sexy", "hot", "elegant", "charming", "sweet",
                "nice", "cute", "lovely", "good girl", "well done",
                // Spanish
                "hermosa", "bonita", "linda", "preciosa", "guapa", "bella",
                "espectacular", "maravillosa", "perfecta", "atractiva", "sexy",
                "buena chica", "bien hecho"
            },
            ["Intimidation"] = new[] {
                "obey", "now", "do it", "command", "order", "must", "forced",
                "threat", "punish", "make you", "i'll", "consequences",
                // Spanish
                "obedece", "ahora", "hazlo", "orden", "obligada", "forzar",
                "amenaza", "castigo", "te haré", "consecuencias"
            },
            ["Seduction"] = new[] {
                "kiss", "touch", "desire", "seduce", "turn on", "horny", "aroused",
                "wet", "pleasure", "tease", "strip", "naked", "body", "breasts",
                "lips", "thighs", "intimate", "bed", "moan",
                // Spanish
                "beso", "tocar", "deseo", "seducir", "excitada", "placer",
                "provocar", "desnuda", "cuerpo", "pechos", "labios", "cama", "gemir"
            },
            ["Professionalism"] = new[] {
                "work", "job", "professional", "model", "photo", "shoot", "pose",
                "portfolio", "contract", "salary", "payment", "career", "industry",
                // Spanish
                "trabajo", "profesional", "modelo", "foto", "sesión", "posar",
                "portafolio", "contrato", "salario", "pago", "carrera"
            },
            ["Humor"] = new[] {
                "haha", "lol", "funny", "joke", "laugh", "hilarious", "silly",
                "comedy", "prank", "kidding", "playful",
                // Spanish
                "jaja", "gracioso", "chiste", "risa", "divertido", "broma",
                "juguetona", "tonto"
            },
            ["Empathy"] = new[] {
                "feel", "understand", "care", "sorry", "comfort", "safe", "trust",
                "listen", "support", "gentle", "kind", "worried", "concern",
                // Spanish
                "sentir", "entender", "cuidar", "perdón", "confort", "segura",
                "confianza", "escuchar", "apoyo", "gentil", "amable", "preocupado"
            },
            ["Dominance"] = new[] {
                "kneel", "obey", "submit", "good girl", "mine", "belong", "control",
                "command", "master", "sir", "daddy", "boss",
                // Spanish
                "arrodíllate", "obedece", "sumérgete", "mía", "perteneces",
                "control", "amo", "jefe", "papi"
            },
            ["Vulnerability"] = new[] {
                "scared", "nervous", "afraid", "alone", "lonely", "sad", "miss",
                "cry", "hurt", "broken", "help", "please", "need",
                // Spanish
                "asustada", "nerviosa", "sola", "triste", "llorar", "dolor",
                "ayuda", "por favor", "necesito"
            },
            ["Negotiation"] = new[] {
                "deal", "offer", "trade", "exchange", "compromise", "agree",
                "price", "worth", "consider", "propose", "negotiate",
                // Spanish
                "trato", "oferta", "intercambio", "acuerdo", "precio",
                "vale", "considerar", "proponer", "negociar"
            },
            ["Provocation"] = new[] {
                "ugly", "stupid", "idiot", "dumb", "fat", "whore", "slut", "bitch",
                "trash", "worthless", "disgusting", "pathetic", "cunt", "fuck you",
                "shut up", "hate", "pig",
                // Spanish
                "fea", "estúpida", "idiota", "tonta", "gorda", "puta", "zorra",
                "perra", "basura", "inútil", "asquerosa", "patética", "cállate",
                "odio", "cerda"
            }
        };

        /// <summary>
        /// Initialize the psychology engine from the live game character.
        /// Performs dice rolls using personality modifiers as seeds.
        /// </summary>
        public void Initialize(Transform root)
        {
            if (root == null) return;

            try
            {
                var personalidad = root.GetComponentInChildren<Personalidad>(true);
                if (personalidad != null)
                {
                    // Read personality accelerators
                    AccPervertido = personalidad.pervertido ? 1f : personalidad.perverticidad / 100f;
                    AccExhibicionista = personalidad.exhibicionista ? 1f : 0f;
                    AccSumiso = personalidad.sumiso ? 1f : personalidad.sumicion / 100f;
                    AccTimido = personalidad.timido ? 1f : personalidad.timidez / 100f;
                    AccExtrovertido = personalidad.extrovertido ? 1f : personalidad.extroversion / 100f;
                    AccGrosero = personalidad.grosero ? 1f : 0f;
                    AccDominancia = personalidad.dominanciaPorPersonalidad / 100f;

                    // Dice rolls for initial mood using personality as base
                    Boredom = DiceRoll(30f, AccExtrovertido * -15f, 10f);
                    Disgust = DiceRoll(5f, AccGrosero * -10f, 8f);
                    Relief = DiceRoll(50f, AccSumiso * 10f, 15f);
                    Thawing = DiceRoll(10f, AccPervertido * 30f + AccExhibicionista * 20f, 10f);

                    // Initial atmosphere based on personality
                    Atmosphere = DiceRoll(25f, AccPervertido * 15f + AccExtrovertido * 10f - AccTimido * 10f, 10f);

                    // Initialize keyword strengths with personality-seeded variance
                    Flattery = DiceRoll(10f, AccExtrovertido * 5f, 5f);
                    Intimidation = DiceRoll(5f, 0f, 3f);
                    Seduction = DiceRoll(5f, AccPervertido * 15f, 5f);
                    Professionalism = DiceRoll(40f, -AccPervertido * 10f, 10f);
                    Humor = DiceRoll(15f, AccExtrovertido * 10f, 8f);
                    Empathy = DiceRoll(20f, AccSumiso * 5f, 5f);
                    Dominance = DiceRoll(5f, AccDominancia * 10f, 5f);
                    Vulnerability = DiceRoll(10f, AccTimido * 10f, 5f);
                    Negotiation = DiceRoll(15f, 0f, 5f);
                    Provocation = DiceRoll(5f, AccGrosero * 10f, 5f);
                }

                // Determine initial modeling stage
                CurrentStage = ModelingStage.Discuss;
                _initialized = true;

                Plugin.Log.LogInfo($"PsychologyEngine initialized. Atmosphere={Atmosphere:F0}, Boredom={Boredom:F0}, Thawing={Thawing:F0}");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"PsychologyEngine init failed: {ex.Message}");
                _initialized = true; // still mark as init so we don't loop
            }
        }

        public bool IsInitialized => _initialized;

        /// <summary>
        /// Analyzes a player message: detects keywords, updates intensities,
        /// shifts atmosphere, and modifies extended mood parameters.
        /// Returns a list of auto-suggested commands (can be empty).
        /// </summary>
        public List<string> ProcessPlayerMessage(string message, Transform root)
        {
            var suggestedCommands = new List<string>();
            if (string.IsNullOrWhiteSpace(message)) return suggestedCommands;

            string lower = message.ToLowerInvariant();

            // ── 1. Keyword detection & intensity update ──
            var hits = DetectKeywords(lower);

            foreach (var kvp in hits)
            {
                float boost = kvp.Value * 8f; // base boost per hit
                switch (kvp.Key)
                {
                    case "Flattery":     Flattery = Clamp100(Flattery + boost); break;
                    case "Intimidation": Intimidation = Clamp100(Intimidation + boost); break;
                    case "Seduction":    Seduction = Clamp100(Seduction + boost * (1f + AccPervertido)); break;
                    case "Professionalism": Professionalism = Clamp100(Professionalism + boost); break;
                    case "Humor":        Humor = Clamp100(Humor + boost); break;
                    case "Empathy":      Empathy = Clamp100(Empathy + boost); break;
                    case "Dominance":    Dominance = Clamp100(Dominance + boost * (1f + AccSumiso)); break;
                    case "Vulnerability": Vulnerability = Clamp100(Vulnerability + boost); break;
                    case "Negotiation":  Negotiation = Clamp100(Negotiation + boost); break;
                    case "Provocation":  Provocation = Clamp100(Provocation + boost); break;
                }
            }

            // ── 2. Atmosphere shifts ──
            float atmoShift = 0f;
            atmoShift += hits.GetValueOrDefault("Seduction") * 5f * (1f + AccPervertido);
            atmoShift += hits.GetValueOrDefault("Flattery") * 2f;
            atmoShift += hits.GetValueOrDefault("Empathy") * 1.5f;
            atmoShift += hits.GetValueOrDefault("Humor") * 1f;
            atmoShift -= hits.GetValueOrDefault("Provocation") * 4f;
            atmoShift -= hits.GetValueOrDefault("Intimidation") * 2f * (1f + AccTimido);
            atmoShift += hits.GetValueOrDefault("Dominance") * 1.5f * AccSumiso;
            atmoShift -= hits.GetValueOrDefault("Dominance") * 2f * (1f - AccSumiso);
            Atmosphere = Clamp100(Atmosphere + atmoShift);

            // ── 3. Extended mood shifts ──
            // Boredom: decreases when anything interesting happens, increases over time
            float interestLevel = hits.Values.Sum();
            if (interestLevel > 0)
                Boredom = Mathf.Max(0f, Boredom - interestLevel * 3f);
            else
                Boredom = Mathf.Min(100f, Boredom + 2f); // slow boredom buildup on bland messages

            // Disgust: provocation + intimidation increase it, empathy decreases
            Disgust = Clamp100(Disgust
                + hits.GetValueOrDefault("Provocation") * 8f
                + hits.GetValueOrDefault("Intimidation") * 3f * (1f + AccTimido)
                - hits.GetValueOrDefault("Empathy") * 4f
                - hits.GetValueOrDefault("Flattery") * 2f);

            // Thawing: seduction and flattery warm her up
            Thawing = Clamp100(Thawing
                + hits.GetValueOrDefault("Seduction") * 5f * (1f + AccPervertido)
                + hits.GetValueOrDefault("Flattery") * 2f
                - hits.GetValueOrDefault("Provocation") * 3f);

            // Relief: empathy and humor bring relief
            Relief = Clamp100(Relief
                + hits.GetValueOrDefault("Empathy") * 4f
                + hits.GetValueOrDefault("Humor") * 3f
                - hits.GetValueOrDefault("Intimidation") * 5f);

            // ── 4. Apply mood to game emotions ──
            ApplyMoodToGameEmotions(root, hits);

            // ── 5. Modeling stage progression ──
            UpdateModelingStage();

            // Natural keyword decay (all categories drift toward baseline)
            DecayKeywords(0.95f);

            return suggestedCommands;
        }

        /// <summary>
        /// Processes the AI's response to detect if she's warming up or resisting.
        /// </summary>
        public void ProcessAIResponse(string response)
        {
            if (string.IsNullOrWhiteSpace(response)) return;

            string lower = response.ToLowerInvariant();
            var hits = DetectKeywords(lower);

            // If the AI herself uses seductive language, boost atmosphere
            float aiSeduction = hits.GetValueOrDefault("Seduction");
            if (aiSeduction > 0)
                Atmosphere = Clamp100(Atmosphere + aiSeduction * 2f);

            // If the AI responds with vulnerability, she's opening up
            float aiVuln = hits.GetValueOrDefault("Vulnerability");
            if (aiVuln > 0)
                Thawing = Clamp100(Thawing + aiVuln * 3f);
        }

        /// <summary>
        /// Generates a compact context string for injection into the system prompt.
        /// Optimized for token efficiency.
        /// </summary>
        public string GenerateContextBlock()
        {
            var sb = new StringBuilder();

            // Atmosphere label
            string atmoLabel;
            if (Atmosphere < 20) atmoLabel = "Cold";
            else if (Atmosphere < 40) atmoLabel = "Neutral";
            else if (Atmosphere < 60) atmoLabel = "Warm";
            else if (Atmosphere < 80) atmoLabel = "Hot";
            else atmoLabel = "Intimate";

            sb.Append($"[VIBE] {atmoLabel}({Atmosphere:F0})");

            // Extended mood (only show non-trivial values)
            var moods = new List<string>();
            if (Boredom > 15) moods.Add($"Bored:{Boredom:F0}");
            if (Disgust > 10) moods.Add($"Disgust:{Disgust:F0}");
            if (Thawing > 15) moods.Add($"Thawing:{Thawing:F0}");
            if (Relief > 20) moods.Add($"Relief:{Relief:F0}");
            if (moods.Count > 0)
                sb.Append($" [XMOOD] {string.Join(" ", moods)}");

            // Top 3 keyword categories (skip low values for token efficiency)
            var topKeywords = GetTopKeywords(3, 15f);
            if (topKeywords.Count > 0)
            {
                sb.Append(" [KWDS]");
                foreach (var kv in topKeywords)
                    sb.Append($" {kv.Key}:{kv.Value:F0}");
            }

            // Modeling stage
            sb.Append($" [STAGE] {CurrentStage}");

            return sb.ToString();
        }

        /// <summary>
        /// Returns a text description of the emotional state suitable for context injection.
        /// Replaces numeric emotion events with natural language.
        /// </summary>
        public string GenerateMoodDescription(Transform root)
        {
            if (root == null) return "";

            try
            {
                var emos = root.GetComponentInChildren<EmocionesFemeninas>(true);
                if (emos == null) return "";

                float arousal = emos.arousal?.valorNoLimitado ?? 0f;
                float pleasure = emos.placer?.valorNoLimitado ?? 0f;
                float joy = emos.alegria?.valorNoLimitado ?? 0f;
                float rage = emos.rage?.valorNoLimitado ?? 0f;
                float pain = emos.dolor?.valorNoLimitado ?? 0f;
                float fear = emos.fear?.valorNoLimitado ?? 0f;
                float consent = emos.consentToHero?.valorNoLimitado ?? 0f;

                var parts = new List<string>();

                // Describe dominant emotion
                if (rage > 70) parts.Add("furious");
                else if (rage > 40) parts.Add("irritated");
                else if (rage > 20) parts.Add("annoyed");

                if (arousal > 70) parts.Add("very aroused");
                else if (arousal > 40) parts.Add("aroused");
                else if (arousal > 20) parts.Add("slightly turned on");

                if (pleasure > 60) parts.Add("feeling great pleasure");
                else if (pleasure > 30) parts.Add("enjoying herself");

                if (joy > 60) parts.Add("happy");
                else if (joy > 30) parts.Add("content");

                if (fear > 50) parts.Add("scared");
                else if (fear > 20) parts.Add("nervous");

                if (pain > 40) parts.Add("in pain");

                if (consent > 70) parts.Add("fully consenting");
                else if (consent > 40) parts.Add("warming up to intimacy");
                else if (consent < 15) parts.Add("not consenting to intimacy");

                if (Boredom > 60) parts.Add("very bored");
                else if (Boredom > 35) parts.Add("getting bored");

                if (Disgust > 50) parts.Add("disgusted");
                else if (Disgust > 25) parts.Add("uncomfortable");

                if (parts.Count == 0) parts.Add("calm and neutral");

                return $"[FEELING] She is currently {string.Join(", ", parts)}.";
            }
            catch
            {
                return "";
            }
        }

        // ── Private helpers ──

        private Dictionary<string, float> DetectKeywords(string lowerText)
        {
            var result = new Dictionary<string, float>();
            foreach (var kvp in KeywordBank)
            {
                int count = 0;
                foreach (string kw in kvp.Value)
                {
                    if (lowerText.Contains(kw))
                        count++;
                }
                if (count > 0)
                    result[kvp.Key] = Mathf.Min(count, 5f); // cap at 5 hits per category
            }
            return result;
        }

        private void ApplyMoodToGameEmotions(Transform root, Dictionary<string, float> hits)
        {
            if (root == null) return;
            try
            {
                var emos = root.GetComponentInChildren<EmocionesFemeninas>(true);
                if (emos == null) return;

                // Persuasion system: keyword intensities drive emotion changes
                float joyDelta = 0f, rageDelta = 0f, arousalDelta = 0f, consentDelta = 0f;

                joyDelta += hits.GetValueOrDefault("Flattery") * 2f;
                joyDelta += hits.GetValueOrDefault("Humor") * 2f;
                joyDelta += hits.GetValueOrDefault("Empathy") * 1.5f;
                joyDelta -= hits.GetValueOrDefault("Provocation") * 3f;

                rageDelta += hits.GetValueOrDefault("Provocation") * 4f;
                rageDelta += hits.GetValueOrDefault("Intimidation") * 2f * (1f + AccTimido);
                rageDelta -= hits.GetValueOrDefault("Flattery") * 1f;
                rageDelta -= hits.GetValueOrDefault("Empathy") * 1.5f;

                arousalDelta += hits.GetValueOrDefault("Seduction") * 3f * (1f + AccPervertido);
                arousalDelta += hits.GetValueOrDefault("Dominance") * 1f * AccSumiso;

                consentDelta += hits.GetValueOrDefault("Flattery") * 1.5f;
                consentDelta += hits.GetValueOrDefault("Empathy") * 2f;
                consentDelta += hits.GetValueOrDefault("Seduction") * 1f * (Atmosphere > 50 ? 1f : 0.3f);
                consentDelta -= hits.GetValueOrDefault("Provocation") * 3f;
                consentDelta -= hits.GetValueOrDefault("Intimidation") * 2f;

                if (emos.alegria != null && joyDelta != 0f)
                    emos.alegria.SetValueNextUpdate(Mathf.Clamp(emos.alegria.value.total + joyDelta, 0f, 100f));
                if (emos.rage != null && rageDelta != 0f)
                    emos.rage.SetValueNextUpdate(Mathf.Clamp(emos.rage.value.total + rageDelta, 0f, 100f));
                if (emos.arousal != null && arousalDelta != 0f)
                    emos.arousal.SetValueNextUpdate(Mathf.Clamp(emos.arousal.value.total + arousalDelta, 0f, 100f));
                if (emos.consentToHero != null && consentDelta != 0f)
                    emos.consentToHero.SetValueNextUpdate(Mathf.Clamp(emos.consentToHero.value.total + consentDelta, 0f, 100f));
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"PsychologyEngine emotion apply failed: {ex.Message}");
            }
        }

        private void UpdateModelingStage()
        {
            // Stage progression based on atmosphere + thawing
            if (CurrentStage == ModelingStage.Discuss && Atmosphere >= 35 && Thawing >= 15)
                CurrentStage = ModelingStage.Photos;
            else if (CurrentStage == ModelingStage.Photos && Atmosphere >= 50 && Thawing >= 30)
                CurrentStage = ModelingStage.Posing;
            else if (CurrentStage == ModelingStage.Posing && Atmosphere >= 65 && Thawing >= 50)
                CurrentStage = ModelingStage.Lingerie;
            else if (CurrentStage == ModelingStage.Lingerie && Atmosphere >= 80 && Thawing >= 70)
                CurrentStage = ModelingStage.Erotic;
        }

        private void DecayKeywords(float factor)
        {
            Flattery *= factor;
            Intimidation *= factor;
            Seduction *= factor;
            Humor *= factor;
            Empathy *= factor;
            Dominance *= factor;
            Vulnerability *= factor;
            Negotiation *= factor;
            Provocation *= factor;
            // Professionalism decays slower
            Professionalism = Mathf.Lerp(Professionalism, 30f, 0.02f);
        }

        private List<KeyValuePair<string, float>> GetTopKeywords(int count, float minValue)
        {
            var all = new Dictionary<string, float>
            {
                ["Flat"] = Flattery, ["Intim"] = Intimidation, ["Seduc"] = Seduction,
                ["Prof"] = Professionalism, ["Humor"] = Humor, ["Empath"] = Empathy,
                ["Domin"] = Dominance, ["Vuln"] = Vulnerability,
                ["Negot"] = Negotiation, ["Provoc"] = Provocation
            };

            return all.Where(kv => kv.Value >= minValue)
                       .OrderByDescending(kv => kv.Value)
                       .Take(count)
                       .ToList();
        }

        private float DiceRoll(float baseVal, float modifier, float variance)
        {
            float roll = (float)(_rng.NextDouble() * 2.0 - 1.0) * variance;
            return Clamp100(baseVal + modifier + roll);
        }

        private static float Clamp100(float v) => Mathf.Clamp(v, 0f, 100f);
    }

    /// <summary>Modeling session stages, replacing the old binary PreferencesDiscussed flag.</summary>
    public enum ModelingStage
    {
        Discuss,    // Initial conversation / interview
        Photos,     // Clothed photo session
        Posing,     // Active posing
        Lingerie,   // Lingerie / partial undress
        Erotic      // Full erotic content
    }
}
