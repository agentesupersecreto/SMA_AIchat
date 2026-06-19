using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D9 RID: 729
	public interface ICalculadorDeEstimuloOnCalculoCallbacks<TCalculo> : ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimulo
	{
		// Token: 0x14000051 RID: 81
		// (add) Token: 0x06001056 RID: 4182
		// (remove) Token: 0x06001057 RID: 4183
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> preCalculadoDeEstimulo;

		// Token: 0x14000052 RID: 82
		// (add) Token: 0x06001058 RID: 4184
		// (remove) Token: 0x06001059 RID: 4185
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> postCalculadoDeEstimulo;

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x0600105A RID: 4186
		// (remove) Token: 0x0600105B RID: 4187
		event CalculadorOnCalculadoTotalCallbacksHandler generadoFrame;
	}
}
