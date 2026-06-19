using System;

namespace Assets
{
	// Token: 0x0200012F RID: 303
	[Serializable]
	public struct ValorModificable
	{
		// Token: 0x06000888 RID: 2184 RVA: 0x0001C80C File Offset: 0x0001AA0C
		public ValorModificable(float @base)
		{
			this.@base = @base;
			this.added = 0f;
			this.percentModed = 0f;
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000889 RID: 2185 RVA: 0x0001C82B File Offset: 0x0001AA2B
		// (set) Token: 0x0600088A RID: 2186 RVA: 0x0001C83F File Offset: 0x0001AA3F
		public float moded
		{
			get
			{
				return 1f + this.percentModed / 100f;
			}
			set
			{
				this.percentModed = (value - 1f) * 100f;
			}
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x0001C854 File Offset: 0x0001AA54
		public float total
		{
			get
			{
				return (this.@base + this.added) * (1f + this.percentModed / 100f);
			}
		}

		// Token: 0x04000231 RID: 561
		public float @base;

		// Token: 0x04000232 RID: 562
		public float added;

		// Token: 0x04000233 RID: 563
		public float percentModed;
	}
}
