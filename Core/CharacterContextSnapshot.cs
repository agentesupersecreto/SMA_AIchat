using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using HarmonyLib;
using UnityEngine;

namespace DialogInterceptorMod.Core
{
    /// <summary>
    /// A point-in-time view of the game data that is useful to the AI prompt.
    /// This class intentionally belongs to AIchat and has no dependency on
    /// DesignerMod. It separates persistent personality data from live
    /// appearance/outfit and interview/economy metadata.
    /// </summary>
    public sealed class CharacterContextSnapshot
    {
        public string CharacterId = "";
        public string CharacterName = "";
        public int Age;
        public float Height;
        public float ModelingExperience;
        public float Fatigue;
        public bool IsHired;
        public float Salary;
        public float Commission;
        public string Job = "";

        public readonly Dictionary<string, float> LiveTraits = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public readonly Dictionary<string, float> HumanTraits = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public readonly Dictionary<string, float> DesireTraits = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public readonly Dictionary<string, float> ConsentTraits = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public readonly Dictionary<string, float> InterviewSets = new Dictionary<string, float>(StringComparer.OrdinalIgnoreCase);
        public readonly Dictionary<string, float[]> AppearanceValues = new Dictionary<string, float[]>(StringComparer.OrdinalIgnoreCase);
        public readonly List<string> Outfit = new List<string>();
        public readonly List<string> AgencyStatuses = new List<string>();

        public bool IsValid => !string.IsNullOrEmpty(CharacterId);

        public static CharacterContextSnapshot Capture(Transform root)
        {
            var snapshot = new CharacterContextSnapshot();
            if (root == null)
                return snapshot;

            try
            {
                Character character = root.GetComponentInChildren<Character>(true);
                if (character == null)
                    return snapshot;

                snapshot.CharacterId = character.ID_UnicoString ?? "";
                snapshot.CharacterName = (character.nombre ?? character.nombreCompleto ?? "AI").Trim();
                snapshot.Height = character.estatura * 100f;

                Component femaleInfo = FindComponentByInterfaceName(root, "IFemaleCharInfo");
                snapshot.Age = ReadIntMember(femaleInfo, "age", 0);

                CaptureMemoryData(snapshot);
                CapturePersonality(snapshot, root);
                CaptureAppearance(snapshot, root);
                CaptureOutfit(snapshot, root);
                CaptureInterviewSets(snapshot, root, character);
                CaptureAgencyStatuses(snapshot, character);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"AIchat character context capture failed: {ex.Message}");
            }

            return snapshot;
        }

        public string ToPromptBlock()
        {
            if (!IsValid)
                return "";

            var sb = new StringBuilder();
            sb.AppendLine("[CHARACTER_CONTEXT]");
            sb.AppendLine($"Identity: {CharacterName}; Age:{Age}; Height:{Height.ToString("F0", CultureInfo.InvariantCulture)}cm; ModelXP:{ModelingExperience.ToString("F1", CultureInfo.InvariantCulture)}; Fatigue:{Fatigue.ToString("F0", CultureInfo.InvariantCulture)}%");
            sb.AppendLine($"Hiring: {(IsHired ? "Hired" : "Not hired")}; Salary:${Salary.ToString("F0", CultureInfo.InvariantCulture)}; Commission:{Commission.ToString("F0", CultureInfo.InvariantCulture)}%; Job:{(string.IsNullOrEmpty(Job) ? "none" : Job)}");
            AppendModifierBlock(sb, "LIVE_TRAITS", LiveTraits);
            AppendModifierBlock(sb, "HUMAN_TRAITS", HumanTraits);
            AppendModifierBlock(sb, "DESIRES", DesireTraits);
            AppendModifierBlock(sb, "CONSENT_RULES", ConsentTraits);
            AppendModifierBlock(sb, "INTERVIEW_PERSONALITY_SETS", InterviewSets);

            if (AppearanceValues.Count > 0)
            {
                sb.Append("[APPEARANCE] ");
                foreach (KeyValuePair<string, float[]> value in AppearanceValues.OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase))
                {
                    sb.Append(ShortName(value.Key));
                    sb.Append(':');
                    sb.Append(string.Join("/", value.Value.Select(number => number.ToString("F2", CultureInfo.InvariantCulture)).ToArray()));
                    sb.Append(' ');
                }
                sb.AppendLine();
            }

            sb.AppendLine(Outfit.Count == 0
                ? "[OUTFIT] Naked or no outfit data available."
                : "[OUTFIT] " + string.Join(", ", Outfit.ToArray()));

