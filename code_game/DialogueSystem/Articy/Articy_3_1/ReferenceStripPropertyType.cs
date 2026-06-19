using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019C RID: 412
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceStripPropertyType : ReferencesType
	{
		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x0600122E RID: 4654 RVA: 0x0001AC00 File Offset: 0x00018E00
		// (set) Token: 0x0600122F RID: 4655 RVA: 0x0001AC08 File Offset: 0x00018E08
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

		// Token: 0x040009FD RID: 2557
		private string nameField;
	}
}
