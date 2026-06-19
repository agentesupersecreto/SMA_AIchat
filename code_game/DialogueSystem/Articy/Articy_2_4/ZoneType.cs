using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000183 RID: 387
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ZoneType
	{
		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x0600113C RID: 4412 RVA: 0x00019118 File Offset: 0x00017318
		// (set) Token: 0x0600113D RID: 4413 RVA: 0x00019120 File Offset: 0x00017320
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

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x0600113E RID: 4414 RVA: 0x0001912C File Offset: 0x0001732C
		// (set) Token: 0x0600113F RID: 4415 RVA: 0x00019134 File Offset: 0x00017334
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

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001140 RID: 4416 RVA: 0x00019140 File Offset: 0x00017340
		// (set) Token: 0x06001141 RID: 4417 RVA: 0x00019148 File Offset: 0x00017348
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

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06001142 RID: 4418 RVA: 0x00019154 File Offset: 0x00017354
		// (set) Token: 0x06001143 RID: 4419 RVA: 0x0001915C File Offset: 0x0001735C
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

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x06001144 RID: 4420 RVA: 0x00019168 File Offset: 0x00017368
		// (set) Token: 0x06001145 RID: 4421 RVA: 0x00019170 File Offset: 0x00017370
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

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x06001146 RID: 4422 RVA: 0x0001917C File Offset: 0x0001737C
		// (set) Token: 0x06001147 RID: 4423 RVA: 0x00019184 File Offset: 0x00017384
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

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001148 RID: 4424 RVA: 0x00019190 File Offset: 0x00017390
		// (set) Token: 0x06001149 RID: 4425 RVA: 0x00019198 File Offset: 0x00017398
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

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x0600114A RID: 4426 RVA: 0x000191A4 File Offset: 0x000173A4
		// (set) Token: 0x0600114B RID: 4427 RVA: 0x000191AC File Offset: 0x000173AC
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

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x0600114C RID: 4428 RVA: 0x000191B8 File Offset: 0x000173B8
		// (set) Token: 0x0600114D RID: 4429 RVA: 0x000191C0 File Offset: 0x000173C0
		public VisibilityType Visibility
		{
			get
			{
				return this.visibilityField;
			}
			set
			{
				this.visibilityField = value;
			}
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x0600114E RID: 4430 RVA: 0x000191CC File Offset: 0x000173CC
		// (set) Token: 0x0600114F RID: 4431 RVA: 0x000191D4 File Offset: 0x000173D4
		public SelectabilityType Selectability
		{
			get
			{
				return this.selectabilityField;
			}
			set
			{
				this.selectabilityField = value;
			}
		}

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x06001150 RID: 4432 RVA: 0x000191E0 File Offset: 0x000173E0
		// (set) Token: 0x06001151 RID: 4433 RVA: 0x000191E8 File Offset: 0x000173E8
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

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x06001152 RID: 4434 RVA: 0x000191F4 File Offset: 0x000173F4
		// (set) Token: 0x06001153 RID: 4435 RVA: 0x000191FC File Offset: 0x000173FC
		public PointType Position
		{
			get
			{
				return this.positionField;
			}
			set
			{
				this.positionField = value;
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x06001154 RID: 4436 RVA: 0x00019208 File Offset: 0x00017408
		// (set) Token: 0x06001155 RID: 4437 RVA: 0x00019210 File Offset: 0x00017410
		public float ZIndex
		{
			get
			{
				return this.zIndexField;
			}
			set
			{
				this.zIndexField = value;
			}
		}

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x06001156 RID: 4438 RVA: 0x0001921C File Offset: 0x0001741C
		// (set) Token: 0x06001157 RID: 4439 RVA: 0x00019224 File Offset: 0x00017424
		public FillType Fill
		{
			get
			{
				return this.fillField;
			}
			set
			{
				this.fillField = value;
			}
		}

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06001158 RID: 4440 RVA: 0x00019230 File Offset: 0x00017430
		// (set) Token: 0x06001159 RID: 4441 RVA: 0x00019238 File Offset: 0x00017438
		public OutlineType Outline
		{
			get
			{
				return this.outlineField;
			}
			set
			{
				this.outlineField = value;
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x0600115A RID: 4442 RVA: 0x00019244 File Offset: 0x00017444
		// (set) Token: 0x0600115B RID: 4443 RVA: 0x0001924C File Offset: 0x0001744C
		public bool ShowDisplayName
		{
			get
			{
				return this.showDisplayNameField;
			}
			set
			{
				this.showDisplayNameField = value;
			}
		}

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x0600115C RID: 4444 RVA: 0x00019258 File Offset: 0x00017458
		// (set) Token: 0x0600115D RID: 4445 RVA: 0x00019260 File Offset: 0x00017460
		public string DisplayNameColor
		{
			get
			{
				return this.displayNameColorField;
			}
			set
			{
				this.displayNameColorField = value;
			}
		}

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x0600115E RID: 4446 RVA: 0x0001926C File Offset: 0x0001746C
		// (set) Token: 0x0600115F RID: 4447 RVA: 0x00019274 File Offset: 0x00017474
		public int DisplayNameSize
		{
			get
			{
				return this.displayNameSizeField;
			}
			set
			{
				this.displayNameSizeField = value;
			}
		}

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001160 RID: 4448 RVA: 0x00019280 File Offset: 0x00017480
		// (set) Token: 0x06001161 RID: 4449 RVA: 0x00019288 File Offset: 0x00017488
		public bool DropShadow
		{
			get
			{
				return this.dropShadowField;
			}
			set
			{
				this.dropShadowField = value;
			}
		}

		// Token: 0x17000723 RID: 1827
		// (get) Token: 0x06001162 RID: 4450 RVA: 0x00019294 File Offset: 0x00017494
		// (set) Token: 0x06001163 RID: 4451 RVA: 0x0001929C File Offset: 0x0001749C
		public PointType DisplayNamePosition
		{
			get
			{
				return this.displayNamePositionField;
			}
			set
			{
				this.displayNamePositionField = value;
			}
		}

		// Token: 0x17000724 RID: 1828
		// (get) Token: 0x06001164 RID: 4452 RVA: 0x000192A8 File Offset: 0x000174A8
		// (set) Token: 0x06001165 RID: 4453 RVA: 0x000192B0 File Offset: 0x000174B0
		public TransformationType Transformation
		{
			get
			{
				return this.transformationField;
			}
			set
			{
				this.transformationField = value;
			}
		}

		// Token: 0x17000725 RID: 1829
		// (get) Token: 0x06001166 RID: 4454 RVA: 0x000192BC File Offset: 0x000174BC
		// (set) Token: 0x06001167 RID: 4455 RVA: 0x000192C4 File Offset: 0x000174C4
		[XmlElement("Coordinates", typeof(CoordinatesType))]
		[XmlElement("Circle", typeof(CircleType))]
		public object Item
		{
			get
			{
				return this.itemField;
			}
			set
			{
				this.itemField = value;
			}
		}

		// Token: 0x17000726 RID: 1830
		// (get) Token: 0x06001168 RID: 4456 RVA: 0x000192D0 File Offset: 0x000174D0
		// (set) Token: 0x06001169 RID: 4457 RVA: 0x000192D8 File Offset: 0x000174D8
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

		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x0600116A RID: 4458 RVA: 0x000192E4 File Offset: 0x000174E4
		// (set) Token: 0x0600116B RID: 4459 RVA: 0x000192EC File Offset: 0x000174EC
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

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x0600116C RID: 4460 RVA: 0x000192F8 File Offset: 0x000174F8
		// (set) Token: 0x0600116D RID: 4461 RVA: 0x00019300 File Offset: 0x00017500
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

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x0600116E RID: 4462 RVA: 0x0001930C File Offset: 0x0001750C
		// (set) Token: 0x0600116F RID: 4463 RVA: 0x00019314 File Offset: 0x00017514
		[XmlAttribute]
		public CShapeType CShape
		{
			get
			{
				return this.cShapeField;
			}
			set
			{
				this.cShapeField = value;
			}
		}

		// Token: 0x04000962 RID: 2402
		private LocalizableTextType displayNameField;

		// Token: 0x04000963 RID: 2403
		private LocalizableTextType textField;

		// Token: 0x04000964 RID: 2404
		private string colorField;

		// Token: 0x04000965 RID: 2405
		private string technicalNameField;

		// Token: 0x04000966 RID: 2406
		private string externalIdField;

		// Token: 0x04000967 RID: 2407
		private string shortIdField;

		// Token: 0x04000968 RID: 2408
		private string urlField;

		// Token: 0x04000969 RID: 2409
		private FeaturesType featuresField;

		// Token: 0x0400096A RID: 2410
		private VisibilityType visibilityField;

		// Token: 0x0400096B RID: 2411
		private SelectabilityType selectabilityField;

		// Token: 0x0400096C RID: 2412
		private PreviewImageType previewImageField;

		// Token: 0x0400096D RID: 2413
		private PointType positionField;

		// Token: 0x0400096E RID: 2414
		private float zIndexField;

		// Token: 0x0400096F RID: 2415
		private FillType fillField;

		// Token: 0x04000970 RID: 2416
		private OutlineType outlineField;

		// Token: 0x04000971 RID: 2417
		private bool showDisplayNameField;

		// Token: 0x04000972 RID: 2418
		private string displayNameColorField;

		// Token: 0x04000973 RID: 2419
		private int displayNameSizeField;

		// Token: 0x04000974 RID: 2420
		private bool dropShadowField;

		// Token: 0x04000975 RID: 2421
		private PointType displayNamePositionField;

		// Token: 0x04000976 RID: 2422
		private TransformationType transformationField;

		// Token: 0x04000977 RID: 2423
		private object itemField;

		// Token: 0x04000978 RID: 2424
		private string idField;

		// Token: 0x04000979 RID: 2425
		private string objectTemplateReferenceField;

		// Token: 0x0400097A RID: 2426
		private string objectTemplateReferenceNameField;

		// Token: 0x0400097B RID: 2427
		private CShapeType cShapeField;
	}
}
