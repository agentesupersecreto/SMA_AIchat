using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200005C RID: 92
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum BackgroundImagePositioningModeType
	{
		// Token: 0x040001AF RID: 431
		Fitting,
		// Token: 0x040001B0 RID: 432
		Filling,
		// Token: 0x040001B1 RID: 433
		Stretched,
		// Token: 0x040001B2 RID: 434
		Repeating,
		// Token: 0x040001B3 RID: 435
		Centered
	}
}
