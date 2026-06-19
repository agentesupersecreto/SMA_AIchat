using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000089 RID: 137
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class DialogType
	{
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600050A RID: 1290 RVA: 0x0000FB00 File Offset: 0x0000DD00
		// (set) Token: 0x0600050B RID: 1291 RVA: 0x0000FB08 File Offset: 0x0000DD08
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

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600050C RID: 1292 RVA: 0x0000FB14 File Offset: 0x0000DD14
		// (set) Token: 0x0600050D RID: 1293 RVA: 0x0000FB1C File Offset: 0x0000DD1C
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x0000FB28 File Offset: 0x0000DD28
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x0000FB30 File Offset: 0x0000DD30
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

		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0000FB3C File Offset: 0x0000DD3C
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x0000FB44 File Offset: 0x0000DD44
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

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x0000FB50 File Offset: 0x0000DD50
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x0000FB58 File Offset: 0x0000DD58
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

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x0000FB64 File Offset: 0x0000DD64
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x0000FB6C File Offset: 0x0000DD6C
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

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x0000FB78 File Offset: 0x0000DD78
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x0000FB80 File Offset: 0x0000DD80
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

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x0000FB8C File Offset: 0x0000DD8C
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x0000FB94 File Offset: 0x0000DD94
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

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x0000FBA0 File Offset: 0x0000DDA0
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x0000FBB4 File Offset: 0x0000DDB4
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x0000FBBC File Offset: 0x0000DDBC
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

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x0000FBC8 File Offset: 0x0000DDC8
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x0000FBD0 File Offset: 0x0000DDD0
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

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x0000FBDC File Offset: 0x0000DDDC
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x0000FBE4 File Offset: 0x0000DDE4
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

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x0000FBF0 File Offset: 0x0000DDF0
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x0000FBF8 File Offset: 0x0000DDF8
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

		// Token: 0x040002AF RID: 687
		private LocalizableTextType displayNameField;

		// Token: 0x040002B0 RID: 688
		private LocalizableTextType textField;

		// Token: 0x040002B1 RID: 689
		private string colorField;

		// Token: 0x040002B2 RID: 690
		private string technicalNameField;

		// Token: 0x040002B3 RID: 691
		private string externalIdField;

		// Token: 0x040002B4 RID: 692
		private string shortIdField;

		// Token: 0x040002B5 RID: 693
		private FeaturesType featuresField;

		// Token: 0x040002B6 RID: 694
		private ReferencesType referencesField;

		// Token: 0x040002B7 RID: 695
		private PreviewImageType previewImageField;

		// Token: 0x040002B8 RID: 696
		private PinsType pinsField;

		// Token: 0x040002B9 RID: 697
		private string guidField;

		// Token: 0x040002BA RID: 698
		private string objectTemplateReferenceField;

		// Token: 0x040002BB RID: 699
		private string objectTemplateReferenceNameField;
	}
}
