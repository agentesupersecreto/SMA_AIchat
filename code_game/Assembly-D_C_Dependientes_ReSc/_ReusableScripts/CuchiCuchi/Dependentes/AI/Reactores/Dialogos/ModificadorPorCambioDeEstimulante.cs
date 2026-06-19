using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000331 RID: 817
	[Serializable]
	public class ModificadorPorCambioDeEstimulante : ModificadorPorCambiosEnCalculos<ParteQuePuedeEstimular>
	{
		// Token: 0x060014A4 RID: 5284 RVA: 0x0006292D File Offset: 0x00060B2D
		public ModificadorPorCambioDeEstimulante()
			: base((ParteQuePuedeEstimular a, ParteQuePuedeEstimular b) => a == b)
		{
		}
	}
}
