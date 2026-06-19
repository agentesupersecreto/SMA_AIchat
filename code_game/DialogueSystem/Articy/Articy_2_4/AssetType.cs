using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000111 RID: 273
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class AssetType
	{
		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x00015864 File Offset: 0x00013A64
		// (set) Token: 0x06000B83 RID: 2947 RVA: 0x0001586C File Offset: 0x00013A6C
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

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00015878 File Offset: 0x00013A78
		// (set) Token: 0x06000B85 RID: 2949 RVA: 0x00015880 File Offset: 0x00013A80
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

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000B86 RID: 2950 RVA: 0x0001588C File Offset: 0x00013A8C
		// (set) Token: 0x06000B87 RID: 2951 RVA: 0x00015894 File Offset: 0x00013A94
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

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000B88 RID: 2952 RVA: 0x000158A0 File Offset: 0x00013AA0
		// (set) Token: 0x06000B89 RID: 2953 RVA: 0x000158A8 File Offset: 0x00013AA8
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

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x000158B4 File Offset: 0x00013AB4
		// (set) Token: 0x06000B8B RID: 2955 RVA: 0x000158BC File Offset: 0x00013ABC
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

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x000158C8 File Offset: 0x00013AC8
		// (set) Token: 0x06000B8D RID: 2957 RVA: 0x000158D0 File Offset: 0x00013AD0
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

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000B8E RID: 2958 RVA: 0x000158DC File Offset: 0x00013ADC
		// (set) Token: 0x06000B8F RID: 2959 RVA: 0x000158E4 File Offset: 0x00013AE4
		public string Url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000B90 RID: 2960 RVA: 0x000158F0 File Offset: 0x00013AF0
		// (set) Token: 0x06000B91 RID: 2961 RVA: 0x000158F8 File Offset: 0x00013AF8
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

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000B92 RID: 2962 RVA: 0x00015904 File Offset: 0x00013B04
		// (set) Token: 0x06000B93 RID: 2963 RVA: 0x0001590C File Offset: 0x00013B0C
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

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000B94 RID: 2964 RVA: 0x00015918 File Offset: 0x00013B18
		// (set) Token: 0x06000B95 RID: 2965 RVA: 0x00015920 File Offset: 0x00013B20
		public string AssetFilename
		{
			get
			{
				return this.assetFilenameField;
			}
			set
			{
				this.assetFilenameField = value;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000B96 RID: 2966 RVA: 0x0001592C File Offset: 0x00013B2C
		// (set) Token: 0x06000B97 RID: 2967 RVA: 0x00015934 File Offset: 0x00013B34
		public string AssetPath
		{
			get
			{
				return this.assetPathField;
			}
			set
			{
				this.assetPathField = value;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x00015940 File Offset: 0x00013B40
		// (set) Token: 0x06000B99 RID: 2969 RVA: 0x00015948 File Offset: 0x00013B48
		public string OriginalSource
		{
			get
			{
				return this.originalSourceField;
			}
			set
			{
				this.originalSourceField = value;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x00015954 File Offset: 0x00013B54
		// (set) Token: 0x06000B9B RID: 2971 RVA: 0x0001595C File Offset: 0x00013B5C
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

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x00015968 File Offset: 0x00013B68
		// (set) Token: 0x06000B9D RID: 2973 RVA: 0x00015970 File Offset: 0x00013B70
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

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x0001597C File Offset: 0x00013B7C
		// (set) Token: 0x06000B9F RID: 2975 RVA: 0x00015984 File Offset: 0x00013B84
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

		// Token: 0x0400064A RID: 1610
		private LocalizableTextType displayNameField;

		// Token: 0x0400064B RID: 1611
		private LocalizableTextType textField;

		// Token: 0x0400064C RID: 1612
		private string colorField;

		// Token: 0x0400064D RID: 1613
		private string technicalNameField;

		// Token: 0x0400064E RID: 1614
		private string externalIdField;

		// Token: 0x0400064F RID: 1615
		private string shortIdField;

		// Token: 0x04000650 RID: 1616
		private string urlField;

		// Token: 0x04000651 RID: 1617
		private FeaturesType featuresField;

		// Token: 0x04000652 RID: 1618
		private PreviewImageType previewImageField;

		// Token: 0x04000653 RID: 1619
		private string assetFilenameField;

		// Token: 0x04000654 RID: 1620
		private string assetPathField;

		// Token: 0x04000655 RID: 1621
		private string originalSourceField;

		// Token: 0x04000656 RID: 1622
		private string idField;

		// Token: 0x04000657 RID: 1623
		private string objectTemplateReferenceField;

		// Token: 0x04000658 RID: 1624
		private string objectTemplateReferenceNameField;
	}
}
