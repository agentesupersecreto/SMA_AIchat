using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Emociones.Handlers.Abstracts
{
	// Token: 0x02000208 RID: 520
	public abstract class CalculoDeEmocionesPorManipulacionDeBones : CalculoDeEmocionesPorMovimientoDeBones
	{
		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x0003842F File Offset: 0x0003662F
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.manipulandoBone;
			}
		}

		// Token: 0x06000CFD RID: 3325 RVA: 0x0003B5E9 File Offset: 0x000397E9
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorManipulacionDeBone> GetEstimulosEnFrame(MovimientosDeBonesByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.enFrame;
		}
	}
}
