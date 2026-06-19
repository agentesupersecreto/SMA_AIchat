using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200001F RID: 31
	public static class InterpretadorDeCheeks
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x00004574 File Offset: 0x00002774
		public static InterpretacionDeCheeks Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeCheeks
			{
				cheekBonesSize = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Bones_Size, 0, false)),
				cheekBonesHeight = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Bones_Height, 0, false)),
				fat = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradores(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Depth, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Face_Flat, 0, 0, false, true)),
				sink = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Sink, 0, false))
			};
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004610 File Offset: 0x00002810
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeCheeks interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Bones_Size, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.cheekBonesSize), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Bones_Height, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.cheekBonesHeight), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.fat), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Face_Flat, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.fat), true);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Cheek_Sink, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.sink), false);
		}
	}
}
