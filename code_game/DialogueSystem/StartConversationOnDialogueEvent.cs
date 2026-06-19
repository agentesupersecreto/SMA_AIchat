using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000295 RID: 661
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Start Conversation On Dialogue Event")]
	public class StartConversationOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BE1 RID: 7137 RVA: 0x00032C90 File Offset: 0x00030E90
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BE2 RID: 7138 RVA: 0x00032CA0 File Offset: 0x00030EA0
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BE3 RID: 7139 RVA: 0x00032CB0 File Offset: 0x00030EB0
		private void TryActions(StartConversationOnDialogueEvent.ConversationAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (StartConversationOnDialogueEvent.ConversationAction conversationAction in actions)
			{
				if (conversationAction != null && conversationAction.condition != null && conversationAction.condition.IsTrue(actor))
				{
					this.DoAction(conversationAction, actor);
				}
			}
		}

		// Token: 0x06001BE4 RID: 7140 RVA: 0x00032D08 File Offset: 0x00030F08
		public void DoAction(StartConversationOnDialogueEvent.ConversationAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.speaker, base.transform });
				Transform transform2 = Tools.Select(new Transform[] { action.listener, actor });
				if (!action.skipIfNoValidEntries || DialogueManager.ConversationHasValidEntry(action.conversation, transform, transform2))
				{
					DialogueManager.StartConversation(action.conversation, transform, transform2);
				}
			}
		}

		// Token: 0x04000FC2 RID: 4034
		public StartConversationOnDialogueEvent.ConversationAction[] onStart = new StartConversationOnDialogueEvent.ConversationAction[0];

		// Token: 0x04000FC3 RID: 4035
		public StartConversationOnDialogueEvent.ConversationAction[] onEnd = new StartConversationOnDialogueEvent.ConversationAction[0];

		// Token: 0x02000296 RID: 662
		[Serializable]
		public class ConversationAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FC4 RID: 4036
			public Transform speaker;

			// Token: 0x04000FC5 RID: 4037
			public Transform listener;

			// Token: 0x04000FC6 RID: 4038
			[ConversationPopup(false)]
			public string conversation;

			// Token: 0x04000FC7 RID: 4039
			public bool skipIfNoValidEntries;
		}
	}
}
