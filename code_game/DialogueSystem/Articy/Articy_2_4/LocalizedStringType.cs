using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000113 RID: 275
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocalizedStringType
	{
		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x000159E4 File Offset: 0x00013BE4
		// (set) Token: 0x06000BA9 RID: 2985 RVA: 0x000159EC File Offset: 0x00013BEC
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

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06000BAA RID: 2986 RVA: 0x000159F8 File Offset: 0x00013BF8
		// (set) Token: 0x06000BAB RID: 2987 RVA: 0x00015A00 File Offset: 0x00013C00
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

		// Token: 0x0400065C RID: 1628
		private string langField;

		// Token: 0x0400065D RID: 1629
		private string valueField;
	}
}
