using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000DD RID: 221
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class SpotType
	{
		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x000128EC File Offset: 0x00010AEC
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x000128F4 File Offset: 0x00010AF4
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

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x00012900 File Offset: 0x00010B00
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x00012908 File Offset: 0x00010B08
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

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x00012914 File Offset: 0x00010B14
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0001291C File Offset: 0x00010B1C
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

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00012928 File Offset: 0x00010B28
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x00012930 File Offset: 0x00010B30
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

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000884 RID: 2180 RVA: 0x0001293C File Offset: 0x00010B3C
		// (set) Token: 0x06000885 RID: 2181 RVA: 0x00012944 File Offset: 0x00010B44
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

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06000886 RID: 2182 RVA: 0x00012950 File Offset: 0x00010B50
		// (set) Token: 0x06000887 RID: 2183 RVA: 0x00012958 File Offset: 0x00010B58
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

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x00012964 File Offset: 0x00010B64
		// (set) Token: 0x06000889 RID: 2185 RVA: 0x0001296C File Offset: 0x00010B6C
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

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00012978 File Offset: 0x00010B78
		// (set) Token: 0x0600088B RID: 2187 RVA: 0x00012980 File Offset: 0x00010B80
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

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x0001298C File Offset: 0x00010B8C
		// (set) Token: 0x0600088D RID: 2189 RVA: 0x00012994 File Offset: 0x00010B94
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

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x000129A0 File Offset: 0x00010BA0
		// (set) Token: 0x0600088F RID: 2191 RVA: 0x000129A8 File Offset: 0x00010BA8
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

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x000129B4 File Offset: 0x00010BB4
		// (set) Token: 0x06000891 RID: 2193 RVA: 0x000129BC File Offset: 0x00010BBC
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

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000892 RID: 2194 RVA: 0x000129C8 File Offset: 0x00010BC8
		// (set) Token: 0x06000893 RID: 2195 RVA: 0x000129D0 File Offset: 0x00010BD0
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

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000894 RID: 2196 RVA: 0x000129DC File Offset: 0x00010BDC
		// (set) Token: 0x06000895 RID: 2197 RVA: 0x000129E4 File Offset: 0x00010BE4
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

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000896 RID: 2198 RVA: 0x000129F0 File Offset: 0x00010BF0
		// (set) Token: 0x06000897 RID: 2199 RVA: 0x000129F8 File Offset: 0x00010BF8
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

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x00012A04 File Offset: 0x00010C04
		// (set) Token: 0x06000899 RID: 2201 RVA: 0x00012A0C File Offset: 0x00010C0C
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

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x00012A18 File Offset: 0x00010C18
		// (set) Token: 0x0600089B RID: 2203 RVA: 0x00012A20 File Offset: 0x00010C20
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

		// Token: 0x040004A7 RID: 1191
		private LocalizableTextType displayNameField;

		// Token: 0x040004A8 RID: 1192
		private LocalizableTextType textField;

		// Token: 0x040004A9 RID: 1193
		private string colorField;

		// Token: 0x040004AA RID: 1194
		private string technicalNameField;

		// Token: 0x040004AB RID: 1195
		private string externalIdField;

		// Token: 0x040004AC RID: 1196
		private string shortIdField;

		// Token: 0x040004AD RID: 1197
		private FeaturesType featuresField;

		// Token: 0x040004AE RID: 1198
		private VisibilityType visibilityField;

		// Token: 0x040004AF RID: 1199
		private SelectabilityType selectabilityField;

		// Token: 0x040004B0 RID: 1200
		private PreviewImageType previewImageField;

		// Token: 0x040004B1 RID: 1201
		private string idField;

		// Token: 0x040004B2 RID: 1202
		private string objectTemplateReferenceField;

		// Token: 0x040004B3 RID: 1203
		private string objectTemplateReferenceNameField;

		// Token: 0x040004B4 RID: 1204
		private float xField;

		// Token: 0x040004B5 RID: 1205
		private float yField;

		// Token: 0x040004B6 RID: 1206
		private float zIndexField;
	}
}
