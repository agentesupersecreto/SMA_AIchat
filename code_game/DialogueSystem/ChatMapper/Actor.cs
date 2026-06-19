using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x02000208 RID: 520
	[Serializable]
	public class Actor
	{
		// Token: 0x04000D5C RID: 3420
		[XmlAttribute("ID")]
		public int ID;

		// Token: 0x04000D5D RID: 3421
		[XmlArray("Fields")]
		[XmlArrayItem("Field")]
		public List<Field> Fields = new List<Field>();
	}
}
