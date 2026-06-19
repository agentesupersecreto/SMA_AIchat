using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000CE RID: 206
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ReachedByType
	{
		// Token: 0x04000435 RID: 1077
		Invalid,
		// Token: 0x04000436 RID: 1078
		JourneyStart,
		// Token: 0x04000437 RID: 1079
		Skip,
		// Token: 0x04000438 RID: 1080
		Next,
		// Token: 0x04000439 RID: 1081
		Submerge,
		// Token: 0x0400043A RID: 1082
		Emerge,
		// Token: 0x0400043B RID: 1083
		Branch,
		// Token: 0x0400043C RID: 1084
		EndPoint
	}
}
