using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000C8 RID: 200
	public static class ___EXTHue
	{
		// Token: 0x060005ED RID: 1517 RVA: 0x00017350 File Offset: 0x00015550
		public static Hue InterpretarHue(this float mod)
		{
			mod = Mathf.Lerp(0f, 360f, mod);
			if (mod <= 15f)
			{
				return Hue.rojo;
			}
			if (mod > 15f && mod <= 45f)
			{
				return Hue.naranja;
			}
			if (mod > 45f && mod <= 75f)
			{
				return Hue.amarillo;
			}
			if (mod > 75f && mod <= 105f)
			{
				return Hue.chartreuse;
			}
			if (mod > 105f && mod <= 135f)
			{
				return Hue.verde;
			}
			if (mod > 135f && mod <= 165f)
			{
				return Hue.acuamarino;
			}
			if (mod > 165f && mod <= 195f)
			{
				return Hue.aquaBlue;
			}
			if (mod > 195f && mod <= 225f)
			{
				return Hue.cobalt;
			}
			if (mod > 225f && mod <= 255f)
			{
				return Hue.azul;
			}
			if (mod > 255f && mod <= 285f)
			{
				return Hue.violeta;
			}
			if (mod > 285f && mod <= 315f)
			{
				return Hue.morado;
			}
			if (mod > 315f && mod <= 345f)
			{
				return Hue.magenta;
			}
			if (mod > 345f)
			{
				return Hue.rojo;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x060005EE RID: 1518 RVA: 0x00017454 File Offset: 0x00015654
		public static float InterpretarHue_Inverse(this Hue hue)
		{
			switch (hue)
			{
			case Hue.rojo:
				return 0f;
			case Hue.naranja:
				return 0.083333336f;
			case Hue.amarillo:
				return 0.16666667f;
			case Hue.chartreuse:
				return 0.25f;
			case Hue.verde:
				return 0.33333334f;
			case Hue.acuamarino:
				return 0.41666666f;
			case Hue.aquaBlue:
				return 0.5f;
			case Hue.cobalt:
				return 0.5833333f;
			case Hue.azul:
				return 0.6666667f;
			case Hue.violeta:
				return 0.75f;
			case Hue.morado:
				return 0.8333333f;
			case Hue.magenta:
				return 0.9166667f;
			default:
				throw new ArgumentOutOfRangeException(hue.ToString());
			}
		}

		// Token: 0x060005EF RID: 1519 RVA: 0x000174F4 File Offset: 0x000156F4
		public static Hue MasCercaAbajo(this float hueValue, out float distance)
		{
			int num = typeof(Hue).MinEnumValue();
			int num2 = typeof(Hue).MaxEnumValue();
			Hue hue = hueValue.InterpretarHue();
			if (hue == (Hue)num)
			{
				Hue hue2 = (Hue)num2;
				distance = Mathf.Abs(hueValue - (float)num);
				return hue2;
			}
			int num3 = hue - Hue.naranja;
			float num4 = ((Hue)num3).InterpretarHue_Inverse();
			distance = Mathf.Abs(hueValue - num4);
			return (Hue)num3;
		}

		// Token: 0x060005F0 RID: 1520 RVA: 0x00017550 File Offset: 0x00015750
		public static Hue MasCercaArriba(this float hueValue, out float distance)
		{
			int num = typeof(Hue).MinEnumValue();
			int num2 = typeof(Hue).MaxEnumValue();
			Hue hue = hueValue.InterpretarHue();
			if (hue == (Hue)num2)
			{
				Hue hue2 = (Hue)num;
				distance = Mathf.Abs((float)num2 - hueValue);
				return hue2;
			}
			Hue hue3 = hue + 1;
			float num3 = hue3.InterpretarHue_Inverse();
			distance = Mathf.Abs(num3 - hueValue);
			return hue3;
		}
	}
}
