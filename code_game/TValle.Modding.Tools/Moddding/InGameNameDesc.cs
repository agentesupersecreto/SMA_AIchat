using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Moddding
{
	// Token: 0x0200002F RID: 47
	[Serializable]
	public class InGameNameDesc
	{
		// Token: 0x04000044 RID: 68
		[Tooltip("Right now, the game is only compatible with English.")]
		public Language language = Language.en;

		// Token: 0x04000045 RID: 69
		[Tooltip("How this item will be called in the game by the player, UI, or NPCs.")]
		public string name;

		// Token: 0x04000046 RID: 70
		[Tooltip("How this level will be described in the game by the player, UI, or NPCs.")]
		[TextArea]
		public string desciption;
	}
}
