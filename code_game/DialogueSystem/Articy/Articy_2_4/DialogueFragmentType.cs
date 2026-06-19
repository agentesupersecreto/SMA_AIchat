using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000131 RID: 305
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class DialogueFragmentType
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000CB2 RID: 3250 RVA: 0x00016410 File Offset: 0x00014610
		// (set) Token: 0x06000CB3 RID: 3251 RVA: 0x00016418 File Offset: 0x00014618
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

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000CB4 RID: 3252 RVA: 0x00016424 File Offset: 0x00014624
		// (set) Token: 0x06000CB5 RID: 3253 RVA: 0x0001642C File Offset: 0x0001462C
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

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000CB6 RID: 3254 RVA: 0x00016438 File Offset: 0x00014638
		// (set) Token: 0x06000CB7 RID: 3255 RVA: 0x00016440 File Offset: 0x00014640
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

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000CB8 RID: 3256 RVA: 0x0001644C File Offset: 0x0001464C
		// (set) Token: 0x06000CB9 RID: 3257 RVA: 0x00016454 File Offset: 0x00014654
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

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000CBA RID: 3258 RVA: 0x00016460 File Offset: 0x00014660
		// (set) Token: 0x06000CBB RID: 3259 RVA: 0x00016468 File Offset: 0x00014668
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

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x00016474 File Offset: 0x00014674
		// (set) Token: 0x06000CBD RID: 3261 RVA: 0x0001647C File Offset: 0x0001467C
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

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000CBE RID: 3262 RVA: 0x00016488 File Offset: 0x00014688
		// (set) Token: 0x06000CBF RID: 3263 RVA: 0x00016490 File Offset: 0x00014690
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

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000CC0 RID: 3264 RVA: 0x0001649C File Offset: 0x0001469C
		// (set) Token: 0x06000CC1 RID: 3265 RVA: 0x000164A4 File Offset: 0x000146A4
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

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000CC2 RID: 3266 RVA: 0x000164B0 File Offset: 0x000146B0
		// (set) Token: 0x06000CC3 RID: 3267 RVA: 0x000164B8 File Offset: 0x000146B8
		public PinsType Pins
		{
			get
			{
				return this.pinsField;
			}
			set
			{
				this.pinsField = value;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000CC4 RID: 3268 RVA: 0x000164C4 File Offset: 0x000146C4
		// (set) Token: 0x06000CC5 RID: 3269 RVA: 0x000164CC File Offset: 0x000146CC
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

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000CC6 RID: 3270 RVA: 0x000164D8 File Offset: 0x000146D8
		// (set) Token: 0x06000CC7 RID: 3271 RVA: 0x000164E0 File Offset: 0x000146E0
		public SizeType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000CC8 RID: 3272 RVA: 0x000164EC File Offset: 0x000146EC
		// (set) Token: 0x06000CC9 RID: 3273 RVA: 0x000164F4 File Offset: 0x000146F4
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

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000CCA RID: 3274 RVA: 0x00016500 File Offset: 0x00014700
		// (set) Token: 0x06000CCB RID: 3275 RVA: 0x00016508 File Offset: 0x00014708
		public ReferenceType Speaker
		{
			get
			{
				return this.speakerField;
			}
			set
			{
				this.speakerField = value;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06000CCC RID: 3276 RVA: 0x00016514 File Offset: 0x00014714
		// (set) Token: 0x06000CCD RID: 3277 RVA: 0x0001651C File Offset: 0x0001471C
		public LocalizableTextType StageDirections
		{
			get
			{
				return this.stageDirectionsField;
			}
			set
			{
				this.stageDirectionsField = value;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06000CCE RID: 3278 RVA: 0x00016528 File Offset: 0x00014728
		// (set) Token: 0x06000CCF RID: 3279 RVA: 0x00016530 File Offset: 0x00014730
		public LocalizableTextType MenuText
		{
			get
			{
				return this.menuTextField;
			}
			set
			{
				this.menuTextField = value;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06000CD0 RID: 3280 RVA: 0x0001653C File Offset: 0x0001473C
		// (set) Token: 0x06000CD1 RID: 3281 RVA: 0x00016544 File Offset: 0x00014744
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

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06000CD2 RID: 3282 RVA: 0x00016550 File Offset: 0x00014750
		// (set) Token: 0x06000CD3 RID: 3283 RVA: 0x00016558 File Offset: 0x00014758
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

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06000CD4 RID: 3284 RVA: 0x00016564 File Offset: 0x00014764
		// (set) Token: 0x06000CD5 RID: 3285 RVA: 0x0001656C File Offset: 0x0001476C
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

		// Token: 0x040006DA RID: 1754
		private string displayNameField;

		// Token: 0x040006DB RID: 1755
		private LocalizableTextType textField;

		// Token: 0x040006DC RID: 1756
		private string colorField;

		// Token: 0x040006DD RID: 1757
		private string technicalNameField;

		// Token: 0x040006DE RID: 1758
		private string externalIdField;

		// Token: 0x040006DF RID: 1759
		private string shortIdField;

		// Token: 0x040006E0 RID: 1760
		private string urlField;

		// Token: 0x040006E1 RID: 1761
		private FeaturesType featuresField;

		// Token: 0x040006E2 RID: 1762
		private PinsType pinsField;

		// Token: 0x040006E3 RID: 1763
		private PointType positionField;

		// Token: 0x040006E4 RID: 1764
		private SizeType sizeField;

		// Token: 0x040006E5 RID: 1765
		private float zIndexField;

		// Token: 0x040006E6 RID: 1766
		private ReferenceType speakerField;

		// Token: 0x040006E7 RID: 1767
		private LocalizableTextType stageDirectionsField;

		// Token: 0x040006E8 RID: 1768
		private LocalizableTextType menuTextField;

		// Token: 0x040006E9 RID: 1769
		private string idField;

		// Token: 0x040006EA RID: 1770
		private string objectTemplateReferenceField;

		// Token: 0x040006EB RID: 1771
		private string objectTemplateReferenceNameField;
	}
}
