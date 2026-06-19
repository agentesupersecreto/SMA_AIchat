using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000061 RID: 97
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum TypeOfJourneyPointType
	{
		// Token: 0x040001C5 RID: 453
		FlowFragment,
		// Token: 0x040001C6 RID: 454
		Dialog,
		// Token: 0x040001C7 RID: 455
		DialogFragment,
		// Token: 0x040001C8 RID: 456
		Connection,
		// Token: 0x040001C9 RID: 457
		Pin,
		// Token: 0x040001CA RID: 458
		Hub,
		// Token: 0x040001CB RID: 459
		Jump,
		// Token: 0x040001CC RID: 460
		FlowConnectionSelection,
		// Token: 0x040001CD RID: 461
		DialogConnectionSelection,
		// Token: 0x040001CE RID: 462
		InputPinSelection,
		// Token: 0x040001CF RID: 463
		OutputPinSelection
	}
}
