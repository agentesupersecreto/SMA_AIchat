using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x020002A5 RID: 677
	[Flags]
	public enum DialogueTriggerEvent
	{
		// Token: 0x04001030 RID: 4144
		OnBarkEnd = 1,
		// Token: 0x04001031 RID: 4145
		OnConversationEnd = 2,
		// Token: 0x04001032 RID: 4146
		OnSequenceEnd = 4,
		// Token: 0x04001033 RID: 4147
		OnTriggerEnter = 8,
		// Token: 0x04001034 RID: 4148
		OnStart = 16,
		// Token: 0x04001035 RID: 4149
		OnUse = 32,
		// Token: 0x04001036 RID: 4150
		OnEnable = 64,
		// Token: 0x04001037 RID: 4151
		OnTriggerExit = 128,
		// Token: 0x04001038 RID: 4152
		OnDisable = 256,
		// Token: 0x04001039 RID: 4153
		OnDestroy = 512,
		// Token: 0x0400103A RID: 4154
		None = 1024,
		// Token: 0x0400103B RID: 4155
		OnCollisionEnter = 2048,
		// Token: 0x0400103C RID: 4156
		OnCollisionExit = 4096
	}
}
