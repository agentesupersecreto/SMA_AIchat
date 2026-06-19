using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014E RID: 334
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ReachedByType
	{
		// Token: 0x040007AB RID: 1963
		Invalid,
		// Token: 0x040007AC RID: 1964
		JourneyStart,
		// Token: 0x040007AD RID: 1965
		Skip,
		// Token: 0x040007AE RID: 1966
		Next,
		// Token: 0x040007AF RID: 1967
		Submerge,
		// Token: 0x040007B0 RID: 1968
		Emerge,
		// Token: 0x040007B1 RID: 1969
		Branch,
		// Token: 0x040007B2 RID: 1970
		EndPoint
	}
}
