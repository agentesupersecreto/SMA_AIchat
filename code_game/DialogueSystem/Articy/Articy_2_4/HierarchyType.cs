using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200010F RID: 271
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class HierarchyType
	{
		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000B7A RID: 2938 RVA: 0x00015818 File Offset: 0x00013A18
		// (set) Token: 0x06000B7B RID: 2939 RVA: 0x00015820 File Offset: 0x00013A20
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

		// Token: 0x04000647 RID: 1607
		private NodeType nodeField;
	}
}
