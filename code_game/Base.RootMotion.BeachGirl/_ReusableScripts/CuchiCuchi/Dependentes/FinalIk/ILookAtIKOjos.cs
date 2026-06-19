using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk
{
	// Token: 0x02000064 RID: 100
	public interface ILookAtIKOjos
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000412 RID: 1042
		ILookAtOjosTargets targets { get; }

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000413 RID: 1043
		// (remove) Token: 0x06000414 RID: 1044
		event Action<ILookAtIKOjos> updating;

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000415 RID: 1045
		Vector3 postUpdateCenterPosition { get; }
	}
}
