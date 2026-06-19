using System;
using System.Collections.Generic;

namespace Assets._ReusableScripts.CuchiCuchi.Dialogos
{
	// Token: 0x020001C9 RID: 457
	public interface IEnvolturaCondicionalDeHolders
	{
		// Token: 0x06000ADE RID: 2782
		bool IsValid();

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000ADF RID: 2783
		IReadOnlyList<IHolderDeCollecionDeDialogoInfo> grupos { get; }
	}
}
