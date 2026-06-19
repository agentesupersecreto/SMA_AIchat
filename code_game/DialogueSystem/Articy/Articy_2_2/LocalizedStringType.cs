using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000AA RID: 170
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocalizedStringType
	{
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x060006E4 RID: 1764 RVA: 0x00011940 File Offset: 0x0000FB40
		// (set) Token: 0x060006E5 RID: 1765 RVA: 0x00011948 File Offset: 0x0000FB48
		[XmlAttribute(DataType = "token")]
		public string Lang
		{
			get
			{
				return this.langField;
			}
			set
			{
				this.langField = value;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x060006E6 RID: 1766 RVA: 0x00011954 File Offset: 0x0000FB54
		// (set) Token: 0x060006E7 RID: 1767 RVA: 0x0001195C File Offset: 0x0000FB5C
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

		// Token: 0x040003B1 RID: 945
		private string langField;

		// Token: 0x040003B2 RID: 946
		private string valueField;
	}
}
