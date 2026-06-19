using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000082 RID: 130
	public static class ListExecuteExt
	{
		// Token: 0x060003BB RID: 955 RVA: 0x00010164 File Offset: 0x0000E364
		public static void Execute<T>(this List<T> list, Action<T> action)
		{
			for (int i = 0; i < list.Count; i++)
			{
				action(list[i]);
			}
		}
	}
}
