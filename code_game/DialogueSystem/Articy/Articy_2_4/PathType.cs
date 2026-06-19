using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200016A RID: 362
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PathType
	{
		// Token: 0x1700065F RID: 1631
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00018294 File Offset: 0x00016494
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x0001829C File Offset: 0x0001649C
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

		// Token: 0x17000660 RID: 1632
		// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x000182A8 File Offset: 0x000164A8
		// (set) Token: 0x06000FC7 RID: 4039 RVA: 0x000182B0 File Offset: 0x000164B0
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

		// Token: 0x17000661 RID: 1633
		// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x000182BC File Offset: 0x000164BC
		// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x000182C4 File Offset: 0x000164C4
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

		// Token: 0x17000662 RID: 1634
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x000182D0 File Offset: 0x000164D0
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x000182D8 File Offset: 0x000164D8
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

		// Token: 0x17000663 RID: 1635
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x000182E4 File Offset: 0x000164E4
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x000182EC File Offset: 0x000164EC
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

		// Token: 0x17000664 RID: 1636
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x000182F8 File Offset: 0x000164F8
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x00018300 File Offset: 0x00016500
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

		// Token: 0x17000665 RID: 1637
		// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x0001830C File Offset: 0x0001650C
		// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x00018314 File Offset: 0x00016514
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

		// Token: 0x17000666 RID: 1638
		// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x00018320 File Offset: 0x00016520
		// (set) Token: 0x06000FD3 RID: 4051 RVA: 0x00018328 File Offset: 0x00016528
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

		// Token: 0x17000667 RID: 1639
		// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x00018334 File Offset: 0x00016534
		// (set) Token: 0x06000FD5 RID: 4053 RVA: 0x0001833C File Offset: 0x0001653C
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

		// Token: 0x17000668 RID: 1640
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x00018348 File Offset: 0x00016548
		// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x00018350 File Offset: 0x00016550
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

		// Token: 0x17000669 RID: 1641
		// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x0001835C File Offset: 0x0001655C
		// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x00018364 File Offset: 0x00016564
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

		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x00018370 File Offset: 0x00016570
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x00018378 File Offset: 0x00016578
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

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x00018384 File Offset: 0x00016584
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x0001838C File Offset: 0x0001658C
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

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00018398 File Offset: 0x00016598
		// (set) Token: 0x06000FDF RID: 4063 RVA: 0x000183A0 File Offset: 0x000165A0
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

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x000183AC File Offset: 0x000165AC
		// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x000183B4 File Offset: 0x000165B4
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

		// Token: 0x1700066E RID: 1646
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x000183C0 File Offset: 0x000165C0
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x000183C8 File Offset: 0x000165C8
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

		// Token: 0x1700066F RID: 1647
		// (get) Token: 0x06000FE4 RID: 4068 RVA: 0x000183D4 File Offset: 0x000165D4
		// (set) Token: 0x06000FE5 RID: 4069 RVA: 0x000183DC File Offset: 0x000165DC
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

		// Token: 0x17000670 RID: 1648
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x000183E8 File Offset: 0x000165E8
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x000183F0 File Offset: 0x000165F0
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

		// Token: 0x17000671 RID: 1649
		// (get) Token: 0x06000FE8 RID: 4072 RVA: 0x000183FC File Offset: 0x000165FC
		// (set) Token: 0x06000FE9 RID: 4073 RVA: 0x00018404 File Offset: 0x00016604
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

		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x06000FEA RID: 4074 RVA: 0x00018410 File Offset: 0x00016610
		// (set) Token: 0x06000FEB RID: 4075 RVA: 0x00018418 File Offset: 0x00016618
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

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06000FEC RID: 4076 RVA: 0x00018424 File Offset: 0x00016624
		// (set) Token: 0x06000FED RID: 4077 RVA: 0x0001842C File Offset: 0x0001662C
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

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06000FEE RID: 4078 RVA: 0x00018438 File Offset: 0x00016638
		// (set) Token: 0x06000FEF RID: 4079 RVA: 0x00018440 File Offset: 0x00016640
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

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06000FF0 RID: 4080 RVA: 0x0001844C File Offset: 0x0001664C
		// (set) Token: 0x06000FF1 RID: 4081 RVA: 0x00018454 File Offset: 0x00016654
		public PathCapNamesType StartCap
		{
			get
			{
				return this.startCapField;
			}
			set
			{
				this.startCapField = value;
			}
		}

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00018460 File Offset: 0x00016660
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00018468 File Offset: 0x00016668
		public PathCapNamesType EndCap
		{
			get
			{
				return this.endCapField;
			}
			set
			{
				this.endCapField = value;
			}
		}

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00018474 File Offset: 0x00016674
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x0001847C File Offset: 0x0001667C
		public int LineWidth
		{
			get
			{
				return this.lineWidthField;
			}
			set
			{
				this.lineWidthField = value;
			}
		}

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x00018488 File Offset: 0x00016688
		// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x00018490 File Offset: 0x00016690
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

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x0001849C File Offset: 0x0001669C
		// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x000184A4 File Offset: 0x000166A4
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

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x000184B0 File Offset: 0x000166B0
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x000184B8 File Offset: 0x000166B8
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

		// Token: 0x0400089F RID: 2207
		private LocalizableTextType displayNameField;

		// Token: 0x040008A0 RID: 2208
		private LocalizableTextType textField;

		// Token: 0x040008A1 RID: 2209
		private string colorField;

		// Token: 0x040008A2 RID: 2210
		private string technicalNameField;

		// Token: 0x040008A3 RID: 2211
		private string externalIdField;

		// Token: 0x040008A4 RID: 2212
		private string shortIdField;

		// Token: 0x040008A5 RID: 2213
		private string urlField;

		// Token: 0x040008A6 RID: 2214
		private FeaturesType featuresField;

		// Token: 0x040008A7 RID: 2215
		private VisibilityType visibilityField;

		// Token: 0x040008A8 RID: 2216
		private SelectabilityType selectabilityField;

		// Token: 0x040008A9 RID: 2217
		private PreviewImageType previewImageField;

		// Token: 0x040008AA RID: 2218
		private PointType positionField;

		// Token: 0x040008AB RID: 2219
		private float zIndexField;

		// Token: 0x040008AC RID: 2220
		private FillType fillField;

		// Token: 0x040008AD RID: 2221
		private OutlineType outlineField;

		// Token: 0x040008AE RID: 2222
		private bool showDisplayNameField;

		// Token: 0x040008AF RID: 2223
		private string displayNameColorField;

		// Token: 0x040008B0 RID: 2224
		private int displayNameSizeField;

		// Token: 0x040008B1 RID: 2225
		private bool dropShadowField;

		// Token: 0x040008B2 RID: 2226
		private PointType displayNamePositionField;

		// Token: 0x040008B3 RID: 2227
		private TransformationType transformationField;

		// Token: 0x040008B4 RID: 2228
		private VerticesType[] coordinatesField;

		// Token: 0x040008B5 RID: 2229
		private PathCapNamesType startCapField;

		// Token: 0x040008B6 RID: 2230
		private PathCapNamesType endCapField;

		// Token: 0x040008B7 RID: 2231
		private int lineWidthField;

		// Token: 0x040008B8 RID: 2232
		private string idField;

		// Token: 0x040008B9 RID: 2233
		private string objectTemplateReferenceField;

		// Token: 0x040008BA RID: 2234
		private string objectTemplateReferenceNameField;
	}
}
