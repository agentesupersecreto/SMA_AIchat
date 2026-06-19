using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200011D RID: 285
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceStripPropertyType : ReferencesType
	{
		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06000BDC RID: 3036 RVA: 0x00015BD8 File Offset: 0x00013DD8
		// (set) Token: 0x06000BDD RID: 3037 RVA: 0x00015BE0 File Offset: 0x00013DE0
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

		// Token: 0x04000671 RID: 1649
		private string nameField;
	}
}
