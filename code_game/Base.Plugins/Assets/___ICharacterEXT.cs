using System;

namespace Assets
{
	// Token: 0x020000BA RID: 186
	public static class ___ICharacterEXT
	{
		// Token: 0x060005A6 RID: 1446 RVA: 0x00016248 File Offset: 0x00014448
		public static ICharacter GetMasterRoot(this ICharacter charr)
		{
			ICharacter character = charr.master;
			if (character == null)
			{
				return null;
			}
			do
			{
				charr = character;
				character = charr.master;
			}
			while (character != null);
			return charr;
		}
	}
}
