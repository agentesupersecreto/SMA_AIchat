using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000BA RID: 186
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocalizableTextPropertyType
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000748 RID: 1864 RVA: 0x00011D14 File Offset: 0x0000FF14
		// (set) Token: 0x06000749 RID: 1865 RVA: 0x00011D1C File Offset: 0x0000FF1C
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

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x0600074A RID: 1866 RVA: 0x00011D28 File Offset: 0x0000FF28
		// (set) Token: 0x0600074B RID: 1867 RVA: 0x00011D30 File Offset: 0x0000FF30
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

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x0600074C RID: 1868 RVA: 0x00011D3C File Offset: 0x0000FF3C
		// (set) Token: 0x0600074D RID: 1869 RVA: 0x00011D44 File Offset: 0x0000FF44
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

		// Token: 0x040003E2 RID: 994
		private LocalizedStringType[] localizedStringField;

		// Token: 0x040003E3 RID: 995
		private string nameField;

		// Token: 0x040003E4 RID: 996
		private int countField;
	}
}
