using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DialogInterceptorMod.Core
{
    /// <summary>
    /// Manages conversation memory for local models with limited context windows.
    /// Provides rolling summarization, topic tagging for long-term memory,
    /// and persistence across sessions.
    /// Optimized for ~8GB VRAM (gemma-4-E4B Q4_K_M).
    /// </summary>
    public class ConversationMemory
    {
        /// <summary>Current short-term summary of the conversation so far.</summary>
        public string ShortTermSummary = "";

        /// <summary>
        /// Tagged important topics for long-term recall.
        /// Examples: "agreed to lingerie shoot", "she likes being called princess"
        /// </summary>
        public List<string> LongTermTags = new List<string>();

        /// <summary>Total number of exchanges in this conversation (including summarized).</summary>
        public int TotalExchangeCount;

        /// <summary>Character ID this memory belongs to.</summary>
        private string _charId;

        private string _savePath;

        public ConversationMemory() { }

        /// <summary>Binds this memory to a specific character for persistence.</summary>
        public void Bind(string charId)
        {
            _charId = charId;
            string dir = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(Plugin.ConfigPath ?? Application.dataPath),
                "AIchat", "memory");
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            _savePath = System.IO.Path.Combine(dir, $"mem_{charId}.txt");
        }

        /// <summary>Adds a topic tag for long-term memory. Max 20 tags.</summary>
        public void TagImportant(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag)) return;
            tag = tag.Trim();
            if (!LongTermTags.Contains(tag))
            {
                LongTermTags.Add(tag);
                if (LongTermTags.Count > 20)
                    LongTermTags.RemoveAt(0);
            }
        }

        /// <summary>
        /// Auto-detects important topics from a message and tags them.
        /// Simple keyword-based detection for common important events.
        /// </summary>
        public void AutoTag(string message, bool isAI)
        {
            if (string.IsNullOrWhiteSpace(message)) return;
            string lower = message.ToLowerInvariant();

            // Detect important events
            if (isAI)
            {
                if (lower.Contains("i agree") || lower.Contains("okay, i'll") || lower.Contains("sure, i"))
                    TagImportant("She agreed to a request");
                if (lower.Contains("i refuse") || lower.Contains("no way") || lower.Contains("absolutely not"))
                    TagImportant("She refused a request");
                if (lower.Contains("i love") || lower.Contains("te amo") || lower.Contains("i like you"))
                    TagImportant("She expressed affection");
            }
            else
            {
                if (lower.Contains("my name is") || lower.Contains("call me"))
                {
                    int idx = lower.IndexOf("my name is");
                    if (idx >= 0)
                    {
                        string after = message.Substring(idx + 10).Trim();
                        string name = after.Split(' ')[0].TrimEnd('.', ',', '!');
                        if (name.Length > 1 && name.Length < 20)
                            TagImportant($"Player's name: {name}");
                    }
                }
            }
        }

        /// <summary>
        /// Generates a compact memory block for injection into the system prompt.
        /// Target: ~200 tokens max.
        /// </summary>
        public string GenerateMemoryBlock()
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrEmpty(ShortTermSummary))
            {
                sb.AppendLine("[MEMORY]");
                sb.AppendLine(ShortTermSummary);
            }

            if (LongTermTags.Count > 0)
            {
                sb.Append("[FACTS] ");
                sb.AppendLine(string.Join(". ", LongTermTags));
            }

            if (TotalExchangeCount > 0)
                sb.AppendLine($"[TURNS] {TotalExchangeCount} exchanges so far.");

            return sb.ToString();
        }

        /// <summary>Persists memory to disk.</summary>
        public void Save()
        {
            if (string.IsNullOrEmpty(_savePath)) return;
            try
            {
                var sb = new StringBuilder();
                sb.AppendLine($"SUMMARY={ShortTermSummary}");
                sb.AppendLine($"TURNS={TotalExchangeCount}");
                foreach (var tag in LongTermTags)
                    sb.AppendLine($"TAG={tag}");
                System.IO.File.WriteAllText(_savePath, sb.ToString());
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"ConversationMemory save failed: {ex.Message}");
            }
        }

        /// <summary>Loads memory from disk if it exists.</summary>
        public void Load()
        {
            if (string.IsNullOrEmpty(_savePath) || !System.IO.File.Exists(_savePath)) return;
            try
            {
                var lines = System.IO.File.ReadAllLines(_savePath);
                LongTermTags.Clear();
                foreach (var line in lines)
                {
                    if (line.StartsWith("SUMMARY="))
                        ShortTermSummary = line.Substring(8);
                    else if (line.StartsWith("TURNS=") && int.TryParse(line.Substring(6), out int t))
                        TotalExchangeCount = t;
                    else if (line.StartsWith("TAG="))
                        LongTermTags.Add(line.Substring(4));
                }
                Plugin.Log.LogInfo($"ConversationMemory loaded: {TotalExchangeCount} turns, {LongTermTags.Count} tags.");
            }
            catch (Exception ex)
            {
                Plugin.Log.LogWarning($"ConversationMemory load failed: {ex.Message}");
            }
        }

        /// <summary>Clears all memory (called on character swap or manual clear).</summary>
        public void Clear()
        {
            ShortTermSummary = "";
            LongTermTags.Clear();
            TotalExchangeCount = 0;
        }
    }
}
