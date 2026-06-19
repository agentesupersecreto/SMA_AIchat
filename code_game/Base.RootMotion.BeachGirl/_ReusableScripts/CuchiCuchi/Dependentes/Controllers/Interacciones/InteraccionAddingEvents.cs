using System;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones
{
	// Token: 0x020000D4 RID: 212
	public interface InteraccionAddingEvents
	{
		// Token: 0x14000063 RID: 99
		// (add) Token: 0x060007A7 RID: 1959
		// (remove) Token: 0x060007A8 RID: 1960
		event Action<Interaccion, IInteraccionesDeCharacter> addedTo;

		// Token: 0x14000064 RID: 100
		// (add) Token: 0x060007A9 RID: 1961
		// (remove) Token: 0x060007AA RID: 1962
		event Action<Interaccion, IInteraccionesDeCharacter> removingFrom;

		// Token: 0x14000065 RID: 101
		// (add) Token: 0x060007AB RID: 1963
		// (remove) Token: 0x060007AC RID: 1964
		event Action<Interaccion, IInteraccionesDeCharacter> removedFrom;

		// Token: 0x060007AD RID: 1965
		void AddedTo(IInteraccionesDeCharacter interaccionesDeCharacter);

		// Token: 0x060007AE RID: 1966
		void RemovingFrom(IInteraccionesDeCharacter interaccionesDeCharacter);

		// Token: 0x060007AF RID: 1967
		void RemovedFrom(IInteraccionesDeCharacter interaccionesDeCharacter);
	}
}
