using System;

namespace Assets
{
	// Token: 0x02000108 RID: 264
	[Serializable]
	public class ValorFlotanteDoble : BaseFlotanteDobleLayer
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x0001A344 File Offset: 0x00018544
		protected override ClampRange Range
		{
			get
			{
				return this.range;
			}
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001A34C File Offset: 0x0001854C
		protected override void LoadBase(float val)
		{
			this.m_base = val;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001A355 File Offset: 0x00018555
		protected override void LoadBase2(float val)
		{
			this.m_base2 = val;
		}

		// Token: 0x04000213 RID: 531
		public ClampRange range = new ClampRange
		{
			maxValue = float.MaxValue,
			minValue = float.MinValue
		};
	}
}
