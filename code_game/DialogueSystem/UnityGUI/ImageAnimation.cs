using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002CD RID: 717
	[Serializable]
	public class ImageAnimation
	{
		// Token: 0x06001D77 RID: 7543 RVA: 0x00038FB8 File Offset: 0x000371B8
		public void RefreshAnimation(Texture2D image)
		{
			if (image == null)
			{
				return;
			}
			if (!Application.isPlaying)
			{
				return;
			}
			if (image != null)
			{
				this.numFrames = image.width / Mathf.Max(this.frameWidth, 1);
				this.frameNormalWidth = 1f / (float)Mathf.Max(this.numFrames, 1);
				this.nextFrameTime = DialogueTime.time + 1f / Mathf.Max(this.framesPerSecond, 0.05f);
				this.lastDialogueTime = DialogueTime.time;
			}
			else
			{
				this.nextFrameTime = float.PositiveInfinity;
			}
		}

		// Token: 0x06001D78 RID: 7544 RVA: 0x00039058 File Offset: 0x00037258
		public void DrawAnimation(Rect rect, Texture2D image)
		{
			if (Application.isPlaying)
			{
				if (DialogueTime.time >= this.nextFrameTime || DialogueTime.time < this.lastDialogueTime)
				{
					if (this.numFrames == 0 || this.frameNormalWidth == 0f)
					{
						this.numFrames = image.width / Mathf.Max(this.frameWidth, 1);
						this.frameNormalWidth = 1f / (float)Mathf.Max(this.numFrames, 1);
					}
					this.currentFrame = (this.currentFrame + 1) % Mathf.Max(this.numFrames, 1);
					this.texCoords = new Rect((float)this.currentFrame * this.frameNormalWidth, 0f, this.frameNormalWidth, 1f);
					this.nextFrameTime = DialogueTime.time + 1f / Mathf.Max(this.framesPerSecond, 0.05f);
				}
				this.lastDialogueTime = DialogueTime.time;
			}
			else
			{
				this.texCoords = new Rect(0f, 0f, (float)this.frameWidth / (float)Mathf.Max(image.width, 1), 1f);
			}
			if (this.texCoords.width > 0f)
			{
				GUI.DrawTextureWithTexCoords(rect, image, this.texCoords);
			}
		}

		// Token: 0x040010F8 RID: 4344
		public bool animate;

		// Token: 0x040010F9 RID: 4345
		public int frameWidth = 64;

		// Token: 0x040010FA RID: 4346
		public float framesPerSecond = 1f;

		// Token: 0x040010FB RID: 4347
		private int numFrames = 1;

		// Token: 0x040010FC RID: 4348
		private float frameNormalWidth = 1f;

		// Token: 0x040010FD RID: 4349
		private int currentFrame;

		// Token: 0x040010FE RID: 4350
		private float nextFrameTime;

		// Token: 0x040010FF RID: 4351
		private Rect texCoords;

		// Token: 0x04001100 RID: 4352
		private float lastDialogueTime;
	}
}
