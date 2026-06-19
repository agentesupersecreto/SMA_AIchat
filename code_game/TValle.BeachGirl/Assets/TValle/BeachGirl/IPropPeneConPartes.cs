using System;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x0200002A RID: 42
	public interface IPropPeneConPartes : IPeneConPartes, IPene, IPertenecibleDeCharacter, IComponentStartable, IPeneSimple
	{
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060000D5 RID: 213
		bool propEstaActivo { get; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060000D6 RID: 214
		Transform baseDeProp { get; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060000D7 RID: 215
		float worldRadiusDeBaseDeProp { get; }
	}
}