            if (AgencyStatuses.Count > 0)
                sb.AppendLine("[AGENCIES] " + string.Join("; ", AgencyStatuses.ToArray()));
            else
                sb.AppendLine("[AGENCIES] Agency evaluation unavailable in the current scene.");

            sb.AppendLine("[/CHARACTER_CONTEXT]");
            return sb.ToString();
        }

        private static void AppendModifierBlock(StringBuilder builder, string section, Dictionary<string, float> values)
        {
            if (values.Count == 0)
                return;

            builder.Append('[').Append(section).Append("] ");
            foreach (KeyValuePair<string, float> value in values.OrderBy(pair => pair.Key, StringComparer.OrdinalIgnoreCase))
            {
                builder.Append(ShortName(value.Key));
                builder.Append(':');
                builder.Append(value.Value.ToString("F2", CultureInfo.InvariantCulture));
                builder.Append(' ');
            }
            builder.AppendLine();
        }

        private static string ShortName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "value";
            int separator = name.LastIndexOf('_');
            return separator >= 0 && separator < name.Length - 1 ? name.Substring(separator + 1) : name;
        }

        private static void CaptureMemoryData(CharacterContextSnapshot snapshot)
        {
            try
            {
                object memory = GetMemorySingletonInstance();
                if (memory == null || string.IsNullOrEmpty(snapshot.CharacterId))
                    return;

                Type models = FindType("Assets.TValle.Pro.Entrevista.Runtime.General.Memoria.MemoriaDeSMAModelosFemeninas");
                Type npcMemory = FindType("Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers.MemoriaDeNpc");
                snapshot.ModelingExperience = InvokeFloat(models, "TryGetModelingExp", memory, snapshot.CharacterId, 0f);
                snapshot.Fatigue = InvokeFloat(npcMemory, "GetFatigue", memory, snapshot.CharacterId, 0f);
                snapshot.IsHired = InvokeBool(models, "IsNPCHired", memory, snapshot.CharacterId);
                if (snapshot.IsHired)
                {
                    object[] args = { memory, snapshot.CharacterId, 0f, 0f };
                    InvokeStatic(models, "GetModeSalaryAndCommission", args);
                    snapshot.Salary = ConvertToFloat(args[2]);
                    snapshot.Commission = ConvertToFloat(args[3]);
                    snapshot.Job = Convert.ToString(InvokeStatic(models, "GetJobOfFemale", memory, snapshot.CharacterId), CultureInfo.InvariantCulture) ?? "";
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"AIchat memory context unavailable: {ex.Message}");
            }
        }

        private static void CapturePersonality(CharacterContextSnapshot snapshot, Transform root)
        {
            Component personality = FindComponentByTypeName(root, "AlteradoresDePersonalidadFemenina");
            foreach (ModifierValue modifier in ReadModifiers(personality))
            {
                if (modifier.Name.StartsWith("Fitness_", StringComparison.OrdinalIgnoreCase))
                {
                    snapshot.InterviewSets[modifier.Name] = modifier.Values.Length > 0 ? modifier.Values[0] : 0f;
                }
                else if (modifier.Name.StartsWith("Personalidad_Rasgo_", StringComparison.OrdinalIgnoreCase))
                {
                    snapshot.LiveTraits[modifier.Name] = FirstValue(modifier.Values);
                }
                else if (modifier.Name.StartsWith("Personalidad_TraitHumano_", StringComparison.OrdinalIgnoreCase))
                {
                    snapshot.HumanTraits[modifier.Name] = FirstValue(modifier.Values);
                }
                else if (modifier.Name.StartsWith("Personalidad_Deseos", StringComparison.OrdinalIgnoreCase))
                {
                    snapshot.DesireTraits[modifier.Name] = FirstValue(modifier.Values);
                }
                else if (modifier.Name.StartsWith("Personalidad_Consent", StringComparison.OrdinalIgnoreCase))
                {
                    snapshot.ConsentTraits[modifier.Name] = FirstValue(modifier.Values);
                }
            }
        }

        private static void CaptureAppearance(CharacterContextSnapshot snapshot, Transform root)
        {
            Component appearance = FindComponentByTypeName(root, "AlteradoresDeAparienciaFemenina");
            foreach (ModifierValue modifier in ReadModifiers(appearance))
                snapshot.AppearanceValues[modifier.Name] = modifier.Values;
        }

        private static void CaptureOutfit(CharacterContextSnapshot snapshot, Transform root)
        {
            IRopaManager clothes = root.GetComponentInChildren<IRopaManager>(true);
            if (clothes == null || clothes.piezasPuestasPorId == null)
                return;

            foreach (string piece in clothes.piezasPuestasPorId.Keys)
            {
                if (!string.IsNullOrEmpty(piece) && !snapshot.Outfit.Contains(piece))
                    snapshot.Outfit.Add(piece);
            }
        }

        private static void CaptureInterviewSets(CharacterContextSnapshot snapshot, Transform root, Character character)
        {
            // The interview sets are held by the active subject, not necessarily
            // by the live modifier map. Reflection keeps this reader tolerant of
            // game assembly version changes and independent of DesignerMod.
            try
            {
                Type activityType = FindType("Assets.TValle.Pro.Entrevista.Runtime.Actividades.Actividad");
                object activity = ReadStaticMember(activityType, "running");
                if (activity == null || activity.GetType().Name.IndexOf("Entrevista", StringComparison.OrdinalIgnoreCase) < 0)
                    return;

                object pool = ReadMember(activity, "currentPiscinaManager");
                object subject = InvokeInstance(pool, "ObtenerSujeto", character.ID_UnicoString);
                object personality = ReadMember(subject, "personalidad");
                object sets = ReadMember(personality, "conjuntoPorNombre");
                if (!(sets is IDictionary dictionary))
                    return;

                foreach (DictionaryEntry entry in dictionary)
                {
                    object value = entry.Value;
                    float fitness = ReadFloatMember(value, "fitnes", float.NaN);
                    if (!float.IsNaN(fitness))
                        snapshot.InterviewSets["Fitness_" + Convert.ToString(entry.Key, CultureInfo.InvariantCulture)] = Mathf.Clamp01(fitness);
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"AIchat interview personality sets unavailable: {ex.Message}");
            }
        }

        private static void CaptureAgencyStatuses(CharacterContextSnapshot snapshot, Character character)
        {
            try
            {
                Type agencyManagerType = FindType("Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas.OtrasAgencias")
                    ?? FindType("Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.OtrasAgencias");
                object agencyManager = GetStaticSingletonInstance(agencyManagerType);
                IEnumerable agencies = ReadMember(agencyManager, "agencias") as IEnumerable;
                Type helperType = FindType("Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.AgenciasHelper");
                if (agencies == null || helperType == null)
                    return;

                MethodInfo evaluator = helperType.GetMethods(BindingFlags.Public | BindingFlags.Static)
                    .FirstOrDefault(method => method.Name == "ModeloEsAceptadaPorAgencia" && method.GetParameters().Length == 4);
                if (evaluator == null)
                    return;

                foreach (object agency in agencies)
                {
                    if (agency == null)
                        continue;
                    object[] args = { character, agency, null, null };
                    evaluator.Invoke(null, args);
                    object response = args[3];
                    string name = Convert.ToString(ReadMember(agency, "nombre"), CultureInfo.InvariantCulture) ?? "Agency";
                    bool accepted = ReadBoolMember(response, "esAceptada", false);
                    snapshot.AgencyStatuses.Add(name + ": " + (accepted ? "Accepted" : "Rejected"));
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"AIchat agency context unavailable: {ex.Message}");
            }
        }

        private struct ModifierValue
        {
            public string Name;
            public float[] Values;
        }

        private static IEnumerable<ModifierValue> ReadModifiers(Component component)
        {
            var result = new List<ModifierValue>();
            if (component == null)
                return result;

            try
            {
                FieldInfo mapField = FindInstanceField(component.GetType(), "m_mapaDeValoresUsando");
                object map = mapField == null ? null : mapField.GetValue(component);
                MethodInfo getter = map?.GetType().GetMethod("ObtenerAlteradorModificadores", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                IEnumerable modifiers = getter?.Invoke(map, null) as IEnumerable;
                if (modifiers == null)
                    return result;

                foreach (object modifier in modifiers)
                {
                    string name = Convert.ToString(ReadMember(modifier, "alteradorName"), CultureInfo.InvariantCulture);
                    float[] values = ReadMember(modifier, "modificadores") as float[];
                    if (!string.IsNullOrEmpty(name) && values != null)
                        result.Add(new ModifierValue { Name = name, Values = (float[])values.Clone() });
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"AIchat modifier map unavailable: {ex.Message}");
            }
            return result;
        }

        private static FieldInfo FindInstanceField(Type type, string name)
        {
            for (Type current = type; current != null; current = current.BaseType)
            {
                FieldInfo field = current.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
                if (field != null)
                    return field;
            }
            return null;
        }

        private static float FirstValue(float[] values) => values != null && values.Length > 0 ? values[0] : 0f;

        private static Type FindType(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                return null;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    Type type = assembly.GetType(fullName, false);
                    if (type != null)
                        return type;
                }
                catch { }
            }
            return null;
        }

        private static Component FindComponentByTypeName(Transform root, string typeName)
        {
            if (root == null)
                return null;
            foreach (Component component in root.GetComponentsInChildren<Component>(true))
            {
                if (component != null && component.GetType().Name == typeName)
                    return component;
            }
            return null;
        }

        private static Component FindComponentByInterfaceName(Transform root, string interfaceName)
        {
            if (root == null)
                return null;
            foreach (Component component in root.GetComponentsInChildren<Component>(true))
            {
                if (component != null && component.GetType().GetInterfaces().Any(type => type.Name == interfaceName))
                    return component;
            }
            return null;
        }

        private static object GetMemorySingletonInstance()
        {
            Type memoryType = FindType("Assets._ReusableScripts.MemoriaJson");
            if (memoryType == null)
                return null;

            object direct = GetStaticSingletonInstance(memoryType);
            if (direct != null)
                return direct;

            // MemoriaJson is normally exposed through the game's generic
            // GlobalSingletonV2<MemoriaJson>, not MemoriaJson.instance.
            Type genericSingleton = FindType("Assets._ReusableScripts.Globales.GlobalSingletonV2`1");
            if (genericSingleton == null)
                return null;

            try
            {
                Type closedSingleton = genericSingleton.MakeGenericType(memoryType);
                return GetStaticSingletonInstance(closedSingleton);
            }
            catch (Exception ex)
            {
                Plugin.Log.LogDebug($"AIchat memory singleton resolution failed: {ex.Message}");
                return null;
            }
        }

        private static object GetStaticSingletonInstance(string typeName)
        {
            return GetStaticSingletonInstance(FindType(typeName));
        }

        private static object GetStaticSingletonInstance(Type type)
        {
            if (type == null)
                return null;
            Type current = type;
            while (current != null)
            {
                object value = ReadStaticMember(current, "instance");
                if (value != null)
                    return value;
                current = current.BaseType;
            }
            return null;
        }

        private static object ReadStaticMember(Type type, string name)
        {
            if (type == null)
                return null;
            PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            if (property != null)
                return property.GetValue(null, null);
            FieldInfo field = type.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.FlattenHierarchy);
            return field?.GetValue(null);
        }

        private static object ReadMember(object target, string name)
        {
            if (target == null)
                return null;
            Type type = target.GetType();
            PropertyInfo property = type.GetProperty(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property != null)
                return property.GetValue(target, null);
            FieldInfo field = type.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return field?.GetValue(target);
        }

        private static object InvokeInstance(object target, string methodName, params object[] args)
        {
            if (target == null)
                return null;
            MethodInfo method = target.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(candidate => candidate.Name == methodName && candidate.GetParameters().Length == args.Length);
            return method?.Invoke(target, args);
        }

        private static object InvokeStatic(Type type, string methodName, params object[] args)
        {
            if (type == null)
                return null;
            MethodInfo method = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
                .FirstOrDefault(candidate => candidate.Name == methodName && candidate.GetParameters().Length == args.Length);
            return method?.Invoke(null, args);
        }

        private static float InvokeFloat(Type type, string methodName, params object[] args)
        {
            return ConvertToFloat(InvokeStatic(type, methodName, args));
        }

        private static bool InvokeBool(Type type, string methodName, params object[] args)
        {
            object result = InvokeStatic(type, methodName, args);
            return result is bool value && value;
        }

        private static float ConvertToFloat(object value)
        {
            try { return value == null ? 0f : Convert.ToSingle(value, CultureInfo.InvariantCulture); }
            catch { return 0f; }
        }

        private static int ReadIntMember(object target, string name, int fallback)
        {
            object value = ReadMember(target, name);
            try { return value == null ? fallback : Convert.ToInt32(value, CultureInfo.InvariantCulture); }
            catch { return fallback; }
        }

        private static float ReadFloatMember(object target, string name, float fallback)
        {
            object value = ReadMember(target, name);
            try { return value == null ? fallback : Convert.ToSingle(value, CultureInfo.InvariantCulture); }
            catch { return fallback; }
        }

        private static bool ReadBoolMember(object target, string name, bool fallback)
        {
            object value = ReadMember(target, name);
            return value is bool boolValue ? boolValue : fallback;
        }
    }
}
