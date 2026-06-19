using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020B RID: 523
	public class Conversation
	{
		// Token: 0x04000D62 RID: 3426
		[XmlAttribute("ID")]
		public int ID;

		// Token: 0x04000D63 RID: 3427
		[XmlAttribute("NodeColor")]
		public string NodeColor;

		// Token: 0x04000D64 RID: 3428
		[XmlAttribute("LockedMode")]
		public string LockedMode;

		// Token: 0x04000D65 RID: 3429
		[XmlArrayItem("Field")]
		[XmlArray("Fields")]
		public List<Field> Fields = new List<Field>();

		// Token: 0x04000D66 RID: 3430
		[XmlArrayItem("DialogEntry")]
		[XmlArray("DialogEntries")]
		public List<DialogEntry> DialogEntries = new List<DialogEntry>();
	}
}
