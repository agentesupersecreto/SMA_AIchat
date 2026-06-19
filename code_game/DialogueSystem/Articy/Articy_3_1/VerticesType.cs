using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001DE RID: 478
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class VerticesType
	{
		// Token: 0x170008FA RID: 2298
		// (get) Token: 0x0600157E RID: 5502 RVA: 0x0001CCD4 File Offset: 0x0001AED4
		// (set) Token: 0x0600157F RID: 5503 RVA: 0x0001CCDC File Offset: 0x0001AEDC
		[XmlAttribute]
		public CoordinateReferenceType Reference
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

		// Token: 0x170008FB RID: 2299
		// (get) Token: 0x06001580 RID: 5504 RVA: 0x0001CCE8 File Offset: 0x0001AEE8
		// (set) Token: 0x06001581 RID: 5505 RVA: 0x0001CCF0 File Offset: 0x0001AEF0
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

		// Token: 0x170008FC RID: 2300
		// (get) Token: 0x06001582 RID: 5506 RVA: 0x0001CCFC File Offset: 0x0001AEFC
		// (set) Token: 0x06001583 RID: 5507 RVA: 0x0001CD04 File Offset: 0x0001AF04
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x04000BD8 RID: 3032
		private CoordinateReferenceType referenceField;

		// Token: 0x04000BD9 RID: 3033
		private int countField;

		// Token: 0x04000BDA RID: 3034
		private string valueField;
	}
}
