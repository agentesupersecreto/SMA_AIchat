using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000029 RID: 41
	public static class InterpretadorDePubicHair
	{
		// Token: 0x06000110 RID: 272 RVA: 0x00006798 File Offset: 0x00004998
		public static InterpretacionDePubicHair Interpretar(IInterpretadorHelperConAlteradoresDeApariencia helper, IPubicHairInterpretadorHelper hairHelper)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			if (hairHelper == null)
			{
				throw new ArgumentNullException("hairHelper", "hairHelper null reference.");
			}
			return new InterpretacionDePubicHair
			{
				density = InterHelper.GetParaGenesDefault<Interpretacion.Capacidad>(hairHelper.currentDensity),
				color = InterHelper.InterpretarColor(hairHelper.colorSinModificaciones)
			};
		}

		// Token: 0x06000111 RID: 273 RVA: 0x000067F8 File Offset: 0x000049F8
		public static void InterpretarInverse(IInterpretadorHelperConAlteradoresDeApariencia helper, Func<float, int> DensidadAIndexDeTexturaDePubes, InterpretacionDePubicHair interpretacion, out Color colorDeCabello)
		{
			if (helper == null)
			{
				throw new ArgumentNullException("helper", "helper null reference.");
			}
			IReadOnlyDictionary<string, ModificadoresDeAlterador> preparedAlteradoresAparienciaDicc = helper.GetPreparedAlteradoresAparienciaDicc();
			float paraGenesDefault_Inverse = InterHelper.GetParaGenesDefault_Inverse<Interpretacion.Capacidad>(interpretacion.density);
			int num = DensidadAIndexDeTexturaDePubes(paraGenesDefault_Inverse);
			InterHelper.SetIndexToAlteradorDeIndex(preparedAlteradoresAparienciaDicc, DiccionarioDeNombresDeAlteradoresFemeninos.Textureador_Pubes, 0, num);
			colorDeCabello = InterHelper.InterpretarColor_Inverse(interpretacion.color);
		}
	}
}
