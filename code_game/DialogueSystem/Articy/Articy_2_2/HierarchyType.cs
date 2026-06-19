using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000AF RID: 175
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HierarchyType
	{
		// Token: 0x17000258 RID: 600
		// (get) Token: 0x060006FA RID: 1786 RVA: 0x00011A1C File Offset: 0x0000FC1C
		// (set) Token: 0x060006FB RID: 1787 RVA: 0x00011A24 File Offset: 0x0000FC24
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

		// Token: 0x040003BD RID: 957
		private NodeType nodeField;
	}
}
