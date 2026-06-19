using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001D9 RID: 473
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocationImageType
	{
		// Token: 0x06001527 RID: 5415 RVA: 0x0001C960 File Offset: 0x0001AB60
		public LocationImageType()
		{
			this.cShapeField = CShapeType.Rectangle;
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06001528 RID: 5416 RVA: 0x0001C970 File Offset: 0x0001AB70
		// (set) Token: 0x06001529 RID: 5417 RVA: 0x0001C978 File Offset: 0x0001AB78
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

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x0600152A RID: 5418 RVA: 0x0001C984 File Offset: 0x0001AB84
		// (set) Token: 0x0600152B RID: 5419 RVA: 0x0001C98C File Offset: 0x0001AB8C
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

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x0600152C RID: 5420 RVA: 0x0001C998 File Offset: 0x0001AB98
		// (set) Token: 0x0600152D RID: 5421 RVA: 0x0001C9A0 File Offset: 0x0001ABA0
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

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x0600152E RID: 5422 RVA: 0x0001C9AC File Offset: 0x0001ABAC
		// (set) Token: 0x0600152F RID: 5423 RVA: 0x0001C9B4 File Offset: 0x0001ABB4
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

		// Token: 0x170008D5 RID: 2261
		// (get) Token: 0x06001530 RID: 5424 RVA: 0x0001C9C0 File Offset: 0x0001ABC0
		// (set) Token: 0x06001531 RID: 5425 RVA: 0x0001C9C8 File Offset: 0x0001ABC8
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

		// Token: 0x170008D6 RID: 2262
		// (get) Token: 0x06001532 RID: 5426 RVA: 0x0001C9D4 File Offset: 0x0001ABD4
		// (set) Token: 0x06001533 RID: 5427 RVA: 0x0001C9DC File Offset: 0x0001ABDC
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

		// Token: 0x170008D7 RID: 2263
		// (get) Token: 0x06001534 RID: 5428 RVA: 0x0001C9E8 File Offset: 0x0001ABE8
		// (set) Token: 0x06001535 RID: 5429 RVA: 0x0001C9F0 File Offset: 0x0001ABF0
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

		// Token: 0x170008D8 RID: 2264
		// (get) Token: 0x06001536 RID: 5430 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		// (set) Token: 0x06001537 RID: 5431 RVA: 0x0001CA04 File Offset: 0x0001AC04
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

		// Token: 0x170008D9 RID: 2265
		// (get) Token: 0x06001538 RID: 5432 RVA: 0x0001CA10 File Offset: 0x0001AC10
		// (set) Token: 0x06001539 RID: 5433 RVA: 0x0001CA18 File Offset: 0x0001AC18
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

		// Token: 0x170008DA RID: 2266
		// (get) Token: 0x0600153A RID: 5434 RVA: 0x0001CA24 File Offset: 0x0001AC24
		// (set) Token: 0x0600153B RID: 5435 RVA: 0x0001CA2C File Offset: 0x0001AC2C
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

		// Token: 0x170008DB RID: 2267
		// (get) Token: 0x0600153C RID: 5436 RVA: 0x0001CA38 File Offset: 0x0001AC38
		// (set) Token: 0x0600153D RID: 5437 RVA: 0x0001CA40 File Offset: 0x0001AC40
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

		// Token: 0x170008DC RID: 2268
		// (get) Token: 0x0600153E RID: 5438 RVA: 0x0001CA4C File Offset: 0x0001AC4C
		// (set) Token: 0x0600153F RID: 5439 RVA: 0x0001CA54 File Offset: 0x0001AC54
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

		// Token: 0x170008DD RID: 2269
		// (get) Token: 0x06001540 RID: 5440 RVA: 0x0001CA60 File Offset: 0x0001AC60
		// (set) Token: 0x06001541 RID: 5441 RVA: 0x0001CA68 File Offset: 0x0001AC68
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

		// Token: 0x170008DE RID: 2270
		// (get) Token: 0x06001542 RID: 5442 RVA: 0x0001CA74 File Offset: 0x0001AC74
		// (set) Token: 0x06001543 RID: 5443 RVA: 0x0001CA7C File Offset: 0x0001AC7C
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

		// Token: 0x170008DF RID: 2271
		// (get) Token: 0x06001544 RID: 5444 RVA: 0x0001CA88 File Offset: 0x0001AC88
		// (set) Token: 0x06001545 RID: 5445 RVA: 0x0001CA90 File Offset: 0x0001AC90
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

		// Token: 0x170008E0 RID: 2272
		// (get) Token: 0x06001546 RID: 5446 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		// (set) Token: 0x06001547 RID: 5447 RVA: 0x0001CAA4 File Offset: 0x0001ACA4
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

		// Token: 0x170008E1 RID: 2273
		// (get) Token: 0x06001548 RID: 5448 RVA: 0x0001CAB0 File Offset: 0x0001ACB0
		// (set) Token: 0x06001549 RID: 5449 RVA: 0x0001CAB8 File Offset: 0x0001ACB8
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

		// Token: 0x170008E2 RID: 2274
		// (get) Token: 0x0600154A RID: 5450 RVA: 0x0001CAC4 File Offset: 0x0001ACC4
		// (set) Token: 0x0600154B RID: 5451 RVA: 0x0001CACC File Offset: 0x0001ACCC
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

		// Token: 0x170008E3 RID: 2275
		// (get) Token: 0x0600154C RID: 5452 RVA: 0x0001CAD8 File Offset: 0x0001ACD8
		// (set) Token: 0x0600154D RID: 5453 RVA: 0x0001CAE0 File Offset: 0x0001ACE0
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

		// Token: 0x170008E4 RID: 2276
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x0001CAEC File Offset: 0x0001ACEC
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x0001CAF4 File Offset: 0x0001ACF4
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

		// Token: 0x170008E5 RID: 2277
		// (get) Token: 0x06001550 RID: 5456 RVA: 0x0001CB00 File Offset: 0x0001AD00
		// (set) Token: 0x06001551 RID: 5457 RVA: 0x0001CB08 File Offset: 0x0001AD08
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

		// Token: 0x170008E6 RID: 2278
		// (get) Token: 0x06001552 RID: 5458 RVA: 0x0001CB14 File Offset: 0x0001AD14
		// (set) Token: 0x06001553 RID: 5459 RVA: 0x0001CB1C File Offset: 0x0001AD1C
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

		// Token: 0x170008E7 RID: 2279
		// (get) Token: 0x06001554 RID: 5460 RVA: 0x0001CB28 File Offset: 0x0001AD28
		// (set) Token: 0x06001555 RID: 5461 RVA: 0x0001CB30 File Offset: 0x0001AD30
		public float Opacity
		{
			get
			{
				return this.opacityField;
			}
			set
			{
				this.opacityField = value;
			}
		}

		// Token: 0x170008E8 RID: 2280
		// (get) Token: 0x06001556 RID: 5462 RVA: 0x0001CB3C File Offset: 0x0001AD3C
		// (set) Token: 0x06001557 RID: 5463 RVA: 0x0001CB44 File Offset: 0x0001AD44
		public ReferenceType Image
		{
			get
			{
				return this.imageField;
			}
			set
			{
				this.imageField = value;
			}
		}

		// Token: 0x170008E9 RID: 2281
		// (get) Token: 0x06001558 RID: 5464 RVA: 0x0001CB50 File Offset: 0x0001AD50
		// (set) Token: 0x06001559 RID: 5465 RVA: 0x0001CB58 File Offset: 0x0001AD58
		public RectangleType ClipRect
		{
			get
			{
				return this.clipRectField;
			}
			set
			{
				this.clipRectField = value;
			}
		}

		// Token: 0x170008EA RID: 2282
		// (get) Token: 0x0600155A RID: 5466 RVA: 0x0001CB64 File Offset: 0x0001AD64
		// (set) Token: 0x0600155B RID: 5467 RVA: 0x0001CB6C File Offset: 0x0001AD6C
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

		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x0600155C RID: 5468 RVA: 0x0001CB78 File Offset: 0x0001AD78
		// (set) Token: 0x0600155D RID: 5469 RVA: 0x0001CB80 File Offset: 0x0001AD80
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

		// Token: 0x170008EC RID: 2284
		// (get) Token: 0x0600155E RID: 5470 RVA: 0x0001CB8C File Offset: 0x0001AD8C
		// (set) Token: 0x0600155F RID: 5471 RVA: 0x0001CB94 File Offset: 0x0001AD94
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

		// Token: 0x170008ED RID: 2285
		// (get) Token: 0x06001560 RID: 5472 RVA: 0x0001CBA0 File Offset: 0x0001ADA0
		// (set) Token: 0x06001561 RID: 5473 RVA: 0x0001CBA8 File Offset: 0x0001ADA8
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

		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x06001562 RID: 5474 RVA: 0x0001CBB4 File Offset: 0x0001ADB4
		// (set) Token: 0x06001563 RID: 5475 RVA: 0x0001CBBC File Offset: 0x0001ADBC
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

		// Token: 0x04000BA9 RID: 2985
		private LocalizableTextType displayNameField;

		// Token: 0x04000BAA RID: 2986
		private LocalizableTextType textField;

		// Token: 0x04000BAB RID: 2987
		private string colorField;

		// Token: 0x04000BAC RID: 2988
		private string technicalNameField;

		// Token: 0x04000BAD RID: 2989
		private string externalIdField;

		// Token: 0x04000BAE RID: 2990
		private string shortIdField;

		// Token: 0x04000BAF RID: 2991
		private string urlField;

		// Token: 0x04000BB0 RID: 2992
		private FeaturesType featuresField;

		// Token: 0x04000BB1 RID: 2993
		private VisibilityType visibilityField;

		// Token: 0x04000BB2 RID: 2994
		private SelectabilityType selectabilityField;

		// Token: 0x04000BB3 RID: 2995
		private PreviewImageType previewImageField;

		// Token: 0x04000BB4 RID: 2996
		private PointType positionField;

		// Token: 0x04000BB5 RID: 2997
		private float zIndexField;

		// Token: 0x04000BB6 RID: 2998
		private FillType fillField;

		// Token: 0x04000BB7 RID: 2999
		private OutlineType outlineField;

		// Token: 0x04000BB8 RID: 3000
		private bool showDisplayNameField;

		// Token: 0x04000BB9 RID: 3001
		private string displayNameColorField;

		// Token: 0x04000BBA RID: 3002
		private int displayNameSizeField;

		// Token: 0x04000BBB RID: 3003
		private bool dropShadowField;

		// Token: 0x04000BBC RID: 3004
		private PointType displayNamePositionField;

		// Token: 0x04000BBD RID: 3005
		private TransformationType transformationField;

		// Token: 0x04000BBE RID: 3006
		private VerticesType[] coordinatesField;

		// Token: 0x04000BBF RID: 3007
		private float opacityField;

		// Token: 0x04000BC0 RID: 3008
		private ReferenceType imageField;

		// Token: 0x04000BC1 RID: 3009
		private RectangleType clipRectField;

		// Token: 0x04000BC2 RID: 3010
		private LocationAnchorsType anchorsField;

		// Token: 0x04000BC3 RID: 3011
		private string idField;

		// Token: 0x04000BC4 RID: 3012
		private string objectTemplateReferenceField;

		// Token: 0x04000BC5 RID: 3013
		private string objectTemplateReferenceNameField;

		// Token: 0x04000BC6 RID: 3014
		private CShapeType cShapeField;
	}
}
