using System;
using com.ootii.Base;
using com.ootii.Items;
using UnityEngine;

namespace com.ootii.Actors.LifeCores
{
	// Token: 0x020000AC RID: 172
	public interface IItemCore : IItem, IBaseObject, ILifeCore
	{
		// Token: 0x17000288 RID: 648
		// (get) Token: 0x06000991 RID: 2449
		// (set) Token: 0x06000992 RID: 2450
		GameObject Owner { get; set; }

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x06000993 RID: 2451
		Vector3 LocalPosition { get; }

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000994 RID: 2452
		Quaternion LocalRotation { get; }

		// Token: 0x06000995 RID: 2453
		void OnEquipped();

		// Token: 0x06000996 RID: 2454
		void OnStored();
	}
}
