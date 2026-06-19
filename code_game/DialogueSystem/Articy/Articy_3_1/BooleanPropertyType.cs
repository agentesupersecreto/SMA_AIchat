using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000196 RID: 406
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class BooleanPropertyType
	{
		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06001210 RID: 4624 RVA: 0x0001AAE0 File Offset: 0x00018CE0
		// (set) Token: 0x06001211 RID: 4625 RVA: 0x0001AAE8 File Offset: 0x00018CE8
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

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06001212 RID: 4626 RVA: 0x0001AAF4 File Offset: 0x00018CF4
		// (set) Token: 0x06001213 RID: 4627 RVA: 0x0001AAFC File Offset: 0x00018CFC
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

		// Token: 0x040009F1 RID: 2545
		private string nameField;

		// Token: 0x040009F2 RID: 2546
		private string valueField;
	}
}
