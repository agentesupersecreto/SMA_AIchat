using System;
using PixelCrushers.DialogueSystem.ChatMapper;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000024 RID: 36
	[Serializable]
	public class Link
	{
		// Token: 0x060001EB RID: 491 RVA: 0x00008C9C File Offset: 0x00006E9C
		public Link()
		{
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00008CAC File Offset: 0x00006EAC
		public Link(Link chatMapperLink)
		{
			if (chatMapperLink != null)
			{
				this.originConversationID = ((chatMapperLink.OriginConvoID != 0 || chatMapperLink.ConversationID <= 0) ? chatMapperLink.OriginConvoID : chatMapperLink.ConversationID);
				this.originDialogueID = chatMapperLink.OriginDialogID;
				this.destinationConversationID = ((chatMapperLink.DestinationConvoID != 0 || chatMapperLink.ConversationID <= 0) ? chatMapperLink.DestinationConvoID : chatMapperLink.ConversationID);
				this.destinationDialogueID = chatMapperLink.DestinationDialogID;
				this.isConnector = chatMapperLink.IsConnector;
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00008D4C File Offset: 0x00006F4C
		public Link(Link sourceLink)
		{
			this.originConversationID = sourceLink.originConversationID;
			this.originDialogueID = sourceLink.originDialogueID;
			this.destinationConversationID = sourceLink.destinationConversationID;
			this.destinationDialogueID = sourceLink.destinationDialogueID;
			this.isConnector = sourceLink.isConnector;
			this.priority = sourceLink.priority;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00008DB0 File Offset: 0x00006FB0
		public Link(int originConversationID, int originDialogueID, int destinationConversationID, int destinationDialogueID)
		{
			this.originConversationID = originConversationID;
			this.originDialogueID = originDialogueID;
			this.destinationConversationID = destinationConversationID;
			this.destinationDialogueID = destinationDialogueID;
		}

		// Token: 0x040000D1 RID: 209
		public int originConversationID;

		// Token: 0x040000D2 RID: 210
		public int originDialogueID;

		// Token: 0x040000D3 RID: 211
		public int destinationConversationID;

		// Token: 0x040000D4 RID: 212
		public int destinationDialogueID;

		// Token: 0x040000D5 RID: 213
		public bool isConnector;

		// Token: 0x040000D6 RID: 214
		public ConditionPriority priority = ConditionPriority.Normal;
	}
}
