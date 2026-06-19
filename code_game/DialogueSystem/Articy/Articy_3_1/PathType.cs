using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E9 RID: 489
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class PathType
	{
		// Token: 0x17000942 RID: 2370
		// (get) Token: 0x06001616 RID: 5654 RVA: 0x0001D2BC File Offset: 0x0001B4BC
		// (set) Token: 0x06001617 RID: 5655 RVA: 0x0001D2C4 File Offset: 0x0001B4C4
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

		// Token: 0x17000943 RID: 2371
		// (get) Token: 0x06001618 RID: 5656 RVA: 0x0001D2D0 File Offset: 0x0001B4D0
		// (set) Token: 0x06001619 RID: 5657 RVA: 0x0001D2D8 File Offset: 0x0001B4D8
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

		// Token: 0x17000944 RID: 2372
		// (get) Token: 0x0600161A RID: 5658 RVA: 0x0001D2E4 File Offset: 0x0001B4E4
		// (set) Token: 0x0600161B RID: 5659 RVA: 0x0001D2EC File Offset: 0x0001B4EC
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

		// Token: 0x17000945 RID: 2373
		// (get) Token: 0x0600161C RID: 5660 RVA: 0x0001D2F8 File Offset: 0x0001B4F8
		// (set) Token: 0x0600161D RID: 5661 RVA: 0x0001D300 File Offset: 0x0001B500
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

		// Token: 0x17000946 RID: 2374
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x0001D30C File Offset: 0x0001B50C
		// (set) Token: 0x0600161F RID: 5663 RVA: 0x0001D314 File Offset: 0x0001B514
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

		// Token: 0x17000947 RID: 2375
		// (get) Token: 0x06001620 RID: 5664 RVA: 0x0001D320 File Offset: 0x0001B520
		// (set) Token: 0x06001621 RID: 5665 RVA: 0x0001D328 File Offset: 0x0001B528
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

		// Token: 0x17000948 RID: 2376
		// (get) Token: 0x06001622 RID: 5666 RVA: 0x0001D334 File Offset: 0x0001B534
		// (set) Token: 0x06001623 RID: 5667 RVA: 0x0001D33C File Offset: 0x0001B53C
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

		// Token: 0x17000949 RID: 2377
		// (get) Token: 0x06001624 RID: 5668 RVA: 0x0001D348 File Offset: 0x0001B548
		// (set) Token: 0x06001625 RID: 5669 RVA: 0x0001D350 File Offset: 0x0001B550
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

		// Token: 0x1700094A RID: 2378
		// (get) Token: 0x06001626 RID: 5670 RVA: 0x0001D35C File Offset: 0x0001B55C
		// (set) Token: 0x06001627 RID: 5671 RVA: 0x0001D364 File Offset: 0x0001B564
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

		// Token: 0x1700094B RID: 2379
		// (get) Token: 0x06001628 RID: 5672 RVA: 0x0001D370 File Offset: 0x0001B570
		// (set) Token: 0x06001629 RID: 5673 RVA: 0x0001D378 File Offset: 0x0001B578
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

		// Token: 0x1700094C RID: 2380
		// (get) Token: 0x0600162A RID: 5674 RVA: 0x0001D384 File Offset: 0x0001B584
		// (set) Token: 0x0600162B RID: 5675 RVA: 0x0001D38C File Offset: 0x0001B58C
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

		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x0600162C RID: 5676 RVA: 0x0001D398 File Offset: 0x0001B598
		// (set) Token: 0x0600162D RID: 5677 RVA: 0x0001D3A0 File Offset: 0x0001B5A0
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

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x0600162E RID: 5678 RVA: 0x0001D3AC File Offset: 0x0001B5AC
		// (set) Token: 0x0600162F RID: 5679 RVA: 0x0001D3B4 File Offset: 0x0001B5B4
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

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06001630 RID: 5680 RVA: 0x0001D3C0 File Offset: 0x0001B5C0
		// (set) Token: 0x06001631 RID: 5681 RVA: 0x0001D3C8 File Offset: 0x0001B5C8
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

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06001632 RID: 5682 RVA: 0x0001D3D4 File Offset: 0x0001B5D4
		// (set) Token: 0x06001633 RID: 5683 RVA: 0x0001D3DC File Offset: 0x0001B5DC
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

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x06001634 RID: 5684 RVA: 0x0001D3E8 File Offset: 0x0001B5E8
		// (set) Token: 0x06001635 RID: 5685 RVA: 0x0001D3F0 File Offset: 0x0001B5F0
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

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x06001636 RID: 5686 RVA: 0x0001D3FC File Offset: 0x0001B5FC
		// (set) Token: 0x06001637 RID: 5687 RVA: 0x0001D404 File Offset: 0x0001B604
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

		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06001638 RID: 5688 RVA: 0x0001D410 File Offset: 0x0001B610
		// (set) Token: 0x06001639 RID: 5689 RVA: 0x0001D418 File Offset: 0x0001B618
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

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x0600163A RID: 5690 RVA: 0x0001D424 File Offset: 0x0001B624
		// (set) Token: 0x0600163B RID: 5691 RVA: 0x0001D42C File Offset: 0x0001B62C
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

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x0600163C RID: 5692 RVA: 0x0001D438 File Offset: 0x0001B638
		// (set) Token: 0x0600163D RID: 5693 RVA: 0x0001D440 File Offset: 0x0001B640
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

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x0600163E RID: 5694 RVA: 0x0001D44C File Offset: 0x0001B64C
		// (set) Token: 0x0600163F RID: 5695 RVA: 0x0001D454 File Offset: 0x0001B654
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

		// Token: 0x17000957 RID: 2391
		// (get) Token: 0x06001640 RID: 5696 RVA: 0x0001D460 File Offset: 0x0001B660
		// (set) Token: 0x06001641 RID: 5697 RVA: 0x0001D468 File Offset: 0x0001B668
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

		// Token: 0x17000958 RID: 2392
		// (get) Token: 0x06001642 RID: 5698 RVA: 0x0001D474 File Offset: 0x0001B674
		// (set) Token: 0x06001643 RID: 5699 RVA: 0x0001D47C File Offset: 0x0001B67C
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

		// Token: 0x17000959 RID: 2393
		// (get) Token: 0x06001644 RID: 5700 RVA: 0x0001D488 File Offset: 0x0001B688
		// (set) Token: 0x06001645 RID: 5701 RVA: 0x0001D490 File Offset: 0x0001B690
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

		// Token: 0x1700095A RID: 2394
		// (get) Token: 0x06001646 RID: 5702 RVA: 0x0001D49C File Offset: 0x0001B69C
		// (set) Token: 0x06001647 RID: 5703 RVA: 0x0001D4A4 File Offset: 0x0001B6A4
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

		// Token: 0x1700095B RID: 2395
		// (get) Token: 0x06001648 RID: 5704 RVA: 0x0001D4B0 File Offset: 0x0001B6B0
		// (set) Token: 0x06001649 RID: 5705 RVA: 0x0001D4B8 File Offset: 0x0001B6B8
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

		// Token: 0x1700095C RID: 2396
		// (get) Token: 0x0600164A RID: 5706 RVA: 0x0001D4C4 File Offset: 0x0001B6C4
		// (set) Token: 0x0600164B RID: 5707 RVA: 0x0001D4CC File Offset: 0x0001B6CC
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

		// Token: 0x1700095D RID: 2397
		// (get) Token: 0x0600164C RID: 5708 RVA: 0x0001D4D8 File Offset: 0x0001B6D8
		// (set) Token: 0x0600164D RID: 5709 RVA: 0x0001D4E0 File Offset: 0x0001B6E0
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

		// Token: 0x04000C2B RID: 3115
		private LocalizableTextType displayNameField;

		// Token: 0x04000C2C RID: 3116
		private LocalizableTextType textField;

		// Token: 0x04000C2D RID: 3117
		private string colorField;

		// Token: 0x04000C2E RID: 3118
		private string technicalNameField;

		// Token: 0x04000C2F RID: 3119
		private string externalIdField;

		// Token: 0x04000C30 RID: 3120
		private string shortIdField;

		// Token: 0x04000C31 RID: 3121
		private string urlField;

		// Token: 0x04000C32 RID: 3122
		private FeaturesType featuresField;

		// Token: 0x04000C33 RID: 3123
		private VisibilityType visibilityField;

		// Token: 0x04000C34 RID: 3124
		private SelectabilityType selectabilityField;

		// Token: 0x04000C35 RID: 3125
		private PreviewImageType previewImageField;

		// Token: 0x04000C36 RID: 3126
		private PointType positionField;

		// Token: 0x04000C37 RID: 3127
		private float zIndexField;

		// Token: 0x04000C38 RID: 3128
		private FillType fillField;

		// Token: 0x04000C39 RID: 3129
		private OutlineType outlineField;

		// Token: 0x04000C3A RID: 3130
		private bool showDisplayNameField;

		// Token: 0x04000C3B RID: 3131
		private string displayNameColorField;

		// Token: 0x04000C3C RID: 3132
		private int displayNameSizeField;

		// Token: 0x04000C3D RID: 3133
		private bool dropShadowField;

		// Token: 0x04000C3E RID: 3134
		private PointType displayNamePositionField;

		// Token: 0x04000C3F RID: 3135
		private TransformationType transformationField;

		// Token: 0x04000C40 RID: 3136
		private VerticesType[] coordinatesField;

		// Token: 0x04000C41 RID: 3137
		private PathCapNamesType startCapField;

		// Token: 0x04000C42 RID: 3138
		private PathCapNamesType endCapField;

		// Token: 0x04000C43 RID: 3139
		private int lineWidthField;

		// Token: 0x04000C44 RID: 3140
		private string idField;

		// Token: 0x04000C45 RID: 3141
		private string objectTemplateReferenceField;

		// Token: 0x04000C46 RID: 3142
		private string objectTemplateReferenceNameField;
	}
}
