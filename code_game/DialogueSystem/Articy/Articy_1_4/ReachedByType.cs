using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000062 RID: 98
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ReachedByType
	{
		// Token: 0x040001D1 RID: 465
		Invalid,
		// Token: 0x040001D2 RID: 466
		JourneyStart,
		// Token: 0x040001D3 RID: 467
		Skip,
		// Token: 0x040001D4 RID: 468
		Next,
		// Token: 0x040001D5 RID: 469
		Submerge,
		// Token: 0x040001D6 RID: 470
		Emerge,
		// Token: 0x040001D7 RID: 471
		Branch,
		// Token: 0x040001D8 RID: 472
		EndPoint
	}
}
