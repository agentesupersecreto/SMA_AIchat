using System;
using com.ootii.Collections;
using UnityEngine;

namespace com.ootii.Physics
{
	// Token: 0x0200001F RID: 31
	public class Force
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060001A0 RID: 416 RVA: 0x0000A4BE File Offset: 0x000086BE
		public float Magnitude
		{
			get
			{
				return this.Value.magnitude;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060001A1 RID: 417 RVA: 0x0000A4CB File Offset: 0x000086CB
		public Vector3 Direction
		{
			get
			{
				return this.Value.normalized;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060001A3 RID: 419 RVA: 0x0000A4E0 File Offset: 0x000086E0
		public static int Length
		{
			get
			{
				return Force.sPool.Length;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000A4EC File Offset: 0x000086EC
		public static Force Allocate()
		{
			Force force = Force.sPool.Allocate();
			force.Type = ForceMode.Force;
			force.Value = Vector3.zero;
			force.StartTime = 0f;
			force.Duration = 0f;
			return force;
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000A520 File Offset: 0x00008720
		public static Force Allocate(Vector3 rValue)
		{
			Force force = Force.sPool.Allocate();
			force.Type = ForceMode.Force;
			force.Value = rValue;
			force.StartTime = 0f;
			force.Duration = 0f;
			return force;
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000A550 File Offset: 0x00008750
		public static void Release(Force rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			Force.sPool.Release(rInstance);
		}

		// Token: 0x04000100 RID: 256
		public ForceMode Type;

		// Token: 0x04000101 RID: 257
		public Vector3 Value;

		// Token: 0x04000102 RID: 258
		public float StartTime;

		// Token: 0x04000103 RID: 259
		public float Duration;

		// Token: 0x04000104 RID: 260
		private static ObjectPool<Force> sPool = new ObjectPool<Force>(20, 5);
	}
}
