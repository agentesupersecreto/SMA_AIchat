using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200011E RID: 286
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[XmlInclude(typeof(ReferenceStripPropertyType))]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferencesType
	{
		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06000BDF RID: 3039 RVA: 0x00015BF4 File Offset: 0x00013DF4
		// (set) Token: 0x06000BE0 RID: 3040 RVA: 0x00015BFC File Offset: 0x00013DFC
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

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000BE1 RID: 3041 RVA: 0x00015C08 File Offset: 0x00013E08
		// (set) Token: 0x06000BE2 RID: 3042 RVA: 0x00015C10 File Offset: 0x00013E10
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

		// Token: 0x04000672 RID: 1650
		private ReferenceType[] referenceField;

		// Token: 0x04000673 RID: 1651
		private int countField;
	}
}
