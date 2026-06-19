using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x0200045B RID: 1115
	[CreateAssetMenu(fileName = "ModifcadorDeIntervalo", menuName = "Objetos/Emociones/ModifcadorDeIntervalo")]
	public class ModifcadorDeIntervalo : AplicableScriptable
	{
		// Token: 0x06001849 RID: 6217 RVA: 0x00060D8C File Offset: 0x0005EF8C
		public RangeValueV2 Modificar(RangeValueV2 range, Emocion emo, float emoMod)
		{
			return this.Modificar(range, emo.value.mod * emoMod);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00060DB0 File Offset: 0x0005EFB0
		public RangeValueV2 Modificar(RangeValueV2 range, PorcentageModificable percent)
		{
			return this.Modificar(range, percent.mod);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x00060DC0 File Offset: 0x0005EFC0
		public RangeValueV2 Modificar(RangeValueV2 range, float mod)
		{
			mod = Mathf.Clamp01(mod);
			switch (this.powerTipo)
			{
			case ModifcadorDeIntervalo.PowerTipo.None:
				break;
			case ModifcadorDeIntervalo.PowerTipo.@in:
				mod = mod.InPow(this.power);
				break;
			case ModifcadorDeIntervalo.PowerTipo.@out:
				mod = mod.OutPow(this.power);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.powerTipo.ToString());
			}
			if (this.minCap < 0f)
			{
				this.minCap = 0f;
			}
			if (this.min < 0f)
			{
				this.min = 0f;
			}
			float num = Mathf.Lerp(this.min, this.max, mod);
			ModifcadorDeIntervalo.Tipo tipo = this.tipo;
			if (tipo != ModifcadorDeIntervalo.Tipo.incrementar)
			{
				if (tipo != ModifcadorDeIntervalo.Tipo.expandir)
				{
					throw new ArgumentOutOfRangeException(this.tipo.ToString());
				}
				range.Expandir(num, this.minCap);
			}
			else
			{
				range.Increase(num, this.minCap);
			}
			return range;
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00060EB4 File Offset: 0x0005F0B4
		public float ModificarSingle(float value, Emocion emo)
		{
			return this.ModificarSingle(value, emo.value.mod);
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x00060ED6 File Offset: 0x0005F0D6
		public float ModificarSingle(float value, PorcentageModificable percent)
		{
			return this.ModificarSingle(value, percent.mod);
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x00060EE8 File Offset: 0x0005F0E8
		public float ModificarSingle(float value, float mod)
		{
			mod = Mathf.Clamp01(mod);
			switch (this.powerTipo)
			{
			case ModifcadorDeIntervalo.PowerTipo.None:
				break;
			case ModifcadorDeIntervalo.PowerTipo.@in:
				mod = mod.InPow(this.power);
				break;
			case ModifcadorDeIntervalo.PowerTipo.@out:
				mod = mod.OutPow(this.power);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.powerTipo.ToString());
			}
			if (this.minCap < 0f)
			{
				this.minCap = 0f;
			}
			if (this.min < 0f)
			{
				this.min = 0f;
			}
			float num = Mathf.Lerp(this.min, this.max, mod);
			value *= num;
			value = ((value < this.minCap) ? this.minCap : value);
			return value;
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x00060FAC File Offset: 0x0005F1AC
		public float Lerp(float t)
		{
			switch (this.powerTipo)
			{
			case ModifcadorDeIntervalo.PowerTipo.None:
				break;
			case ModifcadorDeIntervalo.PowerTipo.@in:
				t = t.InPow(this.power);
				break;
			case ModifcadorDeIntervalo.PowerTipo.@out:
				t = t.OutPow(this.power);
				break;
			default:
				throw new ArgumentOutOfRangeException(this.powerTipo.ToString());
			}
			return Mathf.Lerp(this.min, this.max, t);
		}

		// Token: 0x040012AA RID: 4778
		public ModifcadorDeIntervalo.Tipo tipo;

		// Token: 0x040012AB RID: 4779
		public float min = 1f;

		// Token: 0x040012AC RID: 4780
		public float max = 1f;

		// Token: 0x040012AD RID: 4781
		[NonSerialized]
		public float minCap;

		// Token: 0x040012AE RID: 4782
		public ModifcadorDeIntervalo.PowerTipo powerTipo;

		// Token: 0x040012AF RID: 4783
		[Range(1f, 10f)]
		public float power = 1f;

		// Token: 0x0200045C RID: 1116
		public enum PowerTipo
		{
			// Token: 0x040012B1 RID: 4785
			None,
			// Token: 0x040012B2 RID: 4786
			@in,
			// Token: 0x040012B3 RID: 4787
			@out
		}

		// Token: 0x0200045D RID: 1117
		public enum Tipo
		{
			// Token: 0x040012B5 RID: 4789
			incrementar,
			// Token: 0x040012B6 RID: 4790
			expandir
		}
	}
}
