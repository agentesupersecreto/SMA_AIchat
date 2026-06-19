using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200010B RID: 267
	[Serializable]
	public class ValorDeColorHSV
	{
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x0001A57A File Offset: 0x0001877A
		[Obsolete]
		public Color colorPromediado
		{
			get
			{
				return this.colorCalculado;
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000791 RID: 1937 RVA: 0x0001A582 File Offset: 0x00018782
		[Obsolete]
		public Color colorModificado
		{
			get
			{
				return this.colorCalculado;
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000792 RID: 1938 RVA: 0x0001A58C File Offset: 0x0001878C
		public Color colorCalculado
		{
			get
			{
				Color color = Color.HSVToRGB(this.hue.valorCalculado, this.saturation.valorCalculado, this.value.valorCalculado);
				color.a = this.alpha.valorCalculado;
				return color;
			}
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000793 RID: 1939 RVA: 0x0001A5D4 File Offset: 0x000187D4
		public Color colorInicial
		{
			get
			{
				Color color = Color.HSVToRGB(this.hue.initial, this.saturation.initial, this.value.initial);
				color.a = this.alpha.initial;
				return color;
			}
		}

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0001A61C File Offset: 0x0001881C
		public Color colorCalculadoAlphaNormalizado
		{
			get
			{
				Color color = Color.HSVToRGB(this.hue.valorCalculado, this.saturation.valorCalculado, this.value.valorCalculado);
				color.a = Mathf.InverseLerp(this.alpha.range.minValue, this.alpha.range.maxValue, this.alpha.valorCalculado);
				return color;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001A688 File Offset: 0x00018888
		public Color ColorCalculado(float hueMod, float saturationMod, float valueMod, float alphaMod)
		{
			Color color = Color.HSVToRGB(this.hue.valorCalculado * hueMod, this.saturation.valorCalculado * saturationMod, this.value.valorCalculado * valueMod);
			color.a = this.alpha.valorCalculado * alphaMod;
			return color;
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001A6D8 File Offset: 0x000188D8
		public void InitBase(Color col)
		{
			this.hue.clampBaseComoSiFueraAnguloAOne = true;
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(col, out num, out num2, out num3);
			this.hue.InitBase(num);
			this.saturation.InitBase(num2);
			this.value.InitBase(num3);
			this.alpha.InitBase(col.a);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001A734 File Offset: 0x00018934
		public void ForceNewValue(Color col, bool normalizarAlpha)
		{
			this.hue.clampBaseComoSiFueraAnguloAOne = true;
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(col, out num, out num2, out num3);
			this.hue.ForceNewValue(num, false);
			this.saturation.ForceNewValue(num2, false);
			this.value.ForceNewValue(num3, false);
			this.alpha.ForceNewValue(col.a, normalizarAlpha);
		}

		// Token: 0x04000217 RID: 535
		public WeightFlotanteBaseLibre hue = new WeightFlotanteBaseLibre();

		// Token: 0x04000218 RID: 536
		public WeightFlotanteBaseLibre saturation = new WeightFlotanteBaseLibre();

		// Token: 0x04000219 RID: 537
		public WeightFlotanteBaseLibre value = new WeightFlotanteBaseLibre();

		// Token: 0x0400021A RID: 538
		public WeightFlotanteBaseLibre alpha = new WeightFlotanteBaseLibre();
	}
}
