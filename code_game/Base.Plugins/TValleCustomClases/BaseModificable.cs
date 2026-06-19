using System;
using UnityEngine;

namespace TValleCustomClases
{
	// Token: 0x02000065 RID: 101
	[Serializable]
	public abstract class BaseModificable
	{
		// Token: 0x06000310 RID: 784 RVA: 0x0000E0D2 File Offset: 0x0000C2D2
		public BaseModificable(float baseAmount)
			: this()
		{
			this.Base = baseAmount;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x0000E0E1 File Offset: 0x0000C2E1
		public BaseModificable()
		{
			this.UpdateTotal();
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000312 RID: 786
		// (set) Token: 0x06000313 RID: 787
		protected abstract float Base { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000314 RID: 788
		// (set) Token: 0x06000315 RID: 789
		protected abstract float Moded { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000316 RID: 790
		// (set) Token: 0x06000317 RID: 791
		protected abstract float PercentModed { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000E0EF File Offset: 0x0000C2EF
		public float total
		{
			get
			{
				this.UpdateTotal();
				return this.m_Total;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000319 RID: 793 RVA: 0x0000E0FD File Offset: 0x0000C2FD
		// (set) Token: 0x0600031A RID: 794 RVA: 0x0000E105 File Offset: 0x0000C305
		public float @base
		{
			get
			{
				return this.Base;
			}
			set
			{
				this.Base = value;
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000E10E File Offset: 0x0000C30E
		// (set) Token: 0x0600031C RID: 796 RVA: 0x0000E116 File Offset: 0x0000C316
		public float moded
		{
			get
			{
				return this.Moded;
			}
			set
			{
				this.Moded = value;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000E11F File Offset: 0x0000C31F
		// (set) Token: 0x0600031E RID: 798 RVA: 0x0000E127 File Offset: 0x0000C327
		public float percentModed
		{
			get
			{
				return this.PercentModed;
			}
			set
			{
				this.PercentModed = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600031F RID: 799
		public abstract float maxValue { get; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000320 RID: 800
		public abstract float minValue { get; }

		// Token: 0x06000321 RID: 801 RVA: 0x0000E130 File Offset: 0x0000C330
		public virtual void UpdateTotal()
		{
			this.m_Total = (this.Base + this.Moded) * (1f + this.PercentModed / 100f);
			if (this.m_Total > this.maxValue)
			{
				this.m_Total = this.maxValue;
				return;
			}
			if (this.m_Total < this.minValue)
			{
				this.m_Total = this.minValue;
			}
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000E198 File Offset: 0x0000C398
		private void OnValuesChanged()
		{
			this.UpdateTotal();
		}

		// Token: 0x040000A5 RID: 165
		[ReadOnlyUI]
		[SerializeField]
		protected float m_Total;
	}
}
