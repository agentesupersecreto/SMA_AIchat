using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000140 RID: 320
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum BackgroundImagePositioningModeType
	{
		// Token: 0x0400076C RID: 1900
		Fitting,
		// Token: 0x0400076D RID: 1901
		Filling,
		// Token: 0x0400076E RID: 1902
		Stretched,
		// Token: 0x0400076F RID: 1903
		Repeating,
		// Token: 0x04000770 RID: 1904
		Centered
	}
}
