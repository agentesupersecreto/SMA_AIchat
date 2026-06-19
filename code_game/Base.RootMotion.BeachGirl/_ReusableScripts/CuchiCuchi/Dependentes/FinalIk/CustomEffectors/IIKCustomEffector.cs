using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones.Targets;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.CustomEffectors
{
	// Token: 0x020000C4 RID: 196
	public interface IIKCustomEffector
	{
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600072C RID: 1836
		IReadOnlyList<CustomBipedEffector> effectorsTypes { get; }

		// Token: 0x0600072D RID: 1837
		bool IsEffectorOf(CustomBipedEffector effector);

		// Token: 0x0600072E RID: 1838
		void SetRotationWeightOf(CustomBipedEffector effector, float weight);

		// Token: 0x0600072F RID: 1839
		void SetRotationTargetOf(CustomBipedEffector effector, Quaternion rotation);

		// Token: 0x06000730 RID: 1840
		float GetRotationWeightOf(CustomBipedEffector effector);

		// Token: 0x06000731 RID: 1841
		Quaternion GetRotationTargetOf(CustomBipedEffector effector);
	}
}
