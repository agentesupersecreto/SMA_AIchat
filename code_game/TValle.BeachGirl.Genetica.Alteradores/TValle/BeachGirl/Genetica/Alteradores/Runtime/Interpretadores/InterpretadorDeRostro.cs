using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200002B RID: 43
	public static class InterpretadorDeRostro
	{
		// Token: 0x06000113 RID: 275 RVA: 0x00006938 File Offset: 0x00004B38
		public static InterpretacionDeRostro Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeRostro
			{
				collapse = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Facial, 0, true)),
				aging = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeSliderConPrioridad(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Old, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Young, 0, 0, false, false)),
				thickness = InterHelper.GetParaGenesDefault<Interpretacion.Thickness>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Narrow, 0, true)),
				heart = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Heart, 0, false)),
				square = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Square, 0, false)),
				round = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Round, 0, false)),
				foreHeadWidth = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_FrenteAncho, 0, false)),
				foreHeadProjection = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_FrenteAdelante, 0, false))
			};
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006A38 File Offset: 0x00004C38
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeRostro interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Facial, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.collapse), true);
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.aging);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Old, 0, Mathf.InverseLerp(0.5f, 1f, paraGenesDefault_Inverse), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Young, 0, Mathf.InverseLerp(0.5f, 0f, paraGenesDefault_Inverse), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Heart, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.heart), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Narrow, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Thickness>(interpretacion.thickness), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Round, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.round), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Square, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.square), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_FrenteAdelante, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.foreHeadProjection), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_FrenteAncho, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.foreHeadWidth), false);
		}
	}
}
