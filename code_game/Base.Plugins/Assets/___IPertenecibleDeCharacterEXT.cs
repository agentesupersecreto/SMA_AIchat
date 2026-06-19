using System;

namespace Assets
{
	// Token: 0x020000C6 RID: 198
	public static class ___IPertenecibleDeCharacterEXT
	{
		// Token: 0x060005EC RID: 1516 RVA: 0x00017327 File Offset: 0x00015527
		public static ICharacter GetRootOwner(this IPertenecibleDeCharacter obj)
		{
			ICharacter inmediateOwner = obj.inmediateOwner;
			if (((inmediateOwner != null) ? inmediateOwner.master : null) != null)
			{
				return obj.inmediateOwner.GetMasterRoot();
			}
			return obj.inmediateOwner;
		}
	}
}
