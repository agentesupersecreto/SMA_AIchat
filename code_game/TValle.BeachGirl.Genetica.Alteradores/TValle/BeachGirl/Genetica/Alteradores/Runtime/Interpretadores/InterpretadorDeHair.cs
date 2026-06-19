using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000024 RID: 36
	public static class InterpretadorDeHair
	{
		// Token: 0x06000102 RID: 258 RVA: 0x00005438 File Offset: 0x00003638
		public static InterpretacionDeHair Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IHairInterpretadorHelper hairHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (hairHelper == null)
			{
				throw new ArgumentNullException("hairHelper", "hairHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			return new InterpretacionDeHair
			{
				length = InterHelper.GetParaGenesDefault<Interpretacion.Length>(Mathf.Lerp(hairHelper.currentLengthWeigth * 0.333f, hairHelper.currentLengthWeigth, InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Encojedor_CerdasDeCabello, 0, false))),
				volume = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CerdasDeCabello, 0, false)),
				curls = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(InterHelper.GetModDeAlteradoresD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_RisosDeCabello, DiccionarioDeNombresDeAlteradoresFemeninos.Incrementador_FrequenciaRisosDeCabello, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AxisDeRisosDeCabello, 0, 0, 0, false, false, false)),
				color = InterHelper.InterpretarColor(hairHelper.colorSinModificaciones)
			};
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00005500 File Offset: 0x00003700
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeHair interpretacion, out bool styloEsLargo, out Color colorDeCabello)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Length>(interpretacion.length);
			styloEsLargo = paraGenesDefault_Inverse > 0.5f;
			float num = (styloEsLargo ? Mathf.InverseLerp(0.5f, 1f, paraGenesDefault_Inverse) : Mathf.InverseLerp(0f, 0.5f, paraGenesDefault_Inverse));
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Encojedor_CerdasDeCabello, 0, num, false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_CerdasDeCabello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.volume), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_RisosDeCabello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.curls), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Incrementador_FrequenciaRisosDeCabello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.curls), false);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_AxisDeRisosDeCabello, 0, InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.curls), false);
			colorDeCabello = InterHelper.InterpretarColor_Inverse(interpretacion.color);
		}
	}
}
