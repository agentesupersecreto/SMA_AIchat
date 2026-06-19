using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000241 RID: 577
	[AddComponentMenu("")]
	public class SequencerCommandLookAt : SequencerCommand
	{
		// Token: 0x060019D6 RID: 6614 RVA: 0x0002A94C File Offset: 0x00028B4C
		public void Start()
		{
			this.target = base.GetSubject(0, base.Sequencer.Listener);
			this.subject = base.GetSubject(1, null);
			this.duration = base.GetParameterAsFloat(2, 0f);
			bool flag = string.Compare(base.GetParameter(3, null), "allAxes", StringComparison.OrdinalIgnoreCase) != 0;
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: LookAt({1}, {2}, {3})", new object[] { "Dialogue System", this.target, this.subject, this.duration }));
			}
			if (this.target == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Target '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(0, null)
				}));
			}
			if (this.subject == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Subject '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(1, null)
				}));
			}
			if (this.subject != null && this.target != null && this.subject != this.target)
			{
				if (this.duration > 0.05f)
				{
					this.startTime = DialogueTime.time;
					this.endTime = this.startTime + this.duration;
					this.originalRotation = this.subject.rotation;
					this.targetPosition = ((!flag) ? this.target.position : new Vector3(this.target.position.x, this.subject.position.y, this.target.position.z));
					this.targetRotation = Quaternion.LookRotation(this.targetPosition - this.subject.position, Vector3.up);
				}
				else
				{
					base.Stop();
				}
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019D7 RID: 6615 RVA: 0x0002AB88 File Offset: 0x00028D88
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				this.subject.rotation = Quaternion.Lerp(this.originalRotation, this.targetRotation, num);
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019D8 RID: 6616 RVA: 0x0002ABE4 File Offset: 0x00028DE4
		public void OnDestroy()
		{
			if (this.subject != null && this.target != null)
			{
				this.subject.LookAt(this.targetPosition);
			}
		}

		// Token: 0x04000E67 RID: 3687
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E68 RID: 3688
		private Transform target;

		// Token: 0x04000E69 RID: 3689
		private Transform subject;

		// Token: 0x04000E6A RID: 3690
		private float duration;

		// Token: 0x04000E6B RID: 3691
		private float startTime;

		// Token: 0x04000E6C RID: 3692
		private float endTime;

		// Token: 0x04000E6D RID: 3693
		private Quaternion originalRotation;

		// Token: 0x04000E6E RID: 3694
		private Quaternion targetRotation;

		// Token: 0x04000E6F RID: 3695
		private Vector3 targetPosition;
	}
}
