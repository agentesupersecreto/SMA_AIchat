using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000109 RID: 265
	[Serializable]
	public class WeightFlotante : BaseFlotanteSingleLayer
	{
		// Token: 0x06000782 RID: 1922 RVA: 0x0001A39C File Offset: 0x0001859C
		public WeightFlotante()
		{
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0001A3D8 File Offset: 0x000185D8
		public WeightFlotante(float Base)
		{
			base.InitBase(Base);
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x0001A419 File Offset: 0x00018619
		protected override ClampRange Range
		{
			get
			{
				return this.range;
			}
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0001A421 File Offset: 0x00018621
		protected override void LoadBase(float val)
		{
			this.m_base = Mathf.Clamp01(val);
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0001A42F File Offset: 0x0001862F
		protected override float Clamp(float valor)
		{
			this.range.maxValue = Mathf.Clamp01(this.range.maxValue);
			this.range.minValue = Mathf.Clamp01(this.range.minValue);
			return base.Clamp(valor);
		}

		// Token: 0x04000214 RID: 532
		public ClampRange range = new ClampRange
		{
			maxValue = 1f,
			minValue = 0f
		};
	}
}
