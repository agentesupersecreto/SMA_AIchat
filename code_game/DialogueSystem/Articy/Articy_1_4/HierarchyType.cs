using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000058 RID: 88
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HierarchyType
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000E898 File Offset: 0x0000CA98
		// (set) Token: 0x0600032C RID: 812 RVA: 0x0000E8A0 File Offset: 0x0000CAA0
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

		// Token: 0x040001A1 RID: 417
		private NodeType nodeField;
	}
}
