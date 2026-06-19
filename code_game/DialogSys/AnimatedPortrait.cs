using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000016 RID: 22
	[AddComponentMenu("Dialogue System/UI/Unity UI/Dialogue/Animated Portrait")]
	public class AnimatedPortrait : MonoBehaviour
	{
		// Token: 0x0400002E RID: 46
		[Tooltip("Animator controller that runs this actor's animated portrait. It should animate an Image component, not a SpriteRenderer.")]
		public RuntimeAnimatorController animatorController;
	}
}
