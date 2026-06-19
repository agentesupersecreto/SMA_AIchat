using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000192 RID: 402
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[Serializable]
	public class LocalizedStringType
	{
		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x060011FA RID: 4602 RVA: 0x0001AA0C File Offset: 0x00018C0C
		// (set) Token: 0x060011FB RID: 4603 RVA: 0x0001AA14 File Offset: 0x00018C14
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

		// Token: 0x17000757 RID: 1879
		// (get) Token: 0x060011FC RID: 4604 RVA: 0x0001AA20 File Offset: 0x00018C20
		// (set) Token: 0x060011FD RID: 4605 RVA: 0x0001AA28 File Offset: 0x00018C28
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

		// Token: 0x040009E8 RID: 2536
		private string langField;

		// Token: 0x040009E9 RID: 2537
		private string valueField;
	}
}
