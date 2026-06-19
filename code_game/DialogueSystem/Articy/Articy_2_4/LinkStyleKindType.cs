using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000155 RID: 341
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum LinkStyleKindType
	{
		// Token: 0x040007EB RID: 2027
		Inherited,
		// Token: 0x040007EC RID: 2028
		PreviewImage,
		// Token: 0x040007ED RID: 2029
		IconOnly,
		// Token: 0x040007EE RID: 2030
		Minimal
	}
}
