using System;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002D7 RID: 727
	// (Invoke) Token: 0x0600104F RID: 4175
	public delegate void CalculadorOnCalculadoCallbacksHandler<TCalculo>(TCalculo calculo, float generado, ICalculadorDeEstimuloConCalculos sender) where TCalculo : ICalculoDeEstimulo;
}
