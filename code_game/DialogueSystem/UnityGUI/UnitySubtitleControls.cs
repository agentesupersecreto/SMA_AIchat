using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002DA RID: 730
	[Serializable]
	public class UnitySubtitleControls : AbstractUISubtitleControls
	{
		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06001DDE RID: 7646 RVA: 0x0003B2C8 File Offset: 0x000394C8
		public override bool HasText
		{
			get
			{
				return this.line != null && !string.IsNullOrEmpty(this.line.text);
			}
		}

		// Token: 0x06001DDF RID: 7647 RVA: 0x0003B2F4 File Offset: 0x000394F4
		public override void SetActive(bool value)
		{
			UnityDialogueUIControls.SetControlActive(this.line, value);
			UnityDialogueUIControls.SetControlActive(this.portraitImage, value);
			UnityDialogueUIControls.SetControlActive(this.portraitName, value);
			UnityDialogueUIControls.SetControlActive(this.continueButton, value);
			UnityDialogueUIControls.SetControlActive(this.panel, value);
		}

		// Token: 0x06001DE0 RID: 7648 RVA: 0x0003B340 File Offset: 0x00039540
		public override void SetSubtitle(Subtitle subtitle)
		{
			if (this.portraitImage != null)
			{
				this.portraitImage.image = subtitle.GetSpeakerPortrait();
			}
			if (this.portraitName != null)
			{
				this.portraitName.text = subtitle.speakerInfo.Name;
			}
			if (this.line != null)
			{
				this.line.SetFormattedText(subtitle.formattedText);
			}
		}

		// Token: 0x06001DE1 RID: 7649 RVA: 0x0003B3B8 File Offset: 0x000395B8
		public override void ClearSubtitle()
		{
			if (this.portraitImage != null)
			{
				this.portraitImage.image = null;
			}
			if (this.portraitName != null)
			{
				this.portraitName.text = null;
			}
			if (this.line != null)
			{
				this.line.SetUnformattedText(string.Empty);
			}
		}

		// Token: 0x06001DE2 RID: 7650 RVA: 0x0003B420 File Offset: 0x00039620
		public override void ShowContinueButton()
		{
			UnityDialogueUIControls.SetControlActive(this.continueButton, true);
		}

		// Token: 0x06001DE3 RID: 7651 RVA: 0x0003B430 File Offset: 0x00039630
		public override void HideContinueButton()
		{
			UnityDialogueUIControls.SetControlActive(this.continueButton, false);
		}

		// Token: 0x06001DE4 RID: 7652 RVA: 0x0003B440 File Offset: 0x00039640
		public override void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (this.currentSubtitle != null && string.Equals(this.currentSubtitle.speakerInfo.nameInDatabase, actorName) && this.portraitImage != null)
			{
				this.portraitImage.image = AbstractDialogueUI.GetValidPortraitTexture(actorName, portraitTexture);
			}
		}

		// Token: 0x0400115A RID: 4442
		public GUIControl panel;

		// Token: 0x0400115B RID: 4443
		public GUILabel line;

		// Token: 0x0400115C RID: 4444
		public GUILabel portraitImage;

		// Token: 0x0400115D RID: 4445
		public GUILabel portraitName;

		// Token: 0x0400115E RID: 4446
		public GUIButton continueButton;
	}
}
