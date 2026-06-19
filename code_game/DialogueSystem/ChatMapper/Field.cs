using System;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020F RID: 527
	public class Field
	{
		// Token: 0x04000D79 RID: 3449
		[XmlAttribute("Hint")]
		public string Hint;

		// Token: 0x04000D7A RID: 3450
		[XmlAttribute("Type")]
		public string Type;

		// Token: 0x04000D7B RID: 3451
		public string Title;

		// Token: 0x04000D7C RID: 3452
		public string Value;
	}
}
