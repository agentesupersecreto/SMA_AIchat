using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000209 RID: 521
	public abstract class CalculoDeEmocionesPorGuiaDeBones : CalculoDeEmocionesPorMovimientoDeBones
	{
		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000CFF RID: 3327 RVA: 0x00038440 File Offset: 0x00036640
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.guiandoBone;
			}
		}

		// Token: 0x06000D00 RID: 3328 RVA: 0x0003B5FE File Offset: 0x000397FE
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> GetEstimulosEnFrame(MovimientosDeBonesByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.enFramePeticiones;
		}
	}
}
