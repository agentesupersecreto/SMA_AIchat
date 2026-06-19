using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000021 RID: 33
	public static class InterpretadorDeEyes
	{
		// Token: 0x060000F9 RID: 249 RVA: 0x0000494C File Offset: 0x00002B4C
		public static InterpretacionDeEyes Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IEyesInterpretadorHelper eyesHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (eyesHelper == null)
			{
				throw new ArgumentNullException("eyesHelper", "eyesHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeEyes
			{
				height = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 1, 1, false, false)),
				distance = InterHelper.GetParaGenesDefault<Interpretacion.Distance>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 0, 0, true, true)),
				depth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 2, 2, true, true)),
				size = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ojo_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ojo_R, 0, 0, false, false)),
				amplitude = InterHelper.GetParaGenesDefault<Interpretacion.Amplitude>(InterHelper.GetModDeSlider(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Round, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Thin, 0, 0, false, false)),
				angle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Height_Inner, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Height_Outer, 0, 0, true, true)),
				irisSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Iris_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Iris_R, 0, 0, true, true)),
				irisColor = InterHelper.InterpretarColor(eyesHelper.irisColorLSinModificaciones, eyesHelper.irisColorRSinModificaciones),
				eyelidHeavy = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Heavy, 0, false)),
				eyelidDistance = InterHelper.GetParaGenesDefault<Interpretacion.Distance>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Double_eyelid_type, 0, false)),
				eyelidDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Inner_Depth, 0, false)),
				upperEyelidSmooth = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Smooth, 0, false)),
				upperEyelidHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Upper_Height, 0, false)),
				eyelidTopFlat = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Top_Flat, 0, false)),
				eyelidTopInHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Top_In_Height, 0, false)),
				lowerEyelidHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Lower_Height, 0, true)),
				eyelidBottomDefine = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Bottom_Define, 0, false)),
				eyelidBottomOutHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Bottom_Out_Height, 0, false)),
				wrinkleInner = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Wrinkle_Inner, 0, false)),
				eyelashesLength = InterHelper.GetParaGenesDefault<Interpretacion.Length>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Lower_Eyelashes_Length, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Upper_Eyelashes_Length, 0, 0, false, false)),
				lacrimalDistance = InterHelper.GetParaGenesDefault<Interpretacion.Distance>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Almond_Inner, 0, false)),
				lacrimalExposure = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Lacrimals_Pinch, 0, true))
			};
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004BEC File Offset: 0x00002DEC
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeEyes interpretacion, out Color irisColor)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_L, 2, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.depth), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ojo_R, 2, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.depth), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ojo_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ojo_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Amplitude>(interpretacion.amplitude);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Round, 0, Mathf.InverseLerp(0.5f, 1f, paraGenesDefault_Inverse), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Thin, 0, Mathf.InverseLerp(0.5f, 0f, paraGenesDefault_Inverse), false);
			float paraGenesDefault_Inverse2 = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.angle);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Height_Inner, 0, paraGenesDefault_Inverse2, true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Height_Outer, 0, paraGenesDefault_Inverse2, true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Iris_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.irisSize), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Iris_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.irisSize), true);
			irisColor = InterHelper.InterpretarColor_Inverse(interpretacion.irisColor);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Heavy, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.eyelidHeavy), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Double_eyelid_type, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.eyelidDistance), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Inner_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.eyelidDepth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Smooth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.upperEyelidSmooth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Upper_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.upperEyelidHeight), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Top_Flat, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.eyelidTopFlat), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Top_In_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.eyelidTopInHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Lower_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.lowerEyelidHeight), true);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Bottom_Define, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.eyelidBottomDefine), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eyelid_Bottom_Out_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.eyelidBottomOutHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Wrinkle_Inner, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.wrinkleInner), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Lower_Eyelashes_Length, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.eyelashesLength), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Upper_Eyelashes_Length, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.eyelashesLength), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Almond_Inner, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.lacrimalDistance), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Eye_Lacrimals_Pinch, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.lacrimalExposure), true);
		}
	}
}
