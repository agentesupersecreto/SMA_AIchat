using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000239 RID: 569
	[AddComponentMenu("")]
	public class SequencerCommandAnimatorFloat : SequencerCommand
	{
		// Token: 0x060019B4 RID: 6580 RVA: 0x0002937C File Offset: 0x0002757C
		public void Start()
		{
			string parameter = base.GetParameter(0, null);
			this.animatorParameterHash = Animator.StringToHash(parameter);
			this.targetValue = base.GetParameterAsFloat(1, 1f);
			this.subject = base.GetSubject(2, null);
			this.duration = base.GetParameterAsFloat(3, 0f);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: AnimatorFloat({1}, {2}, {3}, {4})", new object[] { "Dialogue System", parameter, this.targetValue, this.subject, this.duration }));
			}
			if (this.subject == null)
			{
				if (DialogueDebug.LogWarnings)
				{
					Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorFloat(): subject '{1}' wasn't found.", new object[]
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
						Debug.LogWarning(string.Format("{0}: Sequencer: AnimatorFloat(): no Animator found on '{1}'.", new object[]
						{
							"Dialogue System",
							this.subject.name
						}));
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
					this.originalValue = this.animator.GetFloat(this.animatorParameterHash);
				}
			}
		}

		// Token: 0x060019B5 RID: 6581 RVA: 0x00029520 File Offset: 0x00027720
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				float num2 = Mathf.Lerp(this.originalValue, this.targetValue, num / this.duration);
				if (this.animator != null)
				{
					this.animator.SetFloat(this.animatorParameterHash, num2);
				}
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019B6 RID: 6582 RVA: 0x0002959C File Offset: 0x0002779C
		public void OnDestroy()
		{
			if (this.animator != null)
			{
				this.animator.SetFloat(this.animatorParameterHash, this.targetValue);
			}
		}

		// Token: 0x04000E2B RID: 3627
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E2C RID: 3628
		private int animatorParameterHash = -1;

		// Token: 0x04000E2D RID: 3629
		private float targetValue;

		// Token: 0x04000E2E RID: 3630
		private Transform subject;

		// Token: 0x04000E2F RID: 3631
		private float duration;

		// Token: 0x04000E30 RID: 3632
		private Animator animator;

		// Token: 0x04000E31 RID: 3633
		private float startTime;

		// Token: 0x04000E32 RID: 3634
		private float endTime;

		// Token: 0x04000E33 RID: 3635
		private float originalValue;
	}
}
