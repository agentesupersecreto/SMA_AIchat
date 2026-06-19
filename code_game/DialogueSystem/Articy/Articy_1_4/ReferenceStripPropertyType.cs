using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000068 RID: 104
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ReferenceStripPropertyType : ReferencesType
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000EC28 File Offset: 0x0000CE28
		// (set) Token: 0x06000389 RID: 905 RVA: 0x0000EC30 File Offset: 0x0000CE30
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

		// Token: 0x040001F2 RID: 498
		private string nameField;
	}
}
