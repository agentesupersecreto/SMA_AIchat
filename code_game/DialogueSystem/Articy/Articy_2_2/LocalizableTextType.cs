using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000A9 RID: 169
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocalizableTextType
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x000118EC File Offset: 0x0000FAEC
		public LocalizableTextType()
		{
			this.hasMarkupField = false;
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x000118FC File Offset: 0x0000FAFC
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x00011904 File Offset: 0x0000FB04
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

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x00011910 File Offset: 0x0000FB10
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x00011918 File Offset: 0x0000FB18
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

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x00011924 File Offset: 0x0000FB24
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0001192C File Offset: 0x0000FB2C
		[DefaultValue(false)]
		[XmlAttribute]
		public bool HasMarkup
		{
			get
			{
				return this.hasMarkupField;
			}
			set
			{
				this.hasMarkupField = value;
			}
		}

		// Token: 0x040003AE RID: 942
		private LocalizedStringType[] localizedStringField;

		// Token: 0x040003AF RID: 943
		private int countField;

		// Token: 0x040003B0 RID: 944
		private bool hasMarkupField;
	}
}
