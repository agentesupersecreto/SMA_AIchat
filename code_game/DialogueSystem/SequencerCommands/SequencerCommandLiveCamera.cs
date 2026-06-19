using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000240 RID: 576
	[AddComponentMenu("")]
	public class SequencerCommandLiveCamera : SequencerCommand
	{
		// Token: 0x060019D2 RID: 6610 RVA: 0x0002A460 File Offset: 0x00028660
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
			this.isOriginal = string.Equals(text, "original");
			this.angleTransform = ((!this.isOriginal) ? ((!(base.Sequencer.CameraAngles != null)) ? null : base.Sequencer.CameraAngles.transform.Find(text)) : Camera.main.transform);
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
			if (this.isOriginal || (this.angleTransform != null && this.subject != null))
			{
				this.cameraTransform = base.Sequencer.SequencerCameraTransform;
				if (this.isOriginal)
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

		// Token: 0x060019D3 RID: 6611 RVA: 0x0002A784 File Offset: 0x00028984
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				if (this.isOriginal || (this.angleTransform != null && this.subject != null))
				{
					this.cameraTransform = base.Sequencer.SequencerCameraTransform;
					if (this.isOriginal)
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
				}
				float num = (DialogueTime.time - this.startTime) / this.duration;
				this.cameraTransform.rotation = Quaternion.Lerp(this.originalRotation, this.targetRotation, num);
				this.cameraTransform.position = Vector3.Lerp(this.originalPosition, this.targetPosition, num);
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x0002A8F0 File Offset: 0x00028AF0
		public void OnDestroy()
		{
			if (this.angleTransform != null && this.subject != null)
			{
				this.cameraTransform.rotation = this.targetRotation;
				this.cameraTransform.position = this.targetPosition;
			}
		}

		// Token: 0x04000E5A RID: 3674
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E5B RID: 3675
		private Transform subject;

		// Token: 0x04000E5C RID: 3676
		private Transform angleTransform;

		// Token: 0x04000E5D RID: 3677
		private Transform cameraTransform;

		// Token: 0x04000E5E RID: 3678
		private bool isLocalTransform;

		// Token: 0x04000E5F RID: 3679
		private Quaternion targetRotation;

		// Token: 0x04000E60 RID: 3680
		private Vector3 targetPosition;

		// Token: 0x04000E61 RID: 3681
		private float duration;

		// Token: 0x04000E62 RID: 3682
		private float startTime;

		// Token: 0x04000E63 RID: 3683
		private float endTime;

		// Token: 0x04000E64 RID: 3684
		private Quaternion originalRotation;

		// Token: 0x04000E65 RID: 3685
		private Vector3 originalPosition;

		// Token: 0x04000E66 RID: 3686
		private bool isOriginal;
	}
}
