using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x0200007F RID: 127
	public static class ListContainsExt
	{
		// Token: 0x060003AE RID: 942 RVA: 0x0000FD68 File Offset: 0x0000DF68
		public static bool Contains<T, Y>(this List<T> list, Y item, Func<T, Y, bool> comparer)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (comparer(list[i], item))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0000FD9C File Offset: 0x0000DF9C
		public static bool ContainsItemsNull<T>(this IList<T> list)
		{
			if (list.Count == 0)
			{
				return false;
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (EqualityComparer<T>.Default.Equals(list[i], default(T)))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
		public static bool AllItemsNull<T>(this IList<T> list)
		{
			if (list.Count == 0)
			{
				return false;
			}
			int num = 0;
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (EqualityComparer<T>.Default.Equals(list[i], default(T)))
				{
					num++;
				}
			}
			return num == list.Count;
		}
	}
}
