using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000231 RID: 561
	public abstract class OverrideUIBase : MonoBehaviour
	{
		// Token: 0x04000DFD RID: 3581
		[Tooltip("When both participants have overrides, the higher priority takes precedence.")]
		public int priority;
	}
}
