using System;

namespace Assets.TValle.Tools.Runtime.SMA.Jobs
{
	// Token: 0x02000029 RID: 41
	public interface ISMAJobObjective
	{
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000104 RID: 260
		string id { get; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000105 RID: 261
		ObjectiveStatus status { get; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000106 RID: 262
		ObjectiveProgressType progressType { get; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000107 RID: 263
		ObjectiveCheckFrequency checkFrequency { get; }

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000108 RID: 264
		// (remove) Token: 0x06000109 RID: 265
		event ObjectiveStatusChandedHandler statusChanged;

		// Token: 0x1400000D RID: 13
		// (add) Token: 0x0600010A RID: 266
		// (remove) Token: 0x0600010B RID: 267
		event ObjectiveProgressChandedHandler progressChanged;

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x0600010C RID: 268
		// (remove) Token: 0x0600010D RID: 269
		event OnObjectiveCompletedHandler onCompleted;
	}
}
