using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200010B RID: 267
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ErrorEntryType
	{
		// Token: 0x06000B68 RID: 2920 RVA: 0x00015764 File Offset: 0x00013964
		public ErrorEntryType()
		{
			this.severityField = ErrorSeverityType.Soft;
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000B69 RID: 2921 RVA: 0x00015774 File Offset: 0x00013974
		// (set) Token: 0x06000B6A RID: 2922 RVA: 0x0001577C File Offset: 0x0001397C
		[DefaultValue(ErrorSeverityType.Soft)]
		[XmlAttribute]
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

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000B6B RID: 2923 RVA: 0x00015788 File Offset: 0x00013988
		// (set) Token: 0x06000B6C RID: 2924 RVA: 0x00015790 File Offset: 0x00013990
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

		// Token: 0x0400063D RID: 1597
		private ErrorSeverityType severityField;

		// Token: 0x0400063E RID: 1598
		private string valueField;
	}
}
