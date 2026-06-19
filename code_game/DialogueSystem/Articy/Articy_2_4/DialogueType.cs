using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000130 RID: 304
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class DialogueType
	{
		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000C8F RID: 3215 RVA: 0x000162B4 File Offset: 0x000144B4
		// (set) Token: 0x06000C90 RID: 3216 RVA: 0x000162BC File Offset: 0x000144BC
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

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000C91 RID: 3217 RVA: 0x000162C8 File Offset: 0x000144C8
		// (set) Token: 0x06000C92 RID: 3218 RVA: 0x000162D0 File Offset: 0x000144D0
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

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000C93 RID: 3219 RVA: 0x000162DC File Offset: 0x000144DC
		// (set) Token: 0x06000C94 RID: 3220 RVA: 0x000162E4 File Offset: 0x000144E4
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

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x000162F0 File Offset: 0x000144F0
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x000162F8 File Offset: 0x000144F8
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

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00016304 File Offset: 0x00014504
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x0001630C File Offset: 0x0001450C
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

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00016318 File Offset: 0x00014518
		// (set) Token: 0x06000C9A RID: 3226 RVA: 0x00016320 File Offset: 0x00014520
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

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0001632C File Offset: 0x0001452C
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x00016334 File Offset: 0x00014534
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

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x00016340 File Offset: 0x00014540
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00016348 File Offset: 0x00014548
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

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00016354 File Offset: 0x00014554
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x0001635C File Offset: 0x0001455C
		public ReferencesType References
		{
			get
			{
				return this.referencesField;
			}
			set
			{
				this.referencesField = value;
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x00016368 File Offset: 0x00014568
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x00016370 File Offset: 0x00014570
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

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0001637C File Offset: 0x0001457C
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x00016384 File Offset: 0x00014584
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

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000CA5 RID: 3237 RVA: 0x00016390 File Offset: 0x00014590
		// (set) Token: 0x06000CA6 RID: 3238 RVA: 0x00016398 File Offset: 0x00014598
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

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06000CA7 RID: 3239 RVA: 0x000163A4 File Offset: 0x000145A4
		// (set) Token: 0x06000CA8 RID: 3240 RVA: 0x000163AC File Offset: 0x000145AC
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

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06000CA9 RID: 3241 RVA: 0x000163B8 File Offset: 0x000145B8
		// (set) Token: 0x06000CAA RID: 3242 RVA: 0x000163C0 File Offset: 0x000145C0
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

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06000CAB RID: 3243 RVA: 0x000163CC File Offset: 0x000145CC
		// (set) Token: 0x06000CAC RID: 3244 RVA: 0x000163D4 File Offset: 0x000145D4
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

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06000CAD RID: 3245 RVA: 0x000163E0 File Offset: 0x000145E0
		// (set) Token: 0x06000CAE RID: 3246 RVA: 0x000163E8 File Offset: 0x000145E8
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

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000CAF RID: 3247 RVA: 0x000163F4 File Offset: 0x000145F4
		// (set) Token: 0x06000CB0 RID: 3248 RVA: 0x000163FC File Offset: 0x000145FC
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

		// Token: 0x040006C9 RID: 1737
		private LocalizableTextType displayNameField;

		// Token: 0x040006CA RID: 1738
		private LocalizableTextType textField;

		// Token: 0x040006CB RID: 1739
		private string colorField;

		// Token: 0x040006CC RID: 1740
		private string technicalNameField;

		// Token: 0x040006CD RID: 1741
		private string externalIdField;

		// Token: 0x040006CE RID: 1742
		private string shortIdField;

		// Token: 0x040006CF RID: 1743
		private string urlField;

		// Token: 0x040006D0 RID: 1744
		private FeaturesType featuresField;

		// Token: 0x040006D1 RID: 1745
		private ReferencesType referencesField;

		// Token: 0x040006D2 RID: 1746
		private PreviewImageType previewImageField;

		// Token: 0x040006D3 RID: 1747
		private PinsType pinsField;

		// Token: 0x040006D4 RID: 1748
		private PointType positionField;

		// Token: 0x040006D5 RID: 1749
		private SizeType sizeField;

		// Token: 0x040006D6 RID: 1750
		private float zIndexField;

		// Token: 0x040006D7 RID: 1751
		private string idField;

		// Token: 0x040006D8 RID: 1752
		private string objectTemplateReferenceField;

		// Token: 0x040006D9 RID: 1753
		private string objectTemplateReferenceNameField;
	}
}
