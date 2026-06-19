using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000165 RID: 357
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LocationTextType
	{
		// Token: 0x06000F48 RID: 3912 RVA: 0x00017DC0 File Offset: 0x00015FC0
		public LocationTextType()
		{
			this.cShapeField = CShapeType.Rectangle;
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x00017DD0 File Offset: 0x00015FD0
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x00017DD8 File Offset: 0x00015FD8
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

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x00017DE4 File Offset: 0x00015FE4
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x00017DEC File Offset: 0x00015FEC
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

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x00017DF8 File Offset: 0x00015FF8
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x00017E00 File Offset: 0x00016000
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

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x00017E0C File Offset: 0x0001600C
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x00017E14 File Offset: 0x00016014
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

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06000F51 RID: 3921 RVA: 0x00017E20 File Offset: 0x00016020
		// (set) Token: 0x06000F52 RID: 3922 RVA: 0x00017E28 File Offset: 0x00016028
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

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x00017E34 File Offset: 0x00016034
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x00017E3C File Offset: 0x0001603C
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

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x00017E48 File Offset: 0x00016048
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x00017E50 File Offset: 0x00016050
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

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x00017E5C File Offset: 0x0001605C
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x00017E64 File Offset: 0x00016064
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

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x00017E70 File Offset: 0x00016070
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00017E78 File Offset: 0x00016078
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

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x00017E84 File Offset: 0x00016084
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x00017E8C File Offset: 0x0001608C
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

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x00017E98 File Offset: 0x00016098
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x00017EA0 File Offset: 0x000160A0
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

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x00017EAC File Offset: 0x000160AC
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x00017EB4 File Offset: 0x000160B4
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

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x00017EC0 File Offset: 0x000160C0
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x00017EC8 File Offset: 0x000160C8
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

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x00017ED4 File Offset: 0x000160D4
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x00017EDC File Offset: 0x000160DC
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

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x00017EE8 File Offset: 0x000160E8
		// (set) Token: 0x06000F66 RID: 3942 RVA: 0x00017EF0 File Offset: 0x000160F0
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

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x00017EFC File Offset: 0x000160FC
		// (set) Token: 0x06000F68 RID: 3944 RVA: 0x00017F04 File Offset: 0x00016104
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

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06000F69 RID: 3945 RVA: 0x00017F10 File Offset: 0x00016110
		// (set) Token: 0x06000F6A RID: 3946 RVA: 0x00017F18 File Offset: 0x00016118
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

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x00017F24 File Offset: 0x00016124
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x00017F2C File Offset: 0x0001612C
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

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x00017F38 File Offset: 0x00016138
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x00017F40 File Offset: 0x00016140
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

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x00017F4C File Offset: 0x0001614C
		// (set) Token: 0x06000F70 RID: 3952 RVA: 0x00017F54 File Offset: 0x00016154
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

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x00017F60 File Offset: 0x00016160
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x00017F68 File Offset: 0x00016168
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

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x00017F74 File Offset: 0x00016174
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x00017F7C File Offset: 0x0001617C
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

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x00017F88 File Offset: 0x00016188
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x00017F90 File Offset: 0x00016190
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

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06000F77 RID: 3959 RVA: 0x00017F9C File Offset: 0x0001619C
		// (set) Token: 0x06000F78 RID: 3960 RVA: 0x00017FA4 File Offset: 0x000161A4
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

		// Token: 0x04000864 RID: 2148
		private LocalizableTextType displayNameField;

		// Token: 0x04000865 RID: 2149
		private LocalizableTextType textField;

		// Token: 0x04000866 RID: 2150
		private string colorField;

		// Token: 0x04000867 RID: 2151
		private string technicalNameField;

		// Token: 0x04000868 RID: 2152
		private string externalIdField;

		// Token: 0x04000869 RID: 2153
		private string shortIdField;

		// Token: 0x0400086A RID: 2154
		private string urlField;

		// Token: 0x0400086B RID: 2155
		private FeaturesType featuresField;

		// Token: 0x0400086C RID: 2156
		private VisibilityType visibilityField;

		// Token: 0x0400086D RID: 2157
		private SelectabilityType selectabilityField;

		// Token: 0x0400086E RID: 2158
		private PreviewImageType previewImageField;

		// Token: 0x0400086F RID: 2159
		private PointType positionField;

		// Token: 0x04000870 RID: 2160
		private float zIndexField;

		// Token: 0x04000871 RID: 2161
		private FillType fillField;

		// Token: 0x04000872 RID: 2162
		private OutlineType outlineField;

		// Token: 0x04000873 RID: 2163
		private bool dropShadowField;

		// Token: 0x04000874 RID: 2164
		private PointType displayNamePositionField;

		// Token: 0x04000875 RID: 2165
		private TransformationType transformationField;

		// Token: 0x04000876 RID: 2166
		private VerticesType[] coordinatesField;

		// Token: 0x04000877 RID: 2167
		private LocationAnchorsType anchorsField;

		// Token: 0x04000878 RID: 2168
		private string idField;

		// Token: 0x04000879 RID: 2169
		private string objectTemplateReferenceField;

		// Token: 0x0400087A RID: 2170
		private string objectTemplateReferenceNameField;

		// Token: 0x0400087B RID: 2171
		private CShapeType cShapeField;
	}
}
