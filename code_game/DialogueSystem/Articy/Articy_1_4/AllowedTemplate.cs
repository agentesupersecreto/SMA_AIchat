using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000098 RID: 152
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class AllowedTemplate
	{
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x060005C6 RID: 1478 RVA: 0x0001023C File Offset: 0x0000E43C
		// (set) Token: 0x060005C7 RID: 1479 RVA: 0x00010244 File Offset: 0x0000E444
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

		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x060005C8 RID: 1480 RVA: 0x00010250 File Offset: 0x0000E450
		// (set) Token: 0x060005C9 RID: 1481 RVA: 0x00010258 File Offset: 0x0000E458
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

		// Token: 0x0400030C RID: 780
		private string nameField;

		// Token: 0x0400030D RID: 781
		private string guidRefField;
	}
}
