using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006A RID: 106
	[Serializable]
	public class RealModificable : BaseModificable
	{
		// Token: 0x06000333 RID: 819 RVA: 0x0000E21F File Offset: 0x0000C41F
		public RealModificable(float baseAmount)
			: base(baseAmount)
		{
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000E228 File Offset: 0x0000C428
		public RealModificable()
		{
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000E230 File Offset: 0x0000C430
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0000E238 File Offset: 0x0000C438
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0000E241 File Offset: 0x0000C441
		// (set) Token: 0x06000338 RID: 824 RVA: 0x0000E249 File Offset: 0x0000C449
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

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000339 RID: 825 RVA: 0x0000E252 File Offset: 0x0000C452
		// (set) Token: 0x0600033A RID: 826 RVA: 0x0000E25A File Offset: 0x0000C45A
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

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0000E263 File Offset: 0x0000C463
		public override float maxValue
		{
			get
			{
				return 2.0002E+10f;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600033C RID: 828 RVA: 0x0000E26A File Offset: 0x0000C46A
		public override float minValue
		{
			get
			{
				return -2.0002E+10f;
			}
		}

		// Token: 0x040000AE RID: 174
		public const float MaxValue = 2.0002E+10f;

		// Token: 0x040000AF RID: 175
		public const float MinValue = -2.0002E+10f;

		// Token: 0x040000B0 RID: 176
		[Range(-1000000f, 1000000f)]
		[SerializeField]
		protected float m_Base;

		// Token: 0x040000B1 RID: 177
		[Range(-1000000f, 1000000f)]
		[SerializeField]
		protected float m_Moded;

		// Token: 0x040000B2 RID: 178
		[Range(-1000000f, 1000000f)]
		[SerializeField]
		protected float m_PercentModed;
	}
}
