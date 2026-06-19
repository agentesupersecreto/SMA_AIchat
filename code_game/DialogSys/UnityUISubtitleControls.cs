using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000021 RID: 33
	[Serializable]
	public class UnityUISubtitleControls : AbstractUISubtitleControls
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00004CF9 File Offset: 0x00002EF9
		public override bool HasText
		{
			get
			{
				return this.line != null && !string.IsNullOrEmpty(this.line.text);
			}
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00004D1E File Offset: 0x00002F1E
		public override void SetActive(bool value)
		{
			if (value || this.alwaysVisible)
			{
				this.ShowPanel();
				return;
			}
			this.HidePanel();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00004D38 File Offset: 0x00002F38
		private void ShowPanel()
		{
			this.ShowControls();
			this.CheckShowHideController();
			this.showHideController.Show(this.animationTransitions.showTrigger, false, null, true);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00004D5F File Offset: 0x00002F5F
		private void HidePanel()
		{
			this.CheckShowHideController();
			this.showHideController.Hide(this.animationTransitions.hideTrigger, new Action(this.HideControls));
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00004D89 File Offset: 0x00002F89
		private void CheckShowHideController()
		{
			if (this.showHideController == null)
			{
				this.showHideController = new UIShowHideController(null, this.panel, this.animationTransitions.transitionMode);
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00004DB0 File Offset: 0x00002FB0
		private void ShowControls()
		{
			Tools.SetGameObjectActive(this.line, true);
			Tools.SetGameObjectActive(this.portraitImage, true);
			Tools.SetGameObjectActive(this.portraitName, true);
			Tools.SetGameObjectActive(this.continueButton, true);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00004DE4 File Offset: 0x00002FE4
		private void HideControls()
		{
			Tools.SetGameObjectActive(this.line, this.alwaysVisible);
			Tools.SetGameObjectActive(this.portraitImage, this.alwaysVisible);
			Tools.SetGameObjectActive(this.portraitName, this.alwaysVisible);
			Tools.SetGameObjectActive(this.continueButton, this.alwaysVisible);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00004E35 File Offset: 0x00003035
		public override void ShowContinueButton()
		{
			Tools.SetGameObjectActive(this.continueButton, true);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00004E43 File Offset: 0x00003043
		public override void HideContinueButton()
		{
			Tools.SetGameObjectActive(this.continueButton, false);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00004E51 File Offset: 0x00003051
		public override void ShowSubtitle(Subtitle subtitle)
		{
			if (subtitle != null && !string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				this.currentSubtitle = subtitle;
				base.Show();
				this.SetSubtitle(subtitle);
				return;
			}
			this.currentSubtitle = null;
			base.Hide();
			this.ClearSubtitle();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00004E90 File Offset: 0x00003090
		public override void SetSubtitle(Subtitle subtitle)
		{
			if (subtitle != null && !string.IsNullOrEmpty(subtitle.formattedText.text))
			{
				if (this.portraitImage != null)
				{
					this.portraitImage.sprite = UITools.CreateSprite(subtitle.GetSpeakerPortrait());
				}
				if (this.portraitName != null)
				{
					this.portraitName.text = subtitle.speakerInfo.Name;
					UITools.SendTextChangeMessage(this.portraitName);
				}
				if (this.line != null)
				{
					UnityUITypewriterEffect component = this.line.GetComponent<UnityUITypewriterEffect>();
					if (component != null && component.enabled)
					{
						component.Stop();
						component.playOnEnable = false;
					}
					this.SetFormattedText(this.line, subtitle.formattedText);
					if (component != null && component.enabled)
					{
						component.PlayText(subtitle.formattedText.text);
					}
				}
				base.Show();
				if (this.alwaysVisible && this.line != null)
				{
					UnityUITypewriterEffect component2 = this.line.GetComponent<UnityUITypewriterEffect>();
					if (component2 != null)
					{
						component2.OnEnable();
						return;
					}
				}
			}
			else
			{
				if (this.line != null && subtitle != null)
				{
					this.SetFormattedText(this.line, subtitle.formattedText);
				}
				base.Hide();
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004FD8 File Offset: 0x000031D8
		public override void ClearSubtitle()
		{
			this.SetFormattedText(this.line, null);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00004FE8 File Offset: 0x000031E8
		private void SetFormattedText(Text label, FormattedText formattedText)
		{
			if (label != null)
			{
				if (formattedText != null)
				{
					string text = UITools.GetUIFormattedText(formattedText);
					if (this.ignorePauseCodes)
					{
						text = UnityUITypewriterEffect.StripRPGMakerCodes(text);
					}
					label.text = text;
					UITools.SendTextChangeMessage(label);
					if (!this.haveSavedOriginalColor)
					{
						this.originalColor = label.color;
						this.haveSavedOriginalColor = true;
					}
					label.color = ((formattedText.emphases.Length != 0) ? formattedText.emphases[0].color : this.originalColor);
					return;
				}
				label.text = string.Empty;
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005074 File Offset: 0x00003274
		public override void SetActorPortraitTexture(string actorName, Texture2D portraitTexture)
		{
			if (this.currentSubtitle != null && string.Equals(this.currentSubtitle.speakerInfo.nameInDatabase, actorName) && this.portraitImage != null)
			{
				this.portraitImage.sprite = UITools.CreateSprite(AbstractDialogueUI.GetValidPortraitTexture(actorName, portraitTexture));
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000050C6 File Offset: 0x000032C6
		public void AutoFocus(bool allowStealFocus = true)
		{
			UITools.Select(this.continueButton, allowStealFocus);
		}

		// Token: 0x0400007F RID: 127
		[Tooltip("Optional panel for the subtitle elements")]
		public Graphic panel;

		// Token: 0x04000080 RID: 128
		[Tooltip("Subtitle text")]
		public Text line;

		// Token: 0x04000081 RID: 129
		[Tooltip("Optional image for speaker's portrait")]
		public Image portraitImage;

		// Token: 0x04000082 RID: 130
		[Tooltip("Optional label for speaker's name")]
		public Text portraitName;

		// Token: 0x04000083 RID: 131
		[Tooltip("Optional continue button; configure OnClick to invoke dialogue UI's OnContinue method")]
		public Button continueButton;

		// Token: 0x04000084 RID: 132
		[Tooltip("Ignore RPGMaker-style pause codes")]
		public bool ignorePauseCodes;

		// Token: 0x04000085 RID: 133
		[Tooltip("Optional animation transitions; panel should have an Animator")]
		public UnityUISubtitleControls.AnimationTransitions animationTransitions = new UnityUISubtitleControls.AnimationTransitions();

		// Token: 0x04000086 RID: 134
		[Tooltip("Never hide this subtitle panel")]
		public bool alwaysVisible;

		// Token: 0x04000087 RID: 135
		private bool haveSavedOriginalColor;

		// Token: 0x04000088 RID: 136
		private Color originalColor = Color.white;

		// Token: 0x04000089 RID: 137
		private UIShowHideController showHideController;

		// Token: 0x02000065 RID: 101
		[Serializable]
		public class AnimationTransitions
		{
			// Token: 0x04000237 RID: 567
			[Tooltip("To show the subtitle, play this state/trigger.")]
			public string showTrigger = string.Empty;

			// Token: 0x04000238 RID: 568
			[Tooltip("To hide the subtitle, play this state/trigger.")]
			public string hideTrigger = string.Empty;

			// Token: 0x04000239 RID: 569
			[Tooltip("Specifies whether Show Trigger and Hide Trigger are animator states or trigger parameters.")]
			public UIShowHideController.TransitionMode transitionMode;
		}
	}
}
