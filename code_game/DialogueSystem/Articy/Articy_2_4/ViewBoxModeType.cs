using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000123 RID: 291
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ViewBoxModeType
	{
		// Token: 0x04000680 RID: 1664
		FromAsset,
		// Token: 0x04000681 RID: 1665
		Custom,
		// Token: 0x04000682 RID: 1666
		Auto
	}
}
