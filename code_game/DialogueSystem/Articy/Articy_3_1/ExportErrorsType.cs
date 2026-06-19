using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200018C RID: 396
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class ExportErrorsType
	{
		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x060011C0 RID: 4544 RVA: 0x0001A7CC File Offset: 0x000189CC
		// (set) Token: 0x060011C1 RID: 4545 RVA: 0x0001A7D4 File Offset: 0x000189D4
		[XmlElement("Error")]
		public ErrorEntryType[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		// Token: 0x040009CE RID: 2510
		private ErrorEntryType[] itemsField;
	}
}
