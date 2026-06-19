using System;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x02000018 RID: 24
	public interface ISMAUnlockableJob
	{
		// Token: 0x06000084 RID: 132
		bool IsUnlocked(ISMAJobsManager manager, SMAJobMap map);
	}
}
