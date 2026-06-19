using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C0 RID: 192
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ReferenceType
	{
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000764 RID: 1892 RVA: 0x00011E20 File Offset: 0x00010020
		// (set) Token: 0x06000765 RID: 1893 RVA: 0x00011E28 File Offset: 0x00010028
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000766 RID: 1894 RVA: 0x00011E34 File Offset: 0x00010034
		// (set) Token: 0x06000767 RID: 1895 RVA: 0x00011E3C File Offset: 0x0001003C
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

		// Token: 0x040003ED RID: 1005
		private string idRefField;

		// Token: 0x040003EE RID: 1006
		private string valueField;
	}
}
