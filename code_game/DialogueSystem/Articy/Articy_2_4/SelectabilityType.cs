using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000152 RID: 338
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum SelectabilityType
	{
		// Token: 0x040007D2 RID: 2002
		Unselectable,
		// Token: 0x040007D3 RID: 2003
		Selectable
	}
}
