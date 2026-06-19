using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E9 RID: 233
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class DialogueType
	{
		// Token: 0x1700037A RID: 890
		// (get) Token: 0x0600096B RID: 2411 RVA: 0x0001322C File Offset: 0x0001142C
		// (set) Token: 0x0600096C RID: 2412 RVA: 0x00013234 File Offset: 0x00011434
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

		// Token: 0x1700037B RID: 891
		// (get) Token: 0x0600096D RID: 2413 RVA: 0x00013240 File Offset: 0x00011440
		// (set) Token: 0x0600096E RID: 2414 RVA: 0x00013248 File Offset: 0x00011448
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

		// Token: 0x1700037C RID: 892
		// (get) Token: 0x0600096F RID: 2415 RVA: 0x00013254 File Offset: 0x00011454
		// (set) Token: 0x06000970 RID: 2416 RVA: 0x0001325C File Offset: 0x0001145C
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

		// Token: 0x1700037D RID: 893
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x00013268 File Offset: 0x00011468
		// (set) Token: 0x06000972 RID: 2418 RVA: 0x00013270 File Offset: 0x00011470
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

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x0001327C File Offset: 0x0001147C
		// (set) Token: 0x06000974 RID: 2420 RVA: 0x00013284 File Offset: 0x00011484
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

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x00013290 File Offset: 0x00011490
		// (set) Token: 0x06000976 RID: 2422 RVA: 0x00013298 File Offset: 0x00011498
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

		// Token: 0x17000380 RID: 896
		// (get) Token: 0x06000977 RID: 2423 RVA: 0x000132A4 File Offset: 0x000114A4
		// (set) Token: 0x06000978 RID: 2424 RVA: 0x000132AC File Offset: 0x000114AC
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

		// Token: 0x17000381 RID: 897
		// (get) Token: 0x06000979 RID: 2425 RVA: 0x000132B8 File Offset: 0x000114B8
		// (set) Token: 0x0600097A RID: 2426 RVA: 0x000132C0 File Offset: 0x000114C0
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

		// Token: 0x17000382 RID: 898
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x000132CC File Offset: 0x000114CC
		// (set) Token: 0x0600097C RID: 2428 RVA: 0x000132D4 File Offset: 0x000114D4
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

		// Token: 0x17000383 RID: 899
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x000132E0 File Offset: 0x000114E0
		// (set) Token: 0x0600097E RID: 2430 RVA: 0x000132E8 File Offset: 0x000114E8
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

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x000132F4 File Offset: 0x000114F4
		// (set) Token: 0x06000980 RID: 2432 RVA: 0x000132FC File Offset: 0x000114FC
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

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000981 RID: 2433 RVA: 0x00013308 File Offset: 0x00011508
		// (set) Token: 0x06000982 RID: 2434 RVA: 0x00013310 File Offset: 0x00011510
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

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000983 RID: 2435 RVA: 0x0001331C File Offset: 0x0001151C
		// (set) Token: 0x06000984 RID: 2436 RVA: 0x00013324 File Offset: 0x00011524
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

		// Token: 0x0400051C RID: 1308
		private LocalizableTextType displayNameField;

		// Token: 0x0400051D RID: 1309
		private LocalizableTextType textField;

		// Token: 0x0400051E RID: 1310
		private string colorField;

		// Token: 0x0400051F RID: 1311
		private string technicalNameField;

		// Token: 0x04000520 RID: 1312
		private string externalIdField;

		// Token: 0x04000521 RID: 1313
		private string shortIdField;

		// Token: 0x04000522 RID: 1314
		private FeaturesType featuresField;

		// Token: 0x04000523 RID: 1315
		private ReferencesType referencesField;

		// Token: 0x04000524 RID: 1316
		private PreviewImageType previewImageField;

		// Token: 0x04000525 RID: 1317
		private PinsType pinsField;

		// Token: 0x04000526 RID: 1318
		private string idField;

		// Token: 0x04000527 RID: 1319
		private string objectTemplateReferenceField;

		// Token: 0x04000528 RID: 1320
		private string objectTemplateReferenceNameField;
	}
}
