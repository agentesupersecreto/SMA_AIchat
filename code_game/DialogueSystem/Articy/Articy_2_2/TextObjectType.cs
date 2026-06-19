using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B4 RID: 180
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class TextObjectType
	{
		// Token: 0x17000263 RID: 611
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x00011B18 File Offset: 0x0000FD18
		// (set) Token: 0x06000715 RID: 1813 RVA: 0x00011B20 File Offset: 0x0000FD20
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

		// Token: 0x17000264 RID: 612
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x00011B2C File Offset: 0x0000FD2C
		// (set) Token: 0x06000717 RID: 1815 RVA: 0x00011B34 File Offset: 0x0000FD34
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

		// Token: 0x17000265 RID: 613
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00011B40 File Offset: 0x0000FD40
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x00011B48 File Offset: 0x0000FD48
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

		// Token: 0x17000266 RID: 614
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x00011B54 File Offset: 0x0000FD54
		// (set) Token: 0x0600071B RID: 1819 RVA: 0x00011B5C File Offset: 0x0000FD5C
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

		// Token: 0x17000267 RID: 615
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00011B68 File Offset: 0x0000FD68
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x00011B70 File Offset: 0x0000FD70
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

		// Token: 0x17000268 RID: 616
		// (get) Token: 0x0600071E RID: 1822 RVA: 0x00011B7C File Offset: 0x0000FD7C
		// (set) Token: 0x0600071F RID: 1823 RVA: 0x00011B84 File Offset: 0x0000FD84
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

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000720 RID: 1824 RVA: 0x00011B90 File Offset: 0x0000FD90
		// (set) Token: 0x06000721 RID: 1825 RVA: 0x00011B98 File Offset: 0x0000FD98
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

		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000722 RID: 1826 RVA: 0x00011BA4 File Offset: 0x0000FDA4
		// (set) Token: 0x06000723 RID: 1827 RVA: 0x00011BAC File Offset: 0x0000FDAC
		public ReferencesType References
		{
			get
			{
				return this.referencesField;
			}
			set
			{
				this.referencesField = value;
			}
		}

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000724 RID: 1828 RVA: 0x00011BB8 File Offset: 0x0000FDB8
		// (set) Token: 0x06000725 RID: 1829 RVA: 0x00011BC0 File Offset: 0x0000FDC0
		public PreviewImageType PreviewImage
		{
			get
			{
				return this.previewImageField;
			}
			set
			{
				this.previewImageField = value;
			}
		}

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000726 RID: 1830 RVA: 0x00011BCC File Offset: 0x0000FDCC
		// (set) Token: 0x06000727 RID: 1831 RVA: 0x00011BD4 File Offset: 0x0000FDD4
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

		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000728 RID: 1832 RVA: 0x00011BE0 File Offset: 0x0000FDE0
		// (set) Token: 0x06000729 RID: 1833 RVA: 0x00011BE8 File Offset: 0x0000FDE8
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

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x0600072A RID: 1834 RVA: 0x00011BF4 File Offset: 0x0000FDF4
		// (set) Token: 0x0600072B RID: 1835 RVA: 0x00011BFC File Offset: 0x0000FDFC
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

		// Token: 0x040003CB RID: 971
		private LocalizableTextType displayNameField;

		// Token: 0x040003CC RID: 972
		private LocalizableTextType textField;

		// Token: 0x040003CD RID: 973
		private string colorField;

		// Token: 0x040003CE RID: 974
		private string technicalNameField;

		// Token: 0x040003CF RID: 975
		private string externalIdField;

		// Token: 0x040003D0 RID: 976
		private string shortIdField;

		// Token: 0x040003D1 RID: 977
		private FeaturesType featuresField;

		// Token: 0x040003D2 RID: 978
		private ReferencesType referencesField;

		// Token: 0x040003D3 RID: 979
		private PreviewImageType previewImageField;

		// Token: 0x040003D4 RID: 980
		private string idField;

		// Token: 0x040003D5 RID: 981
		private string objectTemplateReferenceField;

		// Token: 0x040003D6 RID: 982
		private string objectTemplateReferenceNameField;
	}
}
