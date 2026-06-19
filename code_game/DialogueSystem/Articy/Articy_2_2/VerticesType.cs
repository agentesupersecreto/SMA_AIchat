using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D8 RID: 216
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VerticesType
	{
		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000848 RID: 2120 RVA: 0x000126EC File Offset: 0x000108EC
		// (set) Token: 0x06000849 RID: 2121 RVA: 0x000126F4 File Offset: 0x000108F4
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x0600084A RID: 2122 RVA: 0x00012700 File Offset: 0x00010900
		// (set) Token: 0x0600084B RID: 2123 RVA: 0x00012708 File Offset: 0x00010908
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x0400048B RID: 1163
		private int countField;

		// Token: 0x0400048C RID: 1164
		private string valueField;
	}
}
