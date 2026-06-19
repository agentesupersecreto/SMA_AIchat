using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000242 RID: 578
	[AddComponentMenu("")]
	public class SequencerCommandMoveTo : SequencerCommand
	{
		// Token: 0x060019DA RID: 6618 RVA: 0x0002AC24 File Offset: 0x00028E24
		public void Start()
		{
			this.target = base.GetSubject(0, null);
			this.subject = base.GetSubject(1, null);
			this.duration = base.GetParameterAsFloat(2, 0f);
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: MoveTo({1}, {2}, {3})", new object[] { "Dialogue System", this.target, this.subject, this.duration }));
			}
			if (this.target == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: MoveTo() target '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(0, null)
				}));
			}
			if (this.subject == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: MoveTo() subject '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(1, null)
				}));
			}
			if (this.subject != null && this.target != null && this.subject != this.target)
			{
				this.subjectRigidbody = this.subject.GetComponent<Rigidbody>();
				if (this.duration > 0.05f)
				{
					this.startTime = DialogueTime.time;
					this.endTime = this.startTime + this.duration;
					this.originalPosition = this.subject.position;
					this.originalRotation = this.subject.rotation;
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

		// Token: 0x060019DB RID: 6619 RVA: 0x0002ADDC File Offset: 0x00028FDC
		private void SetPosition(Vector3 newPosition, Quaternion newRotation)
		{
			if (this.subjectRigidbody != null)
			{
				this.subjectRigidbody.MoveRotation(newRotation);
				this.subjectRigidbody.MovePosition(newPosition);
			}
			else
			{
				this.subject.rotation = newRotation;
				this.subject.position = newPosition;
			}
		}

		// Token: 0x060019DC RID: 6620 RVA: 0x0002AE30 File Offset: 0x00029030
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				this.SetPosition(Vector3.Lerp(this.originalPosition, this.target.position, num), Quaternion.Lerp(this.originalRotation, this.target.rotation, num));
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019DD RID: 6621 RVA: 0x0002AEA0 File Offset: 0x000290A0
		public void OnDestroy()
		{
			if (this.subject != null && this.target != null && this.subject != this.target)
			{
				this.SetPosition(this.target.position, this.target.rotation);
			}
		}

		// Token: 0x04000E70 RID: 3696
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E71 RID: 3697
		private Transform target;

		// Token: 0x04000E72 RID: 3698
		private Transform subject;

		// Token: 0x04000E73 RID: 3699
		private Rigidbody subjectRigidbody;

		// Token: 0x04000E74 RID: 3700
		private float duration;

		// Token: 0x04000E75 RID: 3701
		private float startTime;

		// Token: 0x04000E76 RID: 3702
		private float endTime;

		// Token: 0x04000E77 RID: 3703
		private Vector3 originalPosition;

		// Token: 0x04000E78 RID: 3704
		private Quaternion originalRotation;
	}
}
