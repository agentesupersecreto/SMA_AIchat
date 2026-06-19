using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000079 RID: 121
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class LinkType
	{
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0000F0F4 File Offset: 0x0000D2F4
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x0000F0FC File Offset: 0x0000D2FC
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

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x0000F108 File Offset: 0x0000D308
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x0000F110 File Offset: 0x0000D310
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

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x0000F11C File Offset: 0x0000D31C
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x0000F124 File Offset: 0x0000D324
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

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x0000F130 File Offset: 0x0000D330
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x0000F138 File Offset: 0x0000D338
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

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x0000F144 File Offset: 0x0000D344
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x0000F14C File Offset: 0x0000D34C
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

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06000410 RID: 1040 RVA: 0x0000F158 File Offset: 0x0000D358
		// (set) Token: 0x06000411 RID: 1041 RVA: 0x0000F160 File Offset: 0x0000D360
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

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06000412 RID: 1042 RVA: 0x0000F16C File Offset: 0x0000D36C
		// (set) Token: 0x06000413 RID: 1043 RVA: 0x0000F174 File Offset: 0x0000D374
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

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06000414 RID: 1044 RVA: 0x0000F180 File Offset: 0x0000D380
		// (set) Token: 0x06000415 RID: 1045 RVA: 0x0000F188 File Offset: 0x0000D388
		public ReferenceType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x0000F194 File Offset: 0x0000D394
		// (set) Token: 0x06000417 RID: 1047 RVA: 0x0000F19C File Offset: 0x0000D39C
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

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06000418 RID: 1048 RVA: 0x0000F1A8 File Offset: 0x0000D3A8
		// (set) Token: 0x06000419 RID: 1049 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
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

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000F1BC File Offset: 0x0000D3BC
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000F1C4 File Offset: 0x0000D3C4
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

		// Token: 0x0400022D RID: 557
		private string displayNameField;

		// Token: 0x0400022E RID: 558
		private LocalizableTextType textField;

		// Token: 0x0400022F RID: 559
		private string colorField;

		// Token: 0x04000230 RID: 560
		private string technicalNameField;

		// Token: 0x04000231 RID: 561
		private string externalIdField;

		// Token: 0x04000232 RID: 562
		private string shortIdField;

		// Token: 0x04000233 RID: 563
		private FeaturesType featuresField;

		// Token: 0x04000234 RID: 564
		private ReferenceType targetField;

		// Token: 0x04000235 RID: 565
		private string guidField;

		// Token: 0x04000236 RID: 566
		private string objectTemplateReferenceField;

		// Token: 0x04000237 RID: 567
		private string objectTemplateReferenceNameField;
	}
}
