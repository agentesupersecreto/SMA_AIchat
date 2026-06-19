using System;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000106 RID: 262
	public interface IEquipStoreMotion
	{
		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000F3E RID: 3902
		bool IsEnabled { get; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000F3F RID: 3903
		bool IsActive { get; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000F40 RID: 3904
		// (set) Token: 0x06000F41 RID: 3905
		string OverrideItemID { get; set; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000F42 RID: 3906
		// (set) Token: 0x06000F43 RID: 3907
		string OverrideSlotID { get; set; }
	}
}
