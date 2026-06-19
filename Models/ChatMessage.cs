namespace DialogInterceptorMod.Models
{
    public class ChatMessage
    {
        public bool IsUser;
        public bool IsSystem;
        public string Text;

        public ChatMessage(bool isUser, string text)
        {
            this.IsUser = isUser;
            this.IsSystem = false;
            this.Text = text;
        }

        public static ChatMessage SystemMessage(string text)
        {
            return new ChatMessage(false, text) { IsSystem = true };
        }
    }
}
