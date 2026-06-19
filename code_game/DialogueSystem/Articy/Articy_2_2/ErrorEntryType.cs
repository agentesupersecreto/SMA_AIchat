using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000AB RID: 171
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ErrorEntryType
	{
		// Token: 0x060006E8 RID: 1768 RVA: 0x00011968 File Offset: 0x0000FB68
		public ErrorEntryType()
		{
			this.severityField = ErrorSeverityType.Soft;
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x00011978 File Offset: 0x0000FB78
		// (set) Token: 0x060006EA RID: 1770 RVA: 0x00011980 File Offset: 0x0000FB80
		[XmlAttribute]
		[DefaultValue(ErrorSeverityType.Soft)]
		public ErrorSeverityType Severity
		{
			get
			{
				return this.severityField;
			}
			set
			{
				this.severityField = value;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x0001198C File Offset: 0x0000FB8C
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x00011994 File Offset: 0x0000FB94
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

		// Token: 0x040003B3 RID: 947
		private ErrorSeverityType severityField;

		// Token: 0x040003B4 RID: 948
		private string valueField;
	}
}
