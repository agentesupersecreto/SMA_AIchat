using System;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200026A RID: 618
	public class QuestGroupRecord : IComparable
	{
		// Token: 0x06001A99 RID: 6809 RVA: 0x0002D670 File Offset: 0x0002B870
		public QuestGroupRecord()
		{
		}

		// Token: 0x06001A9A RID: 6810 RVA: 0x0002D678 File Offset: 0x0002B878
		public QuestGroupRecord(string groupName, string questTitle)
		{
			this.groupName = groupName;
			this.questTitle = questTitle;
		}

		// Token: 0x06001A9B RID: 6811 RVA: 0x0002D690 File Offset: 0x0002B890
		public int CompareTo(object obj)
		{
			QuestGroupRecord questGroupRecord = obj as QuestGroupRecord;
			if (questGroupRecord == null)
			{
				return 1;
			}
			if (string.Equals(this.groupName, questGroupRecord.groupName))
			{
				return string.Compare(this.questTitle, questGroupRecord.questTitle);
			}
			return string.Compare(this.groupName, questGroupRecord.groupName);
		}

		// Token: 0x04000F01 RID: 3841
		public string groupName;

		// Token: 0x04000F02 RID: 3842
		public string questTitle;
	}
}
