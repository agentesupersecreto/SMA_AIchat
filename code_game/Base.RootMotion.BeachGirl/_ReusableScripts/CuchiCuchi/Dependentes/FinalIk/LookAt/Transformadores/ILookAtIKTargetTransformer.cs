using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt.Transformadores
{
	// Token: 0x02000094 RID: 148
	public interface ILookAtIKTargetTransformer
	{
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060005F6 RID: 1526
		bool isActiveAndEnabled { get; }

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060005F7 RID: 1527
		int order { get; }

		// Token: 0x060005F8 RID: 1528
		Vector3 Transformar(Vector3 position, Quaternion rotation, Vector3 targetPosition);
	}
}
