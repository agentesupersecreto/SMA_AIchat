using System;
using System.Collections.Generic;
using UnityEngine;

namespace DialogInterceptorMod.Core
{
    /// <summary>
    /// Filters event/command spam in the chat window.
    /// Provides cooldown between system messages, deduplication, and
    /// grouping of similar emotion changes into single messages.
    /// Configurable via settings panel.
    /// </summary>
    public class SpamFilter
    {
        /// <summary>Whether the filter is active.</summary>
        public bool Enabled { get; set; } = true;

        /// <summary>Minimum seconds between system messages.</summary>
        public float CooldownSeconds { get; set; } = 1.5f;

        /// <summary>Window in seconds for dedup of identical messages.</summary>
        public float DedupWindowSeconds { get; set; } = 10f;

        private float _lastSystemMessageTime;
        private readonly Queue<TimedMessage> _recentMessages = new Queue<TimedMessage>();
        private readonly List<string> _pendingBatch = new List<string>();
        private float _batchStartTime;

        /// <summary>
        /// Check if a system message should be displayed or filtered.
        /// Returns true if the message should be shown.
        /// </summary>
        public bool ShouldShow(string message)
        {
            if (!Enabled) return true;
            if (string.IsNullOrWhiteSpace(message)) return false;

            float now = Time.time;

            // Clean old entries from dedup window
            while (_recentMessages.Count > 0 && now - _recentMessages.Peek().Time > DedupWindowSeconds)
                _recentMessages.Dequeue();

            // Check for duplicates
            foreach (var recent in _recentMessages)
            {
                if (string.Equals(recent.Message, message, StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            // Check cooldown
            if (now - _lastSystemMessageTime < CooldownSeconds)
            {
                // Batch it instead of dropping
                _pendingBatch.Add(message);
                if (_batchStartTime == 0f) _batchStartTime = now;
                return false;
            }

            // Show it
            _lastSystemMessageTime = now;
            _recentMessages.Enqueue(new TimedMessage(message, now));
            return true;
        }

        /// <summary>
        /// Returns a batched message if enough time has passed and there are pending items.
        /// Call this periodically (e.g., in Update). Returns null if nothing to flush.
        /// </summary>
        public string FlushBatch()
        {
            if (!Enabled || _pendingBatch.Count == 0) return null;

            float now = Time.time;
            if (now - _batchStartTime < CooldownSeconds) return null;

            string combined;
            if (_pendingBatch.Count == 1)
            {
                combined = _pendingBatch[0];
            }
            else
            {
                combined = $"⚡ ({_pendingBatch.Count} events) {string.Join(" | ", _pendingBatch)}";
            }

            _pendingBatch.Clear();
            _batchStartTime = 0f;
            _lastSystemMessageTime = now;
            _recentMessages.Enqueue(new TimedMessage(combined, now));

            return combined;
        }

        private struct TimedMessage
        {
            public string Message;
            public float Time;
            public TimedMessage(string msg, float time) { Message = msg; Time = time; }
        }
    }
}
