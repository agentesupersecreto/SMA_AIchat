using System;
using com.ootii.Base;

namespace com.ootii.Items
{
	// Token: 0x02000025 RID: 37
	public interface IItemComponent : IItem, IBaseObject
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060001D8 RID: 472
		// (set) Token: 0x060001D9 RID: 473
		bool IsEnabled { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060001DA RID: 474
		// (set) Token: 0x060001DB RID: 475
		bool IsActive { get; set; }

		// Token: 0x060001DC RID: 476
		void UpdateComponent(IItem rItem);

		// Token: 0x060001DD RID: 477
		void OnEquipped(IItem rItem);

		// Token: 0x060001DE RID: 478
		void OnStored(IItem rItem);
	}
}
