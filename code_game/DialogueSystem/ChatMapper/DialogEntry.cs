using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x0200020C RID: 524
	public class DialogEntry
	{
		// Token: 0x04000D67 RID: 3431
		[XmlAttribute("ID")]
		public int ID;

		// Token: 0x04000D68 RID: 3432
		[XmlAttribute("IsRoot")]
		public bool IsRoot;

		// Token: 0x04000D69 RID: 3433
		[XmlAttribute("IsGroup")]
		public bool IsGroup;

		// Token: 0x04000D6A RID: 3434
		[XmlAttribute("NodeColor")]
		public string NodeColor;

		// Token: 0x04000D6B RID: 3435
		[XmlAttribute("DelaySimStatus")]
		public bool DelaySimStatus;

		// Token: 0x04000D6C RID: 3436
		[XmlAttribute("FalseCondtionAction")]
		public string FalseCondtionAction;

		// Token: 0x04000D6D RID: 3437
		[XmlAttribute("ConditionPriority")]
		public string ConditionPriority;

		// Token: 0x04000D6E RID: 3438
		[XmlArrayItem("Field")]
		[XmlArray("Fields")]
		public List<Field> Fields = new List<Field>();

		// Token: 0x04000D6F RID: 3439
		[XmlArrayItem("Link")]
		[XmlArray("OutgoingLinks")]
		public List<Link> OutgoingLinks = new List<Link>();

		// Token: 0x04000D70 RID: 3440
		public string ConditionsString;

		// Token: 0x04000D71 RID: 3441
		public string UserScript;
	}
}
