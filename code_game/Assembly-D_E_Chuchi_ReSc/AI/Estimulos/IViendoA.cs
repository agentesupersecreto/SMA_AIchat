using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E3 RID: 995
	public interface IViendoA
	{
		// Token: 0x0600159C RID: 5532
		bool ContieneEstimuloVisual<T_estimulo>(ICharacter estimulante, out T_estimulo estimulo, out ParteQuePuedeEstimular estimulanteParte) where T_estimulo : EstimuloVisual;
	}
}
