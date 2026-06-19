using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D3 RID: 723
	public interface ICalculadorDeEstimuloOnCalculoCallbacksCoitalPenetracion<TCalculo> : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimuloCoitalHole
	{
		// Token: 0x14000049 RID: 73
		// (add) Token: 0x0600103E RID: 4158
		// (remove) Token: 0x0600103F RID: 4159
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> calculadoDeEstimuloPorPenetracion;

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06001040 RID: 4160
		// (remove) Token: 0x06001041 RID: 4161
		event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorPenetracion;
	}
}
