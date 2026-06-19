using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200027E RID: 638
	[Serializable]
	public class QuestCondition
	{
		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x06001B93 RID: 7059 RVA: 0x00031F8C File Offset: 0x0003018C
		public bool IsTrue
		{
			get
			{
				return string.IsNullOrEmpty(this.questName) || QuestLog.IsQuestInStateMask(this.questName, this.questState);
			}
		}

		// Token: 0x04000F87 RID: 3975
		public string questName = string.Empty;

		// Token: 0x04000F88 RID: 3976
		[QuestState]
		[BitMask(typeof(QuestState))]
		public QuestState questState;
	}
}
