using System;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000033 RID: 51
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/unity_u_i_selector_display.html")]
	[AddComponentMenu("Dialogue System/UI/Unity UI/Selection/Unity UI Selector Elements")]
	public class UnityUISelectorElements : MonoBehaviour
	{
		// Token: 0x0600016D RID: 365 RVA: 0x0000869F File Offset: 0x0000689F
		private void Awake()
		{
			UnityUISelectorElements.instance = this;
		}

		// Token: 0x0400011C RID: 284
		public Graphic mainGraphic;

		// Token: 0x0400011D RID: 285
		public Text nameText;

		// Token: 0x0400011E RID: 286
		public Text useMessageText;

		// Token: 0x0400011F RID: 287
		public Color inRangeColor = Color.yellow;

		// Token: 0x04000120 RID: 288
		public Color outOfRangeColor = Color.gray;

		// Token: 0x04000121 RID: 289
		public Graphic reticleInRange;

		// Token: 0x04000122 RID: 290
		public Graphic reticleOutOfRange;

		// Token: 0x04000123 RID: 291
		public UnityUISelectorDisplay.AnimationTransitions animationTransitions = new UnityUISelectorDisplay.AnimationTransitions();

		// Token: 0x04000124 RID: 292
		public static UnityUISelectorElements instance;
	}
}
