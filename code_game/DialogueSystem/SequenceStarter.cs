using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A9 RID: 681
	[AddComponentMenu("")]
	public abstract class SequenceStarter : DialogueEventStarter
	{
		// Token: 0x06001CB5 RID: 7349 RVA: 0x00035CD0 File Offset: 0x00033ED0
		public void TryStartSequence(Transform actor)
		{
			this.TryStartSequence(actor, actor);
		}

		// Token: 0x06001CB6 RID: 7350 RVA: 0x00035CDC File Offset: 0x00033EDC
		public void TryStartSequence(Transform actor, Transform interactor)
		{
			if (this.tryingToStart)
			{
				return;
			}
			this.tryingToStart = true;
			try
			{
				if ((this.condition == null || this.condition.IsTrue(interactor)) && !string.IsNullOrEmpty(this.sequence))
				{
					DialogueManager.PlaySequence(this.sequence, Tools.Select(new Transform[] { this.speaker, base.transform }), Tools.Select(new Transform[] { this.listener, actor }));
					base.DestroyIfOnce();
				}
			}
			finally
			{
				this.tryingToStart = false;
			}
		}

		// Token: 0x04001055 RID: 4181
		[Tooltip("The sequence to play.")]
		[TextArea(1, 20)]
		public string sequence;

		// Token: 0x04001056 RID: 4182
		[Tooltip("Speaker to use for the sequence (leave unassigned if no speaker is needed). Sequencer commands can reference 'speaker' and 'listener', so you may need to define them here.")]
		public Transform speaker;

		// Token: 0x04001057 RID: 4183
		[Tooltip("Listener to use for the sequence (leave unassigned if no listener is needed). Sequencer commands can reference 'speaker' and 'listener', so you may need to define them here.")]
		public Transform listener;

		// Token: 0x04001058 RID: 4184
		public Condition condition;

		// Token: 0x04001059 RID: 4185
		private bool tryingToStart;
	}
}
