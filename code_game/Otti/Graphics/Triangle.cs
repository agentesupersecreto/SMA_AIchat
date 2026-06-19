using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Graphics
{
	// Token: 0x0200003F RID: 63
	public class Triangle
	{
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000FC36 File Offset: 0x0000DE36
		public static int Length
		{
			get
			{
				return Triangle.sPool.Length;
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x0000FC42 File Offset: 0x0000DE42
		public static Triangle Allocate()
		{
			return Triangle.sPool.Allocate();
		}

		// Token: 0x060002FD RID: 765 RVA: 0x0000FC50 File Offset: 0x0000DE50
		public static void Release(Triangle rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Transform = null;
			rInstance.Point1 = Vector3.zero;
			rInstance.Point2 = Vector3.zero;
			rInstance.Point3 = Vector3.zero;
			rInstance.Color = Color.white;
			rInstance.ExpirationTime = 0f;
			Triangle.sPool.Release(rInstance);
		}

		// Token: 0x040001B4 RID: 436
		public Transform Transform;

		// Token: 0x040001B5 RID: 437
		public Vector3 Point1 = Vector3.zero;

		// Token: 0x040001B6 RID: 438
		public Vector3 Point2 = Vector3.zero;

		// Token: 0x040001B7 RID: 439
		public Vector3 Point3 = Vector3.zero;

		// Token: 0x040001B8 RID: 440
		public Color Color = Color.white;

		// Token: 0x040001B9 RID: 441
		public float ExpirationTime;

		// Token: 0x040001BA RID: 442
		private static ObjectPool<Triangle> sPool = new ObjectPool<Triangle>(20, 5);
	}
}
