using System;

namespace Assets
{
	// Token: 0x02000106 RID: 262
	[Serializable]
	public class ValorFlotanteBaseLibre : BaseFlotanteSingleLayer
	{
		// Token: 0x06000777 RID: 1911 RVA: 0x0001A29C File Offset: 0x0001849C
		public ValorFlotanteBaseLibre()
		{
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0001A2D8 File Offset: 0x000184D8
		public ValorFlotanteBaseLibre(float Base)
		{
			base.InitBase(Base);
		}

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x0001A319 File Offset: 0x00018519
		protected override ClampRange Range
		{
			get
			{
				return this.range;
			}
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x0001A321 File Offset: 0x00018521
		protected override void LoadBase(float val)
		{
			this.m_base = val;
		}

		// Token: 0x17000151 RID: 337
		// (set) Token: 0x0600077B RID: 1915 RVA: 0x0001A32A File Offset: 0x0001852A
		public float baseSetter
		{
			set
			{
				this.LoadBase(value);
			}
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x0001A333 File Offset: 0x00018533
		public void SetBase(float val)
		{
			this.baseSetter = val;
		}

		// Token: 0x04000212 RID: 530
		public ClampRange range = new ClampRange
		{
			maxValue = float.MaxValue,
			minValue = float.MinValue
		};
	}
}
