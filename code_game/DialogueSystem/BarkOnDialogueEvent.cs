using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000281 RID: 641
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Bark On Dialogue Event")]
	public class BarkOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x06001BA0 RID: 7072 RVA: 0x0003210C File Offset: 0x0003030C
		// (set) Token: 0x06001BA1 RID: 7073 RVA: 0x00032114 File Offset: 0x00030314
		public Sequencer sequencer { get; private set; }

		// Token: 0x06001BA2 RID: 7074 RVA: 0x00032120 File Offset: 0x00030320
		private void Awake()
		{
			this.barkHistory = new BarkHistory(this.barkOrder);
			this.sequencer = null;
		}

		// Token: 0x06001BA3 RID: 7075 RVA: 0x0003213C File Offset: 0x0003033C
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BA4 RID: 7076 RVA: 0x0003214C File Offset: 0x0003034C
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BA5 RID: 7077 RVA: 0x0003215C File Offset: 0x0003035C
		private void TryActions(BarkOnDialogueEvent.BarkAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (BarkOnDialogueEvent.BarkAction barkAction in actions)
			{
				if (barkAction != null && barkAction.condition != null && barkAction.condition.IsTrue(actor))
				{
					this.DoAction(barkAction, actor);
				}
			}
		}

		// Token: 0x06001BA6 RID: 7078 RVA: 0x000321B4 File Offset: 0x000303B4
		public void DoAction(BarkOnDialogueEvent.BarkAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.speaker, base.transform });
				Transform transform2 = Tools.Select(new Transform[] { action.listener, actor });
				DialogueManager.Bark(action.conversation, transform, transform2, this.barkHistory);
				this.sequencer = BarkController.LastSequencer;
			}
		}

		// Token: 0x04000F8D RID: 3981
		public BarkOnDialogueEvent.BarkAction[] onStart = new BarkOnDialogueEvent.BarkAction[0];

		// Token: 0x04000F8E RID: 3982
		public BarkOnDialogueEvent.BarkAction[] onEnd = new BarkOnDialogueEvent.BarkAction[0];

		// Token: 0x04000F8F RID: 3983
		[Tooltip("The order in which to bark dialogue entries.")]
		public BarkOrder barkOrder;

		// Token: 0x04000F90 RID: 3984
		private BarkHistory barkHistory;

		// Token: 0x02000282 RID: 642
		[Serializable]
		public class BarkAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000F92 RID: 3986
			public Transform speaker;

			// Token: 0x04000F93 RID: 3987
			public Transform listener;

			// Token: 0x04000F94 RID: 3988
			[ConversationPopup(false)]
			public string conversation;
		}
	}
}
