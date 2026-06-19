using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000083 RID: 131
	public static class RemoveDuplicatesListExt
	{
		// Token: 0x060003BC RID: 956 RVA: 0x00010190 File Offset: 0x0000E390
		public static void RemoveDuplicates<T>(this List<T> list) where T : class
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = list.Count - 1; j >= 0; j--)
				{
					if (i != j && list[i] == list[j])
					{
						list.RemoveAt(j);
						i--;
					}
				}
			}
		}

		// Token: 0x060003BD RID: 957 RVA: 0x000101EC File Offset: 0x0000E3EC
		public static void RemoveDuplicates<T>(this List<T> list, Func<T, T, bool> comparer) where T : class
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = list.Count - 1; j >= 0; j--)
				{
					if (i != j)
					{
						T t = list[i];
						T t2 = list[j];
						if (t == t2 || comparer(t, t2))
						{
							list.RemoveAt(j);
							i--;
						}
					}
				}
			}
		}
	}
}
