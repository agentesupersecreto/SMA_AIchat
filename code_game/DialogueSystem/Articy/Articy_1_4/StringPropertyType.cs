using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000073 RID: 115
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class StringPropertyType
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x060003D5 RID: 981 RVA: 0x0000EF14 File Offset: 0x0000D114
		// (set) Token: 0x060003D6 RID: 982 RVA: 0x0000EF1C File Offset: 0x0000D11C
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

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x060003D7 RID: 983 RVA: 0x0000EF28 File Offset: 0x0000D128
		// (set) Token: 0x060003D8 RID: 984 RVA: 0x0000EF30 File Offset: 0x0000D130
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

		// Token: 0x04000213 RID: 531
		private string nameField;

		// Token: 0x04000214 RID: 532
		private string valueField;
	}
}
