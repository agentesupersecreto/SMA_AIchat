using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019D RID: 413
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[XmlInclude(typeof(ReferenceStripPropertyType))]
	[Serializable]
	public class ReferencesType
	{
		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06001231 RID: 4657 RVA: 0x0001AC1C File Offset: 0x00018E1C
		// (set) Token: 0x06001232 RID: 4658 RVA: 0x0001AC24 File Offset: 0x00018E24
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

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x06001233 RID: 4659 RVA: 0x0001AC30 File Offset: 0x00018E30
		// (set) Token: 0x06001234 RID: 4660 RVA: 0x0001AC38 File Offset: 0x00018E38
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

		// Token: 0x040009FE RID: 2558
		private ReferenceType[] referenceField;

		// Token: 0x040009FF RID: 2559
		private int countField;
	}
}
