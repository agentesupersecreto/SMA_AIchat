using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000202 RID: 514
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class ZoneType
	{
		// Token: 0x170009F3 RID: 2547
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x0001E140 File Offset: 0x0001C340
		// (set) Token: 0x0600178F RID: 6031 RVA: 0x0001E148 File Offset: 0x0001C348
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

		// Token: 0x170009F4 RID: 2548
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x0001E154 File Offset: 0x0001C354
		// (set) Token: 0x06001791 RID: 6033 RVA: 0x0001E15C File Offset: 0x0001C35C
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

		// Token: 0x170009F5 RID: 2549
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x0001E168 File Offset: 0x0001C368
		// (set) Token: 0x06001793 RID: 6035 RVA: 0x0001E170 File Offset: 0x0001C370
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

		// Token: 0x170009F6 RID: 2550
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x0001E17C File Offset: 0x0001C37C
		// (set) Token: 0x06001795 RID: 6037 RVA: 0x0001E184 File Offset: 0x0001C384
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

		// Token: 0x170009F7 RID: 2551
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0001E190 File Offset: 0x0001C390
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x0001E198 File Offset: 0x0001C398
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

		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x0001E1A4 File Offset: 0x0001C3A4
		// (set) Token: 0x06001799 RID: 6041 RVA: 0x0001E1AC File Offset: 0x0001C3AC
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

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x0600179A RID: 6042 RVA: 0x0001E1B8 File Offset: 0x0001C3B8
		// (set) Token: 0x0600179B RID: 6043 RVA: 0x0001E1C0 File Offset: 0x0001C3C0
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

		// Token: 0x170009FA RID: 2554
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0001E1CC File Offset: 0x0001C3CC
		// (set) Token: 0x0600179D RID: 6045 RVA: 0x0001E1D4 File Offset: 0x0001C3D4
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

		// Token: 0x170009FB RID: 2555
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0001E1E0 File Offset: 0x0001C3E0
		// (set) Token: 0x0600179F RID: 6047 RVA: 0x0001E1E8 File Offset: 0x0001C3E8
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

		// Token: 0x170009FC RID: 2556
		// (get) Token: 0x060017A0 RID: 6048 RVA: 0x0001E1F4 File Offset: 0x0001C3F4
		// (set) Token: 0x060017A1 RID: 6049 RVA: 0x0001E1FC File Offset: 0x0001C3FC
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

		// Token: 0x170009FD RID: 2557
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x0001E208 File Offset: 0x0001C408
		// (set) Token: 0x060017A3 RID: 6051 RVA: 0x0001E210 File Offset: 0x0001C410
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

		// Token: 0x170009FE RID: 2558
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0001E21C File Offset: 0x0001C41C
		// (set) Token: 0x060017A5 RID: 6053 RVA: 0x0001E224 File Offset: 0x0001C424
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

		// Token: 0x170009FF RID: 2559
		// (get) Token: 0x060017A6 RID: 6054 RVA: 0x0001E230 File Offset: 0x0001C430
		// (set) Token: 0x060017A7 RID: 6055 RVA: 0x0001E238 File Offset: 0x0001C438
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

		// Token: 0x17000A00 RID: 2560
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x0001E244 File Offset: 0x0001C444
		// (set) Token: 0x060017A9 RID: 6057 RVA: 0x0001E24C File Offset: 0x0001C44C
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

		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x0001E258 File Offset: 0x0001C458
		// (set) Token: 0x060017AB RID: 6059 RVA: 0x0001E260 File Offset: 0x0001C460
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

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x0001E26C File Offset: 0x0001C46C
		// (set) Token: 0x060017AD RID: 6061 RVA: 0x0001E274 File Offset: 0x0001C474
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

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x0001E280 File Offset: 0x0001C480
		// (set) Token: 0x060017AF RID: 6063 RVA: 0x0001E288 File Offset: 0x0001C488
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

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0001E294 File Offset: 0x0001C494
		// (set) Token: 0x060017B1 RID: 6065 RVA: 0x0001E29C File Offset: 0x0001C49C
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

		// Token: 0x17000A05 RID: 2565
		// (get) Token: 0x060017B2 RID: 6066 RVA: 0x0001E2A8 File Offset: 0x0001C4A8
		// (set) Token: 0x060017B3 RID: 6067 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
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

		// Token: 0x17000A06 RID: 2566
		// (get) Token: 0x060017B4 RID: 6068 RVA: 0x0001E2BC File Offset: 0x0001C4BC
		// (set) Token: 0x060017B5 RID: 6069 RVA: 0x0001E2C4 File Offset: 0x0001C4C4
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

		// Token: 0x17000A07 RID: 2567
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x0001E2D0 File Offset: 0x0001C4D0
		// (set) Token: 0x060017B7 RID: 6071 RVA: 0x0001E2D8 File Offset: 0x0001C4D8
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

		// Token: 0x17000A08 RID: 2568
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0001E2E4 File Offset: 0x0001C4E4
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x0001E2EC File Offset: 0x0001C4EC
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

		// Token: 0x17000A09 RID: 2569
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x0001E2F8 File Offset: 0x0001C4F8
		// (set) Token: 0x060017BB RID: 6075 RVA: 0x0001E300 File Offset: 0x0001C500
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

		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x0001E30C File Offset: 0x0001C50C
		// (set) Token: 0x060017BD RID: 6077 RVA: 0x0001E314 File Offset: 0x0001C514
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

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0001E320 File Offset: 0x0001C520
		// (set) Token: 0x060017BF RID: 6079 RVA: 0x0001E328 File Offset: 0x0001C528
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

		// Token: 0x17000A0C RID: 2572
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x0001E334 File Offset: 0x0001C534
		// (set) Token: 0x060017C1 RID: 6081 RVA: 0x0001E33C File Offset: 0x0001C53C
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

		// Token: 0x04000CEE RID: 3310
		private LocalizableTextType displayNameField;

		// Token: 0x04000CEF RID: 3311
		private LocalizableTextType textField;

		// Token: 0x04000CF0 RID: 3312
		private string colorField;

		// Token: 0x04000CF1 RID: 3313
		private string technicalNameField;

		// Token: 0x04000CF2 RID: 3314
		private string externalIdField;

		// Token: 0x04000CF3 RID: 3315
		private string shortIdField;

		// Token: 0x04000CF4 RID: 3316
		private string urlField;

		// Token: 0x04000CF5 RID: 3317
		private FeaturesType featuresField;

		// Token: 0x04000CF6 RID: 3318
		private VisibilityType visibilityField;

		// Token: 0x04000CF7 RID: 3319
		private SelectabilityType selectabilityField;

		// Token: 0x04000CF8 RID: 3320
		private PreviewImageType previewImageField;

		// Token: 0x04000CF9 RID: 3321
		private PointType positionField;

		// Token: 0x04000CFA RID: 3322
		private float zIndexField;

		// Token: 0x04000CFB RID: 3323
		private FillType fillField;

		// Token: 0x04000CFC RID: 3324
		private OutlineType outlineField;

		// Token: 0x04000CFD RID: 3325
		private bool showDisplayNameField;

		// Token: 0x04000CFE RID: 3326
		private string displayNameColorField;

		// Token: 0x04000CFF RID: 3327
		private int displayNameSizeField;

		// Token: 0x04000D00 RID: 3328
		private bool dropShadowField;

		// Token: 0x04000D01 RID: 3329
		private PointType displayNamePositionField;

		// Token: 0x04000D02 RID: 3330
		private TransformationType transformationField;

		// Token: 0x04000D03 RID: 3331
		private object itemField;

		// Token: 0x04000D04 RID: 3332
		private string idField;

		// Token: 0x04000D05 RID: 3333
		private string objectTemplateReferenceField;

		// Token: 0x04000D06 RID: 3334
		private string objectTemplateReferenceNameField;

		// Token: 0x04000D07 RID: 3335
		private CShapeType cShapeField;
	}
}
