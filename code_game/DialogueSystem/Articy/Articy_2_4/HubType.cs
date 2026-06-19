using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200013B RID: 315
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HubType
	{
		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000D70 RID: 3440 RVA: 0x00016B68 File Offset: 0x00014D68
		// (set) Token: 0x06000D71 RID: 3441 RVA: 0x00016B70 File Offset: 0x00014D70
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

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000D72 RID: 3442 RVA: 0x00016B7C File Offset: 0x00014D7C
		// (set) Token: 0x06000D73 RID: 3443 RVA: 0x00016B84 File Offset: 0x00014D84
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

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06000D74 RID: 3444 RVA: 0x00016B90 File Offset: 0x00014D90
		// (set) Token: 0x06000D75 RID: 3445 RVA: 0x00016B98 File Offset: 0x00014D98
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

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06000D76 RID: 3446 RVA: 0x00016BA4 File Offset: 0x00014DA4
		// (set) Token: 0x06000D77 RID: 3447 RVA: 0x00016BAC File Offset: 0x00014DAC
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

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06000D78 RID: 3448 RVA: 0x00016BB8 File Offset: 0x00014DB8
		// (set) Token: 0x06000D79 RID: 3449 RVA: 0x00016BC0 File Offset: 0x00014DC0
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

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06000D7A RID: 3450 RVA: 0x00016BCC File Offset: 0x00014DCC
		// (set) Token: 0x06000D7B RID: 3451 RVA: 0x00016BD4 File Offset: 0x00014DD4
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

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06000D7C RID: 3452 RVA: 0x00016BE0 File Offset: 0x00014DE0
		// (set) Token: 0x06000D7D RID: 3453 RVA: 0x00016BE8 File Offset: 0x00014DE8
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

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06000D7E RID: 3454 RVA: 0x00016BF4 File Offset: 0x00014DF4
		// (set) Token: 0x06000D7F RID: 3455 RVA: 0x00016BFC File Offset: 0x00014DFC
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

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x06000D80 RID: 3456 RVA: 0x00016C08 File Offset: 0x00014E08
		// (set) Token: 0x06000D81 RID: 3457 RVA: 0x00016C10 File Offset: 0x00014E10
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

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x00016C1C File Offset: 0x00014E1C
		// (set) Token: 0x06000D83 RID: 3459 RVA: 0x00016C24 File Offset: 0x00014E24
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

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06000D84 RID: 3460 RVA: 0x00016C30 File Offset: 0x00014E30
		// (set) Token: 0x06000D85 RID: 3461 RVA: 0x00016C38 File Offset: 0x00014E38
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

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06000D86 RID: 3462 RVA: 0x00016C44 File Offset: 0x00014E44
		// (set) Token: 0x06000D87 RID: 3463 RVA: 0x00016C4C File Offset: 0x00014E4C
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

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x06000D88 RID: 3464 RVA: 0x00016C58 File Offset: 0x00014E58
		// (set) Token: 0x06000D89 RID: 3465 RVA: 0x00016C60 File Offset: 0x00014E60
		[XmlText]
		public string[] Text1
		{
			get
			{
				return this.text1Field;
			}
			set
			{
				this.text1Field = value;
			}
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06000D8A RID: 3466 RVA: 0x00016C6C File Offset: 0x00014E6C
		// (set) Token: 0x06000D8B RID: 3467 RVA: 0x00016C74 File Offset: 0x00014E74
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

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00016C80 File Offset: 0x00014E80
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x00016C88 File Offset: 0x00014E88
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

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06000D8E RID: 3470 RVA: 0x00016C94 File Offset: 0x00014E94
		// (set) Token: 0x06000D8F RID: 3471 RVA: 0x00016C9C File Offset: 0x00014E9C
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

		// Token: 0x04000734 RID: 1844
		private LocalizableTextType displayNameField;

		// Token: 0x04000735 RID: 1845
		private LocalizableTextType textField;

		// Token: 0x04000736 RID: 1846
		private string colorField;

		// Token: 0x04000737 RID: 1847
		private string technicalNameField;

		// Token: 0x04000738 RID: 1848
		private string externalIdField;

		// Token: 0x04000739 RID: 1849
		private string shortIdField;

		// Token: 0x0400073A RID: 1850
		private string urlField;

		// Token: 0x0400073B RID: 1851
		private FeaturesType featuresField;

		// Token: 0x0400073C RID: 1852
		private PinsType pinsField;

		// Token: 0x0400073D RID: 1853
		private PointType positionField;

		// Token: 0x0400073E RID: 1854
		private SizeType sizeField;

		// Token: 0x0400073F RID: 1855
		private float zIndexField;

		// Token: 0x04000740 RID: 1856
		private string[] text1Field;

		// Token: 0x04000741 RID: 1857
		private string idField;

		// Token: 0x04000742 RID: 1858
		private string objectTemplateReferenceField;

		// Token: 0x04000743 RID: 1859
		private string objectTemplateReferenceNameField;
	}
}
