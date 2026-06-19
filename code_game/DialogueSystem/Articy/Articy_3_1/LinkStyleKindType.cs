using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001D4 RID: 468
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public enum LinkStyleKindType
	{
		// Token: 0x04000B77 RID: 2935
		Inherited,
		// Token: 0x04000B78 RID: 2936
		PreviewImage,
		// Token: 0x04000B79 RID: 2937
		IconOnly,
		// Token: 0x04000B7A RID: 2938
		Minimal
	}
}
