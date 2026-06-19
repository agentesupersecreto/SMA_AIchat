using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000191 RID: 401
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class LocalizableTextType
	{
		// Token: 0x060011F2 RID: 4594 RVA: 0x0001A9B8 File Offset: 0x00018BB8
		public LocalizableTextType()
		{
			this.hasMarkupField = false;
		}

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0001A9C8 File Offset: 0x00018BC8
		// (set) Token: 0x060011F4 RID: 4596 RVA: 0x0001A9D0 File Offset: 0x00018BD0
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

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x060011F5 RID: 4597 RVA: 0x0001A9DC File Offset: 0x00018BDC
		// (set) Token: 0x060011F6 RID: 4598 RVA: 0x0001A9E4 File Offset: 0x00018BE4
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

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x060011F7 RID: 4599 RVA: 0x0001A9F0 File Offset: 0x00018BF0
		// (set) Token: 0x060011F8 RID: 4600 RVA: 0x0001A9F8 File Offset: 0x00018BF8
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

		// Token: 0x040009E5 RID: 2533
		private LocalizedStringType[] localizedStringField;

		// Token: 0x040009E6 RID: 2534
		private int countField;

		// Token: 0x040009E7 RID: 2535
		private bool hasMarkupField;
	}
}
