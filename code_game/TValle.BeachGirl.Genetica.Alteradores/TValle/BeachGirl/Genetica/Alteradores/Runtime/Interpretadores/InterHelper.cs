using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200004A RID: 74
	public static class InterHelper
	{
		// Token: 0x0600034D RID: 845 RVA: 0x0000D436 File Offset: 0x0000B636
		public static Interpretacion.HoleDepth GetProfundidadConOffsetDeEstados(float[] results)
		{
			if (results[0] < 1f)
			{
				return Interpretacion.HoleDepth.veryDeep;
			}
			if (results[1] < 1f)
			{
				return Interpretacion.HoleDepth.deep;
			}
			if (results[2] < 1f)
			{
				return Interpretacion.HoleDepth.normal;
			}
			if (results[3] < 1f)
			{
				return Interpretacion.HoleDepth.narrow;
			}
			return Interpretacion.HoleDepth.veryNarrow;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0000D46A File Offset: 0x0000B66A
		public static Interpretacion.Tightness GetTightnessConOffsetDeEstados(float[] results)
		{
			if (results[0] < 1f)
			{
				return Interpretacion.Tightness.veryLoose;
			}
			if (results[1] < 1f)
			{
				return Interpretacion.Tightness.loose;
			}
			if (results[2] < 1f)
			{
				return Interpretacion.Tightness.normal;
			}
			if (results[3] < 1f)
			{
				return Interpretacion.Tightness.tight;
			}
			return Interpretacion.Tightness.veryTight;
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000D49E File Offset: 0x0000B69E
		private static Interpretacion.Capacidad GetSinsibilidadConOffsetCentrado(float offset)
		{
			if (offset >= 2f)
			{
				return Interpretacion.Capacidad.veryLow;
			}
			if (offset >= 1.3333f)
			{
				return Interpretacion.Capacidad.low;
			}
			if (offset >= 0.75f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (offset >= 0.5f)
			{
				return Interpretacion.Capacidad.high;
			}
			return Interpretacion.Capacidad.veryHigh;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0000D4CA File Offset: 0x0000B6CA
		private static Interpretacion.Capacidad GetGainConOffsetCentrado(float offset)
		{
			if (offset >= 3f)
			{
				return Interpretacion.Capacidad.veryHigh;
			}
			if (offset >= 1.5f)
			{
				return Interpretacion.Capacidad.high;
			}
			if (offset >= 0.6666f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (offset >= 0.3333f)
			{
				return Interpretacion.Capacidad.low;
			}
			return Interpretacion.Capacidad.veryLow;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000D4F6 File Offset: 0x0000B6F6
		private static Interpretacion.Capacidad GetMaxValueConOffsetCentrado(float offset)
		{
			if (offset >= 1.3333f)
			{
				return Interpretacion.Capacidad.veryHigh;
			}
			if (offset >= 1.16666f)
			{
				return Interpretacion.Capacidad.high;
			}
			if (offset >= 0.857147f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (offset >= 0.75f)
			{
				return Interpretacion.Capacidad.low;
			}
			return Interpretacion.Capacidad.veryLow;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000D522 File Offset: 0x0000B722
		private static Interpretacion.Capacidad GetFavCentrado(float offset)
		{
			if (offset >= 2f)
			{
				return Interpretacion.Capacidad.veryHigh;
			}
			if (offset >= 1.3333f)
			{
				return Interpretacion.Capacidad.high;
			}
			if (offset >= 0.75f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (offset >= 0.5f)
			{
				return Interpretacion.Capacidad.low;
			}
			return Interpretacion.Capacidad.veryLow;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000D550 File Offset: 0x0000B750
		public static Interpretacion.Capacidad GetSensibilidad(float sensibilidadDefaultTactil, float sensibilidadDefaultCoital, float rangoTactilMasBajo_min, float rangoCoitalMasBajo_min, bool inverted)
		{
			float num;
			if (sensibilidadDefaultTactil != 0f)
			{
				num = rangoTactilMasBajo_min / sensibilidadDefaultTactil;
			}
			else
			{
				num = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			float num2;
			if (sensibilidadDefaultCoital != 0f)
			{
				num2 = rangoCoitalMasBajo_min / sensibilidadDefaultCoital;
			}
			else
			{
				num2 = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			num = Mathf.Clamp(num, 0f, 1E+09f);
			num2 = Mathf.Clamp(num2, 0f, 1E+09f);
			if (inverted)
			{
				if (num == 0f)
				{
					num = 1E+09f;
				}
				else
				{
					num = 1f / num;
				}
				if (num2 == 0f)
				{
					num2 = 1E+09f;
				}
				else
				{
					num2 = 1f / num2;
				}
			}
			return InterHelper.GetSinsibilidadConOffsetCentrado((num + num2) / 2f);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000D600 File Offset: 0x0000B800
		public static Interpretacion.Capacidad GetSensibilidadConDistance(float sensibilidadDefaultTactil, float sensibilidadDefaultCoital, float rangoTactilMasBajo_min, float rangoCoitalMasBajo_min, float sensibilidadDefaultDistanceTactil, float sensibilidadDefaultDistanceCoital, float rangoTactilDistance, float rangoCoitalDistance, bool inverted)
		{
			float num;
			if (sensibilidadDefaultTactil != 0f)
			{
				num = rangoTactilMasBajo_min / sensibilidadDefaultTactil;
			}
			else
			{
				num = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			float num2;
			if (sensibilidadDefaultCoital != 0f)
			{
				num2 = rangoCoitalMasBajo_min / sensibilidadDefaultCoital;
			}
			else
			{
				num2 = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			num = Mathf.Clamp(num, 0f, 1E+09f);
			num2 = Mathf.Clamp(num2, 0f, 1E+09f);
			if (inverted)
			{
				if (num == 0f)
				{
					num = 1E+09f;
				}
				else
				{
					num = 1f / num;
				}
				if (num2 == 0f)
				{
					num2 = 1E+09f;
				}
				else
				{
					num2 = 1f / num2;
				}
			}
			if (Mathf.Approximately(sensibilidadDefaultDistanceTactil, 0f))
			{
				Debug.LogError("Valor por defecto de tactil distance es zero");
			}
			if (Mathf.Approximately(sensibilidadDefaultDistanceCoital, 0f))
			{
				Debug.LogError("Valor por defecto de coital distance es zero");
			}
			float num3 = MathfExtension.InverseLerpUnclamped(0f, sensibilidadDefaultDistanceTactil, rangoTactilDistance);
			float num4 = MathfExtension.InverseLerpUnclamped(0f, sensibilidadDefaultDistanceCoital, rangoCoitalDistance);
			num3 = 1f / Mathf.Clamp(num3, 1E-06f, 100f);
			num = Mathf.Lerp(num, num3, 0.8f);
			num4 = 1f / Mathf.Clamp(num4, 1E-06f, 100f);
			num2 = Mathf.Lerp(num2, num4, 0.8f);
			return InterHelper.GetSinsibilidadConOffsetCentrado((num + num2) / 2f);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000D744 File Offset: 0x0000B944
		public static Interpretacion.Capacidad GetGain(float defaultTactilGen, float defaultCoitalGen, float maxTactil, float maxCoital)
		{
			float num;
			if (defaultTactilGen != 0f)
			{
				num = maxTactil / defaultTactilGen;
			}
			else
			{
				num = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			float num2;
			if (defaultCoitalGen != 0f)
			{
				num2 = maxCoital / defaultCoitalGen;
			}
			else
			{
				num2 = 1E+09f;
				Debug.LogError("Default value era zero");
			}
			return InterHelper.GetGainConOffsetCentrado((num + num2) / 2f);
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000D79C File Offset: 0x0000B99C
		public static Interpretacion.Capacidad GetMaxValue(float defaultTactilMaxValue, float defaultCoitalMaxValue, float maxValeTactil, float maxValueCoital)
		{
			float num;
			if (defaultTactilMaxValue != 0f)
			{
				num = maxValeTactil / defaultTactilMaxValue;
			}
			else
			{
				num = 1E+09f;
			}
			float num2;
			if (defaultCoitalMaxValue != 0f)
			{
				num2 = maxValueCoital / defaultCoitalMaxValue;
			}
			else
			{
				num2 = 1E+09f;
			}
			return InterHelper.GetMaxValueConOffsetCentrado((num + num2) / 2f);
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000D7E0 File Offset: 0x0000B9E0
		public static void OffsetMany(IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, RangeValueV2 range, float holeWorldScale, IReadOnlyList<float> penetrationWorldDistances, IList<float> offsetResult)
		{
			if (offsetGetter == null)
			{
				throw new ArgumentNullException("offsetGetter", "offsetGetter null reference.");
			}
			if (penetrationWorldDistances == null)
			{
				throw new ArgumentNullException("penetrationDistances", "penetrationDistances null reference.");
			}
			if (offsetResult == null)
			{
				throw new ArgumentNullException("offsetResult", "offsetResult null reference.");
			}
			while (offsetResult.Count < penetrationWorldDistances.Count)
			{
				offsetResult.Add(0f);
			}
			RangeValueV2 rangeValueV = RangeValueV2.Scale(ref range, holeWorldScale);
			for (int i = 0; i < penetrationWorldDistances.Count; i++)
			{
				offsetResult[i] = offsetGetter(penetrationWorldDistances[i], rangeValueV);
			}
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000D872 File Offset: 0x0000BA72
		public static T_Enum GetParaGenesPorValor<T_Enum>(int valor) where T_Enum : Enum
		{
			return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), valor));
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000D88C File Offset: 0x0000BA8C
		public static T_Enum GetParaGenesPorIndex<T_Enum>(int index) where T_Enum : Enum
		{
			switch (index)
			{
			case 0:
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -2));
			case 1:
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -1));
			case 2:
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 0));
			case 3:
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 1));
			case 4:
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 2));
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000D930 File Offset: 0x0000BB30
		public static T_Enum GetParaGenesDefault<T_Enum>(float geneWeigth) where T_Enum : Enum
		{
			if (geneWeigth >= 0.8f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 2));
			}
			if (geneWeigth >= 0.6f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 1));
			}
			if (geneWeigth > 0.4f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 0));
			}
			if (geneWeigth > 0.2f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -1));
			}
			return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -2));
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000D9CC File Offset: 0x0000BBCC
		public static float GetParaGenesDefault_Inverse<T_Enum>(T_Enum enumVal) where T_Enum : Enum
		{
			switch (Convert.ToInt32(enumVal))
			{
			case -2:
				return 0.1f;
			case -1:
				return 0.3f;
			case 0:
				return 0.5f;
			case 1:
				return 0.70000005f;
			case 2:
				return 0.9f;
			default:
				return 0.5f;
			}
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000DA28 File Offset: 0x0000BC28
		public static T_Enum GetParaGenesNoCentrados<T_Enum>(float geneWeigth, float middleWeigth) where T_Enum : Enum
		{
			if (middleWeigth == 0.5f)
			{
				return InterHelper.GetParaGenesDefault<T_Enum>(geneWeigth);
			}
			float num = (1f - middleWeigth) / 5f;
			float num2 = middleWeigth / 5f;
			if (geneWeigth >= middleWeigth + num * 3f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 2));
			}
			if (geneWeigth >= middleWeigth + num)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 1));
			}
			if (geneWeigth > middleWeigth - num2)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), 0));
			}
			if (geneWeigth > middleWeigth - num2 * 3f)
			{
				return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -1));
			}
			return (T_Enum)((object)Enum.ToObject(typeof(T_Enum), -2));
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		public static float GetParaGenesNoCentrados_Inverse<T_Enum>(T_Enum enumVal, float middleWeigth) where T_Enum : Enum
		{
			if (middleWeigth == 0.5f)
			{
				return InterHelper.GetParaGenesDefault_Inverse<T_Enum>(enumVal);
			}
			float num = (1f - middleWeigth) / 5f;
			float num2 = middleWeigth / 5f;
			int num3 = Convert.ToInt32(enumVal);
			float num4 = middleWeigth + num * 3f;
			float num5 = middleWeigth + num;
			float num6 = middleWeigth - num2;
			float num7 = middleWeigth - num2 * 3f;
			switch (num3)
			{
			case -2:
				return (0f + num7) / 2f;
			case -1:
				return (num7 + num6) / 2f;
			case 0:
				return middleWeigth;
			case 1:
				return (num5 + num4) / 2f;
			case 2:
				return (num4 + 1f) / 2f;
			default:
				return 0.5f;
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000DBAC File Offset: 0x0000BDAC
		private static Interpretacion.Capacidad GetColorSVA(float sva)
		{
			if (sva >= 0.8f)
			{
				return Interpretacion.Capacidad.veryHigh;
			}
			if (sva >= 0.6f)
			{
				return Interpretacion.Capacidad.high;
			}
			if (sva >= 0.4f)
			{
				return Interpretacion.Capacidad.medium;
			}
			if (sva >= 0.2f)
			{
				return Interpretacion.Capacidad.low;
			}
			return Interpretacion.Capacidad.veryLow;
		}

		// Token: 0x0600035F RID: 863 RVA: 0x0000DBD8 File Offset: 0x0000BDD8
		private static float GetColorSVA_Inverse(Interpretacion.Capacidad capacidad)
		{
			float num = Mathf.InverseLerp(-2f, 2f, (float)capacidad);
			num = Mathf.Lerp(-2f, 2f, num);
			capacidad = (Interpretacion.Capacidad)Mathf.RoundToInt(num);
			switch (capacidad)
			{
			case Interpretacion.Capacidad.veryLow:
				return 0.1f;
			case Interpretacion.Capacidad.low:
				return 0.3f;
			case Interpretacion.Capacidad.medium:
				return 0.5f;
			case Interpretacion.Capacidad.high:
				return 0.70000005f;
			case Interpretacion.Capacidad.veryHigh:
				return 0.9f;
			default:
				throw new ArgumentOutOfRangeException(capacidad.ToString());
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000DC60 File Offset: 0x0000BE60
		public static Interpretacion.Capacidad GetFavorability(float defaultFav, float currentFav)
		{
			float num;
			if (defaultFav != 0f)
			{
				num = currentFav / defaultFav;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			return InterHelper.GetFavCentrado(num);
		}

		// Token: 0x06000361 RID: 865 RVA: 0x0000DC94 File Offset: 0x0000BE94
		private static Interpretacion.Capacidad GetGain(float defaultGen, float currentGen)
		{
			float num;
			if (defaultGen != 0f)
			{
				num = currentGen / defaultGen;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			return InterHelper.GetGainConOffsetCentrado(num);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x0000DCC8 File Offset: 0x0000BEC8
		private static Interpretacion.Capacidad GetMaxValue(float defaultMax, float currentMax)
		{
			float num;
			if (defaultMax != 0f)
			{
				num = currentMax / defaultMax;
			}
			else
			{
				num = 1E+13f;
			}
			return InterHelper.GetMaxValueConOffsetCentrado(num);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x0000DCF0 File Offset: 0x0000BEF0
		private static Interpretacion.Capacidad GetSensibilidad(float sensibilidadDefault, float sensibilidadCurrent, bool inverted)
		{
			float num;
			if (sensibilidadDefault != 0f)
			{
				num = sensibilidadCurrent / sensibilidadDefault;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			num = Mathf.Clamp(num, 0f, 1E+09f);
			if (inverted)
			{
				if (num == 0f)
				{
					num = 1E+13f;
				}
				else
				{
					num = 1f / num;
				}
			}
			return InterHelper.GetSinsibilidadConOffsetCentrado(num);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x0000DD50 File Offset: 0x0000BF50
		private static Interpretacion.Capacidad GetSensibilidadConDistance(float sensibilidadDefault, float sensibilidadCurrent, float distanceDefault, float distanceCurrent, bool inverted)
		{
			float num;
			if (sensibilidadDefault != 0f)
			{
				num = sensibilidadCurrent / sensibilidadDefault;
			}
			else
			{
				num = 1E+13f;
				Debug.LogError("Default value era zero");
			}
			num = Mathf.Clamp(num, 0f, 1E+09f);
			if (inverted)
			{
				if (num == 0f)
				{
					num = 1E+13f;
				}
				else
				{
					num = 1f / num;
				}
			}
			if (Mathf.Approximately(distanceDefault, 0f))
			{
				Debug.LogError("Valor por defecto de tactil distance es zero");
			}
			float num2 = MathfExtension.InverseLerpUnclamped(0f, distanceDefault, distanceCurrent);
			num2 = 1f / Mathf.Clamp(num2, 1E-06f, 100f);
			num = Mathf.Lerp(num, num2, 0.8f);
			return InterHelper.GetSinsibilidadConOffsetCentrado(num);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x0000DDF8 File Offset: 0x0000BFF8
		public static FreeColorAlpha InterpretarColorAlpha(Color color)
		{
			FreeColorAlpha freeColorAlpha = default(FreeColorAlpha);
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(color, out num, out num2, out num3);
			float a = color.a;
			freeColorAlpha.hue = num.InterpretarHue();
			freeColorAlpha.saturation = InterHelper.GetColorSVA(num2);
			freeColorAlpha.brightness = InterHelper.GetColorSVA(num3);
			freeColorAlpha.opacity = InterHelper.GetColorSVA(a);
			return freeColorAlpha;
		}

		// Token: 0x06000366 RID: 870 RVA: 0x0000DE58 File Offset: 0x0000C058
		public static Color InterpretarColorAlpha_Inverse(FreeColorAlpha interpretacion)
		{
			float num = interpretacion.hue.InterpretarHue_Inverse();
			float colorSVA_Inverse = InterHelper.GetColorSVA_Inverse(interpretacion.saturation);
			float colorSVA_Inverse2 = InterHelper.GetColorSVA_Inverse(interpretacion.brightness);
			float colorSVA_Inverse3 = InterHelper.GetColorSVA_Inverse(interpretacion.opacity);
			Color color = Color.HSVToRGB(num, colorSVA_Inverse, colorSVA_Inverse2);
			color.a = colorSVA_Inverse3;
			return color;
		}

		// Token: 0x06000367 RID: 871 RVA: 0x0000DEAC File Offset: 0x0000C0AC
		public static Color InterpretarColor_Inverse(FreeColor interpretacion)
		{
			float num = interpretacion.hue.InterpretarHue_Inverse();
			float colorSVA_Inverse = InterHelper.GetColorSVA_Inverse(interpretacion.saturation);
			float colorSVA_Inverse2 = InterHelper.GetColorSVA_Inverse(interpretacion.brightness);
			return Color.HSVToRGB(num, colorSVA_Inverse, colorSVA_Inverse2);
		}

		// Token: 0x06000368 RID: 872 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		public static Color InterpretarColor_Inverse(FreeColor interpretacion, float minBrightness, float maxBrightness)
		{
			float num = interpretacion.hue.InterpretarHue_Inverse();
			float colorSVA_Inverse = InterHelper.GetColorSVA_Inverse(interpretacion.saturation);
			float num2 = InterHelper.GetColorSVA_Inverse(interpretacion.brightness);
			num2 = Mathf.Lerp(minBrightness, maxBrightness, num2);
			return Color.HSVToRGB(num, colorSVA_Inverse, num2);
		}

		// Token: 0x06000369 RID: 873 RVA: 0x0000DF2C File Offset: 0x0000C12C
		public static FreeColor InterpretarColor(Color color)
		{
			FreeColor freeColor = default(FreeColor);
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(color, out num, out num2, out num3);
			freeColor.hue = num.InterpretarHue();
			freeColor.saturation = InterHelper.GetColorSVA(num2);
			freeColor.brightness = InterHelper.GetColorSVA(num3);
			return freeColor;
		}

		// Token: 0x0600036A RID: 874 RVA: 0x0000DF78 File Offset: 0x0000C178
		public static FreeColor InterpretarColor(Color color, float minBrightness, float maxBrightness)
		{
			FreeColor freeColor = default(FreeColor);
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(color, out num, out num2, out num3);
			num3 = Mathf.InverseLerp(minBrightness, maxBrightness, num3);
			freeColor.hue = num.InterpretarHue();
			freeColor.saturation = InterHelper.GetColorSVA(num2);
			freeColor.brightness = InterHelper.GetColorSVA(num3);
			return freeColor;
		}

		// Token: 0x0600036B RID: 875 RVA: 0x0000DFCC File Offset: 0x0000C1CC
		public static FreeColor InterpretarColor(Color colorL, Color colorR)
		{
			FreeColor freeColor = default(FreeColor);
			float num;
			float num2;
			float num3;
			Color.RGBToHSV(colorL, out num, out num2, out num3);
			float num4;
			float num5;
			float num6;
			Color.RGBToHSV(colorR, out num4, out num5, out num6);
			float num7 = (num + num4) / 2f;
			float num8 = (num2 + num5) / 2f;
			float num9 = (num3 + num6) / 2f;
			freeColor.hue = num7.InterpretarHue();
			freeColor.saturation = InterHelper.GetColorSVA(num8);
			freeColor.brightness = InterHelper.GetColorSVA(num9);
			return freeColor;
		}

		// Token: 0x0600036C RID: 876 RVA: 0x0000E048 File Offset: 0x0000C248
		[Obsolete("usar el color", true)]
		public static FreeColorAlpha InterpretarColorAlpha(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName)
		{
			FreeColorAlpha freeColorAlpha = default(FreeColorAlpha);
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 0, false);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 1, false);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 2, false);
			float modDeAlteradorD4 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 3, false);
			freeColorAlpha.hue = modDeAlteradorD.InterpretarHue();
			freeColorAlpha.saturation = InterHelper.GetColorSVA(modDeAlteradorD2);
			freeColorAlpha.brightness = InterHelper.GetColorSVA(modDeAlteradorD3);
			freeColorAlpha.opacity = InterHelper.GetColorSVA(modDeAlteradorD4);
			return freeColorAlpha;
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000E0BC File Offset: 0x0000C2BC
		[Obsolete("usar el color", true)]
		public static FreeColor InterpretarColor(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName)
		{
			FreeColor freeColor = default(FreeColor);
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 0, false);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 1, false);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName, 2, false);
			freeColor.hue = modDeAlteradorD.InterpretarHue();
			freeColor.saturation = InterHelper.GetColorSVA(modDeAlteradorD2);
			freeColor.brightness = InterHelper.GetColorSVA(modDeAlteradorD3);
			return freeColor;
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000E118 File Offset: 0x0000C318
		[Obsolete("usar el color", true)]
		public static FreeColor InterpretarColor(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorNameL, string alteradorNameR)
		{
			FreeColor freeColor = default(FreeColor);
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameL, 0, false);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameL, 1, false);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameL, 2, false);
			float modDeAlteradorD4 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameR, 0, false);
			float modDeAlteradorD5 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameR, 1, false);
			float modDeAlteradorD6 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameR, 2, false);
			float num = (modDeAlteradorD + modDeAlteradorD4) / 2f;
			float num2 = (modDeAlteradorD2 + modDeAlteradorD5) / 2f;
			float num3 = (modDeAlteradorD3 + modDeAlteradorD6) / 2f;
			freeColor.hue = num.InterpretarHue();
			freeColor.saturation = InterHelper.GetColorSVA(num2);
			freeColor.brightness = InterHelper.GetColorSVA(num3);
			return freeColor;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000E1B8 File Offset: 0x0000C3B8
		public static SkinDifficulty InterpretarDificultad(IRangesParaInterpretadores @default, IRangesParaInterpretadores current)
		{
			return new SkinDifficulty
			{
				painSensitivity = InterHelper.GetSensibilidad(@default.painSensibilidad_MinWorldRango_Tactil, current.painSensibilidad_MinWorldRango_Tactil, false),
				pleasureSensitivity = InterHelper.GetSensibilidadConDistance(@default.pleasureSensibilidad_MinWorldRango_Tactil, current.pleasureSensibilidad_MinWorldRango_Tactil, @default.pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil, current.pleasureSensibilidad_MinMaxWorldDistanceRango_Tactil, false),
				painGain = InterHelper.GetGain(@default.painGain_MaxGeneracion, current.painGain_MaxGeneracion),
				pleasureGain = InterHelper.GetGain(@default.pleasureGain_MaxGeneracion, current.pleasureGain_MaxGeneracion),
				anoyanceGain = InterHelper.GetGain(@default.rageGain_MaxGeneracion, current.rageGain_MaxGeneracion),
				maxPleasure = InterHelper.GetMaxValue(@default.pleasure_MaxValue, current.pleasure_MaxValue),
				favorabilityRequirementVisual = InterHelper.GetFavorability(@default.visualFavoravility, current.visualFavoravility),
				favorabilityRequirementTactile = InterHelper.GetFavorability(@default.tactilFavoravility, current.tactilFavoravility),
				favorabilityRequirementExposure = InterHelper.GetFavorability(@default.exposureFavoravility, current.exposureFavoravility)
			};
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
		public static float GetModDeAlteradorND(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName, int index, bool inverted = false)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[alteradorName];
			}
			catch (Exception)
			{
				throw;
			}
			if (modificadoresDeAlterador.initials.GetValueOrDefaultReadOnly(index) != 0.5f)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod ND que es incorrecto");
			}
			float num = Mathf.Clamp01(modificadoresDeAlterador.modificadores.GetValueOrDefault(index));
			return inverted ? (1f - num) : num;
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000E32C File Offset: 0x0000C52C
		public static void SetModDeAlteradorND(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName, int index, float value, bool inverted = false)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[alteradorName];
			}
			catch (Exception)
			{
				throw;
			}
			if (modificadoresDeAlterador.initials.GetValueOrDefaultReadOnly(index) != 0.5f)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod ND que es incorrecto");
			}
			value = (inverted ? (1f - value) : value);
			modificadoresDeAlterador.modificadores.SetValueAt(index, Mathf.Clamp01(value));
		}

		// Token: 0x06000372 RID: 882 RVA: 0x0000E3A8 File Offset: 0x0000C5A8
		public static float GetModDeAlteradorD(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName, int index, bool inverted = false)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[alteradorName];
			}
			catch (Exception)
			{
				throw;
			}
			if (modificadoresDeAlterador.initials.GetValueOrDefaultReadOnly(index) != 0f)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod D que es incorrecto");
			}
			float num = Mathf.Clamp01(modificadoresDeAlterador.modificadores.GetValueOrDefault(index));
			return inverted ? (1f - num) : num;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x0000E420 File Offset: 0x0000C620
		public static void SetModDeAlteradorD(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName, int index, float value, bool inverted = false)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[alteradorName];
			}
			catch (Exception)
			{
				throw;
			}
			if (modificadoresDeAlterador.initials.GetValueOrDefaultReadOnly(index) != 0f)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod D que es incorrecto");
			}
			value = (inverted ? (1f - value) : value);
			modificadoresDeAlterador.modificadores.SetValueAt(index, Mathf.Clamp01(value));
		}

		// Token: 0x06000374 RID: 884 RVA: 0x0000E49C File Offset: 0x0000C69C
		public static void SetIndexToAlteradorDeIndex(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName, int indexDeModificador, int index)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[alteradorName];
			}
			catch (Exception)
			{
				throw;
			}
			if (modificadoresDeAlterador.initials.GetValueOrDefaultReadOnly(indexDeModificador) != 0f)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod D que es incorrecto");
			}
			if (modificadoresDeAlterador.indexCount <= 0 || modificadoresDeAlterador.indexMaxCount <= 0)
			{
				Debug.LogError("Tratando de interpretar un modificador de alterador: " + modificadoresDeAlterador.alteradorName + " con metohod solo para alteradores de index");
			}
			float num = (float)index / (float)modificadoresDeAlterador.indexMaxCount;
			modificadoresDeAlterador.modificadores.SetValueAt(indexDeModificador, Mathf.Clamp01(num));
		}

		// Token: 0x06000375 RID: 885 RVA: 0x0000E53C File Offset: 0x0000C73C
		public static float GetModDeAlteradoresMixtos(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorNameD, string alteradorNameND, int indexD, int indexND, bool invertedD = false, bool invertedND = false)
		{
			float num = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameD, indexD, false);
			if (!invertedD)
			{
				num = Mathf.Lerp(0.5f, 1f, num);
			}
			else
			{
				num = Mathf.Lerp(0.5f, 0f, num);
			}
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorNameND, indexND, invertedND);
			return (num + modDeAlteradorND) / 2f;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000E590 File Offset: 0x0000C790
		public static float GetModDeSliderConPrioridad(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorNameBaja, string alteradorNameAlta, int indexBaja, int indexAlta, bool invertedBaja = false, bool invertedAlta = false)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameAlta, indexAlta, invertedAlta);
			if (modDeAlteradorD > 0f)
			{
				return Mathf.Lerp(0.5f, 1f, modDeAlteradorD);
			}
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameBaja, indexBaja, invertedBaja);
			return Mathf.Lerp(0.5f, 0f, modDeAlteradorD2);
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		public static float GetModDeSlider(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorNameNegative, string alteradorNamePositive, int indexNegative, int indexPositive, bool invertedNegative = false, bool invertedPositive = false)
		{
			float num = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNameNegative, indexNegative, invertedNegative);
			float num2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorNamePositive, indexPositive, invertedPositive);
			num = Mathf.Lerp(0.5f, 0f, num);
			num2 = Mathf.Lerp(0.5f, 1f, num2);
			return (num + num2) / 2f;
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000E630 File Offset: 0x0000C830
		public static float GetModDeAlteradores(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, int index1, int index2, bool inverted1 = false, bool inverted2 = false)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			return (modDeAlteradorND + modDeAlteradorND2) / 2f;
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000E65C File Offset: 0x0000C85C
		public static float GetModDeAlteradores(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, int index1, int index2, int index3, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorND3 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			return (modDeAlteradorND + modDeAlteradorND2 + modDeAlteradorND3) / 3f;
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0000E698 File Offset: 0x0000C898
		public static float GetModDeAlteradores(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, string alteradorName4, int index1, int index2, int index3, int index4, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false, bool inverted4 = false)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorND3 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			float modDeAlteradorND4 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName4, index4, inverted4);
			return (modDeAlteradorND + modDeAlteradorND2 + modDeAlteradorND3 + modDeAlteradorND4) / 4f;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0000E6E4 File Offset: 0x0000C8E4
		public static float GetModDeAlteradores(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, string alteradorName4, string alteradorName5, int index1, int index2, int index3, int index4, int index5, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false, bool inverted4 = false, bool inverted5 = false)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorND3 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			float modDeAlteradorND4 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName4, index4, inverted4);
			float modDeAlteradorND5 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName5, index5, inverted5);
			return (modDeAlteradorND + modDeAlteradorND2 + modDeAlteradorND3 + modDeAlteradorND4 + modDeAlteradorND5) / 5f;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0000E73C File Offset: 0x0000C93C
		public static float GetModDeAlteradores(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, string alteradorName4, string alteradorName5, string alteradorName6, int index1, int index2, int index3, int index4, int index5, int index6, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false, bool inverted4 = false, bool inverted5 = false, bool inverted6 = false)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorND3 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			float modDeAlteradorND4 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName4, index4, inverted4);
			float modDeAlteradorND5 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName5, index5, inverted5);
			float modDeAlteradorND6 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, alteradorName6, index6, inverted6);
			return (modDeAlteradorND + modDeAlteradorND2 + modDeAlteradorND3 + modDeAlteradorND4 + modDeAlteradorND5 + modDeAlteradorND6) / 6f;
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0000E7A8 File Offset: 0x0000C9A8
		public static float GetModDeAlteradoresD(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, string alteradorName4, int index1, int index2, int index3, int index4, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false, bool inverted4 = false)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			float modDeAlteradorD4 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName4, index4, inverted4);
			return (modDeAlteradorD + modDeAlteradorD2 + modDeAlteradorD3 + modDeAlteradorD4) / 4f;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0000E7F4 File Offset: 0x0000C9F4
		public static float GetModDeAlteradoresD(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, string alteradorName4, string alteradorName5, string alteradorName6, int index1, int index2, int index3, int index4, int index5, int index6, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false, bool inverted4 = false, bool inverted5 = false, bool inverted6 = false)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			float modDeAlteradorD4 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName4, index4, inverted4);
			float modDeAlteradorD5 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName5, index5, inverted5);
			float modDeAlteradorD6 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName6, index6, inverted6);
			return (modDeAlteradorD + modDeAlteradorD2 + modDeAlteradorD3 + modDeAlteradorD4 + modDeAlteradorD5 + modDeAlteradorD6) / 6f;
		}

		// Token: 0x0600037F RID: 895 RVA: 0x0000E860 File Offset: 0x0000CA60
		public static float GetModDeAlteradoresD(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, int index1, int index2, int index3, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			return (modDeAlteradorD + modDeAlteradorD2 + modDeAlteradorD3) / 3f;
		}

		// Token: 0x06000380 RID: 896 RVA: 0x0000E89C File Offset: 0x0000CA9C
		[Obsolete("", true)]
		public static float GetModDeAlteradoresD_MULT(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, string alteradorName1, string alteradorName2, string alteradorName3, int index1, int index2, int index3, bool inverted1 = false, bool inverted2 = false, bool inverted3 = false)
		{
			float modDeAlteradorD = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName1, index1, inverted1);
			float modDeAlteradorD2 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName2, index2, inverted2);
			float modDeAlteradorD3 = InterHelper.GetModDeAlteradorD(preparedAlteradoresDicc, alteradorName3, index3, inverted3);
			return modDeAlteradorD * modDeAlteradorD2 * modDeAlteradorD3;
		}

		// Token: 0x06000381 RID: 897 RVA: 0x0000E8D0 File Offset: 0x0000CAD0
		[Obsolete("no estoy usando mod positivo ni mod negativo")]
		private static float ModValorAl05(float[] valores, int index, float modPositivo = 1f, float modNegativo = 1f)
		{
			return InterHelper.ModValorAl05(valores.GetValueOrDefault(index), modPositivo, modNegativo);
		}

		// Token: 0x06000382 RID: 898 RVA: 0x0000E8E0 File Offset: 0x0000CAE0
		[Obsolete("no estoy usando mod positivo ni mod negativo")]
		private static float ModValorAl05(float valor, float modPositivo, float modNegativo)
		{
			if (valor == 0.5f)
			{
				return valor;
			}
			if (valor > 0.5f)
			{
				return valor * modPositivo;
			}
			if (valor < 0.5f)
			{
				return valor * modNegativo;
			}
			throw new ArgumentOutOfRangeException();
		}
	}
}
