using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F1 RID: 241
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public enum ScriptTypeType
	{
		// Token: 0x0400055B RID: 1371
		Unknown,
		// Token: 0x0400055C RID: 1372
		Condition,
		// Token: 0x0400055D RID: 1373
		Outcome
	}
}
