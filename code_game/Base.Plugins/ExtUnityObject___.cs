using System;
using UnityEngine;

// Token: 0x02000034 RID: 52
public static class ExtUnityObject___
{
	// Token: 0x060001E2 RID: 482 RVA: 0x0000A8A0 File Offset: 0x00008AA0
	public static T Coalescing<T>(this T obj) where T : Object
	{
		if (obj == null)
		{
			return default(T);
		}
		return obj;
	}
}
