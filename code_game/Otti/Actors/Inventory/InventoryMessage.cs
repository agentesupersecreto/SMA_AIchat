using System;
using com.ootii.Collections;
using com.ootii.Messages;

namespace com.ootii.Actors.Inventory
{
	// Token: 0x020000BA RID: 186
	public class InventoryMessage : Message
	{
		// Token: 0x06000A4D RID: 2637 RVA: 0x000333FA File Offset: 0x000315FA
		public override void Clear()
		{
			this.InventorySource = null;
			this.ItemID = null;
			this.SlotID = null;
			this.WeaponSetID = null;
			this.Form = 0;
			base.Clear();
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00033425 File Offset: 0x00031625
		public override void Release()
		{
			this.Clear();
			base.IsSent = true;
			base.IsHandled = true;
			if (this != null)
			{
				InventoryMessage.sPool.Release(this);
			}
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x0003344C File Offset: 0x0003164C
		public new static InventoryMessage Allocate()
		{
			InventoryMessage inventoryMessage = InventoryMessage.sPool.Allocate();
			if (inventoryMessage == null)
			{
				inventoryMessage = new InventoryMessage();
			}
			inventoryMessage.IsSent = false;
			inventoryMessage.IsHandled = false;
			return inventoryMessage;
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0003347C File Offset: 0x0003167C
		public static InventoryMessage Allocate(InventoryMessage rSource)
		{
			InventoryMessage inventoryMessage = InventoryMessage.sPool.Allocate();
			if (inventoryMessage == null)
			{
				inventoryMessage = new InventoryMessage();
			}
			inventoryMessage.InventorySource = rSource.InventorySource;
			inventoryMessage.ItemID = rSource.ItemID;
			inventoryMessage.SlotID = rSource.SlotID;
			inventoryMessage.WeaponSetID = rSource.WeaponSetID;
			inventoryMessage.Form = rSource.Form;
			inventoryMessage.IsSent = false;
			inventoryMessage.IsHandled = false;
			return inventoryMessage;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x000334E8 File Offset: 0x000316E8
		public static void Release(InventoryMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			InventoryMessage.sPool.Release(rInstance);
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x0003350D File Offset: 0x0003170D
		public new static void Release(IMessage rInstance)
		{
			if (rInstance == null)
			{
				return;
			}
			rInstance.Clear();
			rInstance.IsSent = true;
			rInstance.IsHandled = true;
			if (rInstance is InventoryMessage)
			{
				InventoryMessage.sPool.Release((InventoryMessage)rInstance);
			}
		}

		// Token: 0x04000520 RID: 1312
		public static int MSG_UNKNOWN = 1500;

		// Token: 0x04000521 RID: 1313
		public static int MSG_ITEM_EQUIPPED = 1501;

		// Token: 0x04000522 RID: 1314
		public static int MSG_ITEM_STORED = 1502;

		// Token: 0x04000523 RID: 1315
		public static int MSG_WEAPON_SET_EQUIPPED = 1503;

		// Token: 0x04000524 RID: 1316
		public static int MSG_WEAPON_SET_STORED = 1504;

		// Token: 0x04000525 RID: 1317
		public IInventorySource InventorySource;

		// Token: 0x04000526 RID: 1318
		public string ItemID;

		// Token: 0x04000527 RID: 1319
		public string SlotID;

		// Token: 0x04000528 RID: 1320
		public string WeaponSetID;

		// Token: 0x04000529 RID: 1321
		public int Form;

		// Token: 0x0400052A RID: 1322
		private static ObjectPool<InventoryMessage> sPool = new ObjectPool<InventoryMessage>(10, 10);
	}
}
