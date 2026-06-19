using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002F5 RID: 757
	public interface ICalculoDeEstimuloCoitalHoleProfundaV2 : ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
	{
		// Token: 0x060010A2 RID: 4258
		void GetEstadoProfundidadReference(out UmbralBasico.Estado profundidad);
	}
}
