using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D4 RID: 724
	public interface ICalculadorDeEstimuloOnCalculoCallbacksCoitalProfundidad<TCalculo> : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimuloCoitalHole
	{
		// Token: 0x1400004B RID: 75
		// (add) Token: 0x06001042 RID: 4162
		// (remove) Token: 0x06001043 RID: 4163
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> calculadoDeEstimuloPorProfundidad;

		// Token: 0x1400004C RID: 76
		// (add) Token: 0x06001044 RID: 4164
		// (remove) Token: 0x06001045 RID: 4165
		event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorProfundidad;
	}
}
