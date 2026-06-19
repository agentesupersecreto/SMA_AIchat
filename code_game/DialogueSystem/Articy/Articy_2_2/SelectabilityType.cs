using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D6 RID: 214
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum SelectabilityType
	{
		// Token: 0x04000478 RID: 1144
		Unselectable,
		// Token: 0x04000479 RID: 1145
		Selectable
	}
}
