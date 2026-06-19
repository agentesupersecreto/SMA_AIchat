using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x02000209 RID: 521
	public class Item
	{
		// Token: 0x04000D5E RID: 3422
		[XmlAttribute("ID")]
		public int ID;

		// Token: 0x04000D5F RID: 3423
		[XmlArrayItem("Field")]
		[XmlArray("Fields")]
		public List<Field> Fields = new List<Field>();
	}
}
