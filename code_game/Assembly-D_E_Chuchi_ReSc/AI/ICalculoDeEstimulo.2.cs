using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E9 RID: 745
	public interface ICalculoDeEstimulo<TEstimulo> : ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable where TEstimulo : InteracionEstimulanteBasica
	{
		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x0600108D RID: 4237
		TEstimulo estimulo { get; }

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x0600108E RID: 4238
		TEstimulo estimuloInvertido { get; }

		// Token: 0x0600108F RID: 4239
		void SetEstimuloInstance(TEstimulo instance, TEstimulo instanceInverted);
	}
}
