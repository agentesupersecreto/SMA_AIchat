using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000045 RID: 69
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questIndicator")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Quest Indicators/Quest State Dispatcher (on Dialogue Manager)")]
	public class QuestStateDispatcher : MonoBehaviour
	{
		// Token: 0x06000208 RID: 520 RVA: 0x0000AB0C File Offset: 0x00008D0C
		public void AddListener(QuestStateListener listener)
		{
			if (listener == null)
			{
				return;
			}
			this.m_listeners.Add(listener);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0000AB24 File Offset: 0x00008D24
		public void RemoveListener(QuestStateListener listener)
		{
			this.m_listeners.Remove(listener);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0000AB34 File Offset: 0x00008D34
		public void OnQuestStateChange(string questName)
		{
			for (int i = 0; i < this.m_listeners.Count; i++)
			{
				QuestStateListener questStateListener = this.m_listeners[i];
				if (string.Equals(questName, questStateListener.questName))
				{
					questStateListener.OnChange();
				}
			}
		}

		// Token: 0x0400018D RID: 397
		private List<QuestStateListener> m_listeners = new List<QuestStateListener>();
	}
}
