using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C4 RID: 196
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ViewBoxModeType
	{
		// Token: 0x040003F9 RID: 1017
		FromAsset,
		// Token: 0x040003FA RID: 1018
		Custom,
		// Token: 0x040003FB RID: 1019
		Auto
	}
}
