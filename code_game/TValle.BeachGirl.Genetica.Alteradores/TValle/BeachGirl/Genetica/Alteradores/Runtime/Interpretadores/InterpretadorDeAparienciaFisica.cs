using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Abstracts;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000058 RID: 88
	[Obsolete("dividir en varios, actualizar los randomizadores", true)]
	public static class InterpretadorDeAparienciaFisica
	{
		// Token: 0x06000426 RID: 1062 RVA: 0x0000F398 File Offset: 0x0000D598
		public static InterpretacionDeAparienciaFisica Interpretar(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc)
		{
			InterpretacionDeAparienciaFisica interpretacionDeAparienciaFisica = default(InterpretacionDeAparienciaFisica);
			interpretacionDeAparienciaFisica.culo = InterpretadorDeAparienciaFisica.InterpretarCulo(preparedAlteradoresDicc, InterpretacionModsCulo.@default, InterpretacionModsCulo.@default);
			interpretacionDeAparienciaFisica.tetas = InterpretadorDeAparienciaFisica.InterpretarTetas(preparedAlteradoresDicc, InterpretacionMods.@default, InterpretacionMods.@default);
			interpretacionDeAparienciaFisica.estatura = InterpretadorDeAparienciaFisica.InterpretarEstatura(preparedAlteradoresDicc, InterpretacionMods.@default, InterpretacionMods.@default);
			interpretacionDeAparienciaFisica.bodyFat = InterpretadorDeAparienciaFisica.InterpretarBodyfat(preparedAlteradoresDicc, InterpretacionMods.@default, InterpretacionMods.@default);
			interpretacionDeAparienciaFisica.thickness = InterpretadorDeAparienciaFisica.InterpretarTickness(preparedAlteradoresDicc, InterpretacionMods.@default, InterpretacionMods.@default, interpretacionDeAparienciaFisica.culo, interpretacionDeAparienciaFisica.bodyFat);
			interpretacionDeAparienciaFisica.tonoPiel = InterpretadorDeAparienciaFisica.InterpretarTonoPiel(preparedAlteradoresDicc, InterpretacionModsColor.@default, InterpretacionModsColor.@default);
			interpretacionDeAparienciaFisica.pielTrigena = InterpretadorDeAparienciaFisica.InterpretarPielTrigena(preparedAlteradoresDicc, InterpretacionModsColor.@default, InterpretacionModsColor.@default, interpretacionDeAparienciaFisica.tonoPiel);
			interpretacionDeAparienciaFisica.tonoCabello = InterpretadorDeAparienciaFisica.InterpretarTonoCabello(preparedAlteradoresDicc, InterpretacionModsColor.@default, InterpretacionModsColor.@default);
			interpretacionDeAparienciaFisica.tonoOjos = InterpretadorDeAparienciaFisica.InterpretarTonoOjos(preparedAlteradoresDicc, InterpretacionModsColor.@default, InterpretacionModsColor.@default);
			return interpretacionDeAparienciaFisica;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000F494 File Offset: 0x0000D694
		public static InterpretacionDeAparienciaFisica Interpretar(MapaDeValoresDeAlteradoresBase mapa)
		{
			bool flag = mapa.preparedAlteradoresDicc != null;
			InterpretacionDeAparienciaFisica interpretacionDeAparienciaFisica;
			try
			{
				if (!flag)
				{
					mapa.PrepareAlteradoresDicc();
				}
				interpretacionDeAparienciaFisica = InterpretadorDeAparienciaFisica.Interpretar(mapa.preparedAlteradoresDicc);
			}
			finally
			{
				if (!flag)
				{
					mapa.FinalizeAlteradoresDicc();
				}
			}
			return interpretacionDeAparienciaFisica;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x0000F4E0 File Offset: 0x0000D6E0
		private static Interpretacion.Size InterpretarCulo(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionModsCulo modPositivo, InterpretacionModsCulo modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			ModificadoresDeAlterador modificadoresDeAlterador2;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L];
				modificadoresDeAlterador2 = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R];
			}
			catch (Exception)
			{
				throw;
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 0, modPositivo.culoGeneral, modNegativo.culoGeneral);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 1, modPositivo.culoX, modNegativo.culoX);
			float num3 = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 2, modPositivo.culoY, modNegativo.culoY);
			float num4 = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 3, modPositivo.culoZ, modNegativo.culoZ);
			float num5 = Mathf.Pow(num2 * num3 * num4, 0.33333334f);
			float num6 = MathfExtension.InverseLerpConMedio(0f, 0.5f, 1f, num5);
			return (Interpretacion.Size)InterpretadorDeAparienciaFisica.CalcularPuntaje(MathfExtension.LerpConMedio(0f, num, 1f, num6), 0.15f, 0.05f, 0.75f, null, null);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x0000F600 File Offset: 0x0000D800
		private static Interpretacion.Size InterpretarTetas(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionMods modPositivo, InterpretacionMods modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			ModificadoresDeAlterador modificadoresDeAlterador2;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_L];
				modificadoresDeAlterador2 = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_R];
			}
			catch (Exception)
			{
				throw;
			}
			return (Interpretacion.Size)InterpretadorDeAparienciaFisica.CalcularPuntaje(InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 0, modPositivo.general, modNegativo.general), 0.33f, 0.145f, 0.66f, null, null);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x0000F680 File Offset: 0x0000D880
		private static Interpretacion.Size InterpretarEstatura(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionMods modPositivo, InterpretacionMods modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scala_Puppet];
			}
			catch (Exception)
			{
				throw;
			}
			return (Interpretacion.Size)InterpretadorDeAparienciaFisica.CalcularPuntaje(InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 0, modPositivo.general, modNegativo.general), 0.4f, 0.12f, 0.8f, null, null);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x0000F6EC File Offset: 0x0000D8EC
		private static Interpretacion.Capacidad InterpretarBodyfat(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionMods modPositivo, InterpretacionMods modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_BODY_fat];
			}
			catch (Exception)
			{
				throw;
			}
			return (Interpretacion.Capacidad)InterpretadorDeAparienciaFisica.CalcularPuntaje(InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 0, modPositivo.general, modNegativo.general), 0.5f, 0.175f, 0.75f, null, null);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x0000F758 File Offset: 0x0000D958
		private static Interpretacion.Capacidad InterpretarTickness(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionMods modPositivo, InterpretacionMods modNegativo, Interpretacion.Size culoInterpretacion, Interpretacion.Capacidad bodyFatInterpretacion)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			ModificadoresDeAlterador modificadoresDeAlterador2;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_L];
				modificadoresDeAlterador2 = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_R];
			}
			catch (Exception)
			{
				throw;
			}
			float num = ((float)(InterpretadorDeAparienciaFisica.CalcularPuntaje(InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 0, modPositivo.general, modNegativo.general), 0.35f, 0.12f, 0.75f, null, null) * 2) + (float)culoInterpretacion + (float)bodyFatInterpretacion * 2f) / 5f;
			num = Mathf.InverseLerp(-2f, 2f, num);
			num = num.InPow(1.25f);
			num = Mathf.Lerp(-2f, 2f, num);
			return (Interpretacion.Capacidad)InterpretadorDeAparienciaFisica.ClampToPuntaje(num);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x0000F824 File Offset: 0x0000DA24
		private static Interpretacion.Tono InterpretarTonoPiel(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionModsColor modPositivo, InterpretacionModsColor modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel];
			}
			catch (Exception)
			{
				throw;
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 1, modPositivo.saturation, modNegativo.saturation);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 2, modPositivo.brightness, modNegativo.brightness);
			float num3 = Mathf.Lerp(1f, 0.5f, num);
			num3 = Mathf.Lerp(0f, num3, num2);
			return (Interpretacion.Tono)InterpretadorDeAparienciaFisica.CalcularPuntaje(num3, 0.5f, 0.25f, 0.775f, null, null);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0000F8CC File Offset: 0x0000DACC
		private static Interpretacion.Capacidad InterpretarPielTrigena(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionModsColor modPositivo, InterpretacionModsColor modNegativo, Interpretacion.Tono tonoPiel)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_MainPiel];
			}
			catch (Exception)
			{
				throw;
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 0, modPositivo.hue, modNegativo.hue);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 1, modPositivo.saturation, modNegativo.saturation);
			int num3 = InterpretadorDeAparienciaFisica.CalcularPuntaje(num, 0.75f, 0.6f, 0.9f, new float?(0.075f), new float?(0.075f));
			float num4 = Mathf.Lerp(-2f, (float)num3, num2.OutPow(2f));
			float num5 = Mathf.InverseLerp(2f, -2f, (float)tonoPiel);
			num4 = Mathf.Lerp(-2f, num4, num5);
			return (Interpretacion.Capacidad)InterpretadorDeAparienciaFisica.ClampToPuntaje(num4);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000F99C File Offset: 0x0000DB9C
		private static Interpretacion.Tono InterpretarTonoCabello(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionModsColor modPositivo, InterpretacionModsColor modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_StyloDeCabello];
			}
			catch (Exception)
			{
				throw;
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 1, modPositivo.saturation, modNegativo.saturation);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05(modificadoresDeAlterador.modificadores, 2, modPositivo.brightness, modNegativo.brightness);
			float num3 = Mathf.Lerp(1f, 0.775f, num);
			num3 = Mathf.Lerp(0f, num3, num2);
			return (Interpretacion.Tono)InterpretadorDeAparienciaFisica.CalcularPuntaje(num3, 0.5f, 0.25f, 0.775f, null, null);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000FA44 File Offset: 0x0000DC44
		private static Interpretacion.Tono InterpretarTonoOjos(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, InterpretacionModsColor modPositivo, InterpretacionModsColor modNegativo)
		{
			ModificadoresDeAlterador modificadoresDeAlterador;
			ModificadoresDeAlterador modificadoresDeAlterador2;
			try
			{
				modificadoresDeAlterador = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Iris_L];
				modificadoresDeAlterador2 = preparedAlteradoresDicc[DiccionarioDeNombresDeAlteradoresFemeninos.Coloreador_Iris_R];
			}
			catch (Exception)
			{
				throw;
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 1, modPositivo.saturation, modNegativo.saturation);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05_Prom(modificadoresDeAlterador.modificadores, modificadoresDeAlterador2.modificadores, 2, modPositivo.brightness, modNegativo.brightness);
			float num3 = Mathf.Lerp(1f, 0.5f, num.OutPow(2f));
			num3 = Mathf.Lerp(0f, num3, num2);
			return (Interpretacion.Tono)InterpretadorDeAparienciaFisica.CalcularPuntaje(num3, 0.5f, 0.25f, 0.775f, null, null);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0000FB14 File Offset: 0x0000DD14
		private static float ModValorAl05_Prom(float[] valoresA, float[] valoresB, int index, float modPositivo, float modNegativo)
		{
			if (valoresA == valoresB)
			{
				throw new InvalidOperationException();
			}
			float num = InterpretadorDeAparienciaFisica.ModValorAl05(valoresA.GetValueOrDefault(index), modPositivo, modNegativo);
			float num2 = InterpretadorDeAparienciaFisica.ModValorAl05(valoresB.GetValueOrDefault(index), modPositivo, modNegativo);
			return (num + num2) / 2f;
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0000FB52 File Offset: 0x0000DD52
		private static float ModValorAl05(float[] valores, int index, float modPositivo, float modNegativo)
		{
			return InterpretadorDeAparienciaFisica.ModValorAl05(valores.GetValueOrDefault(index), modPositivo, modNegativo);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0000FB62 File Offset: 0x0000DD62
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

		// Token: 0x06000434 RID: 1076 RVA: 0x0000FB8B File Offset: 0x0000DD8B
		private static int ClampToPuntaje(float valor)
		{
			return InterpretadorDeAparienciaFisica.ClampToPuntaje(Mathf.RoundToInt(valor));
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0000FB98 File Offset: 0x0000DD98
		private static int ClampToPuntaje(int valor)
		{
			if (valor < -2)
			{
				valor = -2;
			}
			if (valor > 2)
			{
				valor = 2;
			}
			return valor;
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0000FBAB File Offset: 0x0000DDAB
		private static int CalcularPuntajeInverted(float valor, float middle, float verySmall, float veryLarge, float? ThresholdSmallOverride = null, float? ThresholdGrandeOverride = null)
		{
			if (middle <= veryLarge)
			{
				throw new NotSupportedException();
			}
			if (middle >= verySmall)
			{
				throw new NotSupportedException();
			}
			return -1 * InterpretadorDeAparienciaFisica.CalcularPuntaje(valor, middle, veryLarge, verySmall, ThresholdSmallOverride, ThresholdGrandeOverride);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
		private static int CalcularPuntaje(float valor, float middle, float verySmall, float veryLarge, float? ThresholdSmallOverride = null, float? ThresholdGrandeOverride = null)
		{
			veryLarge = Mathf.Clamp01(veryLarge);
			verySmall = Mathf.Clamp01(verySmall);
			middle = Mathf.Clamp01(middle);
			valor = Mathf.Clamp01(valor);
			if (middle >= veryLarge)
			{
				throw new NotSupportedException();
			}
			if (middle <= verySmall)
			{
				throw new NotSupportedException();
			}
			float num = middle;
			float num2 = 1f - middle;
			float num3 = ThresholdSmallOverride ?? (num * 0.1f * 2f);
			float num4 = ThresholdGrandeOverride ?? (num2 * 0.1f * 2f);
			float num5 = middle - num3;
			float num6 = middle + num4;
			if (num5 < verySmall)
			{
				verySmall = num5;
			}
			if (num6 > veryLarge)
			{
				veryLarge = num6;
			}
			if (valor >= num5 && valor <= num6)
			{
				return 0;
			}
			if (valor > veryLarge)
			{
				return 2;
			}
			if (valor < verySmall)
			{
				return -2;
			}
			if (valor < num5)
			{
				return -1;
			}
			if (valor > num6)
			{
				return 1;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0400019A RID: 410
		public const float nalgaScaleMiddle = 0.15f;

		// Token: 0x0400019B RID: 411
		public const float nalgaScaleAxisMiddle = 0.5f;

		// Token: 0x0400019C RID: 412
		public const float nalgaDesplazaminetoZMiddle = 0.25f;

		// Token: 0x0400019D RID: 413
		public const float piernasAnchoMiddle = 0.35f;

		// Token: 0x0400019E RID: 414
		public const float senosScaleMiddle = 0.33f;

		// Token: 0x0400019F RID: 415
		public const float estaturaScaleMiddle = 0.4f;

		// Token: 0x040001A0 RID: 416
		public const float bodyFatAmountMiddle = 0.5f;

		// Token: 0x040001A1 RID: 417
		public const float pielTonoMiddle = 0.5f;

		// Token: 0x040001A2 RID: 418
		public const float pielTonoTrigenaMiddle = 0.75f;

		// Token: 0x040001A3 RID: 419
		public const float cabelloTonoMiddle = 0.5f;

		// Token: 0x040001A4 RID: 420
		public const float ojosTonoMiddle = 0.5f;

		// Token: 0x040001A5 RID: 421
		public const float nalgaScaleVeryLarge = 0.75f;

		// Token: 0x040001A6 RID: 422
		public const float nalgaScaleVerySmall = 0.05f;

		// Token: 0x040001A7 RID: 423
		[Obsolete]
		public const float nalgaScaleAxisVeryLarge = 0.8f;

		// Token: 0x040001A8 RID: 424
		[Obsolete]
		public const float nalgaScaleAxisVerySmall = 0.2f;

		// Token: 0x040001A9 RID: 425
		public const float senosScaleVeryLarge = 0.66f;

		// Token: 0x040001AA RID: 426
		public const float senosScaleVerySmall = 0.145f;

		// Token: 0x040001AB RID: 427
		public const float estaturaScaleVeryLarge = 0.8f;

		// Token: 0x040001AC RID: 428
		public const float estaturaScaleVerySmall = 0.12f;

		// Token: 0x040001AD RID: 429
		public const float bodyFatAmountVeryLarge = 0.75f;

		// Token: 0x040001AE RID: 430
		public const float bodyFatAmountVerySmall = 0.175f;

		// Token: 0x040001AF RID: 431
		public const float piernasAnchoVeryLarge = 0.75f;

		// Token: 0x040001B0 RID: 432
		public const float piernasAnchoVerySmall = 0.12f;

		// Token: 0x040001B1 RID: 433
		public const float pielTonoVeryLight = 0.775f;

		// Token: 0x040001B2 RID: 434
		public const float pielTonoVeryDark = 0.25f;

		// Token: 0x040001B3 RID: 435
		public const float pielTonoTrigenaVeryHigh = 0.9f;

		// Token: 0x040001B4 RID: 436
		public const float pielTonoTrigenaVeryLow = 0.6f;

		// Token: 0x040001B5 RID: 437
		public const float cabelloTonoVeryLight = 0.775f;

		// Token: 0x040001B6 RID: 438
		public const float cabelloTonoVeryDark = 0.25f;

		// Token: 0x040001B7 RID: 439
		public const float ojosTonoVeryLight = 0.775f;

		// Token: 0x040001B8 RID: 440
		public const float ojosTonoVeryDark = 0.25f;
	}
}
