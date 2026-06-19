using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x020002A0 RID: 672
	public interface ITouchedByCharacter
	{
		// Token: 0x06000EF8 RID: 3832
		bool ContieneEstimulosDeCharacter<T_estimulo>(ICharacter estimulanteCharacter, List<T_estimulo> estimulosResultado) where T_estimulo : InteracionEstimulanteBasica;
	}
}
