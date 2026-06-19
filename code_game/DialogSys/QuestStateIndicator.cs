using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000046 RID: 70
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questIndicator")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Quest Indicators/Quest State Indicator")]
	public class QuestStateIndicator : MonoBehaviour
	{
		// Token: 0x0600020C RID: 524 RVA: 0x0000AB8B File Offset: 0x00008D8B
		private void Awake()
		{
			this.InitializeCurrentIndicatorCount();
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0000AB93 File Offset: 0x00008D93
		private void Start()
		{
			this.UpdateIndicator();
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0000AB9C File Offset: 0x00008D9C
		private void InitializeCurrentIndicatorCount()
		{
			this.m_currentIndicatorCount.Clear();
			for (int i = 0; i < this.indicators.Length; i++)
			{
				this.m_currentIndicatorCount.Add(new List<QuestStateListener>());
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0000ABD8 File Offset: 0x00008DD8
		public void SetIndicatorLevel(QuestStateListener listener, int indicatorLevel)
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Dialogue System: ",
					base.name,
					": SetIndicatorLevel(",
					(listener != null) ? listener.ToString() : null,
					", ",
					indicatorLevel.ToString(),
					")"
				}), listener);
			}
			for (int i = 0; i < this.indicators.Length; i++)
			{
				if (this.m_currentIndicatorCount[i].Contains(listener))
				{
					this.m_currentIndicatorCount[i].Remove(listener);
					break;
				}
			}
			if (0 <= indicatorLevel && indicatorLevel < this.indicators.Length)
			{
				this.m_currentIndicatorCount[indicatorLevel].Add(listener);
			}
			this.UpdateIndicator();
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0000ACA4 File Offset: 0x00008EA4
		public void UpdateIndicator()
		{
			for (int i = 0; i < this.indicators.Length; i++)
			{
				if (this.indicators[i] != null)
				{
					this.indicators[i].SetActive(false);
				}
			}
			int j = this.indicators.Length - 1;
			while (j >= 0)
			{
				if (this.m_currentIndicatorCount[j].Count > 0)
				{
					if (!(this.indicators[j] != null))
					{
						break;
					}
					this.indicators[j].SetActive(true);
					if (DialogueDebug.LogInfo)
					{
						Debug.Log("Dialogue System: " + base.name + ": Activating GameObject associated with indicator level " + j.ToString(), this);
						return;
					}
					break;
				}
				else
				{
					j--;
				}
			}
		}

		// Token: 0x0400018E RID: 398
		[Tooltip("GameObject such as a world space canvas element associated with each indicator level. A typical use is to associate indicator level 0 = nothing (unassigned), level 1 = question mark, and level 2 = exclamation mark.")]
		public GameObject[] indicators = new GameObject[0];

		// Token: 0x0400018F RID: 399
		private List<List<QuestStateListener>> m_currentIndicatorCount = new List<List<QuestStateListener>>();
	}
}
