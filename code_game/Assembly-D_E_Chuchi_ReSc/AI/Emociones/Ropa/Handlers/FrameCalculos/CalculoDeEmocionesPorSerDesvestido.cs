using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x0200041F RID: 1055
	public abstract class CalculoDeEmocionesPorSerDesvestido : CalculoDeEmocionesPorDesvestidura
	{
		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x0600172A RID: 5930 RVA: 0x0004408B File Offset: 0x0004228B
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.desvestidura;
			}
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x0005EF0C File Offset: 0x0005D10C
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> GetEstimulosEnFrame(DesvestidurasByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.frameDesvestirudas;
		}
	}
}
