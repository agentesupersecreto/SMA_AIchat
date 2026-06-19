using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos
{
	// Token: 0x020004B5 RID: 1205
	public interface ISesionGeneralTactil : ICalculadorDeSessionDeTipoConResultado<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil, TipoDeEstimuloTactil, DireccionDeEstimulo>, ICalculadorDeSessionDeTipo<TipoDeEstimuloTactil, DireccionDeEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil>, ICalculadorDeSessionConResultado<CalculoDeEstimuloPorCariciasResultado, EstimuloTactil>, ICalculadorDeSessionDeCalculosDeEstimulo<EstimuloTactil>
	{
	}
}
