using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000027 RID: 39
	public static class InterpretadorDeNose
	{
		// Token: 0x0600010B RID: 267 RVA: 0x00005F90 File Offset: 0x00004190
		public static InterpretacionDeNose Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeNose
			{
				size = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradoresMixtos(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Scale, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nariz, 0, 0, false, false)),
				height = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Nariz, 1, false)),
				proyection = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Nariz, 2, false)),
				pinch = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Pinch, 0, true)),
				chisel = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Chisel_Nose, 0, false)),
				bridgeThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradoresMixtos(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Flatten, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Ridge_Width, 0, 0, false, false)),
				bridgeDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Depth, 0, true)),
				bridgeHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Height, 0, false)),
				bridgeSmoothness = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Ridge, 0, true)),
				ridgeBump = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradoresMixtos(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Aquiline_nose, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bump, 0, 0, false, false)),
				ridgeSlope = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Slope, 0, false)),
				tipRoundness = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Round, 0, false)),
				tipThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Width, 0, false)),
				tipDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Depth, 0, true)),
				tipHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Height, 0, false)),
				tipSlope = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Slope, 0, false)),
				nostrilThickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Flesh_Size, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostrils_Width, 0, 0, false, false)),
				nostrilDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Depth_n, 0, false)),
				nostrilAngle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Angle, 0, false)),
				nostrilSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Scale, 0, true)),
				nostrilCollapse = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Type_A, 0, false)),
				nostrilHeight = InterHelper.GetParaGenesDefault<Interpretacion.Height>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Height, 0, false)),
				septumWidth = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Septum_Width, 0, false)),
				septumHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Septum_Height, 0, false)),
				philtrumConcave = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Philtrum_Concave, 0, false))
			};
		}

		// Token: 0x0600010C RID: 268 RVA: 0x00006250 File Offset: 0x00004450
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeNose interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Scale, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Size>(interpretacion.size, 0f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nariz, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Nariz, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Nariz, 2, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.proyection), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Pinch, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.pinch), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Chisel_Nose, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.chisel), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Flatten, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Thickness>(interpretacion.bridgeThickness, 0f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Ridge_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.bridgeThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.bridgeDepth), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.bridgeHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Ridge, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.bridgeSmoothness), true);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Aquiline_nose, 0, InterHelper.GetParaGenesNoCentrados_Inverse<Interpretacion.Size>(interpretacion.ridgeBump, 0f), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bump, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.ridgeBump), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Bridge_Slope, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.ridgeSlope), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Round, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.tipRoundness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.tipThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.tipDepth), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.tipHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Tip_Slope, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.tipSlope), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Flesh_Size, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.nostrilThickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostrils_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.nostrilThickness), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Depth_n, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.nostrilDepth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Angle, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.nostrilAngle), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Scale, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.nostrilSize), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Type_A, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.nostrilCollapse), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nostril_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Height>(interpretacion.nostrilHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Septum_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.septumWidth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Septum_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.septumHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Nose_Philtrum_Concave, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.philtrumConcave), false);
		}
	}
}
