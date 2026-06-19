using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000025 RID: 37
	public static class InterpretadorDeJaw
	{
		// Token: 0x06000104 RID: 260 RVA: 0x000055E8 File Offset: 0x000037E8
		public static InterpretacionDeJaw Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeJaw
			{
				size = InterHelper.GetParaGenesDefault<Interpretacion.Size>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Size, 0, false)),
				width = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Corner_Width, 0, false)),
				angle = InterHelper.GetParaGenesDefault<Interpretacion.AngleDirection>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Angle, 0, false)),
				curve = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Curve, 0, true)),
				define = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Define, 0, false)),
				lineDepth = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Line_Depth, 0, true)),
				chinCleft = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Cleft, 0, false)),
				chinLength = InterHelper.GetParaGenesDefault<Interpretacion.Length>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Length, 0, false)),
				chinDepth = InterHelper.GetParaGenesDefault<Interpretacion.Depth>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Depth, 0, true)),
				chinRecede = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Recede, 0, false)),
				chinSquare = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Square, 0, false)),
				chinWidth = InterHelper.GetParaGenesDefault<Interpretacion.Amplitude>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin__Width, 0, false)),
				chinCrease = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(InterHelper.GetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Crease, 0, false))
			};
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00005760 File Offset: 0x00003960
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeJaw interpretacion)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Size, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Size>(interpretacion.size), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Corner_Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.width), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Angle, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.AngleDirection>(interpretacion.angle), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Curve, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.curve), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Define, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.define), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Jaw_Line_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.lineDepth), true);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Cleft, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.chinCleft), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Length, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.chinLength), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Depth, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Depth>(interpretacion.chinDepth), true);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Recede, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.chinRecede), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Square, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.chinSquare), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin__Width, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Amplitude>(interpretacion.chinWidth), false);
			InterHelper.SetModDeAlteradorND(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Chin_Crease, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.chinCrease), false);
		}
	}
}
