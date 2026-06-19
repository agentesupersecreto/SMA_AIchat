using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023D RID: 573
	[AddComponentMenu("")]
	public class SequencerCommandCamera : SequencerCommand
	{
		// Token: 0x060019C7 RID: 6599 RVA: 0x00029D04 File Offset: 0x00027F04
		public void Start()
		{
			string text = base.GetParameter(0, "Closeup");
			this.subject = base.GetSubject(1, null);
			this.duration = base.GetParameterAsFloat(2, 0f);
			bool flag = string.Equals(text, "default");
			if (flag)
			{
				text = SequencerTools.GetDefaultCameraAngle(this.subject);
			}
			bool flag2 = string.Equals(text, "original");
			this.angleTransform = ((!flag2) ? ((!(base.Sequencer.CameraAngles != null)) ? null : base.Sequencer.CameraAngles.transform.Find(text)) : ((!(Camera.main != null)) ? base.Sequencer.Speaker : Camera.main.transform));
			this.isLocalTransform = true;
			if (this.angleTransform == null)
			{
				this.isLocalTransform = false;
				GameObject gameObject = GameObject.Find(text);
				if (gameObject != null)
				{
					this.angleTransform = gameObject.transform;
				}
			}
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Camera({1}, {2}, {3}s)", new object[]
				{
					"Dialogue System",
					text,
					Tools.GetGameObjectName(this.subject),
					this.duration
				}));
			}
			if (this.angleTransform == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Camera angle '{1}' wasn't found.", new object[] { "Dialogue System", text }));
			}
			if (this.subject == null && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Camera subject '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(1, null)
				}));
			}
			base.Sequencer.TakeCameraControl();
			if (flag2 || (this.angleTransform != null && this.subject != null))
			{
				this.cameraTransform = base.Sequencer.SequencerCameraTransform;
				if (flag2)
				{
					this.targetRotation = base.Sequencer.OriginalCameraRotation;
					this.targetPosition = base.Sequencer.OriginalCameraPosition;
				}
				else if (this.isLocalTransform)
				{
					this.targetRotation = this.subject.rotation * this.angleTransform.localRotation;
					this.targetPosition = this.subject.position + this.subject.rotation * this.angleTransform.localPosition;
				}
				else
				{
					this.targetRotation = this.angleTransform.rotation;
					this.targetPosition = this.angleTransform.position;
				}
				if (this.duration > 0.05f)
				{
					this.startTime = DialogueTime.time;
					this.endTime = this.startTime + this.duration;
					this.originalRotation = this.cameraTransform.rotation;
					this.originalPosition = this.cameraTransform.position;
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

		// Token: 0x060019C8 RID: 6600 RVA: 0x0002A034 File Offset: 0x00028234
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				this.cameraTransform.rotation = Quaternion.Lerp(this.originalRotation, this.targetRotation, num);
				this.cameraTransform.position = Vector3.Lerp(this.originalPosition, this.targetPosition, num);
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019C9 RID: 6601 RVA: 0x0002A0AC File Offset: 0x000282AC
		public void OnDestroy()
		{
			if (this.angleTransform != null && this.subject != null)
			{
				this.cameraTransform.rotation = this.targetRotation;
				this.cameraTransform.position = this.targetPosition;
			}
		}

		// Token: 0x04000E44 RID: 3652
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E45 RID: 3653
		private Transform subject;

		// Token: 0x04000E46 RID: 3654
		private Transform angleTransform;

		// Token: 0x04000E47 RID: 3655
		private Transform cameraTransform;

		// Token: 0x04000E48 RID: 3656
		private bool isLocalTransform;

		// Token: 0x04000E49 RID: 3657
		private Quaternion targetRotation;

		// Token: 0x04000E4A RID: 3658
		private Vector3 targetPosition;

		// Token: 0x04000E4B RID: 3659
		private float duration;

		// Token: 0x04000E4C RID: 3660
		private float startTime;

		// Token: 0x04000E4D RID: 3661
		private float endTime;

		// Token: 0x04000E4E RID: 3662
		private Quaternion originalRotation;

		// Token: 0x04000E4F RID: 3663
		private Vector3 originalPosition;
	}
}
