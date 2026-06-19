using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000119 RID: 281
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LocalizableTextPropertyType
	{
		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06000BC8 RID: 3016 RVA: 0x00015B18 File Offset: 0x00013D18
		// (set) Token: 0x06000BC9 RID: 3017 RVA: 0x00015B20 File Offset: 0x00013D20
		[XmlElement("LocalizedString")]
		public LocalizedStringType[] LocalizedString
		{
			get
			{
				return this.localizedStringField;
			}
			set
			{
				this.localizedStringField = value;
			}
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06000BCA RID: 3018 RVA: 0x00015B2C File Offset: 0x00013D2C
		// (set) Token: 0x06000BCB RID: 3019 RVA: 0x00015B34 File Offset: 0x00013D34
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

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06000BCC RID: 3020 RVA: 0x00015B40 File Offset: 0x00013D40
		// (set) Token: 0x06000BCD RID: 3021 RVA: 0x00015B48 File Offset: 0x00013D48
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x04000669 RID: 1641
		private LocalizedStringType[] localizedStringField;

		// Token: 0x0400066A RID: 1642
		private string nameField;

		// Token: 0x0400066B RID: 1643
		private int countField;
	}
}
