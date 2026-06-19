using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000132 RID: 306
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class DocumentType
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x00016580 File Offset: 0x00014780
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x00016588 File Offset: 0x00014788
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

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00016594 File Offset: 0x00014794
		// (set) Token: 0x06000CDA RID: 3290 RVA: 0x0001659C File Offset: 0x0001479C
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

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x000165A8 File Offset: 0x000147A8
		// (set) Token: 0x06000CDC RID: 3292 RVA: 0x000165B0 File Offset: 0x000147B0
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

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x000165BC File Offset: 0x000147BC
		// (set) Token: 0x06000CDE RID: 3294 RVA: 0x000165C4 File Offset: 0x000147C4
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

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x000165D0 File Offset: 0x000147D0
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x000165D8 File Offset: 0x000147D8
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

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x000165E4 File Offset: 0x000147E4
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x000165EC File Offset: 0x000147EC
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

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x000165F8 File Offset: 0x000147F8
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00016600 File Offset: 0x00014800
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

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x0001660C File Offset: 0x0001480C
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00016614 File Offset: 0x00014814
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

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00016620 File Offset: 0x00014820
		// (set) Token: 0x06000CE8 RID: 3304 RVA: 0x00016628 File Offset: 0x00014828
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

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000CE9 RID: 3305 RVA: 0x00016634 File Offset: 0x00014834
		// (set) Token: 0x06000CEA RID: 3306 RVA: 0x0001663C File Offset: 0x0001483C
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

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000CEB RID: 3307 RVA: 0x00016648 File Offset: 0x00014848
		// (set) Token: 0x06000CEC RID: 3308 RVA: 0x00016650 File Offset: 0x00014850
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

		// Token: 0x040006EC RID: 1772
		private LocalizableTextType displayNameField;

		// Token: 0x040006ED RID: 1773
		private LocalizableTextType textField;

		// Token: 0x040006EE RID: 1774
		private string colorField;

		// Token: 0x040006EF RID: 1775
		private string technicalNameField;

		// Token: 0x040006F0 RID: 1776
		private string externalIdField;

		// Token: 0x040006F1 RID: 1777
		private string shortIdField;

		// Token: 0x040006F2 RID: 1778
		private string urlField;

		// Token: 0x040006F3 RID: 1779
		private FeaturesType featuresField;

		// Token: 0x040006F4 RID: 1780
		private string idField;

		// Token: 0x040006F5 RID: 1781
		private string objectTemplateReferenceField;

		// Token: 0x040006F6 RID: 1782
		private string objectTemplateReferenceNameField;
	}
}
