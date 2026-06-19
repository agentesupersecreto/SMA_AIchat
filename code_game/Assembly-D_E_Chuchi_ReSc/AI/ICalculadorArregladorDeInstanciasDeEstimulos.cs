using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002DB RID: 731
	public interface ICalculadorArregladorDeInstanciasDeEstimulos<T> where T : ICalculoDeInteracionEstimulante
	{
		// Token: 0x06001061 RID: 4193
		void FixEstimulosInstancesTypes(T original, T instanciado);
	}
}
