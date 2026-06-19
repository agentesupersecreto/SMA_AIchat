using System.Collections.Generic;
using UnityEngine;
using DialogInterceptorMod.Models;
using DialogInterceptorMod.UI;
using DialogInterceptorMod.API;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Discursos;

namespace DialogInterceptorMod.Core
{
    /// <summary>
    /// Active AI provider. Kept as a tri-state instead of a bool so new
    /// providers (e.g. Gemma) can be added without breaking existing configs.
    /// </summary>
    public enum ProviderType { Gemini, Ollama, Gemma }

    public class DialogBehaviour : MonoBehaviour
    {
        public static DialogBehaviour Instance { get; private set; }

        public ChatWindow Window { get; private set; }
        public IApiClient APIClient { get; private set; }

        public List<ChatMessage> ChatHistory { get; private set; } = new List<ChatMessage>();
        public string ChatSummary = "";
        public string CustomPrompt = "";

        // --- Config fields ---
        public string ApiKey = "";
        public ProviderType Provider = ProviderType.Gemini;
        public string OllamaUrl = "http://localhost:11434/api/generate";
        public string OllamaModel = "dolphin3:8b";
        public string GemmaUrl = "http://localhost:1234/v1";
        public string GemmaModel = "gemma-the-writer-n-restless-quill-10b-uncensored";
        public KeyCode ChatHotkey { get; set; } = KeyCode.F9;

        /// <summary>
        /// Backward-compat shim for the old UseOllama config key. Reads/writes
        /// map onto <see cref="Provider"/>. New configs use Provider= instead.
        /// </summary>
        public bool UseOllama
        {
            get => Provider == ProviderType.Ollama;
            set => Provider = value ? ProviderType.Ollama : ProviderType.Gemini;
        }

        public bool AllowSluttifyCommand { get; set; } = false;
        public bool AllowPoseChangeCommand { get; set; } = true;
        public bool StrictObedience { get; set; } = false;

        public bool AllowDispatchCommand { get; set; } = false;
        public bool AllowCanICommand { get; set; } = true;
        public bool AllowSentimentReactions { get; set; } = true;
        public int MaxHistoryMessages { get; set; } = 30;

        public string CurrentCharId = "";
        public string CurrentCharName = "AI";
        public bool PreferencesDiscussed = false;

        public ControlladorDeBarkDePersonalidad CachedBarkController { get; private set; }

        // Per-bind character identity (Guid string), used to detect swaps.
        // NOTE: GameObject.GetInstanceID() is NOT reliable here because the game
        // pools and re-binds the female character GameObject instead of recreating
        // it, so its instance ID stays constant across model changes.
        private string _lastCharIdString = "";

        public static void Initialize()
        {
            var _gameObject = new GameObject("DialogInterceptor");
            _gameObject.hideFlags |= (HideFlags)61; // HideAndDontSave
            UnityEngine.Object.DontDestroyOnLoad(_gameObject);
            Instance = _gameObject.AddComponent<DialogBehaviour>();
            Plugin.Log.LogInfo("GameObject persistente 'DialogInterceptor' creado.");
        }

        private void Awake()
        {
            Window = new ChatWindow(this);
            
            string customPromptPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Plugin.ConfigPath ?? Application.dataPath), "AIchat/custom_prompt.txt");
            if (System.IO.File.Exists(customPromptPath))
            {
                CustomPrompt = System.IO.File.ReadAllText(customPromptPath);
                Plugin.Log.LogInfo("Custom prompt loaded.");
            }
        }

        private void Start()
        {
            Window.Initialize();
            // Create the appropriate client based on loaded config
            RebuildApiClient();
        }

        /// <summary>
        /// Recreates the API client based on the active provider.
        /// Called on startup and when the user switches providers.
        /// </summary>
        public void RebuildApiClient()
        {
            switch (Provider)
            {
                case ProviderType.Ollama:
                    APIClient = new OllamaClient(this);
                    Plugin.Log.LogInfo($"Using Ollama ({OllamaModel}) at {OllamaUrl}");
                    break;
                case ProviderType.Gemma:
                    APIClient = new GemmaClient(this);
                    Plugin.Log.LogInfo($"Using Gemma ({GemmaModel}) at {GemmaUrl}");
                    break;
                default:
                    APIClient = new GeminiClient(this);
                    Plugin.Log.LogInfo("Using Gemini API.");
                    break;
            }
        }

        private void Update()
        {
            Window.HandleUpdate();

            var controlador = FindObjectOfType<ControlladorDeBarkDePersonalidad>();
            CachedBarkController = controlador;
            if (controlador != null)
            {
                Transform rootTransform = controlador.GetComponentInParent<Transform>().root;

                // Read the per-character identity FIRST. ID_UnicoString is a fresh
                // Guid assigned on every Bind/SoftBind, so it is the reliable signal
                // that the model has actually changed (unlike GameObject.GetInstanceID()).
                string newCharId = "";
                try
                {
                    if (rootTransform != null)
                    {
                        var character = rootTransform.GetComponentInChildren<Assets._ReusableScripts.CuchiCuchi.Character>();
                        if (character != null)
                        {
                            newCharId = character.ID_UnicoString ?? "";
                            CurrentCharId = newCharId;
                            CurrentCharName = character.nombre.Trim();
                            PreferencesDiscussed = Assets.TValle.Pro.Entrevista.Runtime.General.Memoria.MemoriaDeSMAModelosFemeninas.HabloSobreTipoDeModelaje(Assets._ReusableScripts.Globales.GlobalSingletonV2<Assets._ReusableScripts.MemoriaJson>.instance, CurrentCharId);
                        }
                    }
                }
                catch (System.Exception)
                {
                    // Ignore errors during fetch
                }

                // Detect an actual model swap: a non-empty new id that differs from
                // the previously seen one. On the first character detected, history
                // is already empty so the (empty != non-empty) case is harmless.
                if (!string.IsNullOrEmpty(newCharId) && newCharId != _lastCharIdString)
                {
                    ChatHistory.Clear();
                    ChatSummary = "";
                    Plugin.Log.LogInfo($"Se detectó un cambio de personaje ({_lastCharIdString} → {newCharId}). Historial limpiado.");
                }

                if (!string.IsNullOrEmpty(newCharId))
                    _lastCharIdString = newCharId;

                if (ChatHistory.Count > MaxHistoryMessages)
                {
                    int toRemove = ChatHistory.Count - MaxHistoryMessages;
                    ChatHistory.RemoveRange(0, toRemove);
                }
            }
            else
            {
                // No character present. Reset the identity so the next character we
                // see is treated as a fresh binding, but do NOT clear chat history
                // here — a 1-frame flicker where FindObjectOfType returns null while
                // the pooled object is briefly inactive would otherwise wipe a valid
                // conversation. History clearing is owned by the swap check above.
                _lastCharIdString = "";
                CurrentCharId = "";
                CurrentCharName = "AI";
                PreferencesDiscussed = false;
            }
        }

        private void OnGUI()
        {
            Window.Draw();
        }

        public static void RegisterInterceptedFunction(string func)
        {
            // Optional, for debugging
        }
    }
}
