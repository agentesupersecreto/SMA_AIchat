using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002F7 RID: 759
	public interface ICalculoDeEstimuloCoitalHoleVeloz : ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
	{
		// Token: 0x060010A4 RID: 4260
		void GetEstadoVelocidadReference(out UmbralBasico.Estado velocidad);
	}
}
