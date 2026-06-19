using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200026B RID: 619
	public struct QuestEntryArgs
	{
		// Token: 0x06001A9C RID: 6812 RVA: 0x0002D6E8 File Offset: 0x0002B8E8
		public QuestEntryArgs(string questName, int entryNumber)
		{
			this.questName = questName;
			this.entryNumber = entryNumber;
		}

		// Token: 0x04000F03 RID: 3843
		public string questName;

		// Token: 0x04000F04 RID: 3844
		public int entryNumber;
	}
}
