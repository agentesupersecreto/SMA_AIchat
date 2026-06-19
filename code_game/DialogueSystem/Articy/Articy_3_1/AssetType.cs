using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000190 RID: 400
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class AssetType
	{
		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x060011D4 RID: 4564 RVA: 0x0001A88C File Offset: 0x00018A8C
		// (set) Token: 0x060011D5 RID: 4565 RVA: 0x0001A894 File Offset: 0x00018A94
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

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x060011D6 RID: 4566 RVA: 0x0001A8A0 File Offset: 0x00018AA0
		// (set) Token: 0x060011D7 RID: 4567 RVA: 0x0001A8A8 File Offset: 0x00018AA8
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

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x060011D8 RID: 4568 RVA: 0x0001A8B4 File Offset: 0x00018AB4
		// (set) Token: 0x060011D9 RID: 4569 RVA: 0x0001A8BC File Offset: 0x00018ABC
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

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x0001A8C8 File Offset: 0x00018AC8
		// (set) Token: 0x060011DB RID: 4571 RVA: 0x0001A8D0 File Offset: 0x00018AD0
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

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x0001A8DC File Offset: 0x00018ADC
		// (set) Token: 0x060011DD RID: 4573 RVA: 0x0001A8E4 File Offset: 0x00018AE4
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

		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x060011DE RID: 4574 RVA: 0x0001A8F0 File Offset: 0x00018AF0
		// (set) Token: 0x060011DF RID: 4575 RVA: 0x0001A8F8 File Offset: 0x00018AF8
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

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x060011E0 RID: 4576 RVA: 0x0001A904 File Offset: 0x00018B04
		// (set) Token: 0x060011E1 RID: 4577 RVA: 0x0001A90C File Offset: 0x00018B0C
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

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x060011E2 RID: 4578 RVA: 0x0001A918 File Offset: 0x00018B18
		// (set) Token: 0x060011E3 RID: 4579 RVA: 0x0001A920 File Offset: 0x00018B20
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

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x060011E4 RID: 4580 RVA: 0x0001A92C File Offset: 0x00018B2C
		// (set) Token: 0x060011E5 RID: 4581 RVA: 0x0001A934 File Offset: 0x00018B34
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

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x0001A940 File Offset: 0x00018B40
		// (set) Token: 0x060011E7 RID: 4583 RVA: 0x0001A948 File Offset: 0x00018B48
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

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x060011E8 RID: 4584 RVA: 0x0001A954 File Offset: 0x00018B54
		// (set) Token: 0x060011E9 RID: 4585 RVA: 0x0001A95C File Offset: 0x00018B5C
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

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x060011EA RID: 4586 RVA: 0x0001A968 File Offset: 0x00018B68
		// (set) Token: 0x060011EB RID: 4587 RVA: 0x0001A970 File Offset: 0x00018B70
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

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x060011EC RID: 4588 RVA: 0x0001A97C File Offset: 0x00018B7C
		// (set) Token: 0x060011ED RID: 4589 RVA: 0x0001A984 File Offset: 0x00018B84
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

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x060011EE RID: 4590 RVA: 0x0001A990 File Offset: 0x00018B90
		// (set) Token: 0x060011EF RID: 4591 RVA: 0x0001A998 File Offset: 0x00018B98
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

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x060011F0 RID: 4592 RVA: 0x0001A9A4 File Offset: 0x00018BA4
		// (set) Token: 0x060011F1 RID: 4593 RVA: 0x0001A9AC File Offset: 0x00018BAC
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

		// Token: 0x040009D6 RID: 2518
		private LocalizableTextType displayNameField;

		// Token: 0x040009D7 RID: 2519
		private LocalizableTextType textField;

		// Token: 0x040009D8 RID: 2520
		private string colorField;

		// Token: 0x040009D9 RID: 2521
		private string technicalNameField;

		// Token: 0x040009DA RID: 2522
		private string externalIdField;

		// Token: 0x040009DB RID: 2523
		private string shortIdField;

		// Token: 0x040009DC RID: 2524
		private string urlField;

		// Token: 0x040009DD RID: 2525
		private FeaturesType featuresField;

		// Token: 0x040009DE RID: 2526
		private PreviewImageType previewImageField;

		// Token: 0x040009DF RID: 2527
		private string assetFilenameField;

		// Token: 0x040009E0 RID: 2528
		private string assetPathField;

		// Token: 0x040009E1 RID: 2529
		private string originalSourceField;

		// Token: 0x040009E2 RID: 2530
		private string idField;

		// Token: 0x040009E3 RID: 2531
		private string objectTemplateReferenceField;

		// Token: 0x040009E4 RID: 2532
		private string objectTemplateReferenceNameField;
	}
}
