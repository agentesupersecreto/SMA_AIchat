using System;
using System.IO;
using UnityEngine;
using DialogInterceptorMod.Core;

namespace DialogInterceptorMod.UI
{
    public class ChatWindow
    {
        private DialogBehaviour _behaviour;

        public bool WindowVisible = false;
        private Rect _windowRect;
        private int _windowId = 98765;

        private string _userInput = "";
        private bool _showApiKey = false;
        private Vector2 _chatScroll = Vector2.zero;
        private Vector2 _inputScroll = Vector2.zero;
        public bool AwaitingResponse = false;
        
        private string _statusText = "";
        private bool _statusIsError = false;
        private bool _isResizing = false;

        private string _emotionFeedback = "";
        private float _emotionFeedbackTimer = 0f;

        private string _ollamaModelInput = "";
        private string _ollamaUrlInput = "";
        private string _hotkeyInput = "";
        private bool _showSettings = false;

        private string _configFilePath;
        private string _customPromptPath;
        private DateTime _lastCustomPromptWrite;
        private string _lastCustomPromptContent;
        private float _hotReloadCheckInterval = 2f;
        private float _hotReloadTimer = 0f;

        public ChatWindow(DialogBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        public void Initialize()
        {
            _configFilePath = Path.Combine(Path.GetDirectoryName(Plugin.ConfigPath ?? Application.dataPath), "AIchat/aichat_config.txt");
            _customPromptPath = Path.Combine(Path.GetDirectoryName(Plugin.ConfigPath ?? Application.dataPath), "AIchat/custom_prompt.txt");
            LoadConfig();
            _ollamaModelInput = _behaviour.OllamaModel;
            _ollamaUrlInput = _behaviour.OllamaUrl;
            _hotkeyInput = _behaviour.ChatHotkey.ToString();
            _windowRect = new Rect(Screen.width - 530, 60, 500, 650);
            if (File.Exists(_customPromptPath))
                _lastCustomPromptWrite = File.GetLastWriteTime(_customPromptPath);
        }

        public void HandleUpdate()
        {
            if (Input.GetKeyDown(_behaviour.ChatHotkey))
            {
                WindowVisible = !WindowVisible;
                Plugin.Log.LogInfo($"Chat window: {(WindowVisible ? "opened" : "closed")}");
            }

            if (WindowVisible)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (_emotionFeedbackTimer > 0f)
            {
                _emotionFeedbackTimer -= Time.deltaTime;
                if (_emotionFeedbackTimer <= 0f)
                    _emotionFeedback = "";
            }

            _hotReloadTimer += Time.deltaTime;
            if (_hotReloadTimer >= _hotReloadCheckInterval)
            {
                _hotReloadTimer = 0f;
                CheckHotReload();
            }
        }

        private void CheckHotReload()
        {
            try
            {
                if (!File.Exists(_customPromptPath)) return;
                var lastWrite = File.GetLastWriteTime(_customPromptPath);
                if (lastWrite != _lastCustomPromptWrite)
                {
                    _lastCustomPromptWrite = lastWrite;
                    string newContent = File.ReadAllText(_customPromptPath);
                    if (newContent != _lastCustomPromptContent)
                    {
                        _lastCustomPromptContent = newContent;
                        _behaviour.CustomPrompt = newContent;
                        Plugin.Log.LogInfo("custom_prompt.txt hot-reloaded.");
                        SetStatus("Custom prompt hot-reloaded.", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Hot-reload error: {ex.Message}");
            }
        }

        public void Draw()
        {
            if (!WindowVisible) return;

            if (!ChatStyles.Initialized || ChatStyles.WindowStyle == null || ChatStyles.WindowStyle.normal.background == null)
            {
                ChatStyles.Initialize();
            }

            _windowRect = GUI.Window(_windowId, _windowRect, DrawWindow, "", ChatStyles.WindowStyle);

            if (!string.IsNullOrEmpty(GUI.tooltip))
            {
                Vector2 mousePos = Event.current.mousePosition;
                Vector2 tooltipSize = ChatStyles.TooltipStyle.CalcSize(new GUIContent(GUI.tooltip));
                Rect tooltipRect = new Rect(mousePos.x + 10, mousePos.y + 10, tooltipSize.x + 12, tooltipSize.y + 6);
                GUI.Label(tooltipRect, GUI.tooltip, ChatStyles.TooltipStyle);
            }
        }

        private void DrawWindow(int id)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("[AI Chat v 1.2 beta] made by agenteSuperSecreto", ChatStyles.TitleStyle);
            if (GUILayout.Button(_showSettings ? "Chat" : "Config", ChatStyles.ButtonStyle, GUILayout.Width(50), GUILayout.Height(28)))
            {
                _showSettings = !_showSettings;
            }
            if (GUILayout.Button("X", ChatStyles.ButtonStyle, GUILayout.Width(28), GUILayout.Height(28)))
            {
                WindowVisible = false;
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(6);

            if (_showSettings)
            {
                DrawSettings();
            }
            else
            {
                DrawChat();
            }

            Rect resizeHandle = new Rect(_windowRect.width - 20, _windowRect.height - 20, 20, 20);
            GUI.Label(resizeHandle, "↘");
            if (Event.current.type == EventType.MouseDown && resizeHandle.Contains(Event.current.mousePosition))
            {
                _isResizing = true;
            }
            else if (Event.current.type == EventType.MouseUp)
            {
                _isResizing = false;
            }

            if (_isResizing && Event.current.type == EventType.MouseDrag)
            {
                _windowRect.width += Event.current.delta.x;
                _windowRect.height += Event.current.delta.y;
                
                _windowRect.width = Mathf.Max(_windowRect.width, 300);
                _windowRect.height = Mathf.Max(_windowRect.height, 400);
                Event.current.Use();
            }

            GUI.DragWindow(new Rect(0, 0, _windowRect.width - 25, 30));
        }

        private void DrawSettings()
        {
            GUILayout.Label("AI Provider:", ChatStyles.SectionStyle);
            GUILayout.BeginHorizontal();
            GUIStyle geminiStyle = _behaviour.UseOllama ? ChatStyles.ButtonStyle : ChatStyles.ActiveButtonStyle;
            GUIStyle ollamaStyle = _behaviour.UseOllama ? ChatStyles.ActiveButtonStyle : ChatStyles.ButtonStyle;

            if (GUILayout.Button("Gemini API", geminiStyle, GUILayout.Height(30)))
            {
                if (_behaviour.UseOllama)
                {
                    _behaviour.UseOllama = false;
                    _behaviour.ChatHistory.Clear();
                    _behaviour.ChatSummary = "";
                    _behaviour.RebuildApiClient();
                    SaveConfig();
                    SetStatus("Switched to Gemini API.", false);
                }
            }
            if (GUILayout.Button("Ollama (Local)", ollamaStyle, GUILayout.Height(30)))
            {
                if (!_behaviour.UseOllama)
                {
                    _behaviour.UseOllama = true;
                    _behaviour.ChatHistory.Clear();
                    _behaviour.ChatSummary = "";
                    _behaviour.RebuildApiClient();
                    SaveConfig();
                    SetStatus("Switched to Ollama (Local AI).", false);
                }
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(8);

            if (!_behaviour.UseOllama)
            {
                GUILayout.Label("Gemini API Key:", ChatStyles.LabelStyle);
                GUILayout.BeginHorizontal();
                if (_showApiKey)
                    _behaviour.ApiKey = GUILayout.TextField(_behaviour.ApiKey, ChatStyles.InputStyle, GUILayout.Width(250), GUILayout.Height(24));
                else
                    _behaviour.ApiKey = GUILayout.PasswordField(_behaviour.ApiKey, '\u25CF', ChatStyles.InputStyle, GUILayout.Width(250), GUILayout.Height(24));

                if (GUILayout.Button(_showApiKey ? "[Hide]" : "[Show]", ChatStyles.ButtonStyle, GUILayout.Width(70), GUILayout.Height(24)))
                    _showApiKey = !_showApiKey;
                GUILayout.EndHorizontal();
            }
            else
            {
                GUILayout.Label("Ollama Server URL:", ChatStyles.LabelStyle);
                _ollamaUrlInput = GUILayout.TextField(_ollamaUrlInput, ChatStyles.InputStyle, GUILayout.Height(24));

                GUILayout.Space(4);
                GUILayout.Label(new GUIContent("Ollama Model:", "Use any, but lightweight or older models can be dumb"), ChatStyles.LabelStyle);
                _ollamaModelInput = GUILayout.TextField(_ollamaModelInput, ChatStyles.InputStyle, GUILayout.Height(24));
                
                GUILayout.Space(2);
                GUILayout.Label("Recommended: dolphin3:8b or dolphin-llama3:8b", ChatStyles.StatusStyle);
            }

            GUILayout.Space(10);

            GUILayout.Label(new GUIContent("Toggle Hotkey:", "Press a key name like F9, F10, Tab, etc."), ChatStyles.LabelStyle);
            _hotkeyInput = GUILayout.TextField(_hotkeyInput, ChatStyles.InputStyle, GUILayout.Height(24));

            GUILayout.Space(10);

            GUILayout.Label("AI Behavior Options:", ChatStyles.SectionStyle);
            _behaviour.AllowSluttifyCommand = GUILayout.Toggle(_behaviour.AllowSluttifyCommand, "Allow Sluttify Command");
            _behaviour.AllowPoseChangeCommand = GUILayout.Toggle(_behaviour.AllowPoseChangeCommand, "Allow AI to Change Poses");
            _behaviour.StrictObedience = GUILayout.Toggle(_behaviour.StrictObedience, "Strict Obedience (Forces AI to obey commands)");
            _behaviour.AllowDispatchCommand = GUILayout.Toggle(_behaviour.AllowDispatchCommand, "Allow Dispatch (Fire/Leave) Command");
            _behaviour.AllowCanICommand = GUILayout.Toggle(_behaviour.AllowCanICommand, "Allow \"Can I?\" Touch Command");

            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.Label(new GUIContent($"Max History Messages: {_behaviour.MaxHistoryMessages}", "Higher values = better AI memory, but uses more tokens/RAM."), ChatStyles.LabelStyle, GUILayout.Width(180));
            _behaviour.MaxHistoryMessages = (int)GUILayout.HorizontalSlider(_behaviour.MaxHistoryMessages, 10, 100);
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Save Settings", ChatStyles.ButtonStyle, GUILayout.Height(32)))
            {
                _behaviour.OllamaUrl = _ollamaUrlInput.Trim();
                _behaviour.OllamaModel = _ollamaModelInput.Trim();

                if (Enum.TryParse(_hotkeyInput.Trim(), true, out KeyCode newKey))
                {
                    _behaviour.ChatHotkey = newKey;
                    SetStatus($"Settings saved. Hotkey: {newKey}", false);
                }
                else
                {
                    SetStatus($"Settings saved. Invalid hotkey '{_hotkeyInput}', keeping {_behaviour.ChatHotkey}.", true);
                }

                _behaviour.RebuildApiClient();
                SaveConfig();
            }

            if (!string.IsNullOrEmpty(_statusText))
            {
                GUILayout.Space(4);
                ChatStyles.StatusStyle.normal.textColor = _statusIsError ? new Color(1f, 0.4f, 0.4f) : new Color(0.9f, 0.9f, 0.5f);
                GUILayout.Label(_statusText, ChatStyles.StatusStyle);
            }
        }

        private void DrawChat()
        {
            string providerLabel = _behaviour.UseOllama 
                ? $"[Ollama: {_behaviour.OllamaModel}]" 
                : "[Gemini API]";
            GUILayout.Label($"Provider: {providerLabel}", ChatStyles.LabelStyle);

            GUILayout.Space(4);

            GUILayout.Label("Chat History:", ChatStyles.LabelStyle);
            _chatScroll = GUILayout.BeginScrollView(_chatScroll, ChatStyles.ChatAreaStyle, GUILayout.Height(300));
            foreach (var msg in _behaviour.ChatHistory)
            {
                GUIStyle style;
                string prefix;

                if (msg.IsSystem)
                {
                    style = ChatStyles.ChatSystemStyle;
                    prefix = "";
                }
                else if (msg.IsUser)
                {
                    style = ChatStyles.ChatUserStyle;
                    prefix = "<b>Player:</b> ";
                }
                else
                {
                    style = ChatStyles.ChatAIStyle;
                    prefix = $"<b>{_behaviour.CurrentCharName}:</b> ";
                }

                GUILayout.Label($"{prefix}{msg.Text}", style);
                GUILayout.Space(3);
            }
            GUILayout.EndScrollView();

            if (!string.IsNullOrEmpty(_emotionFeedback))
            {
                GUILayout.Space(2);
                var savedColor = GUI.color;
                GUI.color = new Color(1f, 0.7f, 0.3f);
                GUILayout.Label(_emotionFeedback, ChatStyles.ChatSystemStyle);
                GUI.color = savedColor;
            }

            GUILayout.Space(4);

            GUILayout.Label("Your message:", ChatStyles.LabelStyle);
            Event e = Event.current;
            if (e.type == EventType.KeyDown && (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.KeypadEnter))
            {
                if (GUI.GetNameOfFocusedControl() == "ChatInput")
                {
                    if (!AwaitingResponse && !string.IsNullOrEmpty(_userInput))
                    {
                        bool canSend = _behaviour.UseOllama || !string.IsNullOrEmpty(_behaviour.ApiKey);
                        if (canSend) SendMessage();
                    }
                    e.Use();
                }
            }

            GUI.SetNextControlName("ChatInput");
            _inputScroll = GUILayout.BeginScrollView(_inputScroll, GUILayout.Height(60));
            _userInput = GUILayout.TextArea(_userInput, ChatStyles.TextAreaStyle, GUILayout.ExpandHeight(true));
            GUILayout.EndScrollView();

            GUILayout.Space(4);

            GUILayout.BeginHorizontal();

            bool noChar = string.IsNullOrEmpty(_behaviour.CurrentCharId);
            bool noPrefs = !noChar && !_behaviour.PreferencesDiscussed;
            bool canSendBtn = !AwaitingResponse && !string.IsNullOrEmpty(_userInput) 
                && (_behaviour.UseOllama || !string.IsNullOrEmpty(_behaviour.ApiKey))
                && !noChar && !noPrefs;
            
            GUI.enabled = canSendBtn;
            if (GUILayout.Button("Send \u279B", ChatStyles.ButtonStyle, GUILayout.Height(32)))
            {
                SendMessage();
            }
            GUI.enabled = true;

            if (GUILayout.Button("Clear", ChatStyles.ButtonStyle, GUILayout.Height(32), GUILayout.Width(80)))
            {
                _behaviour.ChatHistory.Clear();
                _behaviour.ChatSummary = "";
                SetStatus("Chat cleared.", false);
            }
            GUILayout.EndHorizontal();

            if (noChar)
            {
                GUILayout.Space(4);
                GUILayout.Label("No character present.", ChatStyles.StatusStyle);
            }
            else if (noPrefs)
            {
                GUILayout.Space(4);
                GUILayout.Label("You must ask about her preferences first (Chat \u279B Whats your preferences?).", ChatStyles.StatusStyle);
            }
            else if (!string.IsNullOrEmpty(_statusText))
            {
                GUILayout.Space(4);
                ChatStyles.StatusStyle.normal.textColor = _statusIsError ? new Color(1f, 0.4f, 0.4f) : new Color(0.9f, 0.9f, 0.5f);
                GUILayout.Label(_statusText, ChatStyles.StatusStyle);
            }
        }

        public void SetStatus(string msg, bool error)
        {
            _statusText = msg;
            _statusIsError = error;
        }

        public void ShowEmotionFeedback(string feedback)
        {
            _emotionFeedback = feedback;
            _emotionFeedbackTimer = 5f;
        }
        
        public void ScrollToBottom()
        {
            _chatScroll.y = float.MaxValue;
        }

        private void SendMessage()
        {
            string message = _userInput.Trim();
            if (string.IsNullOrEmpty(message)) return;

            _behaviour.ChatHistory.Add(new Models.ChatMessage(true, message));

            _userInput = "";
            AwaitingResponse = true;

            string providerName = _behaviour.UseOllama ? $"Ollama ({_behaviour.OllamaModel})" : "Gemini";
            SetStatus($"Waiting for {providerName}'s response...", false);
            ScrollToBottom();

            _behaviour.StartCoroutine(_behaviour.APIClient.SendMessage(message));
        }

        private void SaveConfig()
        {
            try
            {
                string dir = Path.GetDirectoryName(_configFilePath);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                using (var writer = new StreamWriter(_configFilePath))
                {
                    writer.WriteLine($"ApiKey={_behaviour.ApiKey}");
                    writer.WriteLine($"UseOllama={_behaviour.UseOllama}");
                    writer.WriteLine($"OllamaUrl={_behaviour.OllamaUrl}");
                    writer.WriteLine($"OllamaModel={_behaviour.OllamaModel}");
                    writer.WriteLine($"ChatHotkey={_behaviour.ChatHotkey}");
                    writer.WriteLine($"AllowSluttifyCommand={_behaviour.AllowSluttifyCommand}");
                    writer.WriteLine($"AllowPoseChangeCommand={_behaviour.AllowPoseChangeCommand}");
                    writer.WriteLine($"StrictObedience={_behaviour.StrictObedience}");
                    writer.WriteLine($"AllowDispatchCommand={_behaviour.AllowDispatchCommand}");
                    writer.WriteLine($"AllowCanICommand={_behaviour.AllowCanICommand}");
                    writer.WriteLine($"MaxHistoryMessages={_behaviour.MaxHistoryMessages}");
                }
                Plugin.Log.LogInfo("Config saved.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error saving config: {ex.Message}");
            }
        }

        private void LoadConfig()
        {
            if (!File.Exists(_configFilePath))
            {
                Plugin.Log.LogInfo("No config file found. Using defaults.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(_configFilePath);

                if (lines.Length == 1 && !lines[0].Contains("="))
                {
                    _behaviour.ApiKey = lines[0].Trim();
                    return;
                }

                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#")) continue;

                    int eqIdx = trimmed.IndexOf('=');
                    if (eqIdx < 0) continue;

                    string key = trimmed.Substring(0, eqIdx).Trim();
                    string value = trimmed.Substring(eqIdx + 1).Trim();

                    switch (key)
                    {
                        case "ApiKey": _behaviour.ApiKey = value; break;
                        case "UseOllama": if (bool.TryParse(value, out bool useOllama)) _behaviour.UseOllama = useOllama; break;
                        case "OllamaUrl": _behaviour.OllamaUrl = value; break;
                        case "OllamaModel": _behaviour.OllamaModel = value; break;
                        case "ChatHotkey":
                            if (Enum.TryParse(value, true, out KeyCode hk))
                                _behaviour.ChatHotkey = hk;
                            break;
                        case "AllowSluttifyCommand": if (bool.TryParse(value, out bool slut)) _behaviour.AllowSluttifyCommand = slut; break;
                        case "AllowPoseChangeCommand": if (bool.TryParse(value, out bool pose)) _behaviour.AllowPoseChangeCommand = pose; break;
                        case "StrictObedience": if (bool.TryParse(value, out bool obey)) _behaviour.StrictObedience = obey; break;
                        case "AllowDispatchCommand": if (bool.TryParse(value, out bool disp)) _behaviour.AllowDispatchCommand = disp; break;
                        case "AllowCanICommand": if (bool.TryParse(value, out bool cani)) _behaviour.AllowCanICommand = cani; break;
                        case "MaxHistoryMessages": if (int.TryParse(value, out int maxh)) _behaviour.MaxHistoryMessages = maxh; break;
                    }
                }
                Plugin.Log.LogInfo("Config loaded.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"Error loading config: {ex.Message}");
            }
        }
    }
}
