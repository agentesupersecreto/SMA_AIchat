using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E4 RID: 484
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class LocationTextType
	{
		// Token: 0x0600159A RID: 5530 RVA: 0x0001CDE8 File Offset: 0x0001AFE8
		public LocationTextType()
		{
			this.cShapeField = CShapeType.Rectangle;
		}

		// Token: 0x17000907 RID: 2311
		// (get) Token: 0x0600159B RID: 5531 RVA: 0x0001CDF8 File Offset: 0x0001AFF8
		// (set) Token: 0x0600159C RID: 5532 RVA: 0x0001CE00 File Offset: 0x0001B000
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

		// Token: 0x17000908 RID: 2312
		// (get) Token: 0x0600159D RID: 5533 RVA: 0x0001CE0C File Offset: 0x0001B00C
		// (set) Token: 0x0600159E RID: 5534 RVA: 0x0001CE14 File Offset: 0x0001B014
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

		// Token: 0x17000909 RID: 2313
		// (get) Token: 0x0600159F RID: 5535 RVA: 0x0001CE20 File Offset: 0x0001B020
		// (set) Token: 0x060015A0 RID: 5536 RVA: 0x0001CE28 File Offset: 0x0001B028
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

		// Token: 0x1700090A RID: 2314
		// (get) Token: 0x060015A1 RID: 5537 RVA: 0x0001CE34 File Offset: 0x0001B034
		// (set) Token: 0x060015A2 RID: 5538 RVA: 0x0001CE3C File Offset: 0x0001B03C
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

		// Token: 0x1700090B RID: 2315
		// (get) Token: 0x060015A3 RID: 5539 RVA: 0x0001CE48 File Offset: 0x0001B048
		// (set) Token: 0x060015A4 RID: 5540 RVA: 0x0001CE50 File Offset: 0x0001B050
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

		// Token: 0x1700090C RID: 2316
		// (get) Token: 0x060015A5 RID: 5541 RVA: 0x0001CE5C File Offset: 0x0001B05C
		// (set) Token: 0x060015A6 RID: 5542 RVA: 0x0001CE64 File Offset: 0x0001B064
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

		// Token: 0x1700090D RID: 2317
		// (get) Token: 0x060015A7 RID: 5543 RVA: 0x0001CE70 File Offset: 0x0001B070
		// (set) Token: 0x060015A8 RID: 5544 RVA: 0x0001CE78 File Offset: 0x0001B078
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

		// Token: 0x1700090E RID: 2318
		// (get) Token: 0x060015A9 RID: 5545 RVA: 0x0001CE84 File Offset: 0x0001B084
		// (set) Token: 0x060015AA RID: 5546 RVA: 0x0001CE8C File Offset: 0x0001B08C
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

		// Token: 0x1700090F RID: 2319
		// (get) Token: 0x060015AB RID: 5547 RVA: 0x0001CE98 File Offset: 0x0001B098
		// (set) Token: 0x060015AC RID: 5548 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
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

		// Token: 0x17000910 RID: 2320
		// (get) Token: 0x060015AD RID: 5549 RVA: 0x0001CEAC File Offset: 0x0001B0AC
		// (set) Token: 0x060015AE RID: 5550 RVA: 0x0001CEB4 File Offset: 0x0001B0B4
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

		// Token: 0x17000911 RID: 2321
		// (get) Token: 0x060015AF RID: 5551 RVA: 0x0001CEC0 File Offset: 0x0001B0C0
		// (set) Token: 0x060015B0 RID: 5552 RVA: 0x0001CEC8 File Offset: 0x0001B0C8
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

		// Token: 0x17000912 RID: 2322
		// (get) Token: 0x060015B1 RID: 5553 RVA: 0x0001CED4 File Offset: 0x0001B0D4
		// (set) Token: 0x060015B2 RID: 5554 RVA: 0x0001CEDC File Offset: 0x0001B0DC
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

		// Token: 0x17000913 RID: 2323
		// (get) Token: 0x060015B3 RID: 5555 RVA: 0x0001CEE8 File Offset: 0x0001B0E8
		// (set) Token: 0x060015B4 RID: 5556 RVA: 0x0001CEF0 File Offset: 0x0001B0F0
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

		// Token: 0x17000914 RID: 2324
		// (get) Token: 0x060015B5 RID: 5557 RVA: 0x0001CEFC File Offset: 0x0001B0FC
		// (set) Token: 0x060015B6 RID: 5558 RVA: 0x0001CF04 File Offset: 0x0001B104
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

		// Token: 0x17000915 RID: 2325
		// (get) Token: 0x060015B7 RID: 5559 RVA: 0x0001CF10 File Offset: 0x0001B110
		// (set) Token: 0x060015B8 RID: 5560 RVA: 0x0001CF18 File Offset: 0x0001B118
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

		// Token: 0x17000916 RID: 2326
		// (get) Token: 0x060015B9 RID: 5561 RVA: 0x0001CF24 File Offset: 0x0001B124
		// (set) Token: 0x060015BA RID: 5562 RVA: 0x0001CF2C File Offset: 0x0001B12C
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

		// Token: 0x17000917 RID: 2327
		// (get) Token: 0x060015BB RID: 5563 RVA: 0x0001CF38 File Offset: 0x0001B138
		// (set) Token: 0x060015BC RID: 5564 RVA: 0x0001CF40 File Offset: 0x0001B140
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

		// Token: 0x17000918 RID: 2328
		// (get) Token: 0x060015BD RID: 5565 RVA: 0x0001CF4C File Offset: 0x0001B14C
		// (set) Token: 0x060015BE RID: 5566 RVA: 0x0001CF54 File Offset: 0x0001B154
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

		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x060015BF RID: 5567 RVA: 0x0001CF60 File Offset: 0x0001B160
		// (set) Token: 0x060015C0 RID: 5568 RVA: 0x0001CF68 File Offset: 0x0001B168
		[XmlArrayItem("Vertices", IsNullable = false)]
		public VerticesType[] Coordinates
		{
			get
			{
				return this.coordinatesField;
			}
			set
			{
				this.coordinatesField = value;
			}
		}

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x060015C1 RID: 5569 RVA: 0x0001CF74 File Offset: 0x0001B174
		// (set) Token: 0x060015C2 RID: 5570 RVA: 0x0001CF7C File Offset: 0x0001B17C
		public LocationAnchorsType Anchors
		{
			get
			{
				return this.anchorsField;
			}
			set
			{
				this.anchorsField = value;
			}
		}

		// Token: 0x1700091B RID: 2331
		// (get) Token: 0x060015C3 RID: 5571 RVA: 0x0001CF88 File Offset: 0x0001B188
		// (set) Token: 0x060015C4 RID: 5572 RVA: 0x0001CF90 File Offset: 0x0001B190
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

		// Token: 0x1700091C RID: 2332
		// (get) Token: 0x060015C5 RID: 5573 RVA: 0x0001CF9C File Offset: 0x0001B19C
		// (set) Token: 0x060015C6 RID: 5574 RVA: 0x0001CFA4 File Offset: 0x0001B1A4
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

		// Token: 0x1700091D RID: 2333
		// (get) Token: 0x060015C7 RID: 5575 RVA: 0x0001CFB0 File Offset: 0x0001B1B0
		// (set) Token: 0x060015C8 RID: 5576 RVA: 0x0001CFB8 File Offset: 0x0001B1B8
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

		// Token: 0x1700091E RID: 2334
		// (get) Token: 0x060015C9 RID: 5577 RVA: 0x0001CFC4 File Offset: 0x0001B1C4
		// (set) Token: 0x060015CA RID: 5578 RVA: 0x0001CFCC File Offset: 0x0001B1CC
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

		// Token: 0x04000BF0 RID: 3056
		private LocalizableTextType displayNameField;

		// Token: 0x04000BF1 RID: 3057
		private LocalizableTextType textField;

		// Token: 0x04000BF2 RID: 3058
		private string colorField;

		// Token: 0x04000BF3 RID: 3059
		private string technicalNameField;

		// Token: 0x04000BF4 RID: 3060
		private string externalIdField;

		// Token: 0x04000BF5 RID: 3061
		private string shortIdField;

		// Token: 0x04000BF6 RID: 3062
		private string urlField;

		// Token: 0x04000BF7 RID: 3063
		private FeaturesType featuresField;

		// Token: 0x04000BF8 RID: 3064
		private VisibilityType visibilityField;

		// Token: 0x04000BF9 RID: 3065
		private SelectabilityType selectabilityField;

		// Token: 0x04000BFA RID: 3066
		private PreviewImageType previewImageField;

		// Token: 0x04000BFB RID: 3067
		private PointType positionField;

		// Token: 0x04000BFC RID: 3068
		private float zIndexField;

		// Token: 0x04000BFD RID: 3069
		private FillType fillField;

		// Token: 0x04000BFE RID: 3070
		private OutlineType outlineField;

		// Token: 0x04000BFF RID: 3071
		private bool dropShadowField;

		// Token: 0x04000C00 RID: 3072
		private PointType displayNamePositionField;

		// Token: 0x04000C01 RID: 3073
		private TransformationType transformationField;

		// Token: 0x04000C02 RID: 3074
		private VerticesType[] coordinatesField;

		// Token: 0x04000C03 RID: 3075
		private LocationAnchorsType anchorsField;

		// Token: 0x04000C04 RID: 3076
		private string idField;

		// Token: 0x04000C05 RID: 3077
		private string objectTemplateReferenceField;

		// Token: 0x04000C06 RID: 3078
		private string objectTemplateReferenceNameField;

		// Token: 0x04000C07 RID: 3079
		private CShapeType cShapeField;
	}
}
