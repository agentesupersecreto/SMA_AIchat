using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023A RID: 570
	[AddComponentMenu("")]
	public class SequencerCommandAnimatorLayer : SequencerCommand
	{
		// Token: 0x060019B8 RID: 6584 RVA: 0x000295E4 File Offset: 0x000277E4
		public void Start()
		{
			this.layerIndex = base.GetParameterAsInt(0, 1);
			this.weight = base.GetParameterAsFloat(1, 1f);
			this.subject = base.GetSubject(2, null);
			this.duration = base.GetParameterAsFloat(3, 0f);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorLayer({1}, {2}, {3}, {4})", new object[] { "Dialogue System", this.layerIndex, this.weight, this.subject, this.duration }));
			}
			if (this.subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorLayer(): subject '{1}' wasn't found.", new object[]
					{
						"Dialogue System",
						base.GetParameter(2, null)
					}));
				}
				base.Stop();
			}
			else
			{
				this.animator = this.subject.GetComponentInChildren<Animator>();
				if (this.animator == null)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorLayer(): no Animator found on '{1}'.", new object[]
						{
							"Dialogue System",
							this.subject.name
						}));
					}
					base.Stop();
				}
				else if (this.layerIndex < 1 || this.layerIndex >= this.animator.layerCount)
				{
					if (DialogueDebug.LogWarnings)
					{
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorLayer(): layer index {1} is invalid.", new object[] { "Dialogue System", this.layerIndex }));
					}
					base.Stop();
				}
				else if (this.duration < 0.05f)
				{
					base.Stop();
				}
				else
				{
					this.startTime = DialogueTime.time;
					this.endTime = this.startTime + this.duration;
					this.originalWeight = this.animator.GetLayerWeight(this.layerIndex);
				}
			}
		}

		// Token: 0x060019B9 RID: 6585 RVA: 0x000297F0 File Offset: 0x000279F0
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				float num2 = Mathf.Lerp(this.originalWeight, this.weight, num / this.duration);
				if (this.animator != null)
				{
					this.animator.SetLayerWeight(this.layerIndex, num2);
				}
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x0002986C File Offset: 0x00027A6C
		public void OnDestroy()
		{
			if (this.animator != null && 0 < this.layerIndex && this.layerIndex < this.animator.layerCount)
			{
				this.animator.SetLayerWeight(this.layerIndex, this.weight);
			}
		}

		// Token: 0x04000E34 RID: 3636
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E35 RID: 3637
		private int layerIndex = 1;

		// Token: 0x04000E36 RID: 3638
		private float weight;

		// Token: 0x04000E37 RID: 3639
		private Transform subject;

		// Token: 0x04000E38 RID: 3640
		private float duration;

		// Token: 0x04000E39 RID: 3641
		private Animator animator;

		// Token: 0x04000E3A RID: 3642
		private float startTime;

		// Token: 0x04000E3B RID: 3643
		private float endTime;

		// Token: 0x04000E3C RID: 3644
		private float originalWeight;
	}
}
