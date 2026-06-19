using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000005 RID: 5
public interface ICustomClothingItemScript
{
	// Token: 0x0600000C RID: 12
	void OnInit(GameObject yourClothingItemInstance, GameObject yourClothingItemCustomArmatureInstance);

	// Token: 0x0600000D RID: 13
	void OnCollidersInit(IReadOnlyList<GameObject> yourClothingItemInstantiatedColliders);

	// Token: 0x0600000E RID: 14
	void OnMaterialsAdded();

	// Token: 0x0600000F RID: 15
	void OnAdded();

	// Token: 0x06000010 RID: 16
	void OnShown();

	// Token: 0x06000011 RID: 17
	void OnHidden();

	// Token: 0x06000012 RID: 18
	void OnRemoved();
}
