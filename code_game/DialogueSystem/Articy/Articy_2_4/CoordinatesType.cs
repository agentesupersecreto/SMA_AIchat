using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000185 RID: 389
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class CoordinatesType
	{
		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06001178 RID: 4472 RVA: 0x0001936C File Offset: 0x0001756C
		// (set) Token: 0x06001179 RID: 4473 RVA: 0x00019374 File Offset: 0x00017574
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

		// Token: 0x0400097F RID: 2431
		private VerticesType[] verticesField;
	}
}
