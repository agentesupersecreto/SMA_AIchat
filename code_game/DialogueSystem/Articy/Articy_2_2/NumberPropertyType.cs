using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000BD RID: 189
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class NumberPropertyType
	{
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000757 RID: 1879 RVA: 0x00011DA4 File Offset: 0x0000FFA4
		// (set) Token: 0x06000758 RID: 1880 RVA: 0x00011DAC File Offset: 0x0000FFAC
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

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000759 RID: 1881 RVA: 0x00011DB8 File Offset: 0x0000FFB8
		// (set) Token: 0x0600075A RID: 1882 RVA: 0x00011DC0 File Offset: 0x0000FFC0
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

		// Token: 0x040003E8 RID: 1000
		private string nameField;

		// Token: 0x040003E9 RID: 1001
		private string valueField;
	}
}
