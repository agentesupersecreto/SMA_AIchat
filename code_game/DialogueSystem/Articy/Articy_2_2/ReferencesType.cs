using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000BF RID: 191
	[XmlInclude(typeof(ReferenceStripPropertyType))]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferencesType
	{
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x0600075F RID: 1887 RVA: 0x00011DF0 File Offset: 0x0000FFF0
		// (set) Token: 0x06000760 RID: 1888 RVA: 0x00011DF8 File Offset: 0x0000FFF8
		[XmlElement("Reference")]
		public ReferenceType[] Reference
		{
			get
			{
				return this.referenceField;
			}
			set
			{
				this.referenceField = value;
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x00011E04 File Offset: 0x00010004
		// (set) Token: 0x06000762 RID: 1890 RVA: 0x00011E0C File Offset: 0x0001000C
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

		// Token: 0x040003EB RID: 1003
		private ReferenceType[] referenceField;

		// Token: 0x040003EC RID: 1004
		private int countField;
	}
}
