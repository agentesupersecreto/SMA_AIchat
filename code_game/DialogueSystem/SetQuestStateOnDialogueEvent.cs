using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000292 RID: 658
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Set Quest State On Dialogue Event")]
	public class SetQuestStateOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BD7 RID: 7127 RVA: 0x00032B40 File Offset: 0x00030D40
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BD8 RID: 7128 RVA: 0x00032B50 File Offset: 0x00030D50
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BD9 RID: 7129 RVA: 0x00032B60 File Offset: 0x00030D60
		private void TryActions(SetQuestStateOnDialogueEvent.SetQuestStateAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (SetQuestStateOnDialogueEvent.SetQuestStateAction setQuestStateAction in actions)
			{
				if (setQuestStateAction != null && setQuestStateAction.condition != null && setQuestStateAction.condition.IsTrue(actor))
				{
					this.DoAction(setQuestStateAction, actor);
				}
			}
		}

		// Token: 0x06001BDA RID: 7130 RVA: 0x00032BB8 File Offset: 0x00030DB8
		public void DoAction(SetQuestStateOnDialogueEvent.SetQuestStateAction action, Transform actor)
		{
			if (action != null && !string.IsNullOrEmpty(action.questName))
			{
				QuestLog.SetQuestState(action.questName, action.questState);
				if (!string.IsNullOrEmpty(action.alertMessage))
				{
					DialogueManager.ShowAlert(action.alertMessage);
				}
				DialogueManager.SendUpdateTracker();
			}
		}

		// Token: 0x04000FBB RID: 4027
		public SetQuestStateOnDialogueEvent.SetQuestStateAction[] onStart = new SetQuestStateOnDialogueEvent.SetQuestStateAction[0];

		// Token: 0x04000FBC RID: 4028
		public SetQuestStateOnDialogueEvent.SetQuestStateAction[] onEnd = new SetQuestStateOnDialogueEvent.SetQuestStateAction[0];

		// Token: 0x02000293 RID: 659
		[Serializable]
		public class SetQuestStateAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FBD RID: 4029
			[QuestPopup(false)]
			public string questName;

			// Token: 0x04000FBE RID: 4030
			[QuestState]
			public QuestState questState;

			// Token: 0x04000FBF RID: 4031
			public string alertMessage;
		}
	}
}
