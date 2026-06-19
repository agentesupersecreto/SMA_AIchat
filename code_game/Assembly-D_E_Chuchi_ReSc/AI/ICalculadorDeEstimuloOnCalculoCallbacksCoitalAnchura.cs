using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D5 RID: 725
	public interface ICalculadorDeEstimuloOnCalculoCallbacksCoitalAnchura<TCalculo> : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimuloCoitalHole
	{
		// Token: 0x1400004D RID: 77
		// (add) Token: 0x06001046 RID: 4166
		// (remove) Token: 0x06001047 RID: 4167
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> calculadoDeEstimuloPorAnchura;

		// Token: 0x1400004E RID: 78
		// (add) Token: 0x06001048 RID: 4168
		// (remove) Token: 0x06001049 RID: 4169
		event CalculadorOnCalculadoTotalCallbacksHandler calculadoTotalDeFramePorAnchura;
	}
}
