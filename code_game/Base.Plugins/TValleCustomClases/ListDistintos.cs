using System;
using System.Collections.Generic;

namespace TValleCustomClases
{
	// Token: 0x02000081 RID: 129
	public static class ListDistintos
	{
		// Token: 0x060003B2 RID: 946 RVA: 0x0000FE7C File Offset: 0x0000E07C
		public static bool Distintos<T>(this List<T> a, List<T> b)
		{
			if (!a.Distintos<T>())
			{
				return false;
			}
			if (!b.Distintos<T>())
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				T t = a[i];
				if (b.Contains(t))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		public static bool DistintosSeveral<T>(this List<T> list, params List<T>[] lists)
		{
			for (int i = 0; i < lists.Length; i++)
			{
				if (!list.Distintos(lists[i]))
				{
					return false;
				}
			}
			for (int j = lists.Length - 1; j >= 0; j--)
			{
				for (int k = j - 1; k >= 0; k--)
				{
					if (!lists[j].Distintos(lists[k]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x0000FF1C File Offset: 0x0000E11C
		public static bool Distintos<T>(this List<T> list)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (EqualityComparer<T>.Default.Equals(list[i], list[j]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x0000FF68 File Offset: 0x0000E168
		public static bool Distintos<T>(this List<T> list, Func<T, T, bool> assert)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (EqualityComparer<T>.Default.Equals(list[i], list[j]) || !assert(list[i], list[j]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000FFCC File Offset: 0x0000E1CC
		public static bool Distintos<T>(this List<T> list, Func<T, T, bool> assert, out T duplicate)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (EqualityComparer<T>.Default.Equals(list[i], list[j]) || !assert(list[i], list[j]))
					{
						duplicate = list[i];
						return false;
					}
				}
			}
			duplicate = default(T);
			return true;
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00010044 File Offset: 0x0000E244
		public static bool DistintosToNull<T>(this List<T> list)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				if (list[i] == null)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x00010078 File Offset: 0x0000E278
		public static bool DistintosToNull<T>(this List<T> list, Predicate<T> TrueIfNull)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				T t = list[i];
				if (t == null || TrueIfNull(t))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x000100B4 File Offset: 0x0000E2B4
		[Obsolete("error")]
		public static bool Comparar<T>(this List<T> list, Func<T, T, bool> comparador)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (i != j && comparador(list[i], list[j]))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00010100 File Offset: 0x0000E300
		[Obsolete("error")]
		public static bool CompararV2<T>(this List<T> list, Func<T, T, bool> comparador)
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				for (int j = i - 1; j >= 0; j--)
				{
					if (EqualityComparer<T>.Default.Equals(list[i], list[j]) || comparador(list[i], list[j]))
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
