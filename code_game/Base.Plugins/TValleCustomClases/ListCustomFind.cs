using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000080 RID: 128
	public static class ListCustomFind
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x0000FE40 File Offset: 0x0000E040
		public static T Find<T, Y>(this List<T> list, Y param, Func<T, Y, bool> comparer)
		{
			for (int i = 0; i < list.Count; i++)
			{
				T t = list[i];
				if (comparer(t, param))
				{
					return t;
				}
			}
			return default(T);
		}
	}
}
