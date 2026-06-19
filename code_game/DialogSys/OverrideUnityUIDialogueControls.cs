using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000018 RID: 24
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Override/Override Unity UI Dialogue Controls")]
	public class OverrideUnityUIDialogueControls : MonoBehaviour
	{
		// Token: 0x0600005C RID: 92 RVA: 0x00003323 File Offset: 0x00001523
		public virtual void Start()
		{
			if (this.subtitle != null)
			{
				this.subtitle.SetActive(false);
			}
			if (this.subtitleReminder != null)
			{
				this.subtitleReminder.SetActive(false);
			}
			if (this.responseMenu != null)
			{
				this.responseMenu.SetActive(false);
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003364 File Offset: 0x00001564
		public virtual void ApplyToDialogueUI(UnityUIDialogueUI ui)
		{
			if (this.checkedContinueButton)
			{
				return;
			}
			if (this.subtitle != null && this.subtitle.continueButton != null)
			{
				if (this.subtitle.continueButton.onClick.GetPersistentEventCount() == 0 || this.subtitle.continueButton.onClick.GetPersistentTarget(0) == null)
				{
					this.subtitle.continueButton.onClick.AddListener(new UnityAction(ui.OnContinue));
				}
				UnityUIContinueButtonFastForward component = this.subtitle.continueButton.GetComponent<UnityUIContinueButtonFastForward>();
				if (component != null && component.dialogueUI == null)
				{
					component.dialogueUI = ui;
				}
			}
			this.checkedContinueButton = true;
		}

		// Token: 0x04000035 RID: 53
		[Tooltip("Use these controls when playing subtitles through this actor")]
		public UnityUISubtitleControls subtitle;

		// Token: 0x04000036 RID: 54
		[Tooltip("Use these controls when showing subtitle reminders for actor")]
		public UnityUISubtitleControls subtitleReminder;

		// Token: 0x04000037 RID: 55
		[Tooltip("Use these controls when showing a response menu involving this actor")]
		public UnityUIResponseMenuControls responseMenu;

		// Token: 0x04000038 RID: 56
		private bool checkedContinueButton;
	}
}
