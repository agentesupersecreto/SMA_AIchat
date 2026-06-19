using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;

namespace Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores
{
	// Token: 0x02000010 RID: 16
	public interface IInterpretadorHelperConAlteradoresDePersonalidad
	{
		// Token: 0x060000A5 RID: 165
		IReadOnlyDictionary<string, ModificadoresDeAlterador> GetPreparedAlteradoresPersonalidadDicc();
	}
}
