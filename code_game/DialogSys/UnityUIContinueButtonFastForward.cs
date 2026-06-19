using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000026 RID: 38
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUIDialogueUIContinueButtonFastForward")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Continue Button Fast Forward")]
	public class UnityUIContinueButtonFastForward : MonoBehaviour
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00005824 File Offset: 0x00003A24
		public virtual void Awake()
		{
			if (this.dialogueUI == null)
			{
				this.dialogueUI = Tools.GetComponentAnywhere<UnityUIDialogueUI>(base.gameObject);
			}
			if (this.typewriterEffect == null)
			{
				this.typewriterEffect = base.GetComponentInChildren<UnityUITypewriterEffect>();
			}
			this.continueButton = base.GetComponent<Button>();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005878 File Offset: 0x00003A78
		public virtual void OnFastForward()
		{
			if (this.typewriterEffect != null && this.typewriterEffect.IsPlaying)
			{
				this.typewriterEffect.Stop();
				return;
			}
			if (this.hideContinueButtonOnContinue && this.continueButton != null)
			{
				this.continueButton.gameObject.SetActive(false);
			}
			if (this.dialogueUI != null)
			{
				this.dialogueUI.OnContinue();
			}
		}

		// Token: 0x0400009F RID: 159
		[Tooltip("Dialogue UI that the continue button affects.")]
		public UnityUIDialogueUI dialogueUI;

		// Token: 0x040000A0 RID: 160
		[Tooltip("Typewriter effect to fast forward if it's not done playing.")]
		public UnityUITypewriterEffect typewriterEffect;

		// Token: 0x040000A1 RID: 161
		[Tooltip("Hide the continue button when continuing.")]
		public bool hideContinueButtonOnContinue;

		// Token: 0x040000A2 RID: 162
		private Button continueButton;
	}
}
