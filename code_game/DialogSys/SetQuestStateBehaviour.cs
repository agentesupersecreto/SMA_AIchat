using System;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x0200000D RID: 13
	[Serializable]
	public class SetQuestStateBehaviour : PlayableBehaviour
	{
		// Token: 0x04000010 RID: 16
		[QuestPopup(false)]
		public string quest;

		// Token: 0x04000011 RID: 17
		[Tooltip("Change the quest's main state.")]
		public bool setQuestState;

		// Token: 0x04000012 RID: 18
		[QuestState]
		public QuestState questState;

		// Token: 0x04000013 RID: 19
		[Tooltip("Change a quest entry's state.")]
		public bool setQuestEntryState;

		// Token: 0x04000014 RID: 20
		public int questEntryNumber;

		// Token: 0x04000015 RID: 21
		[QuestState]
		public QuestState questEntryState;
	}
}
