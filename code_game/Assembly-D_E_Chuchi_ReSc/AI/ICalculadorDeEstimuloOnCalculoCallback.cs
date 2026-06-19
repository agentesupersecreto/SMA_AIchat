using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D1 RID: 721
	public interface ICalculadorDeEstimuloOnCalculoCallback : ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x14000048 RID: 72
		// (add) Token: 0x0600103A RID: 4154
		// (remove) Token: 0x0600103B RID: 4155
		event CalculadorOnCalculadoTotalCallbacksHandler generadoFrame;
	}
}
