using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200002C RID: 44
	public static class InterpretadorDeSenos
	{
		// Token: 0x06000115 RID: 277 RVA: 0x00006B54 File Offset: 0x00004D54
		public static InterpretacionDeSenos Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, ISenosRangesParaInterpretadores rangosDefaults, ISenosRangesParaInterpretadores rangosHelper, ISenosInterpretadorHelper senosHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (senosHelper == null)
			{
				throw new ArgumentNullException("senosHelper", "senosHelper null reference.");
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
			return new InterpretacionDeSenos
			{
				size = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_R, 0, 0, false, false)),
				projection = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Estirador_Pezones_L, DiccionarioDeNombresDeAlteradoresFemeninos.Estirador_Pezones_R, 0, 0, false, false)),
				distance = InterHelper.GetParaGenesDefault<Interpretacion.Distance>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorLateral_Seno_L, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorLateral_Seno_R, 0, 0, true, true)),
				sagginess = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Senos_L, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Senos_R, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorAltura_Seno_L, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorAltura_Seno_R, 0, 0, 0, 0, true, true, true, true)),
				nippleSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(MathfExtension.LerpConMedio(0f, 1f, 2f, senosHelper.currentSubjectiveNippleSize) * InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pezon_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pezon_R, 0, 0, false, false)),
				areolaSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(MathfExtension.LerpConMedio(0f, 1f, 2f, senosHelper.currentSubjectiveAureolaSize) * InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_SenosAureola, 0, false)),
				nippleColor = InterHelper.InterpretarColor(senosHelper.colorDePezonesSinModificaciones, senosHelper.minBrightness, senosHelper.maxBrightness),
				difficulty = InterHelper.InterpretarDificultad(rangosDefaults, rangosHelper)
			};
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00006CF0 File Offset: 0x00004EF0
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeSenos interpretacion, out Color colorDePezones, float minBrightness, float maxBrightness)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Estirador_Pezones_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.projection), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Estirador_Pezones_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.projection), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorLateral_Seno_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.DesplazadorLateral_Seno_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Senos_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.sagginess), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Suavizador_Senos_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.sagginess), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pezon_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.nippleSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pezon_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.nippleSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_SenosAureola, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.areolaSize), false);
			colorDePezones = InterHelper.InterpretarColor_Inverse(interpretacion.nippleColor, minBrightness, maxBrightness);
		}

		// Token: 0x04000045 RID: 69
		public const float senosScaleMiddle = 0.33f;
	}
}
