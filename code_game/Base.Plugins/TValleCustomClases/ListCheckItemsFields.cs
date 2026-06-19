using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x0200007E RID: 126
	public static class ListCheckItemsFields
	{
		// Token: 0x060003AD RID: 941 RVA: 0x0000FD38 File Offset: 0x0000DF38
		public static bool CheckItems<T>(this List<T> list, Func<T, bool> checker)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (!checker(list[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
