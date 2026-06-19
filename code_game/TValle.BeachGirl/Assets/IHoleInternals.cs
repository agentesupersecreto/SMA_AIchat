using System;
using UnityEngine;

namespace Assets
{
	// Token: 0x0200000A RID: 10
	public interface IHoleInternals
	{
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000038 RID: 56
		SkinnedMeshRenderer skinnedMeshRenderer { get; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000039 RID: 57
		Transform root { get; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600003A RID: 58
		float worldScale { get; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600003B RID: 59
		ModificableDeFloat scaleModificador { get; }

		// Token: 0x0600003C RID: 60
		Vector3 ProyectTo(Vector3 worldPosition);
	}
}
