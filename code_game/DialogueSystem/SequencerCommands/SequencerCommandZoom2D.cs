using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x02000248 RID: 584
	[AddComponentMenu("")]
	public class SequencerCommandZoom2D : SequencerCommand
	{
		// Token: 0x060019F3 RID: 6643 RVA: 0x0002B95C File Offset: 0x00029B5C
		public void Start()
		{
			this.original = string.Equals(base.GetParameter(0, null), "original");
			this.subject = ((!this.original) ? base.GetSubject(0, null) : null);
			this.targetSize = base.GetParameterAsFloat(1, 16f);
			this.duration = base.GetParameterAsFloat(2, 0f);
			if (DialogueDebug.LogInfo)
			{
				if (this.original)
				{
					Debug.Log(string.Format("{0}: Sequencer: Zoom2D(original, -, {1}s)", new object[] { "Dialogue System", this.duration }));
				}
				else
				{
					Debug.Log(string.Format("{0}: Sequencer: Zoom2D({1}, {2}, {3}s)", new object[]
					{
						"Dialogue System",
						Tools.GetGameObjectName(this.subject),
						this.targetSize,
						this.duration
					}));
				}
			}
			if (this.subject == null && !this.original && DialogueDebug.LogWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Camera subject '{1}' wasn't found.", new object[]
				{
					"Dialogue System",
					base.GetParameter(1, null)
				}));
			}
			base.Sequencer.TakeCameraControl();
			if (this.subject != null || this.original)
			{
				if (this.original)
				{
					this.targetPosition = base.Sequencer.OriginalCameraPosition;
					this.targetSize = base.Sequencer.OriginalOrthographicSize;
				}
				else
				{
					this.targetPosition = new Vector3(this.subject.position.x, this.subject.position.y, base.Sequencer.SequencerCamera.transform.position.z);
				}
				this.originalPosition = base.Sequencer.SequencerCamera.transform.position;
				this.originalSize = base.Sequencer.SequencerCamera.orthographicSize;
				if (this.duration > 0.05f)
				{
					this.startTime = DialogueTime.time;
					this.endTime = this.startTime + this.duration;
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

		// Token: 0x060019F4 RID: 6644 RVA: 0x0002BBBC File Offset: 0x00029DBC
		public void Update()
		{
			if (DialogueTime.time < this.endTime)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				base.Sequencer.SequencerCamera.transform.position = Vector3.Lerp(this.originalPosition, this.targetPosition, num);
				base.Sequencer.SequencerCamera.orthographicSize = Mathf.Lerp(this.originalSize, this.targetSize, num);
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019F5 RID: 6645 RVA: 0x0002BC44 File Offset: 0x00029E44
		public void OnDestroy()
		{
			if (this.subject != null || this.original)
			{
				base.Sequencer.SequencerCamera.transform.position = this.targetPosition;
				base.Sequencer.SequencerCamera.orthographicSize = this.targetSize;
			}
		}

		// Token: 0x04000E88 RID: 3720
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E89 RID: 3721
		private bool original;

		// Token: 0x04000E8A RID: 3722
		private Transform subject;

		// Token: 0x04000E8B RID: 3723
		private Vector3 targetPosition;

		// Token: 0x04000E8C RID: 3724
		private Vector3 originalPosition;

		// Token: 0x04000E8D RID: 3725
		private float targetSize;

		// Token: 0x04000E8E RID: 3726
		private float originalSize;

		// Token: 0x04000E8F RID: 3727
		private float duration;

		// Token: 0x04000E90 RID: 3728
		private float startTime;

		// Token: 0x04000E91 RID: 3729
		private float endTime;
	}
}
