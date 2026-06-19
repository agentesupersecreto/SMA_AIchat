using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200010D RID: 269
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ExportErrorsType
	{
		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000B6E RID: 2926 RVA: 0x000157A4 File Offset: 0x000139A4
		// (set) Token: 0x06000B6F RID: 2927 RVA: 0x000157AC File Offset: 0x000139AC
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

		// Token: 0x04000642 RID: 1602
		private ErrorEntryType[] itemsField;
	}
}
