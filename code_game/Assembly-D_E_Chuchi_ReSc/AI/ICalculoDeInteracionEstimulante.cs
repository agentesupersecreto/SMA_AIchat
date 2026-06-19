using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E8 RID: 744
	public interface ICalculoDeInteracionEstimulante : ICalculoDeEstimulo
	{
		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x0600108B RID: 4235
		InteracionEstimulanteBasica estimuloBasico { get; }

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x0600108C RID: 4236
		InteracionEstimulanteBasica estimuloInvertidoBasico { get; }
	}
}
