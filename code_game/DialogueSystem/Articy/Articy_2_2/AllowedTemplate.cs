using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000FB RID: 251
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class AllowedTemplate
	{
		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00013BA8 File Offset: 0x00011DA8
		// (set) Token: 0x06000A62 RID: 2658 RVA: 0x00013BB0 File Offset: 0x00011DB0
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00013BBC File Offset: 0x00011DBC
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x00013BC4 File Offset: 0x00011DC4
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x04000599 RID: 1433
		private string nameField;

		// Token: 0x0400059A RID: 1434
		private string idRefField;
	}
}
