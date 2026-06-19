using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000202 RID: 514
	public abstract class CalculoDeEmocionesPorPeticionEjecutarDePose : CalculoDeEmocionesPorCambioDePose
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000CA0 RID: 3232 RVA: 0x00027012 File Offset: 0x00025212
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.peticionEjecucionDePose;
			}
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x0003AC40 File Offset: 0x00038E40
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorCambiarPose> GetEstimulosEnFrame(CambiosDePoseByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.enFramePeticiones;
		}
	}
}
