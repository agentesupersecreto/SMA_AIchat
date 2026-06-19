using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006E RID: 110
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumPropertyType
	{
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x060003BC RID: 956 RVA: 0x0000EE24 File Offset: 0x0000D024
		// (set) Token: 0x060003BD RID: 957 RVA: 0x0000EE2C File Offset: 0x0000D02C
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

		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x060003BE RID: 958 RVA: 0x0000EE38 File Offset: 0x0000D038
		// (set) Token: 0x060003BF RID: 959 RVA: 0x0000EE40 File Offset: 0x0000D040
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

		// Token: 0x04000209 RID: 521
		private string nameField;

		// Token: 0x0400020A RID: 522
		private string valueField;
	}
}
