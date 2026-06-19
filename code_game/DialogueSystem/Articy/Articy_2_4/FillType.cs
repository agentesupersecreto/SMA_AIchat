using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200015B RID: 347
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FillType
	{
		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x00017BA8 File Offset: 0x00015DA8
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x00017BB0 File Offset: 0x00015DB0
		[XmlAttribute]
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x0400083B RID: 2107
		private string colorField;
	}
}
