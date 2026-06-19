using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000297 RID: 663
	[AddComponentMenu("Dialogue System/Trigger/On Dialogue Event/Start Sequence On Dialogue Event")]
	public class StartSequenceOnDialogueEvent : ActOnDialogueEvent
	{
		// Token: 0x06001BE7 RID: 7143 RVA: 0x00032DAC File Offset: 0x00030FAC
		public override void TryStartActions(Transform actor)
		{
			this.TryActions(this.onStart, actor);
		}

		// Token: 0x06001BE8 RID: 7144 RVA: 0x00032DBC File Offset: 0x00030FBC
		public override void TryEndActions(Transform actor)
		{
			this.TryActions(this.onEnd, actor);
		}

		// Token: 0x06001BE9 RID: 7145 RVA: 0x00032DCC File Offset: 0x00030FCC
		private void TryActions(StartSequenceOnDialogueEvent.SequenceAction[] actions, Transform actor)
		{
			if (actions == null)
			{
				return;
			}
			foreach (StartSequenceOnDialogueEvent.SequenceAction sequenceAction in actions)
			{
				if (sequenceAction != null && sequenceAction.condition != null && sequenceAction.condition.IsTrue(actor))
				{
					this.DoAction(sequenceAction, actor);
				}
			}
		}

		// Token: 0x06001BEA RID: 7146 RVA: 0x00032E24 File Offset: 0x00031024
		public void DoAction(StartSequenceOnDialogueEvent.SequenceAction action, Transform actor)
		{
			if (action != null)
			{
				Transform transform = Tools.Select(new Transform[] { action.actor, base.transform });
				Transform transform2 = Tools.Select(new Transform[] { action.otherParticipant, actor });
				DialogueManager.PlaySequence(action.sequence, transform, transform2);
			}
		}

		// Token: 0x04000FC8 RID: 4040
		public StartSequenceOnDialogueEvent.SequenceAction[] onStart = new StartSequenceOnDialogueEvent.SequenceAction[0];

		// Token: 0x04000FC9 RID: 4041
		public StartSequenceOnDialogueEvent.SequenceAction[] onEnd = new StartSequenceOnDialogueEvent.SequenceAction[0];

		// Token: 0x02000298 RID: 664
		[Serializable]
		public class SequenceAction : ActOnDialogueEvent.Action
		{
			// Token: 0x04000FCA RID: 4042
			public Transform actor;

			// Token: 0x04000FCB RID: 4043
			public Transform otherParticipant;

			// Token: 0x04000FCC RID: 4044
			[Multiline]
			public string sequence;
		}
	}
}
