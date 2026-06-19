using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000132 RID: 306
	[Serializable]
	public struct PercentageRange
	{
		// Token: 0x06000899 RID: 2201 RVA: 0x0001C93C File Offset: 0x0001AB3C
		public PercentageRange(float max)
		{
			this.m_min = 0f;
			this.m_max = Mathf.Clamp(max, 0f, 100f);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0001C95F File Offset: 0x0001AB5F
		public PercentageRange(float min, float max)
		{
			this.m_min = Mathf.Clamp(min, 0f, 100f);
			this.m_max = Mathf.Clamp(max, 0f, 100f);
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x0600089B RID: 2203 RVA: 0x0001C990 File Offset: 0x0001AB90
		public float min
		{
			get
			{
				float num;
				if (this.m_min > this.m_max)
				{
					num = this.m_max;
				}
				else
				{
					num = this.m_min;
				}
				return Mathf.Clamp(num, 0f, 100f);
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x0600089C RID: 2204 RVA: 0x0001C9CC File Offset: 0x0001ABCC
		public float max
		{
			get
			{
				float num;
				if (this.m_max < this.m_min)
				{
					num = this.m_min;
				}
				else
				{
					num = this.m_max;
				}
				return Mathf.Clamp(num, 0f, 100f);
			}
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x0001CA07 File Offset: 0x0001AC07
		public bool PorDebajo(float value)
		{
			return value < this.min;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0001CA12 File Offset: 0x0001AC12
		public bool PorEncima(float value)
		{
			return value > this.max;
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0001CA1D File Offset: 0x0001AC1D
		public float promedio
		{
			get
			{
				return (this.min + this.max) / 2f;
			}
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0001CA32 File Offset: 0x0001AC32
		public void Increase(float value)
		{
			this.m_min *= value;
			this.m_max *= value;
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001CA50 File Offset: 0x0001AC50
		public void Expandir(float value)
		{
			float promedio = this.promedio;
			float num = this.m_max - promedio;
			this.m_min = promedio - num * value;
			this.m_max = promedio + num * value;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0001CA83 File Offset: 0x0001AC83
		public void CapMin(float cap)
		{
			if (this.m_min < cap)
			{
				this.m_min = cap;
			}
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0001CA95 File Offset: 0x0001AC95
		public void CapMax(float cap)
		{
			if (this.m_max > cap)
			{
				this.m_max = cap;
			}
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x0001CAA8 File Offset: 0x0001ACA8
		public static PercentageRange operator *(float d, PercentageRange a)
		{
			PercentageRange percentageRange = new PercentageRange(a.m_min, a.m_max);
			percentageRange.Expandir(d);
			return percentageRange;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0001CAD4 File Offset: 0x0001ACD4
		public static PercentageRange operator *(PercentageRange a, float d)
		{
			PercentageRange percentageRange = new PercentageRange(a.m_min, a.m_max);
			percentageRange.Expandir(d);
			return percentageRange;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0001CAFD File Offset: 0x0001ACFD
		public RangeValue UnClamped()
		{
			return new RangeValue(this.m_min, this.m_max);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x0001CB10 File Offset: 0x0001AD10
		public bool InRange(float value)
		{
			return value <= this.max && value >= this.min;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x0001CB29 File Offset: 0x0001AD29
		public bool InRangeUnClamped(float value)
		{
			return value <= this.m_max && value >= this.m_min;
		}

		// Token: 0x04000236 RID: 566
		[SerializeField]
		private float m_min;

		// Token: 0x04000237 RID: 567
		[SerializeField]
		private float m_max;
	}
}
