using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000056 RID: 86
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocalizedStringType
	{
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600031D RID: 797 RVA: 0x0000E810 File Offset: 0x0000CA10
		// (set) Token: 0x0600031E RID: 798 RVA: 0x0000E818 File Offset: 0x0000CA18
		[XmlAttribute(DataType = "token")]
		public string Lang
		{
			get
			{
				return this.langField;
			}
			set
			{
				this.langField = value;
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600031F RID: 799 RVA: 0x0000E824 File Offset: 0x0000CA24
		// (set) Token: 0x06000320 RID: 800 RVA: 0x0000E82C File Offset: 0x0000CA2C
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

		// Token: 0x0400019B RID: 411
		private string langField;

		// Token: 0x0400019C RID: 412
		private string valueField;
	}
}
