using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000022 RID: 34
	public static class InterpretadorDeFacialSkin
	{
		// Token: 0x060000FB RID: 251 RVA: 0x00004F04 File Offset: 0x00003104
		public static InterpretacionDeFacialSkin Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IFacialSkinRangesParaInterpretadores rangosDefaults, IFacialSkinRangesParaInterpretadores rangosHelper, IFacialSkinInterpretadorHelper facialSkinHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
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
			if (facialSkinHelper == null)
			{
				throw new ArgumentNullException("facialSkinHelper", "facialSkinHelper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			InterpretacionDeFacialSkin interpretacionDeFacialSkin = default(InterpretacionDeFacialSkin);
			float num = InterHelper.GetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Textureador_HeadDecalsAlpha, 0, false).InPow(2f);
			interpretacionDeFacialSkin.makeUpOnCheeks = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(facialSkinHelper.currentCheeksMakeUpWeigth);
			interpretacionDeFacialSkin.makeUpEyeshadow = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(facialSkinHelper.currentEyeShadowWeigth);
			interpretacionDeFacialSkin.makeUpMaxAmount = InterHelper.GetParaGenesDefault<Interpretacion.CantidadNoContable>(num);
			interpretacionDeFacialSkin.difficulty = InterHelper.InterpretarDificultad(rangosDefaults, rangosHelper);
			return interpretacionDeFacialSkin;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004FCC File Offset: 0x000031CC
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, InterpretacionDeFacialSkin interpretacion, out float cheeksMakeUpWeigth, out float eyesShadowMakeUpWeigth)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			cheeksMakeUpWeigth = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.makeUpOnCheeks);
			eyesShadowMakeUpWeigth = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.makeUpEyeshadow);
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.CantidadNoContable>(interpretacion.makeUpMaxAmount);
			InterHelper.SetModDeAlteradorD(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Textureador_HeadDecalsAlpha, 0, paraGenesDefault_Inverse, false);
		}
	}
}
