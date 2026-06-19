using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200005B RID: 91
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferenceType
	{
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0000E948 File Offset: 0x0000CB48
		// (set) Token: 0x0600033E RID: 830 RVA: 0x0000E950 File Offset: 0x0000CB50
		[XmlAttribute]
		public string GuidRef
		{
			get
			{
				return this.guidRefField;
			}
			set
			{
				this.guidRefField = value;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000E95C File Offset: 0x0000CB5C
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0000E964 File Offset: 0x0000CB64
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

		// Token: 0x040001AC RID: 428
		private string guidRefField;

		// Token: 0x040001AD RID: 429
		private string valueField;
	}
}
