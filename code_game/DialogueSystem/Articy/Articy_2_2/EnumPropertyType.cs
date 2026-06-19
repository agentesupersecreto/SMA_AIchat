using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B9 RID: 185
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class EnumPropertyType
	{
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00011CE4 File Offset: 0x0000FEE4
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x00011CEC File Offset: 0x0000FEEC
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

		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00011CF8 File Offset: 0x0000FEF8
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00011D00 File Offset: 0x0000FF00
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

		// Token: 0x040003E0 RID: 992
		private string nameField;

		// Token: 0x040003E1 RID: 993
		private string valueField;
	}
}
