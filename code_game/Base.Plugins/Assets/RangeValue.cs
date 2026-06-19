using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200013A RID: 314
	[Serializable]
	public struct RangeValue
	{
		// Token: 0x060008FC RID: 2300 RVA: 0x0001DB1D File Offset: 0x0001BD1D
		public RangeValue(float max)
		{
			this.m_min = 0f;
			this.m_max = max;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x0001DB31 File Offset: 0x0001BD31
		public RangeValue(float min, float max)
		{
			this.m_min = min;
			this.m_max = max;
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x0001DB41 File Offset: 0x0001BD41
		public float min
		{
			get
			{
				if (this.m_min > this.m_max)
				{
					return this.m_max;
				}
				return this.m_min;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0001DB5E File Offset: 0x0001BD5E
		public float max
		{
			get
			{
				if (this.m_max < this.m_min)
				{
					return this.m_min;
				}
				return this.m_max;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x0001DB7B File Offset: 0x0001BD7B
		public float promedio
		{
			get
			{
				return (this.min + this.max) / 2f;
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x0001DB90 File Offset: 0x0001BD90
		public void Cap(float min = 0f, float max = 100f)
		{
			if (this.m_min < min)
			{
				this.m_min = min;
			}
			if (this.m_max > max)
			{
				this.m_max = max;
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0001DBB2 File Offset: 0x0001BDB2
		public void CapMin(float cap)
		{
			if (this.m_min < cap)
			{
				this.m_min = cap;
			}
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x0001DBC4 File Offset: 0x0001BDC4
		public void CapMax(float cap)
		{
			if (this.m_max > cap)
			{
				this.m_max = cap;
			}
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x0001DBD6 File Offset: 0x0001BDD6
		public bool PorDebajo(float value)
		{
			return value < this.min;
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x0001DBE1 File Offset: 0x0001BDE1
		public bool PorEncima(float value)
		{
			return value > this.max;
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x0001DBEC File Offset: 0x0001BDEC
		public bool InRange(float value)
		{
			return value <= this.max && value >= this.min;
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x0001DC05 File Offset: 0x0001BE05
		public void Increase(float value)
		{
			if (value == 1f)
			{
				return;
			}
			this.m_min *= value;
			this.m_max *= value;
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x0001DC2C File Offset: 0x0001BE2C
		public void Expandir(float value)
		{
			if (value == 1f)
			{
				return;
			}
			float promedio = this.promedio;
			float num = this.max - promedio;
			this.m_min = promedio - num * value;
			this.m_max = promedio + num * value;
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0001DC68 File Offset: 0x0001BE68
		public static RangeValue operator *(float d, RangeValue a)
		{
			float promedio = a.promedio;
			float num = a.max - promedio;
			return new RangeValue(promedio - num * d, promedio + num * d);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0001DC98 File Offset: 0x0001BE98
		public static RangeValue operator *(RangeValue a, float d)
		{
			float promedio = a.promedio;
			float num = a.max - promedio;
			return new RangeValue(promedio - num * d, promedio + num * d);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0001DCC6 File Offset: 0x0001BEC6
		public float CalculeMod(float value, RangeValueCaculeModConfig config)
		{
			return this.CalculeMod(value, config.promedio, config.returnZeroIfOutOfRange, config.minMod, config.maxMod);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0001DCE8 File Offset: 0x0001BEE8
		public float CalculeMod(float value, float promeDio = 0.5f, bool returnZeroIfOutOfRange = true, float minMod = 0f, float maxMod = 1f)
		{
			float num;
			if (promeDio == 0.5f)
			{
				num = this.promedio;
			}
			else
			{
				num = Mathf.Lerp(this.min, this.max, promeDio);
			}
			float num2 = minMod;
			if (value < this.min || value > this.max)
			{
				if (!returnZeroIfOutOfRange)
				{
					return minMod;
				}
				return 0f;
			}
			else
			{
				if (value == num)
				{
					return maxMod;
				}
				if (value < num)
				{
					num2 = Mathf.InverseLerp(this.min, num, value);
				}
				if (value > num)
				{
					num2 = 1f - Mathf.InverseLerp(num, this.max, value);
				}
				return Mathf.Lerp(minMod, maxMod, num2);
			}
		}

		// Token: 0x04000251 RID: 593
		[SerializeField]
		private float m_min;

		// Token: 0x04000252 RID: 594
		[SerializeField]
		private float m_max;
	}
}
