using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000DA RID: 218
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PolygonType
	{
		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000854 RID: 2132 RVA: 0x00012760 File Offset: 0x00010960
		// (set) Token: 0x06000855 RID: 2133 RVA: 0x00012768 File Offset: 0x00010968
		public VerticesType Vertices
		{
			get
			{
				return this.verticesField;
			}
			set
			{
				this.verticesField = value;
			}
		}

		// Token: 0x04000490 RID: 1168
		private VerticesType verticesField;
	}
}
