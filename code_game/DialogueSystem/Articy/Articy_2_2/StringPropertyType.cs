using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C1 RID: 193
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class StringPropertyType
	{
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000769 RID: 1897 RVA: 0x00011E50 File Offset: 0x00010050
		// (set) Token: 0x0600076A RID: 1898 RVA: 0x00011E58 File Offset: 0x00010058
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

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x0600076B RID: 1899 RVA: 0x00011E64 File Offset: 0x00010064
		// (set) Token: 0x0600076C RID: 1900 RVA: 0x00011E6C File Offset: 0x0001006C
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

		// Token: 0x040003EF RID: 1007
		private string nameField;

		// Token: 0x040003F0 RID: 1008
		private string valueField;
	}
}
