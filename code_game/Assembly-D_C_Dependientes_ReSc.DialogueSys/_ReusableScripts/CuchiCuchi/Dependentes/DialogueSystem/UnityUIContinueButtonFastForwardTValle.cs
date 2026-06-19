using System;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000024 RID: 36
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_dialogue_u_i.html#unityUIDialogueUIContinueButtonFastForward")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Effects/Unity UI Continue Button Fast Forward TValle")]
	public class UnityUIContinueButtonFastForwardTValle : MonoBehaviour
	{
		// Token: 0x06000131 RID: 305 RVA: 0x0000670C File Offset: 0x0000490C
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

		// Token: 0x06000132 RID: 306 RVA: 0x00006760 File Offset: 0x00004960
		public virtual void OnFastForward()
		{
			if (this.m_LastPressTime + this.continueDelay > Time.unscaledTime)
			{
				return;
			}
			this.m_LastPressTime = Time.unscaledTime;
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

		// Token: 0x040000A1 RID: 161
		[Tooltip("Dialogue UI that the continue button affects.")]
		public UnityUIDialogueUI dialogueUI;

		// Token: 0x040000A2 RID: 162
		[Tooltip("Typewriter effect to fast forward if it's not done playing.")]
		public UnityUITypewriterEffect typewriterEffect;

		// Token: 0x040000A3 RID: 163
		[Tooltip("Hide the continue button when continuing.")]
		public bool hideContinueButtonOnContinue;

		// Token: 0x040000A4 RID: 164
		private Button continueButton;

		// Token: 0x040000A5 RID: 165
		public float continueDelay = 0.125f;

		// Token: 0x040000A6 RID: 166
		private float m_LastPressTime;
	}
}
