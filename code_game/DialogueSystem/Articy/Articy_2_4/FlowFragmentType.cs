using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200013A RID: 314
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FlowFragmentType
	{
		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x00016A0C File Offset: 0x00014C0C
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x00016A14 File Offset: 0x00014C14
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

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x00016A20 File Offset: 0x00014C20
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x00016A28 File Offset: 0x00014C28
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

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000D51 RID: 3409 RVA: 0x00016A34 File Offset: 0x00014C34
		// (set) Token: 0x06000D52 RID: 3410 RVA: 0x00016A3C File Offset: 0x00014C3C
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

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000D53 RID: 3411 RVA: 0x00016A48 File Offset: 0x00014C48
		// (set) Token: 0x06000D54 RID: 3412 RVA: 0x00016A50 File Offset: 0x00014C50
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

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000D55 RID: 3413 RVA: 0x00016A5C File Offset: 0x00014C5C
		// (set) Token: 0x06000D56 RID: 3414 RVA: 0x00016A64 File Offset: 0x00014C64
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

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000D57 RID: 3415 RVA: 0x00016A70 File Offset: 0x00014C70
		// (set) Token: 0x06000D58 RID: 3416 RVA: 0x00016A78 File Offset: 0x00014C78
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

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x00016A84 File Offset: 0x00014C84
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x00016A8C File Offset: 0x00014C8C
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

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00016A98 File Offset: 0x00014C98
		// (set) Token: 0x06000D5C RID: 3420 RVA: 0x00016AA0 File Offset: 0x00014CA0
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

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000D5D RID: 3421 RVA: 0x00016AAC File Offset: 0x00014CAC
		// (set) Token: 0x06000D5E RID: 3422 RVA: 0x00016AB4 File Offset: 0x00014CB4
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

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00016AC0 File Offset: 0x00014CC0
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x00016AC8 File Offset: 0x00014CC8
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

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x00016AD4 File Offset: 0x00014CD4
		// (set) Token: 0x06000D62 RID: 3426 RVA: 0x00016ADC File Offset: 0x00014CDC
		public PinsType Pins
		{
			get
			{
				return this.pinsField;
			}
			set
			{
				this.pinsField = value;
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x00016AE8 File Offset: 0x00014CE8
		// (set) Token: 0x06000D64 RID: 3428 RVA: 0x00016AF0 File Offset: 0x00014CF0
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

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x00016AFC File Offset: 0x00014CFC
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x00016B04 File Offset: 0x00014D04
		public SizeType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x00016B10 File Offset: 0x00014D10
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x00016B18 File Offset: 0x00014D18
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

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x00016B24 File Offset: 0x00014D24
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x00016B2C File Offset: 0x00014D2C
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

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00016B38 File Offset: 0x00014D38
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x00016B40 File Offset: 0x00014D40
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

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x00016B4C File Offset: 0x00014D4C
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x00016B54 File Offset: 0x00014D54
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

		// Token: 0x04000723 RID: 1827
		private LocalizableTextType displayNameField;

		// Token: 0x04000724 RID: 1828
		private LocalizableTextType textField;

		// Token: 0x04000725 RID: 1829
		private string colorField;

		// Token: 0x04000726 RID: 1830
		private string technicalNameField;

		// Token: 0x04000727 RID: 1831
		private string externalIdField;

		// Token: 0x04000728 RID: 1832
		private string shortIdField;

		// Token: 0x04000729 RID: 1833
		private string urlField;

		// Token: 0x0400072A RID: 1834
		private FeaturesType featuresField;

		// Token: 0x0400072B RID: 1835
		private ReferencesType referencesField;

		// Token: 0x0400072C RID: 1836
		private PreviewImageType previewImageField;

		// Token: 0x0400072D RID: 1837
		private PinsType pinsField;

		// Token: 0x0400072E RID: 1838
		private PointType positionField;

		// Token: 0x0400072F RID: 1839
		private SizeType sizeField;

		// Token: 0x04000730 RID: 1840
		private float zIndexField;

		// Token: 0x04000731 RID: 1841
		private string idField;

		// Token: 0x04000732 RID: 1842
		private string objectTemplateReferenceField;

		// Token: 0x04000733 RID: 1843
		private string objectTemplateReferenceNameField;
	}
}
