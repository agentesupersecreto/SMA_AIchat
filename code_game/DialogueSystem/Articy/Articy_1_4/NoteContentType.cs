using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000077 RID: 119
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class NoteContentType
	{
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x060003EA RID: 1002 RVA: 0x0000EFE0 File Offset: 0x0000D1E0
		// (set) Token: 0x060003EB RID: 1003 RVA: 0x0000EFE8 File Offset: 0x0000D1E8
		[XmlAnyElement]
		public XmlElement Any
		{
			get
			{
				return this.anyField;
			}
			set
			{
				this.anyField = value;
			}
		}

		// Token: 0x170000FA RID: 250
		// (get) Token: 0x060003EC RID: 1004 RVA: 0x0000EFF4 File Offset: 0x0000D1F4
		// (set) Token: 0x060003ED RID: 1005 RVA: 0x0000EFFC File Offset: 0x0000D1FC
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x04000220 RID: 544
		private XmlElement anyField;

		// Token: 0x04000221 RID: 545
		private int countField;
	}
}
