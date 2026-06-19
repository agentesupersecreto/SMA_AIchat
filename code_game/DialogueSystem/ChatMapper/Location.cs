using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020A RID: 522
	public class Location
	{
		// Token: 0x04000D60 RID: 3424
		[XmlAttribute("ID")]
		public int ID;

		// Token: 0x04000D61 RID: 3425
		[XmlArray("Fields")]
		[XmlArrayItem("Field")]
		public List<Field> Fields = new List<Field>();
	}
}
