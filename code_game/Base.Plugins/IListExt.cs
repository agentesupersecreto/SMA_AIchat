using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000030 RID: 48
public static class IListExt
{
	// Token: 0x060001A8 RID: 424 RVA: 0x0000990D File Offset: 0x00007B0D
	public static int GetWrappedIndex(this int index, int length)
	{
		if (length <= 0)
		{
			throw new ArgumentException("Length must be greater than 0.");
		}
		return (index % length + length) % length;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00009928 File Offset: 0x00007B28
	public static void ForEach(this IEnumerable enumeration, Action<object, int> action)
	{
		int num = 0;
		foreach (object obj in enumeration)
		{
			action(obj, num);
			num++;
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00009980 File Offset: 0x00007B80
	public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T, int> action)
	{
		int num = 0;
		foreach (T t in enumeration)
		{
			action(t, num);
			num++;
		}
	}

	// Token: 0x060001AB RID: 427 RVA: 0x000099D0 File Offset: 0x00007BD0
	public static void ForEach(this IEnumerable enumeration, Action<object> action)
	{
		foreach (object obj in enumeration)
		{
			action(obj);
		}
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00009A20 File Offset: 0x00007C20
	public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
	{
		foreach (T t in enumeration)
		{
			action(t);
		}
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00009A68 File Offset: 0x00007C68
	public static bool ScrambledAndCountEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
	{
		int num = list1.Count<T>();
		int num2 = list2.Count<T>();
		return num == num2 && (num == 0 || list1.ScrambledEquals(list2));
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00009A98 File Offset: 0x00007C98
	public static bool ScrambledAndCountEquals<T, T_Arg>(this IEnumerable<T> list1, IEnumerable<T> list2, Func<T, T_Arg> argGetter)
	{
		int num = list1.Count<T>();
		int num2 = list2.Count<T>();
		return num == num2 && (num == 0 || list1.ScrambledEquals(list2, argGetter));
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00009AC8 File Offset: 0x00007CC8
	public static bool ScrambledAndCountEquals<T, T2>(this IEnumerable<T> list1, IEnumerable<T2> list2, Func<T2, T> getter)
	{
		int num = list1.Count<T>();
		int num2 = list2.Count<T2>();
		return num == num2 && (num == 0 || list1.ScrambledEquals(list2, getter));
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00009AF8 File Offset: 0x00007CF8
	public static bool ScrambledEquals<T>(this IEnumerable<T> list1, IEnumerable<T> list2)
	{
		Dictionary<T, int> dictionary = new Dictionary<T, int>();
		foreach (T t in list1)
		{
			if (dictionary.ContainsKey(t))
			{
				Dictionary<T, int> dictionary2 = dictionary;
				T t2 = t;
				int num = dictionary2[t2];
				dictionary2[t2] = num + 1;
			}
			else
			{
				dictionary.Add(t, 1);
			}
		}
		foreach (T t3 in list2)
		{
			if (!dictionary.ContainsKey(t3))
			{
				return false;
			}
			Dictionary<T, int> dictionary3 = dictionary;
			T t2 = t3;
			int num = dictionary3[t2];
			dictionary3[t2] = num - 1;
		}
		return dictionary.Values.All((int c) => c == 0);
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00009BF0 File Offset: 0x00007DF0
	public static bool ScrambledEquals<T, T_Arg>(this IEnumerable<T> list1, IEnumerable<T> list2, Func<T, T_Arg> argGetter)
	{
		Dictionary<T_Arg, int> dictionary = new Dictionary<T_Arg, int>();
		foreach (T t in list1)
		{
			T_Arg t_Arg = argGetter(t);
			if (dictionary.ContainsKey(t_Arg))
			{
				Dictionary<T_Arg, int> dictionary2 = dictionary;
				T_Arg t_Arg2 = t_Arg;
				int num = dictionary2[t_Arg2];
				dictionary2[t_Arg2] = num + 1;
			}
			else
			{
				dictionary.Add(t_Arg, 1);
			}
		}
		foreach (T t2 in list2)
		{
			T_Arg t_Arg3 = argGetter(t2);
			if (!dictionary.ContainsKey(t_Arg3))
			{
				return false;
			}
			Dictionary<T_Arg, int> dictionary3 = dictionary;
			T_Arg t_Arg2 = t_Arg3;
			int num = dictionary3[t_Arg2];
			dictionary3[t_Arg2] = num - 1;
		}
		return dictionary.Values.All((int c) => c == 0);
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00009D00 File Offset: 0x00007F00
	public static bool ScrambledEquals<T, T2>(this IEnumerable<T> list1, IEnumerable<T2> list2, Func<T2, T> getter)
	{
		Dictionary<T, int> dictionary = new Dictionary<T, int>();
		foreach (T t in list1)
		{
			if (dictionary.ContainsKey(t))
			{
				Dictionary<T, int> dictionary2 = dictionary;
				T t2 = t;
				int num = dictionary2[t2];
				dictionary2[t2] = num + 1;
			}
			else
			{
				dictionary.Add(t, 1);
			}
		}
		foreach (T2 t3 in list2)
		{
			T t4 = getter(t3);
			if (!dictionary.ContainsKey(t4))
			{
				return false;
			}
			Dictionary<T, int> dictionary3 = dictionary;
			T t2 = t4;
			int num = dictionary3[t2];
			dictionary3[t2] = num - 1;
		}
		return dictionary.Values.All((int c) => c == 0);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00009E08 File Offset: 0x00008008
	public static int IndexOf<T>(this IReadOnlyList<T> self, T elementToFind)
	{
		if (self is IList<T>)
		{
			return ((IList<T>)self).IndexOf(elementToFind);
		}
		for (int i = 0; i < self.Count; i++)
		{
			if (object.Equals(self[i], elementToFind))
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00009E5B File Offset: 0x0000805B
	public static bool ContieneIndexReadOnly<T>(this IReadOnlyCollection<T> list, int index)
	{
		return index >= 0 && index < list.Count;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00009E6C File Offset: 0x0000806C
	public static bool ContainsAllItems<T>(this IEnumerable<T> a, IEnumerable<T> b)
	{
		return !b.Except(a).Any<T>();
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00009E7D File Offset: 0x0000807D
	public static bool ContainsSomeItem<T>(this IEnumerable<T> a, IEnumerable<T> b)
	{
		return a.Intersect(b).Any<T>();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00009E8B File Offset: 0x0000808B
	public static bool ContieneIndexBase(this ICollection list, int index)
	{
		return index >= 0 && index < list.Count;
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00009E9C File Offset: 0x0000809C
	public static bool ContieneIndex<T>(this ICollection<T> list, int index)
	{
		return index >= 0 && index < list.Count;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00009EB0 File Offset: 0x000080B0
	public static T GetValueOrDefault<T>(this IList<T> list, int index)
	{
		if (!list.ContieneIndex(index))
		{
			return default(T);
		}
		return list[index];
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00009ED8 File Offset: 0x000080D8
	public static void SetValueAt<T>(this IList<T> list, int index, T value)
	{
		if (index < 0)
		{
			return;
		}
		while (!list.ContieneIndex(index))
		{
			list.Add(default(T));
		}
		list[index] = value;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00009F0C File Offset: 0x0000810C
	public static T GetValueOrDefaultReadOnly<T>(this IReadOnlyList<T> list, int index)
	{
		if (!list.ContieneIndexReadOnly(index))
		{
			return default(T);
		}
		return list[index];
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00009F34 File Offset: 0x00008134
	public static int RandomIndexConPreferenciaAlPrimeroReadOnly<T>(this IReadOnlyCollection<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		if (list.Count == 0)
		{
			return -1;
		}
		if (list.Count == 1)
		{
			return 0;
		}
		if (maxCount <= 0)
		{
			maxCount = list.Count;
		}
		maxCount = Math.Min(list.Count, maxCount);
		probabilidadInicial /= 100f;
		float num = 1f / (float)list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			if (i > maxCount)
			{
				return 0;
			}
			int num2 = list.Count - i;
			float num3 = num * (float)num2;
			if ((probabilidadInicial * num3).ProcMod(1f))
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00009FC0 File Offset: 0x000081C0
	public static int RandomIndexConPreferenciaAlPrimeroNoChanceMod<T>(this ICollection<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		if (list.Count == 0)
		{
			return -1;
		}
		if (list.Count == 1)
		{
			return 0;
		}
		if (maxCount <= 0)
		{
			maxCount = list.Count;
		}
		maxCount = Math.Min(list.Count, maxCount);
		probabilidadInicial /= 100f;
		for (int i = 0; i < list.Count; i++)
		{
			if (i > maxCount)
			{
				return 0;
			}
			if (probabilidadInicial.ProcMod(1f))
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000A02C File Offset: 0x0000822C
	public static int RandomIndexConPreferenciaAlPrimero<T>(this ICollection<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		if (list.Count == 0)
		{
			return -1;
		}
		if (list.Count == 1)
		{
			return 0;
		}
		if (maxCount <= 0)
		{
			maxCount = list.Count;
		}
		maxCount = Math.Min(list.Count, maxCount);
		probabilidadInicial /= 100f;
		float num = 1f / (float)list.Count;
		for (int i = 0; i < list.Count; i++)
		{
			if (i > maxCount)
			{
				return 0;
			}
			int num2 = list.Count - i;
			float num3 = num * (float)num2;
			if ((probabilidadInicial * num3).ProcMod(1f))
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000A0B6 File Offset: 0x000082B6
	public static int NextIndexSafe(this int count, int currentIndex)
	{
		currentIndex++;
		if (currentIndex >= count)
		{
			return 0;
		}
		return currentIndex;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000A0C4 File Offset: 0x000082C4
	public static int NextIndexSafe(this ICollection collection, int currentIndex)
	{
		currentIndex++;
		if (currentIndex >= collection.Count)
		{
			return 0;
		}
		return currentIndex;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000A0D7 File Offset: 0x000082D7
	public static int RandomIndex<T>(this IList<T> list)
	{
		if (list.Count == 0)
		{
			return -1;
		}
		if (list.Count == 1)
		{
			return 0;
		}
		return Random.Range(0, list.Count);
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000A0FC File Offset: 0x000082FC
	public static IEnumerable<T> RandomTake<T>(this IEnumerable<T> enumerable, int count)
	{
		return from par in (from item in enumerable
				select new ValueTuple<T, float>(item, Random.value) into par
				orderby par.Item2
				select par).Take(count)
			select par.Item1;
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000A17C File Offset: 0x0000837C
	public static int RandomIndex<T>(this IReadOnlyCollection<T> list)
	{
		if (list.Count == 0)
		{
			return -1;
		}
		if (list.Count == 1)
		{
			return 0;
		}
		return Random.Range(0, list.Count);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0000A1A0 File Offset: 0x000083A0
	public static T RandomItem<T>(this IList<T> list)
	{
		if (list.Count <= 0)
		{
			return default(T);
		}
		return list[Random.Range(0, list.Count)];
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000A1D4 File Offset: 0x000083D4
	public static T RandomItemReadOnly<T>(this IReadOnlyList<T> list)
	{
		if (list.Count <= 0)
		{
			return default(T);
		}
		return list[Random.Range(0, list.Count)];
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000A208 File Offset: 0x00008408
	public static T RandomItemConPreferenciaAlPrimeroNoChaceMod<T>(this IList<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		int num = list.RandomIndexConPreferenciaAlPrimeroNoChanceMod(probabilidadInicial, maxCount);
		if (num < 0)
		{
			return default(T);
		}
		return list[num];
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000A234 File Offset: 0x00008434
	public static T RandomItemConPreferenciaAlPrimero<T>(this IList<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		int num = list.RandomIndexConPreferenciaAlPrimero(probabilidadInicial, maxCount);
		if (num < 0)
		{
			return default(T);
		}
		return list[num];
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000A260 File Offset: 0x00008460
	public static T RandomItemConPreferenciaAlPrimeroReadOnly<T>(this IReadOnlyList<T> list, float probabilidadInicial = 50f, int maxCount = -1)
	{
		int num = list.RandomIndexConPreferenciaAlPrimeroReadOnly(probabilidadInicial, maxCount);
		if (num < 0)
		{
			return default(T);
		}
		return list[num];
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000A28C File Offset: 0x0000848C
	public static T MaxByOrDefault<T>(this IList<T> list, Func<T, float> valueGetter)
	{
		int count = list.Count;
		T t = default(T);
		float num = float.MinValue;
		for (int i = 0; i < count; i++)
		{
			T t2 = list[i];
			float num2 = valueGetter(t2);
			if (num2 > num)
			{
				num = num2;
				t = t2;
			}
		}
		return t;
	}
}
