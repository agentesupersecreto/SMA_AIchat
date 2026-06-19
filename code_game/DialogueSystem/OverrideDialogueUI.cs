using System;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200022F RID: 559
	[AddComponentMenu("Dialogue System/UI/Override/Override Dialogue UI")]
	[HelpURL("http://pixelcrushers.com/dialogue_system/manual/html/override_dialogue_u_i.html")]
	public class OverrideDialogueUI : OverrideUIBase
	{
		// Token: 0x04000DFB RID: 3579
		[Tooltip("Use this dialogue UI for this GameObject.")]
		public GameObject ui;
	}
}
