using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002EC RID: 748
	public interface ICalculoDeEstimuloDeParteEstimulante : ICalculoDeEstimulo
	{
		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06001099 RID: 4249
		// (set) Token: 0x0600109A RID: 4250
		ParteQuePuedeEstimular estimulanteParte { get; set; }

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x0600109B RID: 4251
		// (set) Token: 0x0600109C RID: 4252
		ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }
	}
}
