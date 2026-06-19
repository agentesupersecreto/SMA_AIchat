using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D7 RID: 215
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PathType
	{
		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x00012590 File Offset: 0x00010790
		// (set) Token: 0x06000826 RID: 2086 RVA: 0x00012598 File Offset: 0x00010798
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

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000827 RID: 2087 RVA: 0x000125A4 File Offset: 0x000107A4
		// (set) Token: 0x06000828 RID: 2088 RVA: 0x000125AC File Offset: 0x000107AC
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

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x000125B8 File Offset: 0x000107B8
		// (set) Token: 0x0600082A RID: 2090 RVA: 0x000125C0 File Offset: 0x000107C0
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

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x000125CC File Offset: 0x000107CC
		// (set) Token: 0x0600082C RID: 2092 RVA: 0x000125D4 File Offset: 0x000107D4
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

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x000125E0 File Offset: 0x000107E0
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x000125E8 File Offset: 0x000107E8
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

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x000125F4 File Offset: 0x000107F4
		// (set) Token: 0x06000830 RID: 2096 RVA: 0x000125FC File Offset: 0x000107FC
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

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000831 RID: 2097 RVA: 0x00012608 File Offset: 0x00010808
		// (set) Token: 0x06000832 RID: 2098 RVA: 0x00012610 File Offset: 0x00010810
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

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000833 RID: 2099 RVA: 0x0001261C File Offset: 0x0001081C
		// (set) Token: 0x06000834 RID: 2100 RVA: 0x00012624 File Offset: 0x00010824
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

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000835 RID: 2101 RVA: 0x00012630 File Offset: 0x00010830
		// (set) Token: 0x06000836 RID: 2102 RVA: 0x00012638 File Offset: 0x00010838
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

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000837 RID: 2103 RVA: 0x00012644 File Offset: 0x00010844
		// (set) Token: 0x06000838 RID: 2104 RVA: 0x0001264C File Offset: 0x0001084C
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

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000839 RID: 2105 RVA: 0x00012658 File Offset: 0x00010858
		// (set) Token: 0x0600083A RID: 2106 RVA: 0x00012660 File Offset: 0x00010860
		public VerticesType Vertices
		{
			get
			{
				return this.verticesField;
			}
			set
			{
				this.verticesField = value;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001266C File Offset: 0x0001086C
		// (set) Token: 0x0600083C RID: 2108 RVA: 0x00012674 File Offset: 0x00010874
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

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x00012680 File Offset: 0x00010880
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x00012688 File Offset: 0x00010888
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

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x00012694 File Offset: 0x00010894
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x0001269C File Offset: 0x0001089C
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

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x000126A8 File Offset: 0x000108A8
		// (set) Token: 0x06000842 RID: 2114 RVA: 0x000126B0 File Offset: 0x000108B0
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

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x000126BC File Offset: 0x000108BC
		// (set) Token: 0x06000844 RID: 2116 RVA: 0x000126C4 File Offset: 0x000108C4
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

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000845 RID: 2117 RVA: 0x000126D0 File Offset: 0x000108D0
		// (set) Token: 0x06000846 RID: 2118 RVA: 0x000126D8 File Offset: 0x000108D8
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

		// Token: 0x0400047A RID: 1146
		private LocalizableTextType displayNameField;

		// Token: 0x0400047B RID: 1147
		private LocalizableTextType textField;

		// Token: 0x0400047C RID: 1148
		private string colorField;

		// Token: 0x0400047D RID: 1149
		private string technicalNameField;

		// Token: 0x0400047E RID: 1150
		private string externalIdField;

		// Token: 0x0400047F RID: 1151
		private string shortIdField;

		// Token: 0x04000480 RID: 1152
		private FeaturesType featuresField;

		// Token: 0x04000481 RID: 1153
		private VisibilityType visibilityField;

		// Token: 0x04000482 RID: 1154
		private SelectabilityType selectabilityField;

		// Token: 0x04000483 RID: 1155
		private PreviewImageType previewImageField;

		// Token: 0x04000484 RID: 1156
		private VerticesType verticesField;

		// Token: 0x04000485 RID: 1157
		private string idField;

		// Token: 0x04000486 RID: 1158
		private string objectTemplateReferenceField;

		// Token: 0x04000487 RID: 1159
		private string objectTemplateReferenceNameField;

		// Token: 0x04000488 RID: 1160
		private float xField;

		// Token: 0x04000489 RID: 1161
		private float yField;

		// Token: 0x0400048A RID: 1162
		private float zIndexField;
	}
}
