using System;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020D RID: 525
	public class Link
	{
		// Token: 0x04000D72 RID: 3442
		[XmlAttribute("ConversationID")]
		public int ConversationID;

		// Token: 0x04000D73 RID: 3443
		[XmlAttribute("OriginConvoID")]
		public int OriginConvoID;

		// Token: 0x04000D74 RID: 3444
		[XmlAttribute("DestinationConvoID")]
		public int DestinationConvoID;

		// Token: 0x04000D75 RID: 3445
		[XmlAttribute("OriginDialogID")]
		public int OriginDialogID;

		// Token: 0x04000D76 RID: 3446
		[XmlAttribute("DestinationDialogID")]
		public int DestinationDialogID;

		// Token: 0x04000D77 RID: 3447
		[XmlAttribute("IsConnector")]
		public bool IsConnector;
	}
}
