using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200015A RID: 346
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LocationImageType
	{
		// Token: 0x06000ED5 RID: 3797 RVA: 0x00017938 File Offset: 0x00015B38
		public LocationImageType()
		{
			this.cShapeField = CShapeType.Rectangle;
		}

		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00017948 File Offset: 0x00015B48
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x00017950 File Offset: 0x00015B50
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

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x0001795C File Offset: 0x00015B5C
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x00017964 File Offset: 0x00015B64
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

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x00017970 File Offset: 0x00015B70
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x00017978 File Offset: 0x00015B78
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

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x00017984 File Offset: 0x00015B84
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x0001798C File Offset: 0x00015B8C
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

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x00017998 File Offset: 0x00015B98
		// (set) Token: 0x06000EDF RID: 3807 RVA: 0x000179A0 File Offset: 0x00015BA0
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

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x000179AC File Offset: 0x00015BAC
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x000179B4 File Offset: 0x00015BB4
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

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x000179C0 File Offset: 0x00015BC0
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x000179C8 File Offset: 0x00015BC8
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

		// Token: 0x170005F5 RID: 1525
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x000179D4 File Offset: 0x00015BD4
		// (set) Token: 0x06000EE5 RID: 3813 RVA: 0x000179DC File Offset: 0x00015BDC
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

		// Token: 0x170005F6 RID: 1526
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x000179E8 File Offset: 0x00015BE8
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x000179F0 File Offset: 0x00015BF0
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

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x000179FC File Offset: 0x00015BFC
		// (set) Token: 0x06000EE9 RID: 3817 RVA: 0x00017A04 File Offset: 0x00015C04
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

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x00017A10 File Offset: 0x00015C10
		// (set) Token: 0x06000EEB RID: 3819 RVA: 0x00017A18 File Offset: 0x00015C18
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

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x00017A24 File Offset: 0x00015C24
		// (set) Token: 0x06000EED RID: 3821 RVA: 0x00017A2C File Offset: 0x00015C2C
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

		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x00017A38 File Offset: 0x00015C38
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x00017A40 File Offset: 0x00015C40
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

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x00017A4C File Offset: 0x00015C4C
		// (set) Token: 0x06000EF1 RID: 3825 RVA: 0x00017A54 File Offset: 0x00015C54
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

		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x00017A60 File Offset: 0x00015C60
		// (set) Token: 0x06000EF3 RID: 3827 RVA: 0x00017A68 File Offset: 0x00015C68
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

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06000EF4 RID: 3828 RVA: 0x00017A74 File Offset: 0x00015C74
		// (set) Token: 0x06000EF5 RID: 3829 RVA: 0x00017A7C File Offset: 0x00015C7C
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

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x06000EF6 RID: 3830 RVA: 0x00017A88 File Offset: 0x00015C88
		// (set) Token: 0x06000EF7 RID: 3831 RVA: 0x00017A90 File Offset: 0x00015C90
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

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x00017A9C File Offset: 0x00015C9C
		// (set) Token: 0x06000EF9 RID: 3833 RVA: 0x00017AA4 File Offset: 0x00015CA4
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

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06000EFA RID: 3834 RVA: 0x00017AB0 File Offset: 0x00015CB0
		// (set) Token: 0x06000EFB RID: 3835 RVA: 0x00017AB8 File Offset: 0x00015CB8
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

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06000EFC RID: 3836 RVA: 0x00017AC4 File Offset: 0x00015CC4
		// (set) Token: 0x06000EFD RID: 3837 RVA: 0x00017ACC File Offset: 0x00015CCC
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

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06000EFE RID: 3838 RVA: 0x00017AD8 File Offset: 0x00015CD8
		// (set) Token: 0x06000EFF RID: 3839 RVA: 0x00017AE0 File Offset: 0x00015CE0
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

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06000F00 RID: 3840 RVA: 0x00017AEC File Offset: 0x00015CEC
		// (set) Token: 0x06000F01 RID: 3841 RVA: 0x00017AF4 File Offset: 0x00015CF4
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

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06000F02 RID: 3842 RVA: 0x00017B00 File Offset: 0x00015D00
		// (set) Token: 0x06000F03 RID: 3843 RVA: 0x00017B08 File Offset: 0x00015D08
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

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x06000F04 RID: 3844 RVA: 0x00017B14 File Offset: 0x00015D14
		// (set) Token: 0x06000F05 RID: 3845 RVA: 0x00017B1C File Offset: 0x00015D1C
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

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x06000F06 RID: 3846 RVA: 0x00017B28 File Offset: 0x00015D28
		// (set) Token: 0x06000F07 RID: 3847 RVA: 0x00017B30 File Offset: 0x00015D30
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

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06000F08 RID: 3848 RVA: 0x00017B3C File Offset: 0x00015D3C
		// (set) Token: 0x06000F09 RID: 3849 RVA: 0x00017B44 File Offset: 0x00015D44
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

		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06000F0A RID: 3850 RVA: 0x00017B50 File Offset: 0x00015D50
		// (set) Token: 0x06000F0B RID: 3851 RVA: 0x00017B58 File Offset: 0x00015D58
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

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06000F0C RID: 3852 RVA: 0x00017B64 File Offset: 0x00015D64
		// (set) Token: 0x06000F0D RID: 3853 RVA: 0x00017B6C File Offset: 0x00015D6C
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

		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x00017B78 File Offset: 0x00015D78
		// (set) Token: 0x06000F0F RID: 3855 RVA: 0x00017B80 File Offset: 0x00015D80
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

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x06000F10 RID: 3856 RVA: 0x00017B8C File Offset: 0x00015D8C
		// (set) Token: 0x06000F11 RID: 3857 RVA: 0x00017B94 File Offset: 0x00015D94
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

		// Token: 0x0400081D RID: 2077
		private LocalizableTextType displayNameField;

		// Token: 0x0400081E RID: 2078
		private LocalizableTextType textField;

		// Token: 0x0400081F RID: 2079
		private string colorField;

		// Token: 0x04000820 RID: 2080
		private string technicalNameField;

		// Token: 0x04000821 RID: 2081
		private string externalIdField;

		// Token: 0x04000822 RID: 2082
		private string shortIdField;

		// Token: 0x04000823 RID: 2083
		private string urlField;

		// Token: 0x04000824 RID: 2084
		private FeaturesType featuresField;

		// Token: 0x04000825 RID: 2085
		private VisibilityType visibilityField;

		// Token: 0x04000826 RID: 2086
		private SelectabilityType selectabilityField;

		// Token: 0x04000827 RID: 2087
		private PreviewImageType previewImageField;

		// Token: 0x04000828 RID: 2088
		private PointType positionField;

		// Token: 0x04000829 RID: 2089
		private float zIndexField;

		// Token: 0x0400082A RID: 2090
		private FillType fillField;

		// Token: 0x0400082B RID: 2091
		private OutlineType outlineField;

		// Token: 0x0400082C RID: 2092
		private bool showDisplayNameField;

		// Token: 0x0400082D RID: 2093
		private string displayNameColorField;

		// Token: 0x0400082E RID: 2094
		private int displayNameSizeField;

		// Token: 0x0400082F RID: 2095
		private bool dropShadowField;

		// Token: 0x04000830 RID: 2096
		private PointType displayNamePositionField;

		// Token: 0x04000831 RID: 2097
		private TransformationType transformationField;

		// Token: 0x04000832 RID: 2098
		private VerticesType[] coordinatesField;

		// Token: 0x04000833 RID: 2099
		private float opacityField;

		// Token: 0x04000834 RID: 2100
		private ReferenceType imageField;

		// Token: 0x04000835 RID: 2101
		private RectangleType clipRectField;

		// Token: 0x04000836 RID: 2102
		private LocationAnchorsType anchorsField;

		// Token: 0x04000837 RID: 2103
		private string idField;

		// Token: 0x04000838 RID: 2104
		private string objectTemplateReferenceField;

		// Token: 0x04000839 RID: 2105
		private string objectTemplateReferenceNameField;

		// Token: 0x0400083A RID: 2106
		private CShapeType cShapeField;
	}
}
