using UnityEngine;

namespace DialogInterceptorMod.UI
{
    public static class ChatStyles
    {
        public static bool Initialized = false;
        public static GUIStyle WindowStyle, TitleStyle, LabelStyle, ChatUserStyle, ChatAIStyle,
            InputStyle, TextAreaStyle, ButtonStyle, StatusStyle, ChatAreaStyle, ChatSystemStyle,
            TooltipStyle, SectionStyle, ActiveButtonStyle;

        public static void Initialize()
        {
            var bgWindow = CreateTexture(2, 2, new Color(0.05f, 0.05f, 0.08f, 0.92f)); // Glassmorphism dark
            var bgInput = CreateTexture(2, 2, new Color(0.1f, 0.1f, 0.15f, 0.7f));
            var bgButton = CreateTexture(2, 2, new Color(0.15f, 0.18f, 0.22f, 0.9f));
            var bgActiveButton = CreateTexture(2, 2, new Color(0.0f, 0.85f, 0.9f, 0.9f)); // Neon cyan accent
            var bgChatArea = CreateTexture(2, 2, new Color(0.0f, 0.0f, 0.0f, 0.3f)); // Very dark transparent background
            var bgUserMsg = CreateTexture(2, 2, new Color(0.05f, 0.4f, 0.85f, 0.8f)); // iMessage Blue
            var bgAIMsg = CreateTexture(2, 2, new Color(0.15f, 0.18f, 0.22f, 0.85f)); // Sleek dark gray
            var bgSystemMsg = CreateTexture(2, 2, new Color(0.8f, 0.5f, 0.1f, 0.6f)); // Orange warning
            var bgTooltip = CreateTexture(2, 2, new Color(0.1f, 0.1f, 0.15f, 0.95f));

            WindowStyle = new GUIStyle(GUI.skin.window) { padding = new RectOffset(12, 12, 8, 8), richText = true };
            WindowStyle.normal.background = bgWindow; WindowStyle.onNormal.background = bgWindow;

            TitleStyle = new GUIStyle(GUI.skin.label) { fontSize = 14, fontStyle = FontStyle.Bold, richText = true };
            TitleStyle.normal.textColor = new Color(0.0f, 0.85f, 0.9f); // Cyan title

            LabelStyle = new GUIStyle(GUI.skin.label) { fontSize = 12, fontStyle = FontStyle.Bold, richText = true };
            LabelStyle.normal.textColor = new Color(0.8f, 0.85f, 0.9f);

            SectionStyle = new GUIStyle(GUI.skin.label) { fontSize = 13, fontStyle = FontStyle.Bold };
            SectionStyle.normal.textColor = new Color(0.0f, 0.85f, 0.9f);

            InputStyle = new GUIStyle(GUI.skin.textField) { fontSize = 13, padding = new RectOffset(6, 6, 4, 4) };
            InputStyle.normal.background = bgInput; InputStyle.focused.background = bgInput;
            InputStyle.normal.textColor = Color.white; InputStyle.focused.textColor = Color.white;

            TextAreaStyle = new GUIStyle(GUI.skin.textArea) { fontSize = 13, wordWrap = true, padding = new RectOffset(8, 8, 6, 6) };
            TextAreaStyle.normal.background = bgInput; TextAreaStyle.focused.background = bgInput;
            TextAreaStyle.normal.textColor = Color.white; TextAreaStyle.focused.textColor = Color.white;

            ButtonStyle = new GUIStyle(GUI.skin.button) { fontSize = 13, fontStyle = FontStyle.Bold, padding = new RectOffset(8, 8, 4, 4), richText = true };
            ButtonStyle.normal.background = bgButton; ButtonStyle.normal.textColor = Color.white;

            ActiveButtonStyle = new GUIStyle(ButtonStyle);
            ActiveButtonStyle.normal.background = bgActiveButton;
            ActiveButtonStyle.normal.textColor = Color.black; // Black text on bright cyan

            ChatAreaStyle = new GUIStyle(GUI.skin.scrollView) { padding = new RectOffset(10, 10, 10, 10) };
            ChatAreaStyle.normal.background = bgChatArea;

            // Player bubble (blue, margins push it slightly right but mostly we use GUILayout wrappers)
            ChatUserStyle = new GUIStyle(GUI.skin.label) { fontSize = 13, wordWrap = true, richText = true, padding = new RectOffset(10, 10, 8, 8), margin = new RectOffset(20, 0, 4, 4) };
            ChatUserStyle.normal.background = bgUserMsg; ChatUserStyle.normal.textColor = Color.white;

            // AI bubble (dark, margins push it slightly left)
            ChatAIStyle = new GUIStyle(GUI.skin.label) { fontSize = 13, wordWrap = true, richText = true, padding = new RectOffset(10, 10, 8, 8), margin = new RectOffset(0, 20, 4, 4) };
            ChatAIStyle.normal.background = bgAIMsg; ChatAIStyle.normal.textColor = new Color(0.9f, 0.95f, 1f);

            ChatSystemStyle = new GUIStyle(GUI.skin.label) { fontSize = 12, wordWrap = true, richText = true, fontStyle = FontStyle.Italic, padding = new RectOffset(8, 8, 4, 4), margin = new RectOffset(0, 0, 2, 2) };
            ChatSystemStyle.normal.background = bgSystemMsg; ChatSystemStyle.normal.textColor = new Color(1f, 0.9f, 0.7f);

            StatusStyle = new GUIStyle(GUI.skin.label) { fontSize = 12, fontStyle = FontStyle.Italic, wordWrap = true };

            TooltipStyle = new GUIStyle(GUI.skin.box) { fontSize = 11, wordWrap = true, padding = new RectOffset(6, 6, 4, 4) };
            TooltipStyle.normal.background = bgTooltip;
            TooltipStyle.normal.textColor = new Color(1f, 0.95f, 0.7f);

            Initialized = true;
        }

        private static Texture2D CreateTexture(int w, int h, Color c)
        {
            var px = new Color[w * h];
            for (int i = 0; i < px.Length; i++) px[i] = c;
            var t = new Texture2D(w, h);
            t.SetPixels(px);
            t.Apply();
            return t;
        }
    }
}
