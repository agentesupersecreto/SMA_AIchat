using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002E0 RID: 736
	public interface ICalculadorSimulable : ICalculadorDeEstimuloClasificable, ICalculadorDeEstimulo, IComponentAwakeable
	{
		// Token: 0x06001063 RID: 4195
		void SimularGlobal(ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, float deltaTime, out RangeValueV2 intervalo, out UmbralBasico.Estado minGenerado, out UmbralBasico.Estado maxGenerado, EmocionesFemeninasValues? emocionesValoresMods, out ICalculoDeEstimuloCompleto faseTres);
	}
}
