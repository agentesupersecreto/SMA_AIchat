using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x02000139 RID: 313
	[Serializable]
	public struct RangeValueV2
	{
		// Token: 0x1700018C RID: 396
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x0001D1D8 File Offset: 0x0001B3D8
		public static RangeValueV2 Default
		{
			get
			{
				return RangeValueV2.m_default;
			}
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001D1DF File Offset: 0x0001B3DF
		public static RangeValueV2 JoinRanges(ref RangeValueV2 a, ref RangeValueV2 b)
		{
			return RangeValueV2.TryNew(Mathf.Min(a.min, b.min), Mathf.Max(a.max, b.max), 0.01f, 0.0001f);
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001D212 File Offset: 0x0001B412
		public static RangeValueV2 JoinRanges(RangeValueV2 a, RangeValueV2 b)
		{
			return RangeValueV2.TryNew(Mathf.Min(a.min, b.min), Mathf.Max(a.max, b.max), 0.01f, 0.0001f);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x0001D24C File Offset: 0x0001B44C
		public static RangeValueV2 OverlapRangesConPrioridad(ref RangeValueV2 lessPrioridad, ref RangeValueV2 greaterPrioridad)
		{
			if (greaterPrioridad.min <= lessPrioridad.min && greaterPrioridad.max >= lessPrioridad.max)
			{
				return RangeValueV2.TryNew(0f, 0f, 0.01f, 0.0001f);
			}
			if (greaterPrioridad.min > lessPrioridad.min && greaterPrioridad.min >= lessPrioridad.max)
			{
				return RangeValueV2.TryNew(lessPrioridad.min, Mathf.Lerp(lessPrioridad.max, greaterPrioridad.min, 0.75f), 0.1f, 0.001f);
			}
			if (lessPrioridad.min > greaterPrioridad.min && lessPrioridad.min >= greaterPrioridad.max)
			{
				return lessPrioridad;
			}
			if (greaterPrioridad.min > lessPrioridad.min && greaterPrioridad.max < lessPrioridad.max)
			{
				return RangeValueV2.TryNew(lessPrioridad.min, greaterPrioridad.max, 0.01f, 0.0001f);
			}
			if (lessPrioridad.max > greaterPrioridad.min)
			{
				return RangeValueV2.TryNew(lessPrioridad.min, greaterPrioridad.min, 0.01f, 0.0001f);
			}
			if (greaterPrioridad.max > lessPrioridad.min)
			{
				return RangeValueV2.TryNew(greaterPrioridad.max, lessPrioridad.max, 0.01f, 0.0001f);
			}
			throw new ArgumentOutOfRangeException("No se que condicion me falto");
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x0001D390 File Offset: 0x0001B590
		public static RangeValueV2 SetMaxWithCeilAndKeepLength(ref RangeValueV2 rango, float ceil, float increaseLengthProportionallyW)
		{
			if (ceil <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (rango.max >= ceil)
			{
				return rango;
			}
			float largo = rango.largo;
			float num = Mathf.Lerp(largo, ceil / rango.max * largo, increaseLengthProportionallyW);
			return RangeValueV2.TryNew(ceil - num, ceil, 0.1f, 0.001f);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		public static RangeValueV2 SetMinWithCeilAndKeepLength(ref RangeValueV2 rango, float ceil, float increaseLengthProportionallyW)
		{
			if (ceil <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (rango.min >= ceil)
			{
				return rango;
			}
			float largo = rango.largo;
			float num = Mathf.Lerp(largo, ceil / rango.max * largo, increaseLengthProportionallyW);
			return RangeValueV2.TryNew(ceil, ceil + num, 0.1f, 0.001f);
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x0001D43F File Offset: 0x0001B63F
		public static RangeValueV2 MaxValues(ref RangeValueV2 a, ref RangeValueV2 b)
		{
			return RangeValueV2.TryNew(Mathf.Max(a.m_min, b.m_min), Mathf.Max(a.m_max, b.m_max), 0.1f, 0.001f);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x0001D472 File Offset: 0x0001B672
		public static RangeValueV2 MaxItem(ref RangeValueV2 a, ref RangeValueV2 b)
		{
			if (a.m_max >= b.m_max)
			{
				return a;
			}
			return b;
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0001D48F File Offset: 0x0001B68F
		public static RangeValueV2 Stack(ref RangeValueV2 @base, ref RangeValueV2 top)
		{
			return RangeValueV2.TryNew(@base.max, @base.max + top.largo, 0.1f, 0.001f);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0001D4B4 File Offset: 0x0001B6B4
		public static RangeValueV2 TryNew(float min, float max, float mindistanceMod = 0.1f, float mindistance = 0.001f)
		{
			if (max < 0f)
			{
				max = 0f;
			}
			if (min < 0f)
			{
				min = 0f;
			}
			if (min > max - mindistance || min + min * mindistanceMod > max)
			{
				max = Mathf.Max(min + mindistance, min + min * mindistanceMod);
			}
			return new RangeValueV2(min, max);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0001D503 File Offset: 0x0001B703
		public static RangeValueV2 Scale(ref RangeValueV2 a, float escala)
		{
			return RangeValueV2.TryNew(a.m_min * escala, a.m_max * escala, 0.1f, 0.001f);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0001D524 File Offset: 0x0001B724
		public RangeValueV2(float max)
		{
			if (max <= 0f)
			{
				throw new InvalidOperationException();
			}
			this.m_min = 0f;
			this.m_max = max;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0001D546 File Offset: 0x0001B746
		public RangeValueV2(float min, float max)
		{
			if (min < 0f)
			{
				throw new InvalidOperationException();
			}
			if (max <= 0f)
			{
				throw new InvalidOperationException();
			}
			if (min == max || min > max)
			{
				throw new InvalidOperationException("OJO ESTO");
			}
			this.m_min = min;
			this.m_max = max;
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0001D585 File Offset: 0x0001B785
		public float min
		{
			get
			{
				if (this.m_min >= this.m_max)
				{
					this.m_min = this.m_max * 0.999f;
				}
				return this.m_min;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0001D5AD File Offset: 0x0001B7AD
		public float max
		{
			get
			{
				if (this.m_max <= this.m_min)
				{
					this.m_max = this.m_min * 1.001f;
				}
				return this.m_max;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x060008E4 RID: 2276 RVA: 0x0001D5D5 File Offset: 0x0001B7D5
		public float largo
		{
			get
			{
				return this.max - this.min;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x0001D5E4 File Offset: 0x0001B7E4
		public float promedio
		{
			get
			{
				return (this.min + this.max) / 2f;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0001D5F9 File Offset: 0x0001B7F9
		public PercentageRange percentage
		{
			get
			{
				return new PercentageRange(this.m_min, this.m_max);
			}
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001D60C File Offset: 0x0001B80C
		public void Cap(float maxValue)
		{
			if (maxValue < 0f)
			{
				throw new InvalidOperationException();
			}
			if (this.m_min > maxValue)
			{
				this.m_min = maxValue;
			}
			if (this.m_max > maxValue)
			{
				this.m_max = maxValue;
			}
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0001D63C File Offset: 0x0001B83C
		public void CapMax(float maxValue, float minDistance = 0f)
		{
			this.Cap(maxValue);
			float num = this.m_max - this.m_min;
			if (num < 0f)
			{
				Debug.LogError("Range Invalid values");
				return;
			}
			minDistance = ((minDistance < 0f) ? 0f : minDistance);
			if (num < minDistance)
			{
				this.m_max = this.m_min + minDistance;
			}
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001D695 File Offset: 0x0001B895
		public void ClampMin(float minValor)
		{
			if (minValor < 0f)
			{
				throw new InvalidOperationException();
			}
			if (this.m_min < minValor)
			{
				this.m_min = minValor;
			}
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x0001D6B5 File Offset: 0x0001B8B5
		public void ClampMax(float minValor)
		{
			if (minValor < 0f)
			{
				throw new InvalidOperationException();
			}
			if (this.m_max < minValor)
			{
				this.m_max = minValor;
			}
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x0001D6D5 File Offset: 0x0001B8D5
		public bool PorDebajo(float value)
		{
			return value < this.min;
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x0001D6E0 File Offset: 0x0001B8E0
		public bool PorEncima(float value)
		{
			return value > this.max;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001D6EB File Offset: 0x0001B8EB
		public bool InRange(float value)
		{
			return value <= this.max && value >= this.min;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001D704 File Offset: 0x0001B904
		public void Increase(float value, float cap = 0.0001f)
		{
			if (value == 1f)
			{
				return;
			}
			if (value <= 0f)
			{
				throw new InvalidOperationException();
			}
			this.m_min *= value;
			this.m_max *= value;
			this.ClampMin(cap);
			this.ClampMax(cap);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001D754 File Offset: 0x0001B954
		public void IncreaseMinAndKeepLenght(float value, float cap = 0.0001f)
		{
			if (value == 1f)
			{
				return;
			}
			if (value <= 0f)
			{
				throw new InvalidOperationException();
			}
			float num = this.max - this.min;
			this.m_min *= value;
			this.m_max = this.m_min + num;
			this.ClampMin(cap);
			this.ClampMax(cap);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0001D7B0 File Offset: 0x0001B9B0
		public void IncreaseMaxAndKeepLenght(float value, float cap = 0.0001f)
		{
			if (value == 1f)
			{
				return;
			}
			if (value <= 0f)
			{
				throw new InvalidOperationException();
			}
			float num = this.max - this.min;
			this.m_max *= value;
			this.m_min = this.m_max - num;
			this.ClampMin(cap);
			this.ClampMax(cap);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001D80C File Offset: 0x0001BA0C
		public void MoveTowards(RangeValueV2 target, float maxDelta)
		{
			this.m_min = Mathf.MoveTowards(this.m_min, target.min, maxDelta);
			this.m_max = Mathf.MoveTowards(this.m_max, target.max, maxDelta);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001D840 File Offset: 0x0001BA40
		public void Expandir(float value, float cap = 0.0001f)
		{
			if (value == 1f)
			{
				return;
			}
			if (value <= 0f)
			{
				throw new InvalidOperationException();
			}
			float promedio = this.promedio;
			float num = this.max - promedio;
			this.m_min = promedio - num * value;
			this.m_max = promedio + num * value;
			if (this.m_min < 0f)
			{
				this.m_min = 0f;
			}
			this.ClampMin(cap);
			this.ClampMax(cap);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001D8B0 File Offset: 0x0001BAB0
		public float Lerp(float t)
		{
			return Mathf.Lerp(this.min, this.max, t);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001D8C4 File Offset: 0x0001BAC4
		public static RangeValueV2 operator *(float d, RangeValueV2 a)
		{
			float promedio = a.promedio;
			float num = a.max - promedio;
			return new RangeValueV2(promedio - num * d, promedio + num * d);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001D8F4 File Offset: 0x0001BAF4
		public static RangeValueV2 operator *(RangeValueV2 a, float d)
		{
			float promedio = a.promedio;
			float num = a.max - promedio;
			return new RangeValueV2(promedio - num * d, promedio + num * d);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0001D922 File Offset: 0x0001BB22
		public bool EnMedio(float value, float medioMod)
		{
			medioMod = Mathf.Clamp01(medioMod);
			return Mathf.Approximately(Mathf.Lerp(this.min, this.max, medioMod), value);
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001D944 File Offset: 0x0001BB44
		public bool PorDebajoDelMedio(float value, float medioMod)
		{
			medioMod = Mathf.Clamp01(medioMod);
			float num = Mathf.Lerp(this.min, this.max, medioMod);
			return value < num;
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001D970 File Offset: 0x0001BB70
		public bool PorEncimaDelMedio(float value, float medioMod)
		{
			medioMod = Mathf.Clamp01(medioMod);
			float num = Mathf.Lerp(this.min, this.max, medioMod);
			return value > num;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0001D99C File Offset: 0x0001BB9C
		public float InverseLerpAlMedio(float value, float medioMod, float entrandoOutPower, float saliendoInPower)
		{
			if (this.PorDebajo(value) || this.PorEncima(value))
			{
				return 0f;
			}
			medioMod = Mathf.Clamp01(medioMod);
			float num = Mathf.Lerp(this.min, this.max, medioMod);
			float num2;
			if (num == value)
			{
				num2 = 1f;
			}
			else if (value > num)
			{
				num2 = 1f - Mathf.InverseLerp(num, this.max, value).InPow(saliendoInPower);
			}
			else
			{
				if (value >= num)
				{
					throw new ArgumentOutOfRangeException();
				}
				num2 = Mathf.InverseLerp(this.min, num, value).OutPow(entrandoOutPower);
			}
			return num2;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0001DA2C File Offset: 0x0001BC2C
		public float InverseLerpAlMedio(float value, float minMedioMod, float maxMedioMod, float entrandoOutPower, float saliendoInPower)
		{
			if (this.PorDebajo(value) || this.PorEncima(value))
			{
				return 0f;
			}
			minMedioMod = Mathf.Clamp01(minMedioMod);
			maxMedioMod = Mathf.Clamp01(maxMedioMod);
			if (minMedioMod == maxMedioMod)
			{
				return this.InverseLerpAlMedio(value, minMedioMod, entrandoOutPower, saliendoInPower);
			}
			float num = ((minMedioMod < maxMedioMod) ? minMedioMod : maxMedioMod);
			float num2 = ((maxMedioMod > minMedioMod) ? maxMedioMod : minMedioMod);
			if (num == num2)
			{
				throw new InvalidOperationException();
			}
			num = Mathf.Lerp(this.min, this.max, num);
			num2 = Mathf.Lerp(this.min, this.max, num2);
			float num3;
			if (value >= num && value <= num2)
			{
				num3 = 1f;
			}
			else if (value > num2)
			{
				num3 = 1f - Mathf.InverseLerp(num2, this.max, value).InPow(saliendoInPower);
			}
			else
			{
				if (value >= num)
				{
					throw new ArgumentOutOfRangeException();
				}
				num3 = Mathf.InverseLerp(this.min, num, value).OutPow(entrandoOutPower);
			}
			return num3;
		}

		// Token: 0x0400024E RID: 590
		private static readonly RangeValueV2 m_default = new RangeValueV2(0f, 1f);

		// Token: 0x0400024F RID: 591
		[SerializeField]
		private float m_min;

		// Token: 0x04000250 RID: 592
		[SerializeField]
		private float m_max;
	}
}
