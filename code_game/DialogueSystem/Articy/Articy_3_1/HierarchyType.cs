using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200018E RID: 398
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HierarchyType
	{
		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x060011CC RID: 4556 RVA: 0x0001A840 File Offset: 0x00018A40
		// (set) Token: 0x060011CD RID: 4557 RVA: 0x0001A848 File Offset: 0x00018A48
		public NodeType Node
		{
			get
			{
				return this.nodeField;
			}
			set
			{
				this.nodeField = value;
			}
		}

		// Token: 0x040009D3 RID: 2515
		private NodeType nodeField;
	}
}
