using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000032 RID: 50
public static class ListShuffleExt
{
	// Token: 0x060001D1 RID: 465 RVA: 0x0000A557 File Offset: 0x00008757
	public static void AddOrReplase<TKey, TValue>(this IDictionary<TKey, TValue> dicc, TKey key, TValue value)
	{
		if (dicc.ContainsKey(key))
		{
			dicc[key] = value;
			return;
		}
		dicc.Add(key, value);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000A573 File Offset: 0x00008773
	public static void AddOrSum<TKey>(this IDictionary<TKey, float> dicc, TKey key, float value)
	{
		if (dicc.ContainsKey(key))
		{
			dicc[key] += value;
			return;
		}
		dicc.Add(key, value);
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0000A598 File Offset: 0x00008798
	public static int Plus<TKey>(this IDictionary<TKey, int> dicc, TKey key, int plus)
	{
		int num;
		if (dicc.TryGetValue(key, out num))
		{
			int num2 = num + plus;
			dicc[key] = num2;
			return num2;
		}
		dicc.Add(key, plus);
		return plus;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0000A5C8 File Offset: 0x000087C8
	public static int Plus<TKey>(this IDictionary<TKey, int> dicc, ref TKey key, int plus) where TKey : struct
	{
		int num;
		if (dicc.TryGetValue(key, out num))
		{
			int num2 = num + plus;
			dicc[key] = num2;
			return num2;
		}
		dicc.Add(key, plus);
		return plus;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0000A608 File Offset: 0x00008808
	public static void Shuffle<T>(this IList<T> list)
	{
		int i = list.Count;
		while (i > 1)
		{
			i--;
			int num = Random.Range(0, i + 1);
			T t = list[num];
			list[num] = list[i];
			list[i] = t;
		}
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x0000A650 File Offset: 0x00008850
	public static void Shuffle<T>(this IList<T> list, int length)
	{
		int i = length;
		while (i > 1)
		{
			i--;
			int num = Random.Range(0, i + 1);
			T t = list[num];
			list[num] = list[i];
			list[i] = t;
		}
	}
}
