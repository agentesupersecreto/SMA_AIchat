using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A7 RID: 679
	[AddComponentMenu("Dialogue System/Trigger/Quest Trigger")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/quest_trigger.html")]
	public class QuestTrigger : DialogueEventStarter
	{
		// Token: 0x06001C9C RID: 7324 RVA: 0x00035784 File Offset: 0x00033984
		public void OnBarkEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnBarkEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C9D RID: 7325 RVA: 0x000357A4 File Offset: 0x000339A4
		public void OnConversationEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnConversationEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C9E RID: 7326 RVA: 0x000357C4 File Offset: 0x000339C4
		public void OnSequenceEnd(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnSequenceEnd)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001C9F RID: 7327 RVA: 0x000357E4 File Offset: 0x000339E4
		public void OnUse(Transform actor)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(actor);
			}
		}

		// Token: 0x06001CA0 RID: 7328 RVA: 0x00035808 File Offset: 0x00033A08
		public void OnUse(string message)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001CA1 RID: 7329 RVA: 0x0003582C File Offset: 0x00033A2C
		public void OnUse()
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnUse)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001CA2 RID: 7330 RVA: 0x00035850 File Offset: 0x00033A50
		public void OnTriggerEnter(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x00035878 File Offset: 0x00033A78
		public void OnTriggerEnter2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x000358A0 File Offset: 0x00033AA0
		public void OnTriggerExit(Collider other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x000358CC File Offset: 0x00033ACC
		public void OnTriggerExit2D(Collider2D other)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(other.transform);
			}
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x000358F8 File Offset: 0x00033AF8
		public void OnCollisionEnter(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnCollisionEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00035934 File Offset: 0x00033B34
		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x0003596C File Offset: 0x00033B6C
		public void OnCollisionExit(Collision collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001CA9 RID: 7337 RVA: 0x000359A8 File Offset: 0x00033BA8
		public void OnCollisionExit2D(Collision2D collision)
		{
			if (base.enabled && this.trigger == DialogueTriggerEvent.OnTriggerExit)
			{
				this.TryStart(collision.collider.transform);
			}
		}

		// Token: 0x06001CAA RID: 7338 RVA: 0x000359E4 File Offset: 0x00033BE4
		public void Start()
		{
			if (this.trigger == DialogueTriggerEvent.OnStart)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001CAB RID: 7339 RVA: 0x00035A00 File Offset: 0x00033C00
		public void OnEnable()
		{
			this.listenForOnDestroy = true;
			if (this.trigger == DialogueTriggerEvent.OnEnable)
			{
				base.StartCoroutine(this.StartAfterOneFrame());
			}
		}

		// Token: 0x06001CAC RID: 7340 RVA: 0x00035A24 File Offset: 0x00033C24
		public void OnDisable()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDisable)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001CAD RID: 7341 RVA: 0x00035A54 File Offset: 0x00033C54
		public void OnLevelWillBeUnloaded()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001CAE RID: 7342 RVA: 0x00035A60 File Offset: 0x00033C60
		public void OnApplicationQuit()
		{
			this.listenForOnDestroy = false;
		}

		// Token: 0x06001CAF RID: 7343 RVA: 0x00035A6C File Offset: 0x00033C6C
		public void OnDestroy()
		{
			if (this.listenForOnDestroy && this.trigger == DialogueTriggerEvent.OnDestroy)
			{
				this.TryStart(null);
			}
		}

		// Token: 0x06001CB0 RID: 7344 RVA: 0x00035A9C File Offset: 0x00033C9C
		private IEnumerator StartAfterOneFrame()
		{
			yield return null;
			this.TryStart(null);
			yield break;
		}

		// Token: 0x06001CB1 RID: 7345 RVA: 0x00035AB8 File Offset: 0x00033CB8
		public void TryStart(Transform actor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if ((this.condition == null || this.condition.IsTrue(actor)) && !string.IsNullOrEmpty(this.questName))
				{
					this.Fire();
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x06001CB2 RID: 7346 RVA: 0x00035B34 File Offset: 0x00033D34
		public void Fire()
		{
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Setting quest '{1}' state to '{2}'", new object[]
				{
					"Dialogue System",
					this.questName,
					QuestLog.StateToString(this.questState)
				}));
			}
			if (!string.IsNullOrEmpty(this.questName))
			{
				if (this.setQuestState)
				{
					QuestLog.SetQuestState(this.questName, this.questState);
				}
				if (this.setQuestEntryState)
				{
					QuestLog.SetQuestEntryState(this.questName, this.questEntryNumber, this.questEntryState);
				}
			}
			if (!string.IsNullOrEmpty(this.luaCode))
			{
				Lua.Run(this.luaCode, DialogueDebug.LogInfo);
			}
			if (!string.IsNullOrEmpty(this.alertMessage))
			{
				string text = this.alertMessage;
				if (this.localizedTextTable != null && this.localizedTextTable.ContainsField(this.alertMessage))
				{
					text = this.localizedTextTable[this.alertMessage];
				}
				DialogueManager.ShowAlert(text);
			}
			foreach (QuestTrigger.SendMessageAction sendMessageAction in this.sendMessages)
			{
				if (sendMessageAction.gameObject != null && !string.IsNullOrEmpty(sendMessageAction.message))
				{
					sendMessageAction.gameObject.SendMessage(sendMessageAction.message, sendMessageAction.parameter, SendMessageOptions.DontRequireReceiver);
				}
			}
			DialogueManager.SendUpdateTracker();
			base.DestroyIfOnce();
		}

		// Token: 0x04001042 RID: 4162
		[DialogueTriggerEvent]
		public DialogueTriggerEvent trigger = DialogueTriggerEvent.OnUse;

		// Token: 0x04001043 RID: 4163
		public Condition condition;

		// Token: 0x04001044 RID: 4164
		public string questName;

		// Token: 0x04001045 RID: 4165
		[Tooltip("Set the main state of the quest.")]
		public bool setQuestState = true;

		// Token: 0x04001046 RID: 4166
		[QuestState]
		public QuestState questState;

		// Token: 0x04001047 RID: 4167
		[Tooltip("Set the state of a quest entry (subtask) in the quest.")]
		public bool setQuestEntryState;

		// Token: 0x04001048 RID: 4168
		[Tooltip("Quest entry number whose state to change.")]
		public int questEntryNumber = 1;

		// Token: 0x04001049 RID: 4169
		[QuestState]
		public QuestState questEntryState;

		// Token: 0x0400104A RID: 4170
		[Tooltip("(Optional) Run this Lua code after setting the quest state.")]
		public string luaCode = string.Empty;

		// Token: 0x0400104B RID: 4171
		[Tooltip("(Optional) Show this alert message after setting the quest state.")]
		public string alertMessage;

		// Token: 0x0400104C RID: 4172
		[Tooltip("Localized text table to use for the alert message.")]
		public LocalizedTextTable localizedTextTable;

		// Token: 0x0400104D RID: 4173
		public QuestTrigger.SendMessageAction[] sendMessages = new QuestTrigger.SendMessageAction[0];

		// Token: 0x0400104E RID: 4174
		[HideInInspector]
		public bool useQuestNamePicker = true;

		// Token: 0x0400104F RID: 4175
		[HideInInspector]
		public DialogueDatabase selectedDatabase;

		// Token: 0x04001050 RID: 4176
		private bool tryingToStart;

		// Token: 0x04001051 RID: 4177
		private bool listenForOnDestroy;

		// Token: 0x020002A8 RID: 680
		[Serializable]
		public class SendMessageAction
		{
			// Token: 0x04001052 RID: 4178
			public GameObject gameObject;

			// Token: 0x04001053 RID: 4179
			public string message = "OnUse";

			// Token: 0x04001054 RID: 4180
			public string parameter = string.Empty;
		}
	}
}
