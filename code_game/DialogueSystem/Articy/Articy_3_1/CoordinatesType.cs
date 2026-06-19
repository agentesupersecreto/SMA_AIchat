using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000204 RID: 516
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class CoordinatesType
	{
		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x0001E394 File Offset: 0x0001C594
		// (set) Token: 0x060017CB RID: 6091 RVA: 0x0001E39C File Offset: 0x0001C59C
		[XmlElement("Vertices")]
		public VerticesType[] Vertices
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

		// Token: 0x04000D0B RID: 3339
		private VerticesType[] verticesField;
	}
}
