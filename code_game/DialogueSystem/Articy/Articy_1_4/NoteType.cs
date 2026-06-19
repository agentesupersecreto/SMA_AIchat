using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000078 RID: 120
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NoteType
	{
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x060003EF RID: 1007 RVA: 0x0000F010 File Offset: 0x0000D210
		// (set) Token: 0x060003F0 RID: 1008 RVA: 0x0000F018 File Offset: 0x0000D218
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

		// Token: 0x170000FC RID: 252
		// (get) Token: 0x060003F1 RID: 1009 RVA: 0x0000F024 File Offset: 0x0000D224
		// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000F02C File Offset: 0x0000D22C
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

		// Token: 0x170000FD RID: 253
		// (get) Token: 0x060003F3 RID: 1011 RVA: 0x0000F038 File Offset: 0x0000D238
		// (set) Token: 0x060003F4 RID: 1012 RVA: 0x0000F040 File Offset: 0x0000D240
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

		// Token: 0x170000FE RID: 254
		// (get) Token: 0x060003F5 RID: 1013 RVA: 0x0000F04C File Offset: 0x0000D24C
		// (set) Token: 0x060003F6 RID: 1014 RVA: 0x0000F054 File Offset: 0x0000D254
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

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x060003F7 RID: 1015 RVA: 0x0000F060 File Offset: 0x0000D260
		// (set) Token: 0x060003F8 RID: 1016 RVA: 0x0000F068 File Offset: 0x0000D268
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

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x060003F9 RID: 1017 RVA: 0x0000F074 File Offset: 0x0000D274
		// (set) Token: 0x060003FA RID: 1018 RVA: 0x0000F07C File Offset: 0x0000D27C
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

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000F088 File Offset: 0x0000D288
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000F090 File Offset: 0x0000D290
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

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x060003FD RID: 1021 RVA: 0x0000F09C File Offset: 0x0000D29C
		// (set) Token: 0x060003FE RID: 1022 RVA: 0x0000F0A4 File Offset: 0x0000D2A4
		public NoteContentType NoteContent
		{
			get
			{
				return this.noteContentField;
			}
			set
			{
				this.noteContentField = value;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000F0B0 File Offset: 0x0000D2B0
		// (set) Token: 0x06000400 RID: 1024 RVA: 0x0000F0B8 File Offset: 0x0000D2B8
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

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000401 RID: 1025 RVA: 0x0000F0C4 File Offset: 0x0000D2C4
		// (set) Token: 0x06000402 RID: 1026 RVA: 0x0000F0CC File Offset: 0x0000D2CC
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

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000403 RID: 1027 RVA: 0x0000F0D8 File Offset: 0x0000D2D8
		// (set) Token: 0x06000404 RID: 1028 RVA: 0x0000F0E0 File Offset: 0x0000D2E0
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

		// Token: 0x04000222 RID: 546
		private LocalizableTextType displayNameField;

		// Token: 0x04000223 RID: 547
		private LocalizableTextType textField;

		// Token: 0x04000224 RID: 548
		private string colorField;

		// Token: 0x04000225 RID: 549
		private string technicalNameField;

		// Token: 0x04000226 RID: 550
		private string externalIdField;

		// Token: 0x04000227 RID: 551
		private string shortIdField;

		// Token: 0x04000228 RID: 552
		private FeaturesType featuresField;

		// Token: 0x04000229 RID: 553
		private NoteContentType noteContentField;

		// Token: 0x0400022A RID: 554
		private string guidField;

		// Token: 0x0400022B RID: 555
		private string objectTemplateReferenceField;

		// Token: 0x0400022C RID: 556
		private string objectTemplateReferenceNameField;
	}
}
