using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000120 RID: 288
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class StringPropertyType
	{
		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000BE9 RID: 3049 RVA: 0x00015C54 File Offset: 0x00013E54
		// (set) Token: 0x06000BEA RID: 3050 RVA: 0x00015C5C File Offset: 0x00013E5C
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x00015C68 File Offset: 0x00013E68
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x00015C70 File Offset: 0x00013E70
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

		// Token: 0x04000676 RID: 1654
		private string nameField;

		// Token: 0x04000677 RID: 1655
		private string valueField;
	}
}
