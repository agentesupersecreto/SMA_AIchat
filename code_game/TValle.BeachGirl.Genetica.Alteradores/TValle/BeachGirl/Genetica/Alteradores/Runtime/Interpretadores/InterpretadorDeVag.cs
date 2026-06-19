using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200002D RID: 45
	public static class InterpretadorDeVag
	{
		// Token: 0x06000117 RID: 279 RVA: 0x00006E3C File Offset: 0x0000503C
		public static InterpretacionDeVag Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IEstadisticasDeHoleInterpretadorHelper holeHelper, IHoleRangesParaInterpretadores rangosDefaults, IHoleRangesParaInterpretadores rangosHelper)
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
			InterpretacionDeVag interpretacionDeVag = default(InterpretacionDeVag);
			interpretacionDeVag.lipsOpening = InterHelper.GetParaGenesNoCentrados<Interpretacion.Opening>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Controller_VagDesgaste, 0, false), 0.45f);
			interpretacionDeVag.outerLabiaThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_VagLabia, 0, false));
			interpretacionDeVag.outerLabiaFat = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_VagLabia, 1, false));
			interpretacionDeVag.clitLength = InterHelper.GetParaGenesDefault<Interpretacion.Length>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BaseClitoris, 0, false));
			interpretacionDeVag.clitExtrude = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PuntaClitoris, 0, false));
			interpretacionDeVag.innerLabiaThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradoresD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoAltos, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoBajos, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroAltos, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroBajos, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroMedios, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoMedios, 0, 0, 0, 0, 0, 0, false, false, false, false, false, false));
			interpretacionDeVag.profundidad = InterpretadorDeVag.VagSizeProfundidad(holeHelper);
			interpretacionDeVag.anchura = InterpretadorDeVag.VagSizeAnchura(holeHelper);
			interpretacionDeVag.difficulty.painSensitivity = InterHelper.GetSensibilidad(rangosDefaults.vaginalPainSensibilidad_MinWorldRango_Tactil, rangosDefaults.vaginalPainSensibilidad_MinWorldRango_Coital, rangosHelper.vaginalPainSensibilidad_MinWorldRango_Tactil, rangosHelper.vaginalPainSensibilidad_MinWorldRango_Coital, false);
			interpretacionDeVag.difficulty.pleasureSensitivity = InterHelper.GetSensibilidadConDistance(rangosDefaults.vaginalPleasureSensibilidad_MinWorldRango_Tactil, rangosDefaults.vaginalPleasureSensibilidad_MinWorldRango_Coital, rangosHelper.vaginalPleasureSensibilidad_MinWorldRango_Tactil, rangosHelper.vaginalPleasureSensibilidad_MinWorldRango_Coital, rangosDefaults.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosDefaults.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, rangosHelper.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosHelper.vaginalPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, false);
			interpretacionDeVag.difficulty.painGain = InterHelper.GetGain(rangosDefaults.vaginalPainGain_MaxGeneracion, rangosDefaults.vaginalPainGain_MaxGeneracion_Coital, rangosHelper.vaginalPainGain_MaxGeneracion, rangosHelper.vaginalPainGain_MaxGeneracion_Coital);
			interpretacionDeVag.difficulty.pleasureGain = InterHelper.GetGain(rangosDefaults.vaginalPleasureGain_MaxGeneracion, rangosDefaults.vaginalPleasureGain_MaxGeneracion_Coital, rangosHelper.vaginalPleasureGain_MaxGeneracion, rangosHelper.vaginalPleasureGain_MaxGeneracion_Coital);
			interpretacionDeVag.difficulty.anoyanceGain = InterHelper.GetGain(rangosDefaults.vaginalRageGain_MaxGeneracion, rangosDefaults.vaginalRageGain_MaxGeneracion_Coital, rangosHelper.vaginalRageGain_MaxGeneracion, rangosHelper.vaginalRageGain_MaxGeneracion_Coital);
			interpretacionDeVag.difficulty.maxPleasure = InterHelper.GetMaxValue(rangosDefaults.vaginalPleasure_MaxValue_Tactil, rangosDefaults.vaginalPleasure_MaxValue_Coital, rangosHelper.vaginalPleasure_MaxValue_Tactil, rangosHelper.vaginalPleasure_MaxValue_Coital);
			interpretacionDeVag.difficulty.favorabilityRequirementVisual = InterHelper.GetFavorability(rangosDefaults.vaginalVisualFavoravility, rangosHelper.vaginalVisualFavoravility);
			interpretacionDeVag.difficulty.favorabilityRequirementTactile = InterHelper.GetFavorability(rangosDefaults.vaginalTactilFavoravility, rangosHelper.vaginalTactilFavoravility);
			interpretacionDeVag.difficulty.favorabilityRequirementExposure = InterHelper.GetFavorability(rangosDefaults.vaginalExposureFavoravility, rangosHelper.vaginalExposureFavoravility);
			interpretacionDeVag.difficulty.favorabilityRequirementCoital = InterHelper.GetFavorability(rangosDefaults.vaginalCoitalFavoravility, rangosHelper.vaginalCoitalFavoravility);
			return interpretacionDeVag;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0000710C File Offset: 0x0000530C
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeVag interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Controller_VagDesgaste, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Opening>(interpretacion.lipsOpening, 0.45f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_VagLabia, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.outerLabiaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_VagLabia, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.outerLabiaFat), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BaseClitoris, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.clitLength), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PuntaClitoris, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.clitExtrude), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoAltos, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoBajos, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroAltos, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroBajos, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoDentroMedios, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_VagLavAnchoMedios, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.innerLabiaThickness), false);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0000724C File Offset: 0x0000544C
		private static Interpretacion.HoleDepth VagSizeProfundidad(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.VaginalProfundidadRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeVag.vaginalWorldProfundidades, InterpretadorDeVag.vaginalProfundidadesOffsetsResult);
			return InterHelper.GetProfundidadConOffsetDeEstados(InterpretadorDeVag.vaginalProfundidadesOffsetsResult);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00007284 File Offset: 0x00005484
		private static Interpretacion.Tightness VagSizeAnchura(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.VaginalAnchuraRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeVag.vaginalWorldAnchuras, InterpretadorDeVag.vaginalAnchurasOffsetsResult);
			return InterHelper.GetTightnessConOffsetDeEstados(InterpretadorDeVag.vaginalAnchurasOffsetsResult);
		}

		// Token: 0x04000046 RID: 70
		public const float physcisVagSize = 0.1752038f;

		// Token: 0x04000047 RID: 71
		public const float vaginalSuperSizeQueenProfundidadThresshold = 0.2548164f;

		// Token: 0x04000048 RID: 72
		public const float vaginalSizeQueenProfundidadThresshold = 0.21234702f;

		// Token: 0x04000049 RID: 73
		public const float vaginalSizeNormalProfundidadThresshold = 0.17695583f;

		// Token: 0x0400004A RID: 74
		public const float vaginalSizeSmallProfundidadThresshold = 0.14746319f;

		// Token: 0x0400004B RID: 75
		public const float vaginalSizeVerySmallProfundidadThresshold = 0.122885995f;

		// Token: 0x0400004C RID: 76
		public const float vaginalSuperSizeQueenAnchuraThresshold = 0.052519996f;

		// Token: 0x0400004D RID: 77
		public const float vaginalSizeQueenAnchuraThresshold = 0.04545f;

		// Token: 0x0400004E RID: 78
		public const float vaginalSizeNormalAnchuraThresshold = 0.0404f;

		// Token: 0x0400004F RID: 79
		public const float vaginalSizeSmallAnchuraThresshold = 0.030299999f;

		// Token: 0x04000050 RID: 80
		public const float vaginalSizeVerySmallAnchuraThresshold = 0.0202f;

		// Token: 0x04000051 RID: 81
		private static readonly float[] vaginalWorldProfundidades = new float[] { 0.2548164f, 0.21234702f, 0.17695583f, 0.14746319f, 0.122885995f };

		// Token: 0x04000052 RID: 82
		private static readonly float[] vaginalWorldAnchuras = new float[] { 0.052519996f, 0.04545f, 0.0404f, 0.030299999f, 0.0202f };

		// Token: 0x04000053 RID: 83
		private static readonly float[] vaginalProfundidadesOffsetsResult = new float[5];

		// Token: 0x04000054 RID: 84
		private static readonly float[] vaginalAnchurasOffsetsResult = new float[5];

		// Token: 0x04000055 RID: 85
		public const float maxDesgastePorApertura = 0.666f;

		// Token: 0x04000056 RID: 86
		public const float desgasteGeneWMiddle = 0.45f;
	}
}
