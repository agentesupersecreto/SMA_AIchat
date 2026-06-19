using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000197 RID: 407
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class EnumPropertyType
	{
		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06001215 RID: 4629 RVA: 0x0001AB10 File Offset: 0x00018D10
		// (set) Token: 0x06001216 RID: 4630 RVA: 0x0001AB18 File Offset: 0x00018D18
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

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x0001AB24 File Offset: 0x00018D24
		// (set) Token: 0x06001218 RID: 4632 RVA: 0x0001AB2C File Offset: 0x00018D2C
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

		// Token: 0x040009F3 RID: 2547
		private string nameField;

		// Token: 0x040009F4 RID: 2548
		private string valueField;
	}
}
