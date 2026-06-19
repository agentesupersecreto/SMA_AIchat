using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D4 RID: 212
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LinkType
	{
		// Token: 0x170002CC RID: 716
		// (get) Token: 0x060007FE RID: 2046 RVA: 0x0001240C File Offset: 0x0001060C
		// (set) Token: 0x060007FF RID: 2047 RVA: 0x00012414 File Offset: 0x00010614
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

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000800 RID: 2048 RVA: 0x00012420 File Offset: 0x00010620
		// (set) Token: 0x06000801 RID: 2049 RVA: 0x00012428 File Offset: 0x00010628
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

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000802 RID: 2050 RVA: 0x00012434 File Offset: 0x00010634
		// (set) Token: 0x06000803 RID: 2051 RVA: 0x0001243C File Offset: 0x0001063C
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

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000804 RID: 2052 RVA: 0x00012448 File Offset: 0x00010648
		// (set) Token: 0x06000805 RID: 2053 RVA: 0x00012450 File Offset: 0x00010650
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

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000806 RID: 2054 RVA: 0x0001245C File Offset: 0x0001065C
		// (set) Token: 0x06000807 RID: 2055 RVA: 0x00012464 File Offset: 0x00010664
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

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x00012470 File Offset: 0x00010670
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x00012478 File Offset: 0x00010678
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

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x0600080A RID: 2058 RVA: 0x00012484 File Offset: 0x00010684
		// (set) Token: 0x0600080B RID: 2059 RVA: 0x0001248C File Offset: 0x0001068C
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

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x00012498 File Offset: 0x00010698
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x000124A0 File Offset: 0x000106A0
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

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x000124AC File Offset: 0x000106AC
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x000124B4 File Offset: 0x000106B4
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

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x000124C0 File Offset: 0x000106C0
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x000124C8 File Offset: 0x000106C8
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

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x000124D4 File Offset: 0x000106D4
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x000124DC File Offset: 0x000106DC
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

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000814 RID: 2068 RVA: 0x000124E8 File Offset: 0x000106E8
		// (set) Token: 0x06000815 RID: 2069 RVA: 0x000124F0 File Offset: 0x000106F0
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

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000816 RID: 2070 RVA: 0x000124FC File Offset: 0x000106FC
		// (set) Token: 0x06000817 RID: 2071 RVA: 0x00012504 File Offset: 0x00010704
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

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000818 RID: 2072 RVA: 0x00012510 File Offset: 0x00010710
		// (set) Token: 0x06000819 RID: 2073 RVA: 0x00012518 File Offset: 0x00010718
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

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x0600081A RID: 2074 RVA: 0x00012524 File Offset: 0x00010724
		// (set) Token: 0x0600081B RID: 2075 RVA: 0x0001252C File Offset: 0x0001072C
		[XmlIgnore]
		public bool XSpecified
		{
			get
			{
				return this.xFieldSpecified;
			}
			set
			{
				this.xFieldSpecified = value;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x0600081C RID: 2076 RVA: 0x00012538 File Offset: 0x00010738
		// (set) Token: 0x0600081D RID: 2077 RVA: 0x00012540 File Offset: 0x00010740
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

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600081E RID: 2078 RVA: 0x0001254C File Offset: 0x0001074C
		// (set) Token: 0x0600081F RID: 2079 RVA: 0x00012554 File Offset: 0x00010754
		[XmlIgnore]
		public bool YSpecified
		{
			get
			{
				return this.yFieldSpecified;
			}
			set
			{
				this.yFieldSpecified = value;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000820 RID: 2080 RVA: 0x00012560 File Offset: 0x00010760
		// (set) Token: 0x06000821 RID: 2081 RVA: 0x00012568 File Offset: 0x00010768
		[XmlAttribute]
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

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x00012574 File Offset: 0x00010774
		// (set) Token: 0x06000823 RID: 2083 RVA: 0x0001257C File Offset: 0x0001077C
		[XmlIgnore]
		public bool ZIndexSpecified
		{
			get
			{
				return this.zIndexFieldSpecified;
			}
			set
			{
				this.zIndexFieldSpecified = value;
			}
		}

		// Token: 0x04000461 RID: 1121
		private string displayNameField;

		// Token: 0x04000462 RID: 1122
		private LocalizableTextType textField;

		// Token: 0x04000463 RID: 1123
		private string colorField;

		// Token: 0x04000464 RID: 1124
		private string technicalNameField;

		// Token: 0x04000465 RID: 1125
		private string externalIdField;

		// Token: 0x04000466 RID: 1126
		private string shortIdField;

		// Token: 0x04000467 RID: 1127
		private FeaturesType featuresField;

		// Token: 0x04000468 RID: 1128
		private VisibilityType visibilityField;

		// Token: 0x04000469 RID: 1129
		private SelectabilityType selectabilityField;

		// Token: 0x0400046A RID: 1130
		private ReferenceType targetField;

		// Token: 0x0400046B RID: 1131
		private string idField;

		// Token: 0x0400046C RID: 1132
		private string objectTemplateReferenceField;

		// Token: 0x0400046D RID: 1133
		private string objectTemplateReferenceNameField;

		// Token: 0x0400046E RID: 1134
		private float xField;

		// Token: 0x0400046F RID: 1135
		private bool xFieldSpecified;

		// Token: 0x04000470 RID: 1136
		private float yField;

		// Token: 0x04000471 RID: 1137
		private bool yFieldSpecified;

		// Token: 0x04000472 RID: 1138
		private float zIndexField;

		// Token: 0x04000473 RID: 1139
		private bool zIndexFieldSpecified;
	}
}
