using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000118 RID: 280
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EnumPropertyType
	{
		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06000BC3 RID: 3011 RVA: 0x00015AE8 File Offset: 0x00013CE8
		// (set) Token: 0x06000BC4 RID: 3012 RVA: 0x00015AF0 File Offset: 0x00013CF0
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

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06000BC5 RID: 3013 RVA: 0x00015AFC File Offset: 0x00013CFC
		// (set) Token: 0x06000BC6 RID: 3014 RVA: 0x00015B04 File Offset: 0x00013D04
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

		// Token: 0x04000667 RID: 1639
		private string nameField;

		// Token: 0x04000668 RID: 1640
		private string valueField;
	}
}
