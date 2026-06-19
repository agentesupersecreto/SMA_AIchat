using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000047 RID: 71
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_log_window.html#questIndicator")]
	[AddComponentMenu("Dialogue System/Miscellaneous/Quest Indicators/Quest State Listener")]
	public class QuestStateListener : MonoBehaviour
	{
		// Token: 0x06000212 RID: 530 RVA: 0x0000AD74 File Offset: 0x00008F74
		private void Awake()
		{
			this.m_questStateDispatcher = Object.FindObjectOfType<QuestStateDispatcher>();
			this.m_questStateIndicator = base.GetComponent<QuestStateIndicator>();
			if (this.m_questStateDispatcher == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning("Dialogue System: " + base.name + ": Can't find a QuestStateDispatcher on the Dialogue Manager.", this);
				}
				base.enabled = false;
			}
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0000ADCF File Offset: 0x00008FCF
		private IEnumerator Start()
		{
			yield return null;
			if (base.enabled)
			{
				if (DialogueDebug.LogInfo)
				{
					Debug.Log(string.Concat(new string[] { "Dialogue System: ", base.name, ": Listening for state changes to quest '", this.questName, "'." }), this);
				}
				this.m_started = true;
				this.m_questStateDispatcher.AddListener(this);
				this.UpdateIndicator();
			}
			yield break;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0000ADDE File Offset: 0x00008FDE
		private void OnEnable()
		{
			if (this.m_started)
			{
				this.m_questStateDispatcher.AddListener(this);
			}
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0000ADF4 File Offset: 0x00008FF4
		private void OnDisable()
		{
			if (this.m_questStateDispatcher != null)
			{
				this.m_questStateDispatcher.RemoveListener(this);
			}
		}

		// Token: 0x06000216 RID: 534 RVA: 0x0000AE10 File Offset: 0x00009010
		public void OnChange()
		{
			this.UpdateIndicator();
		}

		// Token: 0x06000217 RID: 535 RVA: 0x0000AE18 File Offset: 0x00009018
		public void UpdateIndicator()
		{
			QuestState questState = QuestLog.GetQuestState(this.questName);
			for (int i = 0; i < this.questStateIndicatorLevels.Length; i++)
			{
				QuestStateListener.QuestStateIndicatorLevel questStateIndicatorLevel = this.questStateIndicatorLevels[i];
				if (questState == questStateIndicatorLevel.questState && questStateIndicatorLevel.condition.IsTrue(null))
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Concat(new string[]
						{
							"Dialogue System: ",
							base.name,
							": Quest '",
							this.questName,
							"' changed to state ",
							questState.ToString(),
							"."
						}), this);
					}
					if (this.m_questStateIndicator != null)
					{
						this.m_questStateIndicator.SetIndicatorLevel(this, questStateIndicatorLevel.indicatorLevel);
					}
					questStateIndicatorLevel.onEnterState.Invoke();
				}
			}
			for (int j = 0; j < this.questEntryStateIndicatorLevels.Length; j++)
			{
				QuestStateListener.QuestEntryStateIndicatorLevel questEntryStateIndicatorLevel = this.questEntryStateIndicatorLevels[j];
				QuestState questEntryState = QuestLog.GetQuestEntryState(this.questName, questEntryStateIndicatorLevel.entryNumber);
				if (questEntryState == questEntryStateIndicatorLevel.questState && questEntryStateIndicatorLevel.condition.IsTrue(null))
				{
					if (DialogueDebug.LogInfo)
					{
						Debug.Log(string.Concat(new string[]
						{
							"Dialogue System: ",
							base.name,
							": Quest '",
							this.questName,
							"' entry ",
							questEntryStateIndicatorLevel.entryNumber.ToString(),
							" changed to state ",
							questEntryState.ToString(),
							"."
						}), this);
					}
					if (this.m_questStateIndicator != null)
					{
						this.m_questStateIndicator.SetIndicatorLevel(this, questEntryStateIndicatorLevel.indicatorLevel);
					}
					questEntryStateIndicatorLevel.onEnterState.Invoke();
				}
			}
		}

		// Token: 0x04000190 RID: 400
		[QuestPopup(true)]
		public string questName;

		// Token: 0x04000191 RID: 401
		public QuestStateListener.QuestStateIndicatorLevel[] questStateIndicatorLevels = new QuestStateListener.QuestStateIndicatorLevel[0];

		// Token: 0x04000192 RID: 402
		public QuestStateListener.QuestEntryStateIndicatorLevel[] questEntryStateIndicatorLevels = new QuestStateListener.QuestEntryStateIndicatorLevel[0];

		// Token: 0x04000193 RID: 403
		private QuestStateDispatcher m_questStateDispatcher;

		// Token: 0x04000194 RID: 404
		private QuestStateIndicator m_questStateIndicator;

		// Token: 0x04000195 RID: 405
		private bool m_started;

		// Token: 0x0200008A RID: 138
		[Serializable]
		public class QuestStateIndicatorLevel
		{
			// Token: 0x040002C7 RID: 711
			[Tooltip("Quest state to listen for.")]
			public QuestState questState;

			// Token: 0x040002C8 RID: 712
			[Tooltip("Conditions that must also be true.")]
			public Condition condition;

			// Token: 0x040002C9 RID: 713
			[Tooltip("Indicator level to use when this quest state is reached.")]
			public int indicatorLevel;

			// Token: 0x040002CA RID: 714
			public UnityEvent onEnterState = new UnityEvent();
		}

		// Token: 0x0200008B RID: 139
		[Serializable]
		public class QuestEntryStateIndicatorLevel
		{
			// Token: 0x040002CB RID: 715
			[Tooltip("Quest entry number.")]
			public int entryNumber;

			// Token: 0x040002CC RID: 716
			[Tooltip("Quest entry state to listen for.")]
			public QuestState questState;

			// Token: 0x040002CD RID: 717
			[Tooltip("Conditions that must also be true.")]
			public Condition condition;

			// Token: 0x040002CE RID: 718
			[Tooltip("Indicator level to use when this quest state is reached.")]
			public int indicatorLevel;

			// Token: 0x040002CF RID: 719
			public UnityEvent onEnterState = new UnityEvent();
		}
	}
}
