using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200002E RID: 46
public static class DiccEXT
{
	// Token: 0x06000195 RID: 405 RVA: 0x00009498 File Offset: 0x00007698
	public static TValue GetValueNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dicc, TKey key) where TValue : new()
	{
		TValue tvalue;
		if (!dicc.TryGetValue(key, out tvalue))
		{
			tvalue = new TValue();
			dicc.Add(key, tvalue);
		}
		return tvalue;
	}

	// Token: 0x06000196 RID: 406 RVA: 0x000094C0 File Offset: 0x000076C0
	public static TValue GetValueNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dicc, TKey key, TValue defaultValue)
	{
		TValue tvalue;
		if (!dicc.TryGetValue(key, out tvalue))
		{
			tvalue = defaultValue;
			dicc.Add(key, tvalue);
		}
		return tvalue;
	}

	// Token: 0x06000197 RID: 407 RVA: 0x000094E4 File Offset: 0x000076E4
	public static TValue GetValueNotNull<TKey, TValue>(this IDictionary<TKey, TValue> dicc, TKey key, Func<TKey, TValue> constructor)
	{
		TValue tvalue;
		if (!dicc.TryGetValue(key, out tvalue))
		{
			try
			{
				tvalue = constructor(key);
			}
			catch (Exception ex)
			{
				Debug.LogError("Key: " + key.ToString() + " fallo.");
				throw ex;
			}
			dicc.Add(key, tvalue);
		}
		return tvalue;
	}
}
