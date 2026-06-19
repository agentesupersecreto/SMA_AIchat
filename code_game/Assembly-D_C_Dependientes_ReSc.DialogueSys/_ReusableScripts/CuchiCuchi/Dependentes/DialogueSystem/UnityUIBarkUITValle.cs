using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000023 RID: 35
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_bark_u_i.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Bark/Unity UI Bark UI Tavo")]
	public class UnityUIBarkUITValle : UnityUIBarkUI, ICharacterBarkUI
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600012A RID: 298 RVA: 0x000064BD File Offset: 0x000046BD
		Text ICharacterBarkUI.barkText
		{
			get
			{
				return this.barkText;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600012B RID: 299 RVA: 0x000064C5 File Offset: 0x000046C5
		Text ICharacterBarkUI.nameText
		{
			get
			{
				return this.nameText;
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000064D0 File Offset: 0x000046D0
		public bool ShouldShowText()
		{
			bool flag = this.textDisplaySetting == BarkSubtitleSetting.Show || (this.textDisplaySetting == BarkSubtitleSetting.SameAsDialogueManager && DialogueManager.DisplaySettings.subtitleSettings.showNPCSubtitlesDuringLine);
			bool flag2 = true;
			return flag && flag2;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006508 File Offset: 0x00004708
		public bool ShouldShowText(string subtitle)
		{
			bool flag = this.textDisplaySetting == BarkSubtitleSetting.Show || (this.textDisplaySetting == BarkSubtitleSetting.SameAsDialogueManager && DialogueManager.DisplaySettings.subtitleSettings.showNPCSubtitlesDuringLine);
			bool flag2 = !string.IsNullOrEmpty(subtitle);
			return flag && flag2;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006548 File Offset: 0x00004748
		public bool Bark(string subtitle, string speakerName = "NONE")
		{
			if (this.ShouldShowText(subtitle))
			{
				base.SetUIElementsActive(false);
				string text = subtitle;
				if (this.includeName)
				{
					if (this.nameText != null)
					{
						this.nameText.text = speakerName;
					}
					else
					{
						text = string.Format("{0}: {1}", text, subtitle);
					}
				}
				if (this.barkText != null)
				{
					this.barkText.text = text;
				}
				base.SetUIElementsActive(true);
				if (base.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.showTrigger))
				{
					this.animator.SetTrigger(this.animationTransitions.showTrigger);
				}
				base.CancelInvoke("Hide");
				float num = (Mathf.Approximately(0f, this.duration) ? DialogueManager.GetBarkDuration(text) : this.duration);
				if (!this.waitUntilSequenceEnds && !this.waitForContinueButton)
				{
					base.Invoke("Hide", num);
				}
				this.doneTime = DialogueTime.time + num;
				return true;
			}
			return false;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006644 File Offset: 0x00004844
		public bool BarkPermanente(string subtitle, string speakerName = "NONE")
		{
			if (this.ShouldShowText(subtitle))
			{
				base.SetUIElementsActive(false);
				string text = subtitle;
				if (this.includeName)
				{
					if (this.nameText != null)
					{
						this.nameText.text = speakerName;
					}
					else
					{
						text = string.Format("{0}: {1}", text, subtitle);
					}
				}
				if (this.barkText != null)
				{
					this.barkText.text = text;
				}
				base.SetUIElementsActive(true);
				if (base.CanTriggerAnimations() && !string.IsNullOrEmpty(this.animationTransitions.showTrigger))
				{
					this.animator.SetTrigger(this.animationTransitions.showTrigger);
				}
				base.CancelInvoke("Hide");
				this.doneTime = float.MaxValue;
				return true;
			}
			return false;
		}
	}
}
