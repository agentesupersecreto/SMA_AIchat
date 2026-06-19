using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200007D RID: 125
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class PolygonType
	{
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000446 RID: 1094 RVA: 0x0000F36C File Offset: 0x0000D56C
		// (set) Token: 0x06000447 RID: 1095 RVA: 0x0000F374 File Offset: 0x0000D574
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

		// Token: 0x0400024B RID: 587
		private VerticesType verticesField;
	}
}
