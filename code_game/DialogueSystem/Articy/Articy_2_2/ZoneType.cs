using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000DB RID: 219
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ZoneType
	{
		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0001277C File Offset: 0x0001097C
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x00012784 File Offset: 0x00010984
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

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x00012790 File Offset: 0x00010990
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x00012798 File Offset: 0x00010998
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

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x000127A4 File Offset: 0x000109A4
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x000127AC File Offset: 0x000109AC
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

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x000127B8 File Offset: 0x000109B8
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x000127C0 File Offset: 0x000109C0
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

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x000127CC File Offset: 0x000109CC
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x000127D4 File Offset: 0x000109D4
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

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000861 RID: 2145 RVA: 0x000127E0 File Offset: 0x000109E0
		// (set) Token: 0x06000862 RID: 2146 RVA: 0x000127E8 File Offset: 0x000109E8
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

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000863 RID: 2147 RVA: 0x000127F4 File Offset: 0x000109F4
		// (set) Token: 0x06000864 RID: 2148 RVA: 0x000127FC File Offset: 0x000109FC
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

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000865 RID: 2149 RVA: 0x00012808 File Offset: 0x00010A08
		// (set) Token: 0x06000866 RID: 2150 RVA: 0x00012810 File Offset: 0x00010A10
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

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000867 RID: 2151 RVA: 0x0001281C File Offset: 0x00010A1C
		// (set) Token: 0x06000868 RID: 2152 RVA: 0x00012824 File Offset: 0x00010A24
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

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000869 RID: 2153 RVA: 0x00012830 File Offset: 0x00010A30
		// (set) Token: 0x0600086A RID: 2154 RVA: 0x00012838 File Offset: 0x00010A38
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

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x0600086B RID: 2155 RVA: 0x00012844 File Offset: 0x00010A44
		// (set) Token: 0x0600086C RID: 2156 RVA: 0x0001284C File Offset: 0x00010A4C
		[XmlElement("Circle", typeof(CircleType))]
		[XmlElement("Rectangle", typeof(RectangleType))]
		[XmlElement("Polygon", typeof(PolygonType))]
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

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600086D RID: 2157 RVA: 0x00012858 File Offset: 0x00010A58
		// (set) Token: 0x0600086E RID: 2158 RVA: 0x00012860 File Offset: 0x00010A60
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

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x0600086F RID: 2159 RVA: 0x0001286C File Offset: 0x00010A6C
		// (set) Token: 0x06000870 RID: 2160 RVA: 0x00012874 File Offset: 0x00010A74
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

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00012880 File Offset: 0x00010A80
		// (set) Token: 0x06000872 RID: 2162 RVA: 0x00012888 File Offset: 0x00010A88
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

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000873 RID: 2163 RVA: 0x00012894 File Offset: 0x00010A94
		// (set) Token: 0x06000874 RID: 2164 RVA: 0x0001289C File Offset: 0x00010A9C
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

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x06000875 RID: 2165 RVA: 0x000128A8 File Offset: 0x00010AA8
		// (set) Token: 0x06000876 RID: 2166 RVA: 0x000128B0 File Offset: 0x00010AB0
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

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06000877 RID: 2167 RVA: 0x000128BC File Offset: 0x00010ABC
		// (set) Token: 0x06000878 RID: 2168 RVA: 0x000128C4 File Offset: 0x00010AC4
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

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x000128D0 File Offset: 0x00010AD0
		// (set) Token: 0x0600087A RID: 2170 RVA: 0x000128D8 File Offset: 0x00010AD8
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

		// Token: 0x04000491 RID: 1169
		private LocalizableTextType displayNameField;

		// Token: 0x04000492 RID: 1170
		private LocalizableTextType textField;

		// Token: 0x04000493 RID: 1171
		private string colorField;

		// Token: 0x04000494 RID: 1172
		private string technicalNameField;

		// Token: 0x04000495 RID: 1173
		private string externalIdField;

		// Token: 0x04000496 RID: 1174
		private string shortIdField;

		// Token: 0x04000497 RID: 1175
		private FeaturesType featuresField;

		// Token: 0x04000498 RID: 1176
		private VisibilityType visibilityField;

		// Token: 0x04000499 RID: 1177
		private SelectabilityType selectabilityField;

		// Token: 0x0400049A RID: 1178
		private PreviewImageType previewImageField;

		// Token: 0x0400049B RID: 1179
		private object itemField;

		// Token: 0x0400049C RID: 1180
		private string idField;

		// Token: 0x0400049D RID: 1181
		private string objectTemplateReferenceField;

		// Token: 0x0400049E RID: 1182
		private string objectTemplateReferenceNameField;

		// Token: 0x0400049F RID: 1183
		private float xField;

		// Token: 0x040004A0 RID: 1184
		private float yField;

		// Token: 0x040004A1 RID: 1185
		private float zIndexField;

		// Token: 0x040004A2 RID: 1186
		private CShapeType cShapeField;
	}
}
