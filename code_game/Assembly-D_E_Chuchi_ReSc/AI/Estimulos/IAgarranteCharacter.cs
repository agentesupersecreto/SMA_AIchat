using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos.ObjetosEstimulantes;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Estimulos
{
	// Token: 0x020003DF RID: 991
	public interface IAgarranteCharacter
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x0600158E RID: 5518
		Character character { get; }

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x0600158F RID: 5519
		IReadOnlyList<AgarranteObjeto> agarrantes { get; }

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001590 RID: 5520
		bool listoParaAgarrar { get; }

		// Token: 0x06001591 RID: 5521
		bool ListoParaAgarrarCon(AgarranteObjeto agarrante);
	}
}
