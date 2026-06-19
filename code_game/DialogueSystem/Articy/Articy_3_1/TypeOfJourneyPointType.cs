using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CC RID: 460
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public enum TypeOfJourneyPointType
	{
		// Token: 0x04000B2B RID: 2859
		FlowFragment,
		// Token: 0x04000B2C RID: 2860
		Dialogue,
		// Token: 0x04000B2D RID: 2861
		DialogueFragment,
		// Token: 0x04000B2E RID: 2862
		Connection,
		// Token: 0x04000B2F RID: 2863
		Pin,
		// Token: 0x04000B30 RID: 2864
		Hub,
		// Token: 0x04000B31 RID: 2865
		Jump,
		// Token: 0x04000B32 RID: 2866
		FlowConnectionSelection,
		// Token: 0x04000B33 RID: 2867
		DialogueConnectionSelection,
		// Token: 0x04000B34 RID: 2868
		InputPinSelection,
		// Token: 0x04000B35 RID: 2869
		OutputPinSelection
	}
}
