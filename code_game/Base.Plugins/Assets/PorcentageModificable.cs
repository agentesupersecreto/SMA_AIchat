using System;

namespace Assets
{
	// Token: 0x0200012E RID: 302
	[Serializable]
	public struct PorcentageModificable
	{
		// Token: 0x17000176 RID: 374
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0001C6DA File Offset: 0x0001A8DA
		public static PorcentageModificable _100
		{
			get
			{
				return new PorcentageModificable(100f);
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x0001C6E6 File Offset: 0x0001A8E6
		public static PorcentageModificable _50
		{
			get
			{
				return new PorcentageModificable(50f);
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0001C6F4 File Offset: 0x0001A8F4
		public PorcentageModificable(float @base)
		{
			this.@base = @base;
			this.percentModed = (this.moded = 0f);
		}

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x06000883 RID: 2179 RVA: 0x0001C71C File Offset: 0x0001A91C
		public float totalUnClamped
		{
			get
			{
				return (this.@base + this.moded) * (1f + this.percentModed / 100f);
			}
		}

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x0001C740 File Offset: 0x0001A940
		public float total
		{
			get
			{
				float num = (this.@base + this.moded) * (1f + this.percentModed / 100f);
				if (num < 0f)
				{
					return 0f;
				}
				if (num > 100f)
				{
					return 100f;
				}
				return num;
			}
		}

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x06000885 RID: 2181 RVA: 0x0001C78B File Offset: 0x0001A98B
		public float mod
		{
			get
			{
				return this.total / 100f;
			}
		}

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x0001C799 File Offset: 0x0001A999
		public Percentage percent
		{
			get
			{
				return new Percentage(this.total);
			}
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0001C7A8 File Offset: 0x0001A9A8
		public void CapMaxValue(float max)
		{
			if (this.percentModed != 0f)
			{
				throw new NotSupportedException();
			}
			float total = this.total;
			if (max < 0f)
			{
				max = 0f;
			}
			if (max >= total || total <= 0f)
			{
				return;
			}
			this.moded = max / (1f + this.percentModed / 100f) - this.@base;
		}

		// Token: 0x0400022E RID: 558
		public float @base;

		// Token: 0x0400022F RID: 559
		public float moded;

		// Token: 0x04000230 RID: 560
		public float percentModed;
	}
}
