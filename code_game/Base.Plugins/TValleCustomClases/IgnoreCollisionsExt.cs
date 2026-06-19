using System;
using System.Collections.Generic;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200007D RID: 125
	public static class IgnoreCollisionsExt
	{
		// Token: 0x060003A3 RID: 931 RVA: 0x0000FAB8 File Offset: 0x0000DCB8
		public static void Collisions<T>(this List<T> list, Collider collider, bool ignore) where T : Collider
		{
			for (int i = 0; i < list.Count; i++)
			{
				Physics.IgnoreCollision(list[i], collider, ignore);
			}
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000FAEC File Offset: 0x0000DCEC
		public static void Collisions<T>(this HashSet<T> set, Collider collider, bool ignore) where T : Collider
		{
			foreach (T t in set)
			{
				Physics.IgnoreCollision(t, collider, ignore);
			}
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0000FB40 File Offset: 0x0000DD40
		public static void Collisions<T>(this HashSet<T> set, HashSet<T> others, bool ignore) where T : Collider
		{
			foreach (T t in others)
			{
				set.Collisions(t, ignore);
			}
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x0000FB94 File Offset: 0x0000DD94
		public static void Collisions<T>(this HashSet<T> set, List<T> others, bool ignore) where T : Collider
		{
			for (int i = 0; i < others.Count; i++)
			{
				T t = others[i];
				set.Collisions(t, ignore);
			}
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x0000FBC8 File Offset: 0x0000DDC8
		public static void Collisions<T>(this List<T> list, List<T> others, bool ignore) where T : Collider
		{
			for (int i = 0; i < others.Count; i++)
			{
				T t = others[i];
				list.Collisions(t, ignore);
			}
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x0000FBFC File Offset: 0x0000DDFC
		public static void Collisions<T>(this List<T> list, HashSet<T> others, bool ignore) where T : Collider
		{
			foreach (T t in others)
			{
				list.Collisions(t, ignore);
			}
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x0000FC50 File Offset: 0x0000DE50
		public static void RemoveDisabledAndTriggers<T>(this List<T> list) where T : Collider
		{
			for (int i = list.Count - 1; i >= 0; i--)
			{
				T t = list[i];
				if (!t.enabled || t.isTrigger)
				{
					list.RemoveAt(i);
				}
			}
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0000FC99 File Offset: 0x0000DE99
		public static void RemoveDisabledAndTriggers<T>(this HashSet<T> set) where T : Collider
		{
			set.RemoveWhere((T c) => !c.enabled || c.isTrigger);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0000FCC4 File Offset: 0x0000DEC4
		public static void CollisionsNonTriggers(this Rigidbody a, Rigidbody b, bool ignore)
		{
			a.GetComponentsInChildren<Collider>(false, IgnoreCollisionsExt.TEMP_A);
			b.GetComponentsInChildren<Collider>(false, IgnoreCollisionsExt.TEMP_b);
			IgnoreCollisionsExt.TEMP_A.RemoveDisabledAndTriggers<Collider>();
			IgnoreCollisionsExt.TEMP_b.RemoveDisabledAndTriggers<Collider>();
			IgnoreCollisionsExt.TEMP_A.Collisions(IgnoreCollisionsExt.TEMP_b, ignore);
			IgnoreCollisionsExt.TEMP_b.Clear();
			IgnoreCollisionsExt.TEMP_A.Clear();
		}

		// Token: 0x040000C9 RID: 201
		private static List<Collider> TEMP_A = new List<Collider>();

		// Token: 0x040000CA RID: 202
		private static List<Collider> TEMP_b = new List<Collider>();
	}
}
