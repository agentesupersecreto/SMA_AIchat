using System;
using UnityEngine;

namespace com.ootii.Actors.Inventory
{
	// Token: 0x020000B9 RID: 185
	public interface IInventorySource
	{
		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000A47 RID: 2631
		bool AllowMotionSelfActivation { get; }

		// Token: 0x06000A48 RID: 2632
		GameObject EquipItem(string rItemID, string rSlotID, string rResourcePath = "");

		// Token: 0x06000A49 RID: 2633
		void StoreItem(string rSlotID);

		// Token: 0x06000A4A RID: 2634
		string GetItemID(string rSlotID, bool rRequireIsEquipped = true);

		// Token: 0x06000A4B RID: 2635
		T GetItemPropertyValue<T>(string rItemID, string rPropertyID);

		// Token: 0x06000A4C RID: 2636
		void SetItemPropertyValue<T>(string rItemID, string rPropertyID, T rValue);
	}
}
