using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000069 RID: 105
	[Serializable]
	public class RealAngleModificable : BaseModificable
	{
		// Token: 0x06000329 RID: 809 RVA: 0x0000E1CD File Offset: 0x0000C3CD
		public RealAngleModificable(float baseAmount)
			: base(baseAmount)
		{
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0000E1D6 File Offset: 0x0000C3D6
		public RealAngleModificable()
		{
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000E1DE File Offset: 0x0000C3DE
		// (set) Token: 0x0600032C RID: 812 RVA: 0x0000E1E6 File Offset: 0x0000C3E6
		protected override float Base
		{
			get
			{
				return this.m_Base;
			}
			set
			{
				this.m_Base = value;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000E1EF File Offset: 0x0000C3EF
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0000E1F7 File Offset: 0x0000C3F7
		protected override float Moded
		{
			get
			{
				return this.m_Moded;
			}
			set
			{
				this.m_Moded = value;
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000E200 File Offset: 0x0000C400
		// (set) Token: 0x06000330 RID: 816 RVA: 0x0000E208 File Offset: 0x0000C408
		protected override float PercentModed
		{
			get
			{
				return this.m_PercentModed;
			}
			set
			{
				this.m_PercentModed = value;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000331 RID: 817 RVA: 0x0000E211 File Offset: 0x0000C411
		public override float maxValue
		{
			get
			{
				return 180f;
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000E218 File Offset: 0x0000C418
		public override float minValue
		{
			get
			{
				return -180f;
			}
		}

		// Token: 0x040000A9 RID: 169
		public const float MaxValue = 180f;

		// Token: 0x040000AA RID: 170
		public const float MinValue = -180f;

		// Token: 0x040000AB RID: 171
		[Range(-180f, 180f)]
		[SerializeField]
		protected float m_Base;

		// Token: 0x040000AC RID: 172
		[Range(-180f, 180f)]
		[SerializeField]
		protected float m_Moded;

		// Token: 0x040000AD RID: 173
		[Range(-1000000f, 1000000f)]
		[SerializeField]
		protected float m_PercentModed;
	}
}
