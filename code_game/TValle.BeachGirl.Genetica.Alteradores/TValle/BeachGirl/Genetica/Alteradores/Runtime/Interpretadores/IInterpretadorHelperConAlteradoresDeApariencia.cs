using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x0200000F RID: 15
	public interface IInterpretadorHelperConAlteradoresDeApariencia
	{
		// Token: 0x060000A4 RID: 164
		IReadOnlyDictionary<string, ModificadoresDeAlterador> GetPreparedAlteradoresAparienciaDicc();
	}
}
