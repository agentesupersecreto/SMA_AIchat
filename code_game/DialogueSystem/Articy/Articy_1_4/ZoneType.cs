using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200007E RID: 126
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ZoneType
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000449 RID: 1097 RVA: 0x0000F388 File Offset: 0x0000D588
		// (set) Token: 0x0600044A RID: 1098 RVA: 0x0000F390 File Offset: 0x0000D590
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

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000F39C File Offset: 0x0000D59C
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0000F3A4 File Offset: 0x0000D5A4
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

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000F3B0 File Offset: 0x0000D5B0
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
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

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000F3C4 File Offset: 0x0000D5C4
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000F3CC File Offset: 0x0000D5CC
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

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000F3D8 File Offset: 0x0000D5D8
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000F3E0 File Offset: 0x0000D5E0
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

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000453 RID: 1107 RVA: 0x0000F3EC File Offset: 0x0000D5EC
		// (set) Token: 0x06000454 RID: 1108 RVA: 0x0000F3F4 File Offset: 0x0000D5F4
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

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000455 RID: 1109 RVA: 0x0000F400 File Offset: 0x0000D600
		// (set) Token: 0x06000456 RID: 1110 RVA: 0x0000F408 File Offset: 0x0000D608
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

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000457 RID: 1111 RVA: 0x0000F414 File Offset: 0x0000D614
		// (set) Token: 0x06000458 RID: 1112 RVA: 0x0000F41C File Offset: 0x0000D61C
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

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000459 RID: 1113 RVA: 0x0000F428 File Offset: 0x0000D628
		// (set) Token: 0x0600045A RID: 1114 RVA: 0x0000F430 File Offset: 0x0000D630
		[XmlElement("Circle", typeof(CircleType))]
		[XmlElement("Rectangle", typeof(RectangleType))]
		[XmlElement("Polygon", typeof(PolygonType))]
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

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x0600045B RID: 1115 RVA: 0x0000F43C File Offset: 0x0000D63C
		// (set) Token: 0x0600045C RID: 1116 RVA: 0x0000F444 File Offset: 0x0000D644
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

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x0600045D RID: 1117 RVA: 0x0000F450 File Offset: 0x0000D650
		// (set) Token: 0x0600045E RID: 1118 RVA: 0x0000F458 File Offset: 0x0000D658
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

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000F464 File Offset: 0x0000D664
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0000F46C File Offset: 0x0000D66C
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

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000F478 File Offset: 0x0000D678
		// (set) Token: 0x06000462 RID: 1122 RVA: 0x0000F480 File Offset: 0x0000D680
		[XmlAttribute]
		public float X
		{
			get
			{
				return this.xField;
			}
			set
			{
				this.xField = value;
			}
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000463 RID: 1123 RVA: 0x0000F48C File Offset: 0x0000D68C
		// (set) Token: 0x06000464 RID: 1124 RVA: 0x0000F494 File Offset: 0x0000D694
		[XmlAttribute]
		public float Y
		{
			get
			{
				return this.yField;
			}
			set
			{
				this.yField = value;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000465 RID: 1125 RVA: 0x0000F4A0 File Offset: 0x0000D6A0
		// (set) Token: 0x06000466 RID: 1126 RVA: 0x0000F4A8 File Offset: 0x0000D6A8
		[XmlAttribute]
		public ShapeType Shape
		{
			get
			{
				return this.shapeField;
			}
			set
			{
				this.shapeField = value;
			}
		}

		// Token: 0x0400024C RID: 588
		private LocalizableTextType displayNameField;

		// Token: 0x0400024D RID: 589
		private LocalizableTextType textField;

		// Token: 0x0400024E RID: 590
		private string colorField;

		// Token: 0x0400024F RID: 591
		private string technicalNameField;

		// Token: 0x04000250 RID: 592
		private string externalIdField;

		// Token: 0x04000251 RID: 593
		private string shortIdField;

		// Token: 0x04000252 RID: 594
		private FeaturesType featuresField;

		// Token: 0x04000253 RID: 595
		private PreviewImageType previewImageField;

		// Token: 0x04000254 RID: 596
		private object itemField;

		// Token: 0x04000255 RID: 597
		private string guidField;

		// Token: 0x04000256 RID: 598
		private string objectTemplateReferenceField;

		// Token: 0x04000257 RID: 599
		private string objectTemplateReferenceNameField;

		// Token: 0x04000258 RID: 600
		private float xField;

		// Token: 0x04000259 RID: 601
		private float yField;

		// Token: 0x0400025A RID: 602
		private ShapeType shapeField;
	}
}
