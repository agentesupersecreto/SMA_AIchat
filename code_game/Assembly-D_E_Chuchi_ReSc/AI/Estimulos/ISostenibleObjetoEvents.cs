using System;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003E1 RID: 993
	public interface ISostenibleObjetoEvents : ISostenibleObjeto
	{
		// Token: 0x06001593 RID: 5523
		void OnSostenido(AgarranteObjeto por);

		// Token: 0x06001594 RID: 5524
		void OnSoltado(AgarranteObjeto por);
	}
}
