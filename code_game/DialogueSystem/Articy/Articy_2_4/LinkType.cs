using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000153 RID: 339
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LinkType
	{
		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x06000E5C RID: 3676 RVA: 0x00017484 File Offset: 0x00015684
		// (set) Token: 0x06000E5D RID: 3677 RVA: 0x0001748C File Offset: 0x0001568C
		public string DisplayName
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

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x06000E5E RID: 3678 RVA: 0x00017498 File Offset: 0x00015698
		// (set) Token: 0x06000E5F RID: 3679 RVA: 0x000174A0 File Offset: 0x000156A0
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

		// Token: 0x170005B5 RID: 1461
		// (get) Token: 0x06000E60 RID: 3680 RVA: 0x000174AC File Offset: 0x000156AC
		// (set) Token: 0x06000E61 RID: 3681 RVA: 0x000174B4 File Offset: 0x000156B4
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

		// Token: 0x170005B6 RID: 1462
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x000174C0 File Offset: 0x000156C0
		// (set) Token: 0x06000E63 RID: 3683 RVA: 0x000174C8 File Offset: 0x000156C8
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

		// Token: 0x170005B7 RID: 1463
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x000174D4 File Offset: 0x000156D4
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x000174DC File Offset: 0x000156DC
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

		// Token: 0x170005B8 RID: 1464
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x000174E8 File Offset: 0x000156E8
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x000174F0 File Offset: 0x000156F0
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

		// Token: 0x170005B9 RID: 1465
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x000174FC File Offset: 0x000156FC
		// (set) Token: 0x06000E69 RID: 3689 RVA: 0x00017504 File Offset: 0x00015704
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

		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x00017510 File Offset: 0x00015710
		// (set) Token: 0x06000E6B RID: 3691 RVA: 0x00017518 File Offset: 0x00015718
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

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x00017524 File Offset: 0x00015724
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x0001752C File Offset: 0x0001572C
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

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x00017538 File Offset: 0x00015738
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x00017540 File Offset: 0x00015740
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

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x0001754C File Offset: 0x0001574C
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x00017554 File Offset: 0x00015754
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

		// Token: 0x170005BE RID: 1470
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x00017560 File Offset: 0x00015760
		// (set) Token: 0x06000E73 RID: 3699 RVA: 0x00017568 File Offset: 0x00015768
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

		// Token: 0x170005BF RID: 1471
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x00017574 File Offset: 0x00015774
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x0001757C File Offset: 0x0001577C
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

		// Token: 0x170005C0 RID: 1472
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x00017588 File Offset: 0x00015788
		// (set) Token: 0x06000E77 RID: 3703 RVA: 0x00017590 File Offset: 0x00015790
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

		// Token: 0x170005C1 RID: 1473
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x0001759C File Offset: 0x0001579C
		// (set) Token: 0x06000E79 RID: 3705 RVA: 0x000175A4 File Offset: 0x000157A4
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

		// Token: 0x170005C2 RID: 1474
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x000175B0 File Offset: 0x000157B0
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x000175B8 File Offset: 0x000157B8
		public ReferenceType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x170005C3 RID: 1475
		// (get) Token: 0x06000E7C RID: 3708 RVA: 0x000175C4 File Offset: 0x000157C4
		// (set) Token: 0x06000E7D RID: 3709 RVA: 0x000175CC File Offset: 0x000157CC
		public LinkStyleType Style
		{
			get
			{
				return this.styleField;
			}
			set
			{
				this.styleField = value;
			}
		}

		// Token: 0x170005C4 RID: 1476
		// (get) Token: 0x06000E7E RID: 3710 RVA: 0x000175D8 File Offset: 0x000157D8
		// (set) Token: 0x06000E7F RID: 3711 RVA: 0x000175E0 File Offset: 0x000157E0
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

		// Token: 0x170005C5 RID: 1477
		// (get) Token: 0x06000E80 RID: 3712 RVA: 0x000175EC File Offset: 0x000157EC
		// (set) Token: 0x06000E81 RID: 3713 RVA: 0x000175F4 File Offset: 0x000157F4
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

		// Token: 0x170005C6 RID: 1478
		// (get) Token: 0x06000E82 RID: 3714 RVA: 0x00017600 File Offset: 0x00015800
		// (set) Token: 0x06000E83 RID: 3715 RVA: 0x00017608 File Offset: 0x00015808
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

		// Token: 0x040007D4 RID: 2004
		private string displayNameField;

		// Token: 0x040007D5 RID: 2005
		private LocalizableTextType textField;

		// Token: 0x040007D6 RID: 2006
		private string colorField;

		// Token: 0x040007D7 RID: 2007
		private string technicalNameField;

		// Token: 0x040007D8 RID: 2008
		private string externalIdField;

		// Token: 0x040007D9 RID: 2009
		private string shortIdField;

		// Token: 0x040007DA RID: 2010
		private string urlField;

		// Token: 0x040007DB RID: 2011
		private FeaturesType featuresField;

		// Token: 0x040007DC RID: 2012
		private VisibilityType visibilityField;

		// Token: 0x040007DD RID: 2013
		private SelectabilityType selectabilityField;

		// Token: 0x040007DE RID: 2014
		private PointType positionField;

		// Token: 0x040007DF RID: 2015
		private float zIndexField;

		// Token: 0x040007E0 RID: 2016
		private bool showDisplayNameField;

		// Token: 0x040007E1 RID: 2017
		private string displayNameColorField;

		// Token: 0x040007E2 RID: 2018
		private bool dropShadowField;

		// Token: 0x040007E3 RID: 2019
		private ReferenceType targetField;

		// Token: 0x040007E4 RID: 2020
		private LinkStyleType styleField;

		// Token: 0x040007E5 RID: 2021
		private string idField;

		// Token: 0x040007E6 RID: 2022
		private string objectTemplateReferenceField;

		// Token: 0x040007E7 RID: 2023
		private string objectTemplateReferenceNameField;
	}
}
