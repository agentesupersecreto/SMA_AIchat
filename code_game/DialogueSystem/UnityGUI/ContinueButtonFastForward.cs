using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.UnityGUI
{
	// Token: 0x020002BE RID: 702
	[AddComponentMenu("Dialogue System/UI/Unity GUI/Controls/Effects/Continue Button Fast Forward (Unity GUI)")]
	public class ContinueButtonFastForward : MonoBehaviour
	{
		// Token: 0x06001D4A RID: 7498 RVA: 0x000385D0 File Offset: 0x000367D0
		public void OnFastForward()
		{
			if (this.typewriterEffect != null && this.typewriterEffect.IsPlaying)
			{
				this.typewriterEffect.Stop();
			}
			else if (this.dialogueUI != null)
			{
				this.dialogueUI.OnContinue();
			}
		}

		// Token: 0x040010B4 RID: 4276
		public UnityDialogueUI dialogueUI;

		// Token: 0x040010B5 RID: 4277
		public TypewriterEffect typewriterEffect;
	}
}
