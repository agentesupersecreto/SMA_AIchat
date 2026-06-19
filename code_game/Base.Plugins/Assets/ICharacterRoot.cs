using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000BB RID: 187
	public interface ICharacterRoot : IComponentStartable, IComponentAwakeable
	{
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060005A7 RID: 1447
		Transform transform { get; }

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060005A8 RID: 1448
		Animator bodyAnimator { get; }

		// Token: 0x060005A9 RID: 1449
		T GetComponentInChildren<T>();

		// Token: 0x060005AA RID: 1450
		T GetComponentInParent<T>();

		// Token: 0x060005AB RID: 1451
		T GetComponentInParent<T>(bool includeInactive);

		// Token: 0x060005AC RID: 1452
		T GetComponentInChildren<T>(bool includeInactive);

		// Token: 0x060005AD RID: 1453
		T GetComponentEnRoot<T>();

		// Token: 0x060005AE RID: 1454
		T GetComponent<T>();

		// Token: 0x060005AF RID: 1455
		T GetComponentNotNull<T>() where T : Component;

		// Token: 0x060005B0 RID: 1456
		void GetComponentsInChildren<T>(List<T> results);

		// Token: 0x060005B1 RID: 1457
		void GetComponentsInChildren<T>(bool includeInactive, List<T> result);

		// Token: 0x060005B2 RID: 1458
		T[] GetComponentsInChildren<T>(bool includeInactive);

		// Token: 0x060005B3 RID: 1459
		Coroutine StartCoroutine(IEnumerator routine);
	}
}
