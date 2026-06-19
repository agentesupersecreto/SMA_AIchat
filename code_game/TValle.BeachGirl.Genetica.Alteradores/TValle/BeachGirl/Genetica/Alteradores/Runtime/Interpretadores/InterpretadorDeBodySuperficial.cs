using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200001D RID: 29
	public static class InterpretadorDeBodySuperficial
	{
		// Token: 0x060000EF RID: 239 RVA: 0x00003E48 File Offset: 0x00002048
		public static InterpretacionDeBodySuperficial Interpretar(IBodySuperficialInterpretadorHelper helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			float worldSpaceEstatura = helper.GetWorldSpaceEstatura();
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeBodySuperficial
			{
				altura = InterpretadorDeBodySuperficial.GetEstatura(worldSpaceEstatura),
				bodyfat = InterHelper.GetParaGenesNoCentrados<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_BODY_fat, 0, false), 0.5f),
				ribcageThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine02, 0, false)),
				headsize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Cabeza, 0, false)),
				neckThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Cuello, 0, false)),
				neckLength = InterHelper.GetParaGenesDefault<Interpretacion.Length>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Cuello, 0, false)),
				armsThickness = InterHelper.GetParaGenesNoCentrados<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoInferior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoInferior_R, 0, 0, 0, 0, false, false, false, false), 0.35f),
				forearmsThickness = InterHelper.GetParaGenesNoCentrados<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoInferior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoInferior_R, 0, 0, 0, 0, false, false, false, false), 0.4f),
				handsSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_R, 0, 0, false, false)),
				cinturaThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine01, 0, false)),
				caderaThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_R, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_R, 0, 0, 0, 0, false, false, false, false)),
				caderaAltura = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_R, 2, 2, true, true)),
				thighgap = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_R, 0, 0, false, false)),
				thighThickness = InterHelper.GetParaGenesNoCentrados<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaInferior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaInferior_R, 0, 0, 0, 0, false, false, false, false), 0.35f),
				calfThickness = InterHelper.GetParaGenesNoCentrados<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_R, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaInferior_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaInferior_R, 0, 0, 0, 0, false, false, false, false), 0.45f),
				feetSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_R, 0, 0, false, false))
			};
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000040A4 File Offset: 0x000022A4
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeBodySuperficial interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scala_Puppet, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Height>(interpretacion.altura, 0.4f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_BODY_fat, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Capacidad>(interpretacion.bodyfat, 0.5f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine02, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.ribcageThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Cabeza, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.headsize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Cuello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.neckThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Cuello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.neckLength), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.armsThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoSuperior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.armsThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoInferior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.armsThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_BrazoInferior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.armsThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.forearmsThickness, 0.4f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoSuperior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.forearmsThickness, 0.4f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoInferior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.forearmsThickness, 0.4f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AnteBrazoInferior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.forearmsThickness, 0.4f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.handsSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Mano_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.handsSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine01, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.cinturaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.caderaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.caderaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.caderaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.caderaThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_L, 2, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.caderaAltura), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_R, 2, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.caderaAltura), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.thighgap), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.thighgap), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.thighThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.thighThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaInferior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.thighThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaInferior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.thighThickness, 0.35f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.calfThickness, 0.45f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaSuperior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.calfThickness, 0.45f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaInferior_L, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.calfThickness, 0.45f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CanillaInferior_R, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.calfThickness, 0.45f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.feetSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Pie_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.feetSize), false);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000448E File Offset: 0x0000268E
		private static Interpretacion.Height GetEstatura(float worldSpaceEstatura)
		{
			if (worldSpaceEstatura >= 1.9250001f)
			{
				return Interpretacion.Height.veryTall;
			}
			if (worldSpaceEstatura >= 1.75f)
			{
				return Interpretacion.Height.tall;
			}
			if (worldSpaceEstatura >= 1.590909f)
			{
				return Interpretacion.Height.normal;
			}
			if (worldSpaceEstatura >= 1.446281f)
			{
				return Interpretacion.Height.@short;
			}
			return Interpretacion.Height.veryShort;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x000044BC File Offset: 0x000026BC
		[Obsolete("No funciona bien", true)]
		private static float GetEstaturaInverseMod(Interpretacion.Height feight)
		{
			switch (feight)
			{
			case Interpretacion.Height.veryShort:
				return 0.3305785f;
			case Interpretacion.Height.@short:
				return 0.36363637f;
			case Interpretacion.Height.normal:
				return 0.4f;
			case Interpretacion.Height.tall:
				return 0.5f;
			case Interpretacion.Height.veryTall:
				return 0.75f;
			default:
				throw new ArgumentOutOfRangeException(feight.ToString());
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004518 File Offset: 0x00002718
		private static float GetEstaturaInverseCM(Interpretacion.Height feight)
		{
			switch (feight)
			{
			case Interpretacion.Height.veryShort:
				return 1.3910794f;
			case Interpretacion.Height.@short:
				return 1.518595f;
			case Interpretacion.Height.normal:
				return 91.59546f;
			case Interpretacion.Height.tall:
				return 181.6f;
			case Interpretacion.Height.veryTall:
				return 2.02125f;
			default:
				throw new ArgumentOutOfRangeException(feight.ToString());
			}
		}

		// Token: 0x0400002A RID: 42
		public const float estaturaDeMeshValorGlobalDefectoEnMetros = 1.816f;

		// Token: 0x0400002B RID: 43
		public const float estaturaParaSerAlta = 1.75f;

		// Token: 0x0400002C RID: 44
		public const float piernasAnchoMiddleWeigth = 0.35f;

		// Token: 0x0400002D RID: 45
		public const float calfAnchoMiddleWeigth = 0.45f;

		// Token: 0x0400002E RID: 46
		public const float brazosAnchoMiddleWeigth = 0.35f;

		// Token: 0x0400002F RID: 47
		public const float antebrazosAnchoMiddleWeigth = 0.4f;

		// Token: 0x04000030 RID: 48
		public const float estaturaMiddleWeigth = 0.4f;

		// Token: 0x04000031 RID: 49
		public const float bodyFatAmountMiddle = 0.5f;
	}
}
