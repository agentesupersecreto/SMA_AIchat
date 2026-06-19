using System;

namespace com.ootii.Actors.AnimationControllers
{
	// Token: 0x02000107 RID: 263
	public interface IWalkRunMotion
	{
		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000F44 RID: 3908
		bool IsEnabled { get; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000F45 RID: 3909
		bool IsActive { get; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000F46 RID: 3910
		bool IsRunActive { get; }

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000F47 RID: 3911
		// (set) Token: 0x06000F48 RID: 3912
		bool StartInMove { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000F49 RID: 3913
		// (set) Token: 0x06000F4A RID: 3914
		bool StartInWalk { get; set; }

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000F4B RID: 3915
		// (set) Token: 0x06000F4C RID: 3916
		bool StartInRun { get; set; }
	}
}
