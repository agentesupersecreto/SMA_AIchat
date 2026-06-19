using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000055 RID: 85
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocalizableTextType
	{
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000318 RID: 792 RVA: 0x0000E7E0 File Offset: 0x0000C9E0
		// (set) Token: 0x06000319 RID: 793 RVA: 0x0000E7E8 File Offset: 0x0000C9E8
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

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000E7F4 File Offset: 0x0000C9F4
		// (set) Token: 0x0600031B RID: 795 RVA: 0x0000E7FC File Offset: 0x0000C9FC
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

		// Token: 0x04000199 RID: 409
		private LocalizedStringType[] localizedStringField;

		// Token: 0x0400019A RID: 410
		private int countField;
	}
}
