using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200001B RID: 27
	public static class InterpretadorDeAss
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x00003694 File Offset: 0x00001894
		public static InterpretacionDeAss Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, INalgasRangesParaInterpretadores rangosDefaults, INalgasRangesParaInterpretadores rangosHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (rangosHelper == null)
			{
				throw new ArgumentNullException("rangosHelper", "rangosHelper null reference.");
			}
			if (rangosDefaults == null)
			{
				throw new ArgumentNullException("rangosDefaults", "rangosDefaults null reference.");
			}
			if (rangosHelper == rangosDefaults)
			{
				throw new InvalidOperationException();
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterpretacionDeAss interpretacionDeAss = default(InterpretacionDeAss);
			Interpretacion.Size size;
			Interpretacion.Capacidad capacidad;
			InterpretadorDeAss.InterpretarNalgas(preparedAlteradoresAparienciaDicc, out size, out capacidad);
			interpretacionDeAss.size = size;
			interpretacionDeAss.projection = capacidad;
			interpretacionDeAss.anusGap = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_GlutenAperture_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_GlutenAperture_R, 0, 0, false, false));
			interpretacionDeAss.sagginess = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Nalga_L, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Nalga_R, 0, 0, true, true));
			interpretacionDeAss.difficulty = InterHelper.InterpretarDificultad(rangosDefaults, rangosHelper);
			return interpretacionDeAss;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000375C File Offset: 0x0000195C
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeAss interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			float num = InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Size>(interpretacion.size, 0.15f);
			float num2 = InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Size>(interpretacion.size, 0.15f);
			float num3 = InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Size>(interpretacion.size, 0.15f);
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.projection);
			num3 = MathfExtension.LerpConMedio(Mathf.Clamp01(num3 * 0.666f), num3, Mathf.Clamp01(num3 * 1.5f), paraGenesDefault_Inverse);
			num2 = MathfExtension.LerpConMedio(Mathf.Clamp01(num2 * 1.333333f), num2, Mathf.Clamp01(num2 * 0.75f), paraGenesDefault_Inverse);
			num = MathfExtension.LerpConMedio(Mathf.Clamp01(num * 1.333333f), num, Mathf.Clamp01(num * 0.75f), paraGenesDefault_Inverse);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 1, num, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 1, num, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 2, num2, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 2, num2, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 3, num3, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 3, num3, false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_GlutenAperture_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.anusGap), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_GlutenAperture_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.anusGap), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Nalga_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.sagginess), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Nalga_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.sagginess), true);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000038DC File Offset: 0x00001ADC
		private static void InterpretarNalgas(IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresDicc, out Interpretacion.Size size, out Interpretacion.Capacidad proyeccion)
		{
			float modDeAlteradorND = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 0, false);
			float modDeAlteradorND2 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 0, false);
			float num = (modDeAlteradorND + modDeAlteradorND2) / 2f;
			float modDeAlteradorND3 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 1, false);
			float modDeAlteradorND4 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 1, false);
			float num2 = (modDeAlteradorND3 + modDeAlteradorND4) / 2f;
			float modDeAlteradorND5 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 2, false);
			float modDeAlteradorND6 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 2, false);
			float num3 = (modDeAlteradorND5 + modDeAlteradorND6) / 2f;
			float modDeAlteradorND7 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L, 3, false);
			float modDeAlteradorND8 = InterHelper.GetModDeAlteradorND(preparedAlteradoresDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R, 3, false);
			float num4 = (modDeAlteradorND7 + modDeAlteradorND8) / 2f;
			float num5 = Mathf.Pow(num2 * num3 * num4, 0.33333334f);
			float num6 = MathfExtension.InverseLerpConMedio(0f, 0.5f, 1f, num5);
			float num7 = MathfExtension.LerpConMedio(0f, num, 1f, num6);
			size = InterHelper.GetParaGenesNoCentrados<Interpretacion.Size>(num7, 0.15f);
			float num8 = num4;
			float num9 = Mathf.Pow(num2 * num3, 0.5f);
			float num10 = MathfExtension.InverseLerpConMedio(0f, 0.5f, 1f, num8);
			float num11 = MathfExtension.InverseLerpConMedio(0f, 0.5f, 1f, num9);
			num8 = MathfExtension.LerpConMedio(0f, num, 1f, num10);
			num9 = MathfExtension.LerpConMedio(0f, num, 1f, num11);
			num8 = Mathf.InverseLerp(-1f, 1f, num8 - num9);
			proyeccion = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(num8);
		}

		// Token: 0x04000027 RID: 39
		public const float nalgaScaleMiddle = 0.15f;

		// Token: 0x04000028 RID: 40
		public const float nalgaScaleAxisMiddle = 0.5f;

		// Token: 0x04000029 RID: 41
		public const float nalgaDesplazaminetoZMiddle = 0.25f;
	}
}
