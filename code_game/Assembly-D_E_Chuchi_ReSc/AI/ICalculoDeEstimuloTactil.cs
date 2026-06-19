using System;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x020002F1 RID: 753
	public interface ICalculoDeEstimuloTactil : ICalculoDeEstimulo<EstimuloTactil>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
	{
		// Token: 0x170003CD RID: 973
		// (get) Token: 0x0600109D RID: 4253
		[Obsolete("", true)]
		UmbralBasico.Estado estado { get; }

		// Token: 0x0600109E RID: 4254
		void FixEstimuloInstanceTypes(EstimuloTactil instance, EstimuloTactil instanceInverted);
	}
}
