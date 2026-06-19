using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200001A RID: 26
	public static class InterpretadorDeAnus
	{
		// Token: 0x060000E1 RID: 225 RVA: 0x00003330 File Offset: 0x00001530
		public static InterpretacionDeAnus Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IEstadisticasDeHoleInterpretadorHelper holeHelper, IHoleRangesParaInterpretadores rangosDefaults, IHoleRangesParaInterpretadores rangosHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (holeHelper == null)
			{
				throw new ArgumentNullException("holeHelper", "holeHelper null reference.");
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
			InterpretacionDeAnus interpretacionDeAnus = default(InterpretacionDeAnus);
			interpretacionDeAnus.size = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Anus, 0, false));
			interpretacionDeAnus.opening = InterHelper.GetParaGenesNoCentrados<Interpretacion.Opening>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Controller_AnusDesgaste, 0, false), 0.2f);
			interpretacionDeAnus.profundidad = InterpretadorDeAnus.AnoSizeProfundidad(holeHelper);
			interpretacionDeAnus.anchura = InterpretadorDeAnus.AnoSizeAnchura(holeHelper);
			interpretacionDeAnus.difficulty.painSensitivity = InterHelper.GetSensibilidad(rangosDefaults.analPainSensibilidad_MinWorldRango_Tactil, rangosDefaults.analPainSensibilidad_MinWorldRango_Coital, rangosHelper.analPainSensibilidad_MinWorldRango_Tactil, rangosHelper.analPainSensibilidad_MinWorldRango_Coital, false);
			interpretacionDeAnus.difficulty.pleasureSensitivity = InterHelper.GetSensibilidadConDistance(rangosDefaults.analPleasureSensibilidad_MinWorldRango_Tactil, rangosDefaults.analPleasureSensibilidad_MinWorldRango_Coital, rangosHelper.analPleasureSensibilidad_MinWorldRango_Tactil, rangosHelper.analPleasureSensibilidad_MinWorldRango_Coital, rangosDefaults.analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosDefaults.analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, rangosHelper.analPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosHelper.analPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, false);
			interpretacionDeAnus.difficulty.painGain = InterHelper.GetGain(rangosDefaults.analPainGain_MaxGeneracion, rangosDefaults.analPainGain_MaxGeneracion_Coital, rangosHelper.analPainGain_MaxGeneracion, rangosHelper.analPainGain_MaxGeneracion_Coital);
			interpretacionDeAnus.difficulty.pleasureGain = InterHelper.GetGain(rangosDefaults.analPleasureGain_MaxGeneracion, rangosDefaults.analPleasureGain_MaxGeneracion_Coital, rangosHelper.analPleasureGain_MaxGeneracion, rangosHelper.analPleasureGain_MaxGeneracion_Coital);
			interpretacionDeAnus.difficulty.anoyanceGain = InterHelper.GetGain(rangosDefaults.analRageGain_MaxGeneracion, rangosDefaults.analRageGain_MaxGeneracion_Coital, rangosHelper.analRageGain_MaxGeneracion, rangosHelper.analRageGain_MaxGeneracion_Coital);
			interpretacionDeAnus.difficulty.maxPleasure = InterHelper.GetMaxValue(rangosDefaults.analPleasure_MaxValue_Tactil, rangosDefaults.analPleasure_MaxValue_Coital, rangosHelper.analPleasure_MaxValue_Tactil, rangosHelper.analPleasure_MaxValue_Coital);
			interpretacionDeAnus.difficulty.favorabilityRequirementVisual = InterHelper.GetFavorability(rangosDefaults.analVisualFavoravility, rangosHelper.analVisualFavoravility);
			interpretacionDeAnus.difficulty.favorabilityRequirementTactile = InterHelper.GetFavorability(rangosDefaults.analTactilFavoravility, rangosHelper.analTactilFavoravility);
			interpretacionDeAnus.difficulty.favorabilityRequirementExposure = InterHelper.GetFavorability(rangosDefaults.analExposureFavoravility, rangosHelper.analExposureFavoravility);
			interpretacionDeAnus.difficulty.favorabilityRequirementCoital = InterHelper.GetFavorability(rangosDefaults.analCoitalFavoravility, rangosHelper.analCoitalFavoravility);
			return interpretacionDeAnus;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00003578 File Offset: 0x00001778
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeAnus interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Anus, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Controller_AnusDesgaste, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Opening>(interpretacion.opening, 0.2f), false);
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000035D4 File Offset: 0x000017D4
		private static Interpretacion.HoleDepth AnoSizeProfundidad(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.AnalProfundidadRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeAnus.analWorldProfundidades, InterpretadorDeAnus.analProfundidadesOffsetsResult);
			return InterHelper.GetProfundidadConOffsetDeEstados(InterpretadorDeAnus.analProfundidadesOffsetsResult);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x0000360C File Offset: 0x0000180C
		private static Interpretacion.Tightness AnoSizeAnchura(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.AnalAnchuraRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeAnus.analWorldAnchuras, InterpretadorDeAnus.analAnchurasOffsetsResult);
			return InterHelper.GetTightnessConOffsetDeEstados(InterpretadorDeAnus.analAnchurasOffsetsResult);
		}

		// Token: 0x04000016 RID: 22
		public const float maxDesgastePorApertura = 0.333f;

		// Token: 0x04000017 RID: 23
		public const float desgasteGeneWMiddle = 0.2f;

		// Token: 0x04000018 RID: 24
		public const float physcisAnalSize = 0.2183122f;

		// Token: 0x04000019 RID: 25
		public const float analSuperSizeQueenProfundidadThresshold = 0.3175133f;

		// Token: 0x0400001A RID: 26
		public const float analSizeQueenProfundidadThresshold = 0.2645944f;

		// Token: 0x0400001B RID: 27
		public const float analSizeNormalProfundidadThresshold = 0.22049533f;

		// Token: 0x0400001C RID: 28
		public const float analSizeSmallProfundidadThresshold = 0.18374604f;

		// Token: 0x0400001D RID: 29
		public const float analSizeVerySmallProfundidadThresshold = 0.15312175f;

		// Token: 0x0400001E RID: 30
		public const float analSuperSizeQueenAnchuraThresshold = 0.052519996f;

		// Token: 0x0400001F RID: 31
		public const float analSizeQueenAnchuraThresshold = 0.04545f;

		// Token: 0x04000020 RID: 32
		public const float analSizeNormalAnchuraThresshold = 0.0404f;

		// Token: 0x04000021 RID: 33
		public const float analSizeSmallAnchuraThresshold = 0.030299999f;

		// Token: 0x04000022 RID: 34
		public const float analSizeVerySmallAnchuraThresshold = 0.0202f;

		// Token: 0x04000023 RID: 35
		private static readonly float[] analWorldProfundidades = new float[] { 0.3175133f, 0.2645944f, 0.22049533f, 0.18374604f, 0.15312175f };

		// Token: 0x04000024 RID: 36
		private static readonly float[] analWorldAnchuras = new float[] { 0.052519996f, 0.04545f, 0.0404f, 0.030299999f, 0.0202f };

		// Token: 0x04000025 RID: 37
		private static readonly float[] analProfundidadesOffsetsResult = new float[5];

		// Token: 0x04000026 RID: 38
		private static readonly float[] analAnchurasOffsetsResult = new float[5];
	}
}
