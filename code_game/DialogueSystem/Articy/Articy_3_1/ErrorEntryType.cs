using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200018A RID: 394
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ErrorEntryType
	{
		// Token: 0x060011BA RID: 4538 RVA: 0x0001A78C File Offset: 0x0001898C
		public ErrorEntryType()
		{
			this.severityField = ErrorSeverityType.Soft;
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x060011BB RID: 4539 RVA: 0x0001A79C File Offset: 0x0001899C
		// (set) Token: 0x060011BC RID: 4540 RVA: 0x0001A7A4 File Offset: 0x000189A4
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

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x060011BD RID: 4541 RVA: 0x0001A7B0 File Offset: 0x000189B0
		// (set) Token: 0x060011BE RID: 4542 RVA: 0x0001A7B8 File Offset: 0x000189B8
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

		// Token: 0x040009C9 RID: 2505
		private ErrorSeverityType severityField;

		// Token: 0x040009CA RID: 2506
		private string valueField;
	}
}
