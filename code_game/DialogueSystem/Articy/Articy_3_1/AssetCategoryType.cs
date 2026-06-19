using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F5 RID: 501
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public enum AssetCategoryType
	{
		// Token: 0x04000C84 RID: 3204
		Image,
		// Token: 0x04000C85 RID: 3205
		Audio,
		// Token: 0x04000C86 RID: 3206
		Video,
		// Token: 0x04000C87 RID: 3207
		Document,
		// Token: 0x04000C88 RID: 3208
		Misc
	}
}
