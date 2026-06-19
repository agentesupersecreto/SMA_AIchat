using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A8 RID: 1192
	public interface ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<TCalculoResult, TEstimulo> : ICalculadorDeSessionConResultado<TCalculoResult, TEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionDeCalculosDeEstimulo<TEstimulo> where TCalculoResult : ICalculoDeEstimulo<TEstimulo> where TEstimulo : InteracionEstimulanteBasica
	{
	}
}
