using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000BE RID: 190
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ReferenceStripPropertyType : ReferencesType
	{
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x0600075C RID: 1884 RVA: 0x00011DD4 File Offset: 0x0000FFD4
		// (set) Token: 0x0600075D RID: 1885 RVA: 0x00011DDC File Offset: 0x0000FFDC
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

		// Token: 0x040003EA RID: 1002
		private string nameField;
	}
}
