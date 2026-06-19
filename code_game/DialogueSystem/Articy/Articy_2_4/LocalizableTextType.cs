using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000112 RID: 274
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocalizableTextType
	{
		// Token: 0x06000BA0 RID: 2976 RVA: 0x00015990 File Offset: 0x00013B90
		public LocalizableTextType()
		{
			this.hasMarkupField = false;
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x000159A0 File Offset: 0x00013BA0
		// (set) Token: 0x06000BA2 RID: 2978 RVA: 0x000159A8 File Offset: 0x00013BA8
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

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x000159B4 File Offset: 0x00013BB4
		// (set) Token: 0x06000BA4 RID: 2980 RVA: 0x000159BC File Offset: 0x00013BBC
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

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x000159C8 File Offset: 0x00013BC8
		// (set) Token: 0x06000BA6 RID: 2982 RVA: 0x000159D0 File Offset: 0x00013BD0
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

		// Token: 0x04000659 RID: 1625
		private LocalizedStringType[] localizedStringField;

		// Token: 0x0400065A RID: 1626
		private int countField;

		// Token: 0x0400065B RID: 1627
		private bool hasMarkupField;
	}
}
