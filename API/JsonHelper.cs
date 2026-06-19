using System.Text;

namespace DialogInterceptorMod.API
{
    /// <summary>
    /// Shared JSON parsing utilities for both Gemini and Ollama responses.
    /// Handles malformed JSON, markdown wrapping, and edge cases from small local models.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Extracts the value of a given key from a JSON-like string.
        /// Handles escaped quotes, null values, and malformed responses.
        /// </summary>
        public static string ExtractJsonValue(string json, string clave)
        {
            if (string.IsNullOrEmpty(json)) return null;

            // Strip markdown code blocks if present
            json = StripMarkdownCodeBlocks(json);

            string target = $"\"{clave}\"";
            int keyIdx = json.IndexOf(target);
            if (keyIdx < 0)
            {
                // Try case-insensitive search
                string jsonLower = json.ToLower();
                keyIdx = jsonLower.IndexOf($"\"{clave.ToLower()}\"");
                if (keyIdx < 0) return null;
            }

            int colonIdx = json.IndexOf(':', keyIdx + target.Length);
            if (colonIdx < 0) return null;

            int i = colonIdx + 1;
            while (i < json.Length && char.IsWhiteSpace(json[i])) i++;

            if (i >= json.Length) return null;

            // Handle null literal
            if (i + 4 <= json.Length && json.Substring(i, 4) == "null")
                return null;

            // Handle string value
            if (json[i] == '"')
            {
                StringBuilder result = new StringBuilder();
                i++;
                while (i < json.Length)
                {
                    char c = json[i];
                    if (c == '\\' && i + 1 < json.Length)
                    {
                        char next = json[i + 1];
                        switch (next)
                        {
                            case '"': result.Append('"'); break;
                            case '\\': result.Append('\\'); break;
                            case 'n': result.Append('\n'); break;
                            case 'r': break;
                            case 't': result.Append('\t'); break;
                            default: result.Append(next); break;
                        }
                        i += 2;
                    }
                    else if (c == '"')
                    {
                        break;
                    }
                    else
                    {
                        result.Append(c);
                        i++;
                    }
                }
                return result.ToString();
            }
            else
            {
                // Handle non-string (number, boolean, etc.)
                int endToken = json.IndexOfAny(new char[] { ',', '}', '\n', ']' }, i);
                if (endToken > i) return json.Substring(i, endToken - i).Trim();
                return json.Substring(i).Trim();
            }
        }

        /// <summary>
        /// Removes markdown code block wrappers (```json ... ```) from AI responses.
        /// </summary>
        public static string StripMarkdownCodeBlocks(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            text = text.Trim();

            if (text.StartsWith("```json"))
                text = text.Substring(7);
            else if (text.StartsWith("```"))
                text = text.Substring(3);

            if (text.EndsWith("```"))
                text = text.Substring(0, text.Length - 3);

            return text.Trim();
        }

        /// <summary>
        /// Extracts the value of a key using the LAST occurrence of the key name.
        /// This avoids matching keys that appear inside string values (e.g. "comando" inside dialogo text).
        /// </summary>
        public static string ExtractJsonValueFromEnd(string json, string clave)
        {
            if (string.IsNullOrEmpty(json)) return null;

            json = StripMarkdownCodeBlocks(json);

            string target = $"\"{clave}\"";
            int keyIdx = json.LastIndexOf(target);
            if (keyIdx < 0)
            {
                string jsonLower = json.ToLower();
                keyIdx = jsonLower.LastIndexOf($"\"{clave.ToLower()}\"");
                if (keyIdx < 0) return null;
            }

            int colonIdx = json.IndexOf(':', keyIdx + target.Length);
            if (colonIdx < 0) return null;

            int i = colonIdx + 1;
            while (i < json.Length && char.IsWhiteSpace(json[i])) i++;

            if (i >= json.Length) return null;

            if (i + 4 <= json.Length && json.Substring(i, 4) == "null")
                return null;

            if (json[i] == '"')
            {
                StringBuilder result = new StringBuilder();
                i++;
                while (i < json.Length)
                {
                    char c = json[i];
                    if (c == '\\' && i + 1 < json.Length)
                    {
                        char next = json[i + 1];
                        switch (next)
                        {
                            case '"': result.Append('"'); break;
                            case '\\': result.Append('\\'); break;
                            case 'n': result.Append('\n'); break;
                            case 'r': break;
                            case 't': result.Append('\t'); break;
                            default: result.Append(next); break;
                        }
                        i += 2;
                    }
                    else if (c == '"') break;
                    else { result.Append(c); i++; }
                }
                return result.ToString();
            }
            else
            {
                int endToken = json.IndexOfAny(new char[] { ',', '}', '\n', ']' }, i);
                if (endToken > i) return json.Substring(i, endToken - i).Trim();
                return json.Substring(i).Trim();
            }
        }

        public static string EscapeJson(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            return texto
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }
    }
}
