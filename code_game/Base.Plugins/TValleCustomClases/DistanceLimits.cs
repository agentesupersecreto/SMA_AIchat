using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000085 RID: 133
	public struct DistanceLimits
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x00010329 File Offset: 0x0000E529
		public static DistanceLimits All
		{
			get
			{
				return new DistanceLimits(0f, float.MaxValue);
			}
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0001033A File Offset: 0x0000E53A
		public DistanceLimits(float min, float max)
		{
			this.min = ((min < 0f) ? 0f : min);
			this.max = ((max < this.min) ? this.min : max);
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0001036A File Offset: 0x0000E56A
		public float sqrMin
		{
			get
			{
				return this.min * this.min;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003C6 RID: 966 RVA: 0x00010379 File Offset: 0x0000E579
		public float sqrMax
		{
			get
			{
				return this.max * this.max;
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x00010388 File Offset: 0x0000E588
		public bool IsInLimits(float distance)
		{
			return distance >= this.min && distance <= this.max;
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000103A4 File Offset: 0x0000E5A4
		public bool IsInLimits(Vector3 direction)
		{
			float sqrMagnitude = direction.sqrMagnitude;
			return sqrMagnitude >= this.sqrMin && sqrMagnitude <= this.sqrMax;
		}

		// Token: 0x040000CE RID: 206
		public float min;

		// Token: 0x040000CF RID: 207
		public float max;
	}
}
