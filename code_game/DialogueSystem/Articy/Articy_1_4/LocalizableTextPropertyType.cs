using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006F RID: 111
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocalizableTextPropertyType
	{
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0000EE54 File Offset: 0x0000D054
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0000EE5C File Offset: 0x0000D05C
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

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000EE68 File Offset: 0x0000D068
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0000EE70 File Offset: 0x0000D070
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

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x060003C5 RID: 965 RVA: 0x0000EE7C File Offset: 0x0000D07C
		// (set) Token: 0x060003C6 RID: 966 RVA: 0x0000EE84 File Offset: 0x0000D084
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

		// Token: 0x0400020B RID: 523
		private LocalizedStringType[] localizedStringField;

		// Token: 0x0400020C RID: 524
		private string nameField;

		// Token: 0x0400020D RID: 525
		private int countField;
	}
}
