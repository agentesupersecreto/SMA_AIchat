using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C5 RID: 197
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class DocumentType
	{
		// Token: 0x17000290 RID: 656
		// (get) Token: 0x0600077E RID: 1918 RVA: 0x00011F1C File Offset: 0x0001011C
		// (set) Token: 0x0600077F RID: 1919 RVA: 0x00011F24 File Offset: 0x00010124
		public LocalizableTextType DisplayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x00011F30 File Offset: 0x00010130
		// (set) Token: 0x06000781 RID: 1921 RVA: 0x00011F38 File Offset: 0x00010138
		public LocalizableTextType Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x00011F44 File Offset: 0x00010144
		// (set) Token: 0x06000783 RID: 1923 RVA: 0x00011F4C File Offset: 0x0001014C
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x06000784 RID: 1924 RVA: 0x00011F58 File Offset: 0x00010158
		// (set) Token: 0x06000785 RID: 1925 RVA: 0x00011F60 File Offset: 0x00010160
		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00011F6C File Offset: 0x0001016C
		// (set) Token: 0x06000787 RID: 1927 RVA: 0x00011F74 File Offset: 0x00010174
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x00011F80 File Offset: 0x00010180
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x00011F88 File Offset: 0x00010188
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x0600078A RID: 1930 RVA: 0x00011F94 File Offset: 0x00010194
		// (set) Token: 0x0600078B RID: 1931 RVA: 0x00011F9C File Offset: 0x0001019C
		public FeaturesType Features
		{
			get
			{
				return this.featuresField;
			}
			set
			{
				this.featuresField = value;
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x00011FA8 File Offset: 0x000101A8
		// (set) Token: 0x0600078D RID: 1933 RVA: 0x00011FB0 File Offset: 0x000101B0
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600078E RID: 1934 RVA: 0x00011FBC File Offset: 0x000101BC
		// (set) Token: 0x0600078F RID: 1935 RVA: 0x00011FC4 File Offset: 0x000101C4
		[XmlAttribute]
		public string ObjectTemplateReference
		{
			get
			{
				return this.objectTemplateReferenceField;
			}
			set
			{
				this.objectTemplateReferenceField = value;
			}
		}

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x00011FD0 File Offset: 0x000101D0
		// (set) Token: 0x06000791 RID: 1937 RVA: 0x00011FD8 File Offset: 0x000101D8
		[XmlAttribute]
		public string ObjectTemplateReferenceName
		{
			get
			{
				return this.objectTemplateReferenceNameField;
			}
			set
			{
				this.objectTemplateReferenceNameField = value;
			}
		}

		// Token: 0x040003FC RID: 1020
		private LocalizableTextType displayNameField;

		// Token: 0x040003FD RID: 1021
		private LocalizableTextType textField;

		// Token: 0x040003FE RID: 1022
		private string colorField;

		// Token: 0x040003FF RID: 1023
		private string technicalNameField;

		// Token: 0x04000400 RID: 1024
		private string externalIdField;

		// Token: 0x04000401 RID: 1025
		private string shortIdField;

		// Token: 0x04000402 RID: 1026
		private FeaturesType featuresField;

		// Token: 0x04000403 RID: 1027
		private string idField;

		// Token: 0x04000404 RID: 1028
		private string objectTemplateReferenceField;

		// Token: 0x04000405 RID: 1029
		private string objectTemplateReferenceNameField;
	}
}
