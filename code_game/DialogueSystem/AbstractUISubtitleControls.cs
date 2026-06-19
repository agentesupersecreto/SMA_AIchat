using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000268 RID: 616
	[Serializable]
	public abstract class AbstractUISubtitleControls : AbstractUIControls
	{
		// Token: 0x17000A5F RID: 2655
		// (get) Token: 0x06001A91 RID: 6801
		public abstract bool HasText { get; }

		// Token: 0x06001A92 RID: 6802
		public abstract void SetSubtitle(Subtitle subtitle);

		// Token: 0x06001A93 RID: 6803
		public abstract void ClearSubtitle();

		// Token: 0x06001A94 RID: 6804 RVA: 0x0002D600 File Offset: 0x0002B800
		public virtual void ShowContinueButton()
		{
		}

		// Token: 0x06001A95 RID: 6805 RVA: 0x0002D604 File Offset: 0x0002B804
		public virtual void HideContinueButton()
		{
		}

		// Token: 0x06001A96 RID: 6806 RVA: 0x0002D608 File Offset: 0x0002B808
		public virtual void ShowSubtitle(Subtitle subtitle)
		{
			if (subtitle != null && !string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				this.currentSubtitle = subtitle;
				this.SetSubtitle(subtitle);
				base.Show();
			}
			else
			{
				this.currentSubtitle = null;
				this.ClearSubtitle();
				base.Hide();
			}
		}

		// Token: 0x06001A97 RID: 6807 RVA: 0x0002D65C File Offset: 0x0002B85C
		public virtual void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
		}

		// Token: 0x04000F00 RID: 3840
		protected Subtitle currentSubtitle;
	}
}
