using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000201 RID: 513
	public abstract class CalculoDeEmocionesPorEjecutarDePose : CalculoDeEmocionesPorCambioDePose
	{
		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00026DED File Offset: 0x00024FED
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.ejecucionDePose;
			}
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x0003AC2B File Offset: 0x00038E2B
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> GetEstimulosEnFrame(CambiosDePoseByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.enFrame;
		}
	}
}
