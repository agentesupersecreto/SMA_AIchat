using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000211 RID: 529
	public static class CharacterTypeTools
	{
		// Token: 0x060017E1 RID: 6113 RVA: 0x0001EDDC File Offset: 0x0001CFDC
		public static CharacterType OtherType(CharacterType characterType)
		{
			return (characterType != CharacterType.PC) ? CharacterType.PC : CharacterType.NPC;
		}
	}
}
