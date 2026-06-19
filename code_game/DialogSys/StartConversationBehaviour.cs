using System;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class StartConversationBehaviour : PlayableBehaviour
	{
		// Token: 0x04000009 RID: 9
		[Tooltip("(Optional) The other participant.")]
		public Transform conversant;

		// Token: 0x0400000A RID: 10
		[Tooltip("The conversation to start.")]
		[ConversationPopup(false)]
		public string conversation;

		// Token: 0x0400000B RID: 11
		[Tooltip("Jump to a specific dialogue entry instead of starting from the conversation's START node.")]
		public bool jumpToSpecificEntry;

		// Token: 0x0400000C RID: 12
		[Tooltip("Dialogue entry to jump to.")]
		public int entryID;
	}
}
