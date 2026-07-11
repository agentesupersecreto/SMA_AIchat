using System;

namespace DialogInterceptorMod.Models
{
    public class ChatMessage
    {
        public bool IsUser;
        public bool IsSystem;
        public string Text;
        public DateTime Timestamp;

        public ChatMessage(bool isUser, string text)
        {
            this.IsUser = isUser;
            this.IsSystem = false;
            this.Text = text;
            this.Timestamp = DateTime.Now;
        }

        public static ChatMessage SystemMessage(string text)
        {
            return new ChatMessage(false, text) { IsSystem = true };
        }

        /// <summary>Serialize to a simple line format for history persistence.</summary>
        public string ToLine()
        {
            string type = IsSystem ? "S" : (IsUser ? "U" : "A");
            string escaped = Text.Replace("\n", "\\n").Replace("\r", "");
            return $"{type}|{Timestamp:o}|{escaped}";
        }

        /// <summary>Deserialize from the line format.</summary>
        public static ChatMessage FromLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return null;
            
            int first = line.IndexOf('|');
            if (first < 0) return null;
            int second = line.IndexOf('|', first + 1);
            if (second < 0) return null;

            string type = line.Substring(0, first);
            string timeStr = line.Substring(first + 1, second - first - 1);
            string text = line.Substring(second + 1).Replace("\\n", "\n");

            DateTime ts = DateTime.Now;
            DateTime.TryParse(timeStr, null, System.Globalization.DateTimeStyles.RoundtripKind, out ts);

            var msg = new ChatMessage(type == "U", text);
            msg.IsSystem = type == "S";
            msg.Timestamp = ts;
            return msg;
        }
    }
}
