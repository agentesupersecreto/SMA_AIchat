using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000088 RID: 136
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class DialogFragmentType
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		// (set) Token: 0x060004EE RID: 1262 RVA: 0x0000F9E8 File Offset: 0x0000DBE8
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

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x0000F9F4 File Offset: 0x0000DBF4
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0000F9FC File Offset: 0x0000DBFC
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

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060004F1 RID: 1265 RVA: 0x0000FA08 File Offset: 0x0000DC08
		// (set) Token: 0x060004F2 RID: 1266 RVA: 0x0000FA10 File Offset: 0x0000DC10
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

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060004F3 RID: 1267 RVA: 0x0000FA1C File Offset: 0x0000DC1C
		// (set) Token: 0x060004F4 RID: 1268 RVA: 0x0000FA24 File Offset: 0x0000DC24
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

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060004F5 RID: 1269 RVA: 0x0000FA30 File Offset: 0x0000DC30
		// (set) Token: 0x060004F6 RID: 1270 RVA: 0x0000FA38 File Offset: 0x0000DC38
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

		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000FA44 File Offset: 0x0000DC44
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x0000FA4C File Offset: 0x0000DC4C
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

		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060004F9 RID: 1273 RVA: 0x0000FA58 File Offset: 0x0000DC58
		// (set) Token: 0x060004FA RID: 1274 RVA: 0x0000FA60 File Offset: 0x0000DC60
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

		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060004FB RID: 1275 RVA: 0x0000FA6C File Offset: 0x0000DC6C
		// (set) Token: 0x060004FC RID: 1276 RVA: 0x0000FA74 File Offset: 0x0000DC74
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

		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0000FA80 File Offset: 0x0000DC80
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x0000FA88 File Offset: 0x0000DC88
		public ReferenceType Entity
		{
			get
			{
				return this.entityField;
			}
			set
			{
				this.entityField = value;
			}
		}

		// Token: 0x1700017C RID: 380
		// (get) Token: 0x060004FF RID: 1279 RVA: 0x0000FA94 File Offset: 0x0000DC94
		// (set) Token: 0x06000500 RID: 1280 RVA: 0x0000FA9C File Offset: 0x0000DC9C
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

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000501 RID: 1281 RVA: 0x0000FAA8 File Offset: 0x0000DCA8
		// (set) Token: 0x06000502 RID: 1282 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		public LocalizableTextType PreviewText
		{
			get
			{
				return this.previewTextField;
			}
			set
			{
				this.previewTextField = value;
			}
		}

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x0000FABC File Offset: 0x0000DCBC
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x0000FAC4 File Offset: 0x0000DCC4
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x0000FAD0 File Offset: 0x0000DCD0
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x0000FAD8 File Offset: 0x0000DCD8
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

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x0000FAE4 File Offset: 0x0000DCE4
		// (set) Token: 0x06000508 RID: 1288 RVA: 0x0000FAEC File Offset: 0x0000DCEC
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

		// Token: 0x040002A1 RID: 673
		private string displayNameField;

		// Token: 0x040002A2 RID: 674
		private LocalizableTextType textField;

		// Token: 0x040002A3 RID: 675
		private string colorField;

		// Token: 0x040002A4 RID: 676
		private string technicalNameField;

		// Token: 0x040002A5 RID: 677
		private string externalIdField;

		// Token: 0x040002A6 RID: 678
		private string shortIdField;

		// Token: 0x040002A7 RID: 679
		private FeaturesType featuresField;

		// Token: 0x040002A8 RID: 680
		private PinsType pinsField;

		// Token: 0x040002A9 RID: 681
		private ReferenceType entityField;

		// Token: 0x040002AA RID: 682
		private LocalizableTextType stageDirectionsField;

		// Token: 0x040002AB RID: 683
		private LocalizableTextType previewTextField;

		// Token: 0x040002AC RID: 684
		private string guidField;

		// Token: 0x040002AD RID: 685
		private string objectTemplateReferenceField;

		// Token: 0x040002AE RID: 686
		private string objectTemplateReferenceNameField;
	}
}
