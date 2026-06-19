using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D6 RID: 726
	public interface ICalculadorDeEstimuloOnCalculoCallbacksCoitales<TCalculo> : ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculo : ICalculoDeEstimuloCoitalHole
	{
		// Token: 0x1400004F RID: 79
		// (add) Token: 0x0600104A RID: 4170
		// (remove) Token: 0x0600104B RID: 4171
		event CalculadorOnCalculadoCallbacksHandler<TCalculo> calculadoDeEstimulo;

		// Token: 0x14000050 RID: 80
		// (add) Token: 0x0600104C RID: 4172
		// (remove) Token: 0x0600104D RID: 4173
		event CalculadorOnCalculadoTotalCallbacksHandler generadoFrame;
	}
}
