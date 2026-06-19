using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x0200006B RID: 107
	[Serializable]
	public class RealModificablePercentage : BaseModificable
	{
		// Token: 0x0600033D RID: 829 RVA: 0x0000E271 File Offset: 0x0000C471
		public RealModificablePercentage(float baseAmount)
			: base(baseAmount)
		{
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0000E27A File Offset: 0x0000C47A
		public RealModificablePercentage()
		{
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000E282 File Offset: 0x0000C482
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0000E28A File Offset: 0x0000C48A
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

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000E293 File Offset: 0x0000C493
		// (set) Token: 0x06000342 RID: 834 RVA: 0x0000E29B File Offset: 0x0000C49B
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

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000343 RID: 835 RVA: 0x0000E2A4 File Offset: 0x0000C4A4
		// (set) Token: 0x06000344 RID: 836 RVA: 0x0000E2AB File Offset: 0x0000C4AB
		protected override float PercentModed
		{
			get
			{
				return 1f;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000345 RID: 837 RVA: 0x0000E2B2 File Offset: 0x0000C4B2
		public override float maxValue
		{
			get
			{
				return 100f;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000E2B9 File Offset: 0x0000C4B9
		public override float minValue
		{
			get
			{
				return -100f;
			}
		}

		// Token: 0x040000B3 RID: 179
		public const float MaxValue = 100f;

		// Token: 0x040000B4 RID: 180
		public const float MinValue = -100f;

		// Token: 0x040000B5 RID: 181
		[Range(-100f, 100f)]
		[SerializeField]
		protected float m_Base;

		// Token: 0x040000B6 RID: 182
		[Range(-100f, 100f)]
		[SerializeField]
		protected float m_Moded;
	}
}
