using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000020 RID: 32
	public static class InterpretadorDeEyebrows
	{
		// Token: 0x060000F7 RID: 247 RVA: 0x000046B4 File Offset: 0x000028B4
		public static InterpretacionDeEyebrows Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, ICejasInterpretadorHelper cejasHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (cejasHelper == null)
			{
				throw new ArgumentNullException("cejasHelper", "cejasHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeEyebrows
			{
				height = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Lower, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_R, 0, 1, 1, true, false, false)),
				distance = InterHelper.GetParaGenesDefault<Interpretacion.Distance>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Near_Brown, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_L, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_R, 0, 0, 0, true, false, false)),
				thickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_R, 1, 1, false, false)),
				length = InterHelper.GetParaGenesDefault<Interpretacion.Length>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_L, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_R, 0, 0, false, false)),
				ridgeSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Width, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brown_Depth, 0, 0, false, false)),
				angle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brown_Angle, 0, false)),
				color = InterHelper.InterpretarColorAlpha(cejasHelper.colorDeCejasSinModificaciones)
			};
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000047D0 File Offset: 0x000029D0
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeEyebrows interpretacion, out Color colorDeCejas)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Lower, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_L, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_R, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.height), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Near_Brown, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_Ceja_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Distance>(interpretacion.distance), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_L, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.thickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_R, 1, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.thickness), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_L, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.length), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Ceja_R, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.length), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brow_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.ridgeSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brown_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.ridgeSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Brown_Angle, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.angle), false);
			colorDeCejas = InterHelper.InterpretarColorAlpha_Inverse(interpretacion.color);
		}
	}
}
