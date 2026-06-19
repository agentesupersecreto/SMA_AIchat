using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000072 RID: 114
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NumberPropertyType
	{
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000EEEC File Offset: 0x0000D0EC
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

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x0000EEF8 File Offset: 0x0000D0F8
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x0000EF00 File Offset: 0x0000D100
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

		// Token: 0x04000211 RID: 529
		private string nameField;

		// Token: 0x04000212 RID: 530
		private string valueField;
	}
}
