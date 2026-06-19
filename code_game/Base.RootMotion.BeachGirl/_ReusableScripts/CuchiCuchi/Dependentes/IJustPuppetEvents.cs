using System;
using RootMotion.Dynamics;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes
{
	// Token: 0x02000056 RID: 86
	public interface IJustPuppetEvents
	{
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060003A8 RID: 936
		// (remove) Token: 0x060003A9 RID: 937
		event Action<PuppetMasterUpdater, PuppetMaster> justFixedUpdating;

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060003AA RID: 938
		// (remove) Token: 0x060003AB RID: 939
		event Action<PuppetMasterUpdater, PuppetMaster> justFixedUpdated;

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x060003AC RID: 940
		// (remove) Token: 0x060003AD RID: 941
		event Action<PuppetMasterUpdater, PuppetMaster> justUpdating;

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x060003AE RID: 942
		// (remove) Token: 0x060003AF RID: 943
		event Action<PuppetMasterUpdater, PuppetMaster> justUpdated;

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x060003B0 RID: 944
		// (remove) Token: 0x060003B1 RID: 945
		event Action<PuppetMasterUpdater, PuppetMaster> justLateUpdating;

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060003B2 RID: 946
		// (remove) Token: 0x060003B3 RID: 947
		event Action<PuppetMasterUpdater, PuppetMaster> justLateUpdated;
	}
}
