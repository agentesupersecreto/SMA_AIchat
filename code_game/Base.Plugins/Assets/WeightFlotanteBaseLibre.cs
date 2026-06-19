using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200010A RID: 266
	[Serializable]
	public class WeightFlotanteBaseLibre : BaseFlotanteSingleLayer
	{
		// Token: 0x06000787 RID: 1927 RVA: 0x0001A470 File Offset: 0x00018670
		public WeightFlotanteBaseLibre()
		{
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x0001A4AC File Offset: 0x000186AC
		public WeightFlotanteBaseLibre(float Base)
		{
			base.InitBase(Base);
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000789 RID: 1929 RVA: 0x0001A4ED File Offset: 0x000186ED
		protected override ClampRange Range
		{
			get
			{
				return this.range;
			}
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0001A4F5 File Offset: 0x000186F5
		protected override void LoadBase(float val)
		{
			if (this.clampBaseComoSiFueraAnguloAOne)
			{
				this.m_base = val.ToWeight();
				return;
			}
			this.m_base = Mathf.Clamp01(val);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001A518 File Offset: 0x00018718
		protected override float Clamp(float valor)
		{
			this.range.maxValue = Mathf.Clamp01(this.range.maxValue);
			this.range.minValue = Mathf.Clamp01(this.range.minValue);
			return base.Clamp(valor);
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0001A557 File Offset: 0x00018757
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x0001A55F File Offset: 0x0001875F
		public bool clampBaseComoSiFueraAnguloAOne { get; set; }

		// Token: 0x17000156 RID: 342
		// (set) Token: 0x0600078E RID: 1934 RVA: 0x0001A568 File Offset: 0x00018768
		public float baseSetter
		{
			set
			{
				this.LoadBase(value);
			}
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0001A571 File Offset: 0x00018771
		public void SetBase(float val)
		{
			this.baseSetter = val;
		}

		// Token: 0x04000215 RID: 533
		public ClampRange range = new ClampRange
		{
			maxValue = 1f,
			minValue = 0f
		};
	}
}
