using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014D RID: 333
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum TypeOfJourneyPointType
	{
		// Token: 0x0400079F RID: 1951
		FlowFragment,
		// Token: 0x040007A0 RID: 1952
		Dialogue,
		// Token: 0x040007A1 RID: 1953
		DialogueFragment,
		// Token: 0x040007A2 RID: 1954
		Connection,
		// Token: 0x040007A3 RID: 1955
		Pin,
		// Token: 0x040007A4 RID: 1956
		Hub,
		// Token: 0x040007A5 RID: 1957
		Jump,
		// Token: 0x040007A6 RID: 1958
		FlowConnectionSelection,
		// Token: 0x040007A7 RID: 1959
		DialogueConnectionSelection,
		// Token: 0x040007A8 RID: 1960
		InputPinSelection,
		// Token: 0x040007A9 RID: 1961
		OutputPinSelection
	}
}
