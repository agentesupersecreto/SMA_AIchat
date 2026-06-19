using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200029E RID: 670
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/condition_observer.html")]
	[AddComponentMenu("Dialogue System/Trigger/Condition Observer")]
	public class ConditionObserver : MonoBehaviour
	{
		// Token: 0x06001C36 RID: 7222 RVA: 0x00033EA0 File Offset: 0x000320A0
		private void Start()
		{
			this.started = true;
			this.StartObserving();
		}

		// Token: 0x06001C37 RID: 7223 RVA: 0x00033EB0 File Offset: 0x000320B0
		private void OnEnable()
		{
			if (this.started)
			{
				this.StartObserving();
			}
		}

		// Token: 0x06001C38 RID: 7224 RVA: 0x00033EC4 File Offset: 0x000320C4
		private void OnDisable()
		{
			this.StopObserving();
		}

		// Token: 0x06001C39 RID: 7225 RVA: 0x00033ECC File Offset: 0x000320CC
		private void StartObserving()
		{
			this.StopObserving();
			base.StartCoroutine(this.Observe());
		}

		// Token: 0x06001C3A RID: 7226 RVA: 0x00033EE4 File Offset: 0x000320E4
		private void StopObserving()
		{
			base.StopAllCoroutines();
		}

		// Token: 0x06001C3B RID: 7227 RVA: 0x00033EEC File Offset: 0x000320EC
		private IEnumerator Observe()
		{
			yield return new WaitForSeconds(Random.value);
			for (;;)
			{
				this.Check();
				yield return new WaitForSeconds(this.frequency);
			}
			yield break;
		}

		// Token: 0x06001C3C RID: 7228 RVA: 0x00033F08 File Offset: 0x00032108
		public void Check()
		{
			Transform transform = ((!(this.observeGameObject == null)) ? this.observeGameObject.transform : null);
			if (this.condition.IsTrue(transform))
			{
				this.Fire();
			}
		}

		// Token: 0x06001C3D RID: 7229 RVA: 0x00033F50 File Offset: 0x00032150
		public void Check(GameObject gameObject)
		{
			this.observeGameObject = gameObject;
			this.Check();
		}

		// Token: 0x06001C3E RID: 7230 RVA: 0x00033F60 File Offset: 0x00032160
		public void Check(string gameObjectName)
		{
			GameObject gameObject = Tools.GameObjectHardFind(gameObjectName);
			if (gameObject != null)
			{
				this.observeGameObject = gameObject;
			}
			this.Check();
		}

		// Token: 0x06001C3F RID: 7231 RVA: 0x00033F90 File Offset: 0x00032190
		public void Fire()
		{
			if (!string.IsNullOrEmpty(this.questName))
			{
				QuestLog.SetQuestState(this.questName, this.questState);
			}
			if (!string.IsNullOrEmpty(this.luaCode))
			{
				Lua.Run(this.luaCode, DialogueDebug.LogInfo);
				DialogueManager.CheckAlerts();
			}
			if (!string.IsNullOrEmpty(this.sequence))
			{
				DialogueManager.PlaySequence(this.sequence);
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
			foreach (ConditionObserver.SendMessageAction sendMessageAction in this.sendMessages)
			{
				if (sendMessageAction.gameObject != null && !string.IsNullOrEmpty(sendMessageAction.message))
				{
					sendMessageAction.gameObject.SendMessage(sendMessageAction.message, sendMessageAction.parameter, SendMessageOptions.DontRequireReceiver);
				}
			}
			DialogueManager.SendUpdateTracker();
			if (this.once)
			{
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x04000FE5 RID: 4069
		[Tooltip("Frequency in seconds between checks.")]
		public float frequency = 1f;

		// Token: 0x04000FE6 RID: 4070
		[Tooltip("Destroy this component after the condition is true.")]
		public bool once;

		// Token: 0x04000FE7 RID: 4071
		[Tooltip("Refer to this GameObject when evaluating the Condition.")]
		public GameObject observeGameObject;

		// Token: 0x04000FE8 RID: 4072
		public Condition condition = new Condition();

		// Token: 0x04000FE9 RID: 4073
		[Tooltip("Set this quest's state when the condition is true.")]
		public string questName = string.Empty;

		// Token: 0x04000FEA RID: 4074
		[Tooltip("Set the quest to this state when the condition is true.")]
		[QuestState]
		public QuestState questState;

		// Token: 0x04000FEB RID: 4075
		[Tooltip("Run this Lua code when the condition is true. Leave blank to skip.")]
		public string luaCode = string.Empty;

		// Token: 0x04000FEC RID: 4076
		[Tooltip("Play this sequence when the condition is true. Leave blank to skip.")]
		public string sequence = string.Empty;

		// Token: 0x04000FED RID: 4077
		[Tooltip("Show this alert message when the condition is true. Leave blank to skip.")]
		public string alertMessage = string.Empty;

		// Token: 0x04000FEE RID: 4078
		[Tooltip("Localized text table to use for the alert message.")]
		public LocalizedTextTable localizedTextTable;

		// Token: 0x04000FEF RID: 4079
		public ConditionObserver.SendMessageAction[] sendMessages = new ConditionObserver.SendMessageAction[0];

		// Token: 0x04000FF0 RID: 4080
		[HideInInspector]
		public bool useQuestNamePicker = true;

		// Token: 0x04000FF1 RID: 4081
		private bool started;

		// Token: 0x0200029F RID: 671
		[Serializable]
		public class SendMessageAction
		{
			// Token: 0x04000FF2 RID: 4082
			public GameObject gameObject;

			// Token: 0x04000FF3 RID: 4083
			public string message = "OnUse";

			// Token: 0x04000FF4 RID: 4084
			public string parameter = string.Empty;
		}
	}
}
