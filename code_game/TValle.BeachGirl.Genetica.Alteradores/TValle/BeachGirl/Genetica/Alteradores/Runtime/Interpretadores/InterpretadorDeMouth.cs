using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000026 RID: 38
	public static class InterpretadorDeMouth
	{
		// Token: 0x06000106 RID: 262 RVA: 0x000058CC File Offset: 0x00003ACC
		public static InterpretacionDeMouth Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IEstadisticasDeHoleInterpretadorHelper holeHelper, IHoleRangesParaInterpretadores rangosDefaults, IHoleRangesParaInterpretadores rangosHelper, IFacialSkinInterpretadorHelper facialHelper)
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
			if (facialHelper == null)
			{
				throw new ArgumentNullException("facialHelper", "facialHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterpretacionDeMouth interpretacionDeMouth = default(InterpretacionDeMouth);
			interpretacionDeMouth.width = InterHelper.GetParaGenesDefault<Interpretacion.Amplitude>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Width, 0, false));
			interpretacionDeMouth.angle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Angle, 0, true));
			interpretacionDeMouth.cornerAngle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Corner_Of_The_Mouth, 0, false));
			interpretacionDeMouth.curves = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Curves, 0, false));
			interpretacionDeMouth.heart = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lips_Heart, 0, false));
			interpretacionDeMouth.edgeDefine = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Edge_Define, 0, false));
			interpretacionDeMouth.topPeak = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Top_Peak, 0, false));
			interpretacionDeMouth.upperCurves = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Curves, 0, false));
			interpretacionDeMouth.upperLipMiddleThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Middle_Fill, 0, false));
			interpretacionDeMouth.upperLipThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Tone, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Size, 0, 0, true, false));
			interpretacionDeMouth.lowerLipThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Tone, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Size, 0, 0, true, false));
			interpretacionDeMouth.lowerLipWidth = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Width, 0, false));
			interpretacionDeMouth.lowerDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Depth, 0, true));
			interpretacionDeMouth.grooveDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Depth, 0, false));
			interpretacionDeMouth.grooveAngle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Angle, 0, false));
			interpretacionDeMouth.grooveTone = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Tone, 0, false));
			interpretacionDeMouth.grooveWidth = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Width, 0, false));
			interpretacionDeMouth.lipstick = InterHelper.InterpretarColorAlpha(facialHelper.lipstickColorSinModificaciones);
			interpretacionDeMouth.profundidad = InterpretadorDeMouth.BocaSizeProfundidad(holeHelper);
			interpretacionDeMouth.anchura = InterpretadorDeMouth.BocaSizeAnchura(holeHelper);
			interpretacionDeMouth.difficulty.painSensitivity = InterHelper.GetSensibilidad(rangosDefaults.oralPainSensibilidad_MinWorldRango_Tactil, rangosDefaults.oralPainSensibilidad_MinWorldRango_Coital, rangosHelper.oralPainSensibilidad_MinWorldRango_Tactil, rangosHelper.oralPainSensibilidad_MinWorldRango_Coital, false);
			interpretacionDeMouth.difficulty.pleasureSensitivity = InterHelper.GetSensibilidadConDistance(rangosDefaults.oralPleasureSensibilidad_MinWorldRango_Tactil, rangosDefaults.oralPleasureSensibilidad_MinWorldRango_Coital, rangosHelper.oralPleasureSensibilidad_MinWorldRango_Tactil, rangosHelper.oralPleasureSensibilidad_MinWorldRango_Coital, rangosDefaults.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosDefaults.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, rangosHelper.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Tactil, rangosHelper.oralPleasureSensibilidad_MinMaxDistanceWorldRango_Coital, false);
			interpretacionDeMouth.difficulty.painGain = InterHelper.GetGain(rangosDefaults.oralPainGain_MaxGeneracion, rangosDefaults.oralPainGain_MaxGeneracion_Coital, rangosHelper.oralPainGain_MaxGeneracion, rangosHelper.oralPainGain_MaxGeneracion_Coital);
			interpretacionDeMouth.difficulty.pleasureGain = InterHelper.GetGain(rangosDefaults.oralPleasureGain_MaxGeneracion, rangosDefaults.oralPleasureGain_MaxGeneracion_Coital, rangosHelper.oralPleasureGain_MaxGeneracion, rangosHelper.oralPleasureGain_MaxGeneracion_Coital);
			interpretacionDeMouth.difficulty.anoyanceGain = InterHelper.GetGain(rangosDefaults.oralRageGain_MaxGeneracion, rangosDefaults.oralRageGain_MaxGeneracion_Coital, rangosHelper.oralRageGain_MaxGeneracion, rangosHelper.oralRageGain_MaxGeneracion_Coital);
			interpretacionDeMouth.difficulty.maxPleasure = InterHelper.GetMaxValue(rangosDefaults.oralPleasure_MaxValue_Tactil, rangosDefaults.oralPleasure_MaxValue_Coital, rangosHelper.oralPleasure_MaxValue_Tactil, rangosHelper.oralPleasure_MaxValue_Coital);
			interpretacionDeMouth.difficulty.favorabilityRequirementVisual = InterHelper.GetFavorability(rangosDefaults.oralVisualFavoravility, rangosHelper.oralVisualFavoravility);
			interpretacionDeMouth.difficulty.favorabilityRequirementTactile = InterHelper.GetFavorability(rangosDefaults.oralTactilFavoravility, rangosHelper.oralTactilFavoravility);
			interpretacionDeMouth.difficulty.favorabilityRequirementExposure = InterHelper.GetFavorability(rangosDefaults.oralExposureFavoravility, rangosHelper.oralExposureFavoravility);
			interpretacionDeMouth.difficulty.favorabilityRequirementCoital = InterHelper.GetFavorability(rangosDefaults.oralCoitalFavoravility, rangosHelper.oralCoitalFavoravility);
			return interpretacionDeMouth;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005CBC File Offset: 0x00003EBC
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeMouth interpretacion, out Color lipstickColor)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Amplitude>(interpretacion.width), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Angle, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.angle), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Corner_Of_The_Mouth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.cornerAngle), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Mouth_Curves, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.curves), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lips_Heart, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.heart), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Edge_Define, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.edgeDefine), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Top_Peak, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.topPeak), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Curves, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.upperCurves), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Middle_Fill, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.upperLipMiddleThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Tone, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.upperLipThickness), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Size, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.upperLipThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Tone, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.lowerLipThickness), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Size, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.lowerLipThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.lowerLipWidth), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Lower_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.lowerDepth), true);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.grooveDepth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Angle, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.grooveAngle), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Tone, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.grooveTone), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Lip_Upper_Lip_Groove_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.grooveWidth), false);
			lipstickColor = InterHelper.InterpretarColorAlpha_Inverse(interpretacion.lipstick);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005ED0 File Offset: 0x000040D0
		private static Interpretacion.HoleDepth BocaSizeProfundidad(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.OralProfundidadRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeMouth.oralWorldProfundidades, InterpretadorDeMouth.oralProfundidadesOffsetsResult);
			return InterHelper.GetProfundidadConOffsetDeEstados(InterpretadorDeMouth.oralProfundidadesOffsetsResult);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005F08 File Offset: 0x00004108
		private static Interpretacion.Tightness BocaSizeAnchura(IEstadisticasDeHoleInterpretadorHelper helper)
		{
			IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetterHandler;
			RangeValueV2 rangeValueV;
			float num;
			helper.OralAnchuraRangoDeSufrimiento(out offsetGetterHandler, out rangeValueV, out num);
			InterHelper.OffsetMany(offsetGetterHandler, rangeValueV, num, InterpretadorDeMouth.oralWorldAnchuras, InterpretadorDeMouth.oralAnchurasOffsetsResult);
			return InterHelper.GetTightnessConOffsetDeEstados(InterpretadorDeMouth.oralAnchurasOffsetsResult);
		}

		// Token: 0x04000032 RID: 50
		public const float physcisOralSize = 0.35f;

		// Token: 0x04000033 RID: 51
		public const float oralSuperSizeQueenProfundidadThresshold = 0.50904f;

		// Token: 0x04000034 RID: 52
		public const float oralSizeQueenProfundidadThresshold = 0.4242f;

		// Token: 0x04000035 RID: 53
		public const float oralSizeNormalProfundidadThresshold = 0.35349998f;

		// Token: 0x04000036 RID: 54
		public const float oralSizeSmallProfundidadThresshold = 0.29458332f;

		// Token: 0x04000037 RID: 55
		public const float oralSizeVerySmallProfundidadThresshold = 0.2454861f;

		// Token: 0x04000038 RID: 56
		public const float oralSuperSizeQueenAnchuraThresshold = 0.052519996f;

		// Token: 0x04000039 RID: 57
		public const float oralSizeQueenAnchuraThresshold = 0.04545f;

		// Token: 0x0400003A RID: 58
		public const float oralSizeNormalAnchuraThresshold = 0.0404f;

		// Token: 0x0400003B RID: 59
		public const float oralSizeSmallAnchuraThresshold = 0.030299999f;

		// Token: 0x0400003C RID: 60
		public const float oralSizeVerySmallAnchuraThresshold = 0.0202f;

		// Token: 0x0400003D RID: 61
		private static readonly float[] oralWorldProfundidades = new float[] { 0.50904f, 0.4242f, 0.35349998f, 0.29458332f, 0.2454861f };

		// Token: 0x0400003E RID: 62
		private static readonly float[] oralWorldAnchuras = new float[] { 0.052519996f, 0.04545f, 0.0404f, 0.030299999f, 0.0202f };

		// Token: 0x0400003F RID: 63
		private static readonly float[] oralProfundidadesOffsetsResult = new float[5];

		// Token: 0x04000040 RID: 64
		private static readonly float[] oralAnchurasOffsetsResult = new float[5];

		// Token: 0x04000041 RID: 65
		public const float defaultVisualFavoravility = 0.99f;

		// Token: 0x04000042 RID: 66
		public const float defaultTactilFavoravility = 0.99f;

		// Token: 0x04000043 RID: 67
		public const float defaultExposureFavoravility = 0.99f;

		// Token: 0x04000044 RID: 68
		public const float defaultCoitalFavoravility = 0.99f;
	}
}
