using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000067 RID: 103
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[XmlInclude(typeof(ReferenceStripPropertyType))]
	[Serializable]
	public class ReferencesType
	{
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0000EBF8 File Offset: 0x0000CDF8
		// (set) Token: 0x06000384 RID: 900 RVA: 0x0000EC00 File Offset: 0x0000CE00
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

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000385 RID: 901 RVA: 0x0000EC0C File Offset: 0x0000CE0C
		// (set) Token: 0x06000386 RID: 902 RVA: 0x0000EC14 File Offset: 0x0000CE14
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

		// Token: 0x040001F0 RID: 496
		private ReferenceType[] referenceField;

		// Token: 0x040001F1 RID: 497
		private int countField;
	}
}
