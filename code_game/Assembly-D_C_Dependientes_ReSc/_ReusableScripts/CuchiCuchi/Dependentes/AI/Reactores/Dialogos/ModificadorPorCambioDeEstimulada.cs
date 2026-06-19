using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x0200032F RID: 815
	[Serializable]
	public class ModificadorPorCambioDeEstimulada : ModificadorPorCambiosEnCalculos<ParteDelCuerpoHumano>
	{
		// Token: 0x060014A0 RID: 5280 RVA: 0x000628F4 File Offset: 0x00060AF4
		public ModificadorPorCambioDeEstimulada()
			: base((ParteDelCuerpoHumano a, ParteDelCuerpoHumano b) => a == b)
		{
		}
	}
}
