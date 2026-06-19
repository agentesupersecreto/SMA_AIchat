using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008A RID: 138
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class FlowFragmentType
	{
		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000525 RID: 1317 RVA: 0x0000FC0C File Offset: 0x0000DE0C
		// (set) Token: 0x06000526 RID: 1318 RVA: 0x0000FC14 File Offset: 0x0000DE14
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

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000527 RID: 1319 RVA: 0x0000FC20 File Offset: 0x0000DE20
		// (set) Token: 0x06000528 RID: 1320 RVA: 0x0000FC28 File Offset: 0x0000DE28
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

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000529 RID: 1321 RVA: 0x0000FC34 File Offset: 0x0000DE34
		// (set) Token: 0x0600052A RID: 1322 RVA: 0x0000FC3C File Offset: 0x0000DE3C
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

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600052B RID: 1323 RVA: 0x0000FC48 File Offset: 0x0000DE48
		// (set) Token: 0x0600052C RID: 1324 RVA: 0x0000FC50 File Offset: 0x0000DE50
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

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x0000FC5C File Offset: 0x0000DE5C
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x0000FC64 File Offset: 0x0000DE64
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

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x0000FC70 File Offset: 0x0000DE70
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x0000FC78 File Offset: 0x0000DE78
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

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x0000FC84 File Offset: 0x0000DE84
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x0000FC8C File Offset: 0x0000DE8C
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

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000FC98 File Offset: 0x0000DE98
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0000FCA0 File Offset: 0x0000DEA0
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

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000535 RID: 1333 RVA: 0x0000FCAC File Offset: 0x0000DEAC
		// (set) Token: 0x06000536 RID: 1334 RVA: 0x0000FCB4 File Offset: 0x0000DEB4
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

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0000FCC8 File Offset: 0x0000DEC8
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

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000FCD4 File Offset: 0x0000DED4
		// (set) Token: 0x0600053A RID: 1338 RVA: 0x0000FCDC File Offset: 0x0000DEDC
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

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x0000FCE8 File Offset: 0x0000DEE8
		// (set) Token: 0x0600053C RID: 1340 RVA: 0x0000FCF0 File Offset: 0x0000DEF0
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

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x0000FD04 File Offset: 0x0000DF04
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

		// Token: 0x040002BC RID: 700
		private LocalizableTextType displayNameField;

		// Token: 0x040002BD RID: 701
		private LocalizableTextType textField;

		// Token: 0x040002BE RID: 702
		private string colorField;

		// Token: 0x040002BF RID: 703
		private string technicalNameField;

		// Token: 0x040002C0 RID: 704
		private string externalIdField;

		// Token: 0x040002C1 RID: 705
		private string shortIdField;

		// Token: 0x040002C2 RID: 706
		private FeaturesType featuresField;

		// Token: 0x040002C3 RID: 707
		private ReferencesType referencesField;

		// Token: 0x040002C4 RID: 708
		private PreviewImageType previewImageField;

		// Token: 0x040002C5 RID: 709
		private PinsType pinsField;

		// Token: 0x040002C6 RID: 710
		private string guidField;

		// Token: 0x040002C7 RID: 711
		private string objectTemplateReferenceField;

		// Token: 0x040002C8 RID: 712
		private string objectTemplateReferenceNameField;
	}
}
