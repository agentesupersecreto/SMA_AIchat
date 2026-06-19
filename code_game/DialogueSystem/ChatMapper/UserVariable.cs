using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020E RID: 526
	public class UserVariable
	{
		// Token: 0x04000D78 RID: 3448
		[XmlArrayItem("Field")]
		[XmlArray("Fields")]
		public List<Field> Fields = new List<Field>();
	}
}
