using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000AD RID: 173
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ExportErrorsType
	{
		// Token: 0x17000253 RID: 595
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x000119A8 File Offset: 0x0000FBA8
		// (set) Token: 0x060006EF RID: 1775 RVA: 0x000119B0 File Offset: 0x0000FBB0
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

		// Token: 0x040003B8 RID: 952
		private ErrorEntryType[] itemsField;
	}
}
