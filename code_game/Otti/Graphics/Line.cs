using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003B RID: 59
	public class Line
	{
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x0000F98B File Offset: 0x0000DB8B
		public static int Length
		{
			get
			{
				return Line.sPool.Length;
			}
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0000F997 File Offset: 0x0000DB97
		public static Line Allocate()
		{
			return Line.sPool.Allocate();
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000F9A4 File Offset: 0x0000DBA4
		public static void Release(Line rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Transform = null;
			rInstance.Start = Vector3.zero;
			rInstance.End = Vector3.zero;
			rInstance.Color = Color.white;
			rInstance.ExpirationTime = 0f;
			Line.sPool.Release(rInstance);
		}

		// Token: 0x04000197 RID: 407
		public Transform Transform;

		// Token: 0x04000198 RID: 408
		public Vector3 Start = Vector3.zero;

		// Token: 0x04000199 RID: 409
		public Vector3 End = Vector3.zero;

		// Token: 0x0400019A RID: 410
		public Color Color = Color.white;

		// Token: 0x0400019B RID: 411
		public float ExpirationTime;

		// Token: 0x0400019C RID: 412
		private static ObjectPool<Line> sPool = new ObjectPool<Line>(20, 5);
	}
}
