using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004A9 RID: 1193
	public interface ICalculadorDeSessionDeTipoConResultado<TCalculoResult, TEstimulo, T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable> : ICalculadorDeSessionDeTipo<T_TipoDeEstimuloEnumerable, T_DireccionDeEstimuloEnumerable>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<TCalculoResult, TEstimulo>, ICalculadorDeSessionConResultado<TCalculoResult, TEstimulo>, ICalculadorDeSessionDeCalculosDeEstimulo<TEstimulo> where TCalculoResult : ICalculoDeEstimulo<TEstimulo> where TEstimulo : InteracionEstimulanteBasica where T_TipoDeEstimuloEnumerable : struct where T_DireccionDeEstimuloEnumerable : struct
	{
	}
}
