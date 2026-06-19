using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Ropa.Handlers.FrameCalculos
{
	// Token: 0x02000420 RID: 1056
	public abstract class CalculoDeEmocionesPorPeticionDesvestidura : CalculoDeEmocionesPorDesvestidura
	{
		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x0600172D RID: 5933 RVA: 0x0005644B File Offset: 0x0005464B
		public override TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return TipoDeEstimulo.peticionDesvestidura;
			}
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x0005EF21 File Offset: 0x0005D121
		protected sealed override DiccionaryEnum<ParteQuePuedeEstimular, EstimuloPorDesvestir> GetEstimulosEnFrame(DesvestidurasByMainInFrame collecor)
		{
			return this.m_EstimuloByMainInFrame.framePeticionesDeDesvestirudas;
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x0005EF2E File Offset: 0x0005D12E
		protected override void AlterarDataGenerada(CalculoDeEstimuloDesvestidoResultado data)
		{
			base.AlterarDataGenerada(data);
			data.reaccionable = false;
		}

		// Token: 0x04001204 RID: 4612
		private static bool printedNoReaccionPAraDesvestiduraPEticion;
	}
}
