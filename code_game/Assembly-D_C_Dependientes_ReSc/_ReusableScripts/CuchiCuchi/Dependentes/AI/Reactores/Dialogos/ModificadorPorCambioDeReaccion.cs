using System;
using Assets._ReusableScripts.CuchiCuchi.AI;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x02000333 RID: 819
	[Serializable]
	public class ModificadorPorCambioDeReaccion : ModificadorPorCambiosEnCalculos<ReaccionHumana>
	{
		// Token: 0x060014A8 RID: 5288 RVA: 0x00062960 File Offset: 0x00060B60
		public ModificadorPorCambioDeReaccion()
			: base((ReaccionHumana a, ReaccionHumana b) => a == b)
		{
		}
	}
}
