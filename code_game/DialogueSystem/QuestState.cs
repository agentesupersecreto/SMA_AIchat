using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000271 RID: 625
	[Flags]
	public enum QuestState
	{
		// Token: 0x04000F31 RID: 3889
		Unassigned = 1,
		// Token: 0x04000F32 RID: 3890
		Active = 2,
		// Token: 0x04000F33 RID: 3891
		Success = 4,
		// Token: 0x04000F34 RID: 3892
		Failure = 8,
		// Token: 0x04000F35 RID: 3893
		Abandoned = 16
	}
}
