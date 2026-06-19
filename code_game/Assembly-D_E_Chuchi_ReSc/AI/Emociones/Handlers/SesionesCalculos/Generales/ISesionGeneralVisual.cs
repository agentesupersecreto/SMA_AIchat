using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.SesionesCalculos.Generales
{
	// Token: 0x020004C7 RID: 1223
	public interface ISesionGeneralVisual : ICalculadorDeSessionDeTipoConResultado<CalculoDeEstimuloVisualResultado, EstimuloVisual, TipoDeEstimuloVisual, DireccionDeEstimulo>, ICalculadorDeSessionDeTipo<TipoDeEstimuloVisual, DireccionDeEstimulo>, ICalculadorDeSession, ICalculadorDeEstimuloConCalculos, ICalculadorDeEstimulo, IComponentAwakeable, ICalculadorDeSessionConResultadoDeCalculosDeEstimulo<CalculoDeEstimuloVisualResultado, EstimuloVisual>, ICalculadorDeSessionConResultado<CalculoDeEstimuloVisualResultado, EstimuloVisual>, ICalculadorDeSessionDeCalculosDeEstimulo<EstimuloVisual>
	{
	}
}
