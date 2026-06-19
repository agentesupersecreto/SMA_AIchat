using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000CD RID: 205
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum TypeOfJourneyPointType
	{
		// Token: 0x04000427 RID: 1063
		FlowFragment,
		// Token: 0x04000428 RID: 1064
		Dialogue,
		// Token: 0x04000429 RID: 1065
		DialogueFragment,
		// Token: 0x0400042A RID: 1066
		Connection,
		// Token: 0x0400042B RID: 1067
		Pin,
		// Token: 0x0400042C RID: 1068
		Hub,
		// Token: 0x0400042D RID: 1069
		Jump,
		// Token: 0x0400042E RID: 1070
		FlowConnectionSelection,
		// Token: 0x0400042F RID: 1071
		DialogueConnectionSelection,
		// Token: 0x04000430 RID: 1072
		InputPinSelection,
		// Token: 0x04000431 RID: 1073
		OutputPinSelection,
		// Token: 0x04000432 RID: 1074
		ConditionNode,
		// Token: 0x04000433 RID: 1075
		OutcomeNode
	}
}
