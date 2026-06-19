using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000017 RID: 23
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Use Animated Portraits")]
	public class UseAnimatedPortraits : MonoBehaviour
	{
		// Token: 0x06000055 RID: 85 RVA: 0x00003196 File Offset: 0x00001396
		public void OnConversationLine(Subtitle subtitle)
		{
			if (!this.FindDialogueUI())
			{
				return;
			}
			base.StartCoroutine(this.SetAnimatorAtEndOfFrame(subtitle));
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000031AF File Offset: 0x000013AF
		private IEnumerator SetAnimatorAtEndOfFrame(Subtitle subtitle)
		{
			yield return new WaitForEndOfFrame();
			if (subtitle.speakerInfo.characterType == CharacterType.NPC)
			{
				this.SetAnimatorController(this.dialogueUI.dialogue.npcSubtitle.portraitImage, subtitle.speakerInfo.transform, ref this.npcPortraitAnimator);
			}
			else
			{
				this.SetAnimatorController(this.dialogueUI.dialogue.pcSubtitle.portraitImage, subtitle.speakerInfo.transform, ref this.pcPortraitAnimator);
			}
			this.lastSpeaker = subtitle.speakerInfo.transform;
			yield break;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x000031C5 File Offset: 0x000013C5
		public void OnConversationResponseMenu(Response[] responses)
		{
			if (!this.FindDialogueUI())
			{
				return;
			}
			this.SetAnimatorController(this.dialogueUI.dialogue.responseMenu.subtitleReminder.portraitImage, this.lastSpeaker, ref this.npcReminderPortraitAnimator);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000031FC File Offset: 0x000013FC
		public void OnConversationEnd(Transform actor)
		{
			this.animatedPortraits.Clear();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000320C File Offset: 0x0000140C
		private bool FindDialogueUI()
		{
			if (this.dialogueUI == null && DialogueManager.DisplaySettings.dialogueUI)
			{
				this.dialogueUI = DialogueManager.DisplaySettings.dialogueUI.GetComponent<UnityUIDialogueUI>();
			}
			return this.dialogueUI != null;
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000325C File Offset: 0x0000145C
		private void SetAnimatorController(Image image, Transform speaker, ref Animator animator)
		{
			if (speaker == null || image == null)
			{
				return;
			}
			if (animator == null)
			{
				animator = image.GetComponent<Animator>();
			}
			if (animator == null)
			{
				animator = image.gameObject.AddComponent<Animator>();
			}
			if (!this.animatedPortraits.ContainsKey(speaker))
			{
				AnimatedPortrait animatedPortrait = ((speaker != null) ? speaker.GetComponentInChildren<AnimatedPortrait>() : null);
				this.animatedPortraits.Add(speaker, animatedPortrait);
			}
			if (this.animatedPortraits[speaker] != null)
			{
				RuntimeAnimatorController animatorController = this.animatedPortraits[speaker].animatorController;
				if (animator.runtimeAnimatorController != animatorController)
				{
					animator.runtimeAnimatorController = animatorController;
				}
			}
		}

		// Token: 0x0400002F RID: 47
		private UnityUIDialogueUI dialogueUI;

		// Token: 0x04000030 RID: 48
		private Animator npcPortraitAnimator;

		// Token: 0x04000031 RID: 49
		private Animator npcReminderPortraitAnimator;

		// Token: 0x04000032 RID: 50
		private Animator pcPortraitAnimator;

		// Token: 0x04000033 RID: 51
		private Dictionary<Transform, AnimatedPortrait> animatedPortraits = new Dictionary<Transform, AnimatedPortrait>();

		// Token: 0x04000034 RID: 52
		private Transform lastSpeaker;
	}
}
