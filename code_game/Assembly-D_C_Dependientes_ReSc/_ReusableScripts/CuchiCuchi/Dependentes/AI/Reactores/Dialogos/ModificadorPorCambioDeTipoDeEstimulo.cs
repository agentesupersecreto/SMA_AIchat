using System;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000335 RID: 821
	[Serializable]
	public class ModificadorPorCambioDeTipoDeEstimulo : ModificadorPorCambiosEnCalculos<TipoDeEstimulo>
	{
		// Token: 0x060014AC RID: 5292 RVA: 0x00062993 File Offset: 0x00060B93
		public ModificadorPorCambioDeTipoDeEstimulo()
			: base((TipoDeEstimulo a, TipoDeEstimulo b) => a == b)
		{
		}
	}
}
