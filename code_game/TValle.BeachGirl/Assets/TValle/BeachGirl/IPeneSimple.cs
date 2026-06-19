using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.TValle.BeachGirl
{
	// Token: 0x02000032 RID: 50
	public interface IPeneSimple : IPertenecibleDeCharacter, IComponentStartable
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060000EF RID: 239
		Transform root { get; }

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x060000F0 RID: 240
		bool isPenetrating { get; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x060000F1 RID: 241
		float worldScale { get; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x060000F2 RID: 242
		float worldMaxWidth { get; }

		// Token: 0x060000F3 RID: 243
		void GetColliders(List<Collider> todosResult);

		// Token: 0x060000F4 RID: 244
		IPenetrable TryGetPenetratingObject();
	}
}
