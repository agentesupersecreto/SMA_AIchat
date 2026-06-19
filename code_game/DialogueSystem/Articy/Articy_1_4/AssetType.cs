using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000054 RID: 84
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class AssetType
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002FB RID: 763 RVA: 0x0000E6C0 File Offset: 0x0000C8C0
		// (set) Token: 0x060002FC RID: 764 RVA: 0x0000E6C8 File Offset: 0x0000C8C8
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

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002FD RID: 765 RVA: 0x0000E6D4 File Offset: 0x0000C8D4
		// (set) Token: 0x060002FE RID: 766 RVA: 0x0000E6DC File Offset: 0x0000C8DC
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

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000E6E8 File Offset: 0x0000C8E8
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0000E6F0 File Offset: 0x0000C8F0
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

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000E6FC File Offset: 0x0000C8FC
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0000E704 File Offset: 0x0000C904
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000303 RID: 771 RVA: 0x0000E710 File Offset: 0x0000C910
		// (set) Token: 0x06000304 RID: 772 RVA: 0x0000E718 File Offset: 0x0000C918
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

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000305 RID: 773 RVA: 0x0000E724 File Offset: 0x0000C924
		// (set) Token: 0x06000306 RID: 774 RVA: 0x0000E72C File Offset: 0x0000C92C
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

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000307 RID: 775 RVA: 0x0000E738 File Offset: 0x0000C938
		// (set) Token: 0x06000308 RID: 776 RVA: 0x0000E740 File Offset: 0x0000C940
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

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000309 RID: 777 RVA: 0x0000E74C File Offset: 0x0000C94C
		// (set) Token: 0x0600030A RID: 778 RVA: 0x0000E754 File Offset: 0x0000C954
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

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600030B RID: 779 RVA: 0x0000E760 File Offset: 0x0000C960
		// (set) Token: 0x0600030C RID: 780 RVA: 0x0000E768 File Offset: 0x0000C968
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

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600030D RID: 781 RVA: 0x0000E774 File Offset: 0x0000C974
		// (set) Token: 0x0600030E RID: 782 RVA: 0x0000E77C File Offset: 0x0000C97C
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

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x0600030F RID: 783 RVA: 0x0000E788 File Offset: 0x0000C988
		// (set) Token: 0x06000310 RID: 784 RVA: 0x0000E790 File Offset: 0x0000C990
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

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000311 RID: 785 RVA: 0x0000E79C File Offset: 0x0000C99C
		// (set) Token: 0x06000312 RID: 786 RVA: 0x0000E7A4 File Offset: 0x0000C9A4
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000313 RID: 787 RVA: 0x0000E7B0 File Offset: 0x0000C9B0
		// (set) Token: 0x06000314 RID: 788 RVA: 0x0000E7B8 File Offset: 0x0000C9B8
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

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000315 RID: 789 RVA: 0x0000E7C4 File Offset: 0x0000C9C4
		// (set) Token: 0x06000316 RID: 790 RVA: 0x0000E7CC File Offset: 0x0000C9CC
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

		// Token: 0x0400018B RID: 395
		private LocalizableTextType displayNameField;

		// Token: 0x0400018C RID: 396
		private LocalizableTextType textField;

		// Token: 0x0400018D RID: 397
		private string colorField;

		// Token: 0x0400018E RID: 398
		private string technicalNameField;

		// Token: 0x0400018F RID: 399
		private string externalIdField;

		// Token: 0x04000190 RID: 400
		private string shortIdField;

		// Token: 0x04000191 RID: 401
		private FeaturesType featuresField;

		// Token: 0x04000192 RID: 402
		private PreviewImageType previewImageField;

		// Token: 0x04000193 RID: 403
		private string assetFilenameField;

		// Token: 0x04000194 RID: 404
		private string assetPathField;

		// Token: 0x04000195 RID: 405
		private string originalSourceField;

		// Token: 0x04000196 RID: 406
		private string guidField;

		// Token: 0x04000197 RID: 407
		private string objectTemplateReferenceField;

		// Token: 0x04000198 RID: 408
		private string objectTemplateReferenceNameField;
	}
}
