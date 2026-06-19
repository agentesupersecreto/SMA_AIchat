using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	// Token: 0x0200023F RID: 575
	[AddComponentMenu("")]
	public class SequencerCommandFade : SequencerCommand
	{
		// Token: 0x060019CE RID: 6606 RVA: 0x0002A180 File Offset: 0x00028380
		public void Start()
		{
			this.direction = base.GetParameter(0, null);
			this.duration = base.GetParameterAsFloat(1, 0f);
			this.color = Tools.WebColor(base.GetParameter(2, "#000000"));
			if (DialogueDebug.LogInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Fade({1}, {2}, {3})", new object[] { "Dialogue System", this.direction, this.duration, this.color }));
			}
			if (this.duration > 0.05f)
			{
				this.faderCanvas = new GameObject("Fader", new Type[] { typeof(Canvas) }).GetComponent<Canvas>();
				this.faderCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
				this.faderCanvas.sortingOrder = 9999;
				this.faderImage = new GameObject("Fader Image", new Type[] { typeof(Image) }).GetComponent<Image>();
				this.faderImage.transform.SetParent(this.faderCanvas.transform, false);
				this.faderImage.rectTransform.anchorMin = Vector2.zero;
				this.faderImage.rectTransform.anchorMax = Vector2.one;
				this.faderImage.sprite = null;
				this.startTime = DialogueTime.time;
				this.endTime = this.startTime + this.duration;
				this.fadeIn = string.Equals(this.direction, "in", StringComparison.OrdinalIgnoreCase);
				if (this.fadeIn)
				{
					this.faderImage.color = new Color(this.color.r, this.color.g, this.color.b, 1f);
				}
				else
				{
					this.faderImage.color = new Color(this.color.r, this.color.g, this.color.b, 0f);
				}
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x0002A39C File Offset: 0x0002859C
		public void Update()
		{
			if (DialogueTime.time < this.endTime && this.faderImage != null)
			{
				float num = (DialogueTime.time - this.startTime) / this.duration;
				float num2 = ((!this.fadeIn) ? num : (1f - num));
				this.faderImage.color = new Color(this.color.r, this.color.g, this.color.b, num2);
			}
			else
			{
				base.Stop();
			}
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x0002A434 File Offset: 0x00028634
		public void OnDestroy()
		{
			if (this.faderCanvas != null)
			{
				Object.Destroy(this.faderCanvas.gameObject);
			}
		}

		// Token: 0x04000E51 RID: 3665
		private const float SmoothMoveCutoff = 0.05f;

		// Token: 0x04000E52 RID: 3666
		private string direction;

		// Token: 0x04000E53 RID: 3667
		private float duration;

		// Token: 0x04000E54 RID: 3668
		private Color color;

		// Token: 0x04000E55 RID: 3669
		private bool fadeIn;

		// Token: 0x04000E56 RID: 3670
		private float startTime;

		// Token: 0x04000E57 RID: 3671
		private float endTime;

		// Token: 0x04000E58 RID: 3672
		private Canvas faderCanvas;

		// Token: 0x04000E59 RID: 3673
		private Image faderImage;
	}
}
