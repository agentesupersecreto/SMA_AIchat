using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200007A RID: 122
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class PathType
	{
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x0600041D RID: 1053 RVA: 0x0000F1D8 File Offset: 0x0000D3D8
		// (set) Token: 0x0600041E RID: 1054 RVA: 0x0000F1E0 File Offset: 0x0000D3E0
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

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000F1EC File Offset: 0x0000D3EC
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x0000F1F4 File Offset: 0x0000D3F4
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

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06000421 RID: 1057 RVA: 0x0000F200 File Offset: 0x0000D400
		// (set) Token: 0x06000422 RID: 1058 RVA: 0x0000F208 File Offset: 0x0000D408
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

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000F214 File Offset: 0x0000D414
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000F21C File Offset: 0x0000D41C
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

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06000425 RID: 1061 RVA: 0x0000F228 File Offset: 0x0000D428
		// (set) Token: 0x06000426 RID: 1062 RVA: 0x0000F230 File Offset: 0x0000D430
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

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0000F23C File Offset: 0x0000D43C
		// (set) Token: 0x06000428 RID: 1064 RVA: 0x0000F244 File Offset: 0x0000D444
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

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000F250 File Offset: 0x0000D450
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0000F258 File Offset: 0x0000D458
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

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x0600042B RID: 1067 RVA: 0x0000F264 File Offset: 0x0000D464
		// (set) Token: 0x0600042C RID: 1068 RVA: 0x0000F26C File Offset: 0x0000D46C
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

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x0600042D RID: 1069 RVA: 0x0000F278 File Offset: 0x0000D478
		// (set) Token: 0x0600042E RID: 1070 RVA: 0x0000F280 File Offset: 0x0000D480
		public VerticesType Vertices
		{
			get
			{
				return this.verticesField;
			}
			set
			{
				this.verticesField = value;
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x0600042F RID: 1071 RVA: 0x0000F28C File Offset: 0x0000D48C
		// (set) Token: 0x06000430 RID: 1072 RVA: 0x0000F294 File Offset: 0x0000D494
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

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06000431 RID: 1073 RVA: 0x0000F2A0 File Offset: 0x0000D4A0
		// (set) Token: 0x06000432 RID: 1074 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
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

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000F2BC File Offset: 0x0000D4BC
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

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000F2C8 File Offset: 0x0000D4C8
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000F2D0 File Offset: 0x0000D4D0
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

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000437 RID: 1079 RVA: 0x0000F2DC File Offset: 0x0000D4DC
		// (set) Token: 0x06000438 RID: 1080 RVA: 0x0000F2E4 File Offset: 0x0000D4E4
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

		// Token: 0x04000238 RID: 568
		private LocalizableTextType displayNameField;

		// Token: 0x04000239 RID: 569
		private LocalizableTextType textField;

		// Token: 0x0400023A RID: 570
		private string colorField;

		// Token: 0x0400023B RID: 571
		private string technicalNameField;

		// Token: 0x0400023C RID: 572
		private string externalIdField;

		// Token: 0x0400023D RID: 573
		private string shortIdField;

		// Token: 0x0400023E RID: 574
		private FeaturesType featuresField;

		// Token: 0x0400023F RID: 575
		private PreviewImageType previewImageField;

		// Token: 0x04000240 RID: 576
		private VerticesType verticesField;

		// Token: 0x04000241 RID: 577
		private string guidField;

		// Token: 0x04000242 RID: 578
		private string objectTemplateReferenceField;

		// Token: 0x04000243 RID: 579
		private string objectTemplateReferenceNameField;

		// Token: 0x04000244 RID: 580
		private float xField;

		// Token: 0x04000245 RID: 581
		private float yField;
	}
}
