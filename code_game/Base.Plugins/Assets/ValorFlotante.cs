using System;

namespace Assets
{
	// Token: 0x02000105 RID: 261
	[Serializable]
	public class ValorFlotante : BaseFlotanteSingleLayer
	{
		// Token: 0x06000773 RID: 1907 RVA: 0x0001A20C File Offset: 0x0001840C
		public ValorFlotante()
		{
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001A248 File Offset: 0x00018448
		public ValorFlotante(float Base)
		{
			base.InitBase(Base);
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x0001A289 File Offset: 0x00018489
		protected override ClampRange Range
		{
			get
			{
				return this.range;
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001A291 File Offset: 0x00018491
		protected override void LoadBase(float val)
		{
			this.m_base = val;
		}

		// Token: 0x04000211 RID: 529
		public ClampRange range = new ClampRange
		{
			maxValue = float.MaxValue,
			minValue = float.MinValue
		};
	}
}
