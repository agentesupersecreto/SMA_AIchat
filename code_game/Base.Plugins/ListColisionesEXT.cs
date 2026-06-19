using System;
using System.Collections.Generic;

// Token: 0x02000031 RID: 49
public static class ListColisionesEXT
{
	// Token: 0x060001CA RID: 458 RVA: 0x0000A2DC File Offset: 0x000084DC
	public static void ColisionarContra<T>(this IList<T> listA, IList<T> listB, Action<T, T> onCollision)
	{
		if (listA == null || listA.Count == 0)
		{
			return;
		}
		if (listB == null || listB.Count == 0)
		{
			return;
		}
		for (int i = 0; i < listA.Count; i++)
		{
			T t = listA[i];
			for (int j = 0; j < listB.Count; j++)
			{
				onCollision(t, listB[j]);
			}
		}
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000A33C File Offset: 0x0000853C
	public static void ColisionarContraReadOnly<T>(this IReadOnlyList<T> listA, IReadOnlyList<T> listB, Action<T, T> onCollision)
	{
		if (listA == null || listA.Count == 0)
		{
			return;
		}
		if (listB == null || listB.Count == 0)
		{
			return;
		}
		for (int i = 0; i < listA.Count; i++)
		{
			T t = listA[i];
			for (int j = 0; j < listB.Count; j++)
			{
				onCollision(t, listB[j]);
			}
		}
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000A39C File Offset: 0x0000859C
	public static void Colisionar<T>(this IList<T> list, Action<T, T> onCollision)
	{
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				onCollision(list[i], list[j]);
			}
		}
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000A3EC File Offset: 0x000085EC
	public static void ColisionarReadOnly<T>(this IReadOnlyList<T> list, Action<T, T> onCollision)
	{
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				onCollision(list[i], list[j]);
			}
		}
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000A43C File Offset: 0x0000863C
	public static void CheckColisionASC<T, T_Arg>(this IReadOnlyList<T> list, Func<T, T, bool> isCollision, ListColisionesEXT.OnListCollisionHandler<T, T_Arg> onCollision, ref T_Arg argument)
	{
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				T t = list[i];
				T t2 = list[j];
				if (isCollision(t, t2))
				{
					onCollision(t, t2, ref argument);
				}
			}
		}
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0000A49C File Offset: 0x0000869C
	public static void CheckColisionASC<T>(this IList<T> list, Func<T, T, bool> isCollision, Action<T, T> onCollision)
	{
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = list.Count - 1; i >= 0; i--)
		{
			for (int j = i - 1; j >= 0; j--)
			{
				T t = list[i];
				T t2 = list[j];
				if (isCollision(t, t2))
				{
					onCollision(t, t2);
				}
			}
		}
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000A4F8 File Offset: 0x000086F8
	public static void CheckColisionDESC<T>(this IList<T> list, Func<T, T, bool> isCollision, Action<T, T> onCollision)
	{
		if (list == null || list.Count == 0)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = i + 1; j < list.Count; j++)
			{
				T t = list[i];
				T t2 = list[j];
				if (isCollision(t, t2))
				{
					onCollision(t, t2);
				}
			}
		}
	}

	// Token: 0x020001A3 RID: 419
	// (Invoke) Token: 0x06000BFB RID: 3067
	public delegate void OnListCollisionHandler<T, T_Arg>(T a, T b, ref T_Arg argument);
}
