using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A7 RID: 1191
	public interface ICalculadorDeSessionConResultado<TCalculoResult, TEstimulo> : ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable where TCalculoResult : ICalculoDeEstimulo<TEstimulo> where TEstimulo : InteracionEstimulanteBasica
	{
		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06001C29 RID: 7209
		TCalculoResult resultado { get; }
	}
}
