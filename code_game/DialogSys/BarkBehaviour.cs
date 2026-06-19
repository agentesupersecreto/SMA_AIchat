using System;
using UnityEngine;
using UnityEngine.Playables;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000003 RID: 3
	[Serializable]
	public class BarkBehaviour : PlayableBehaviour
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public string GetEditorBarkText()
		{
			if (!this.useConversation)
			{
				return this.text;
			}
			return "(From " + this.conversation + ")";
		}

		// Token: 0x04000001 RID: 1
		[Tooltip("Get bark text from a conversation.")]
		public bool useConversation = true;

		// Token: 0x04000002 RID: 2
		[Tooltip("Get the bark text from this conversation.")]
		[ConversationPopup(false)]
		public string conversation;

		// Token: 0x04000003 RID: 3
		[Tooltip("Bark this text.")]
		public string text;

		// Token: 0x04000004 RID: 4
		[Tooltip("(Optional) Barker is barking to this listener.")]
		public Transform listener;
	}
}
