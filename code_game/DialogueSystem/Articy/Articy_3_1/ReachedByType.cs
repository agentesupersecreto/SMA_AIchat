using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CD RID: 461
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public enum ReachedByType
	{
		// Token: 0x04000B37 RID: 2871
		Invalid,
		// Token: 0x04000B38 RID: 2872
		JourneyStart,
		// Token: 0x04000B39 RID: 2873
		Skip,
		// Token: 0x04000B3A RID: 2874
		Next,
		// Token: 0x04000B3B RID: 2875
		Submerge,
		// Token: 0x04000B3C RID: 2876
		Emerge,
		// Token: 0x04000B3D RID: 2877
		Branch,
		// Token: 0x04000B3E RID: 2878
		EndPoint
	}
}
