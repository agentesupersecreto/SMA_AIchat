using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C8 RID: 200
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum BackgroundImagePositioningModeType
	{
		// Token: 0x04000411 RID: 1041
		Fitting,
		// Token: 0x04000412 RID: 1042
		Filling,
		// Token: 0x04000413 RID: 1043
		Stretched,
		// Token: 0x04000414 RID: 1044
		Repeating,
		// Token: 0x04000415 RID: 1045
		Centered
	}
}
