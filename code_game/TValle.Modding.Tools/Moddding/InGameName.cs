using System;
using UnityEngine;

namespace Assets.TValle.Tools.Runtime.Moddding
{
	// Token: 0x0200002E RID: 46
	[Serializable]
	public class InGameName
	{
		// Token: 0x04000041 RID: 65
		[Tooltip("Right now, the game is only compatible with English.")]
		public Language language = Language.en;

		// Token: 0x04000042 RID: 66
		[Tooltip("How this item will be called in the game by the player, UI, or NPCs.")]
		public string name;

		// Token: 0x04000043 RID: 67
		[Tooltip("Whether it's a pair of gloves, shoes, glasses, or just a ring or a neckless")]
		public bool isPlural;
	}
}
