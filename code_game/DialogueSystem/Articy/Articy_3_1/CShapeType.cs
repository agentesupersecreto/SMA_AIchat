using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E3 RID: 483
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public enum CShapeType
	{
		// Token: 0x04000BED RID: 3053
		Polygon,
		// Token: 0x04000BEE RID: 3054
		Circle,
		// Token: 0x04000BEF RID: 3055
		Rectangle
	}
}
