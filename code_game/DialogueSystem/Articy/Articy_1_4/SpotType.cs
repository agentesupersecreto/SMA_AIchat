using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000080 RID: 128
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class SpotType
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x0000F4BC File Offset: 0x0000D6BC
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x0000F4C4 File Offset: 0x0000D6C4
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

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x0000F4D0 File Offset: 0x0000D6D0
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
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

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x0000F4E4 File Offset: 0x0000D6E4
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x0000F4EC File Offset: 0x0000D6EC
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

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0000F4F8 File Offset: 0x0000D6F8
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x0000F500 File Offset: 0x0000D700
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

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000F50C File Offset: 0x0000D70C
		// (set) Token: 0x06000471 RID: 1137 RVA: 0x0000F514 File Offset: 0x0000D714
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

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x0000F520 File Offset: 0x0000D720
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x0000F528 File Offset: 0x0000D728
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

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000F534 File Offset: 0x0000D734
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x0000F53C File Offset: 0x0000D73C
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

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x0000F548 File Offset: 0x0000D748
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x0000F550 File Offset: 0x0000D750
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

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000478 RID: 1144 RVA: 0x0000F55C File Offset: 0x0000D75C
		// (set) Token: 0x06000479 RID: 1145 RVA: 0x0000F564 File Offset: 0x0000D764
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

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000F570 File Offset: 0x0000D770
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x0000F578 File Offset: 0x0000D778
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

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x0000F584 File Offset: 0x0000D784
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x0000F58C File Offset: 0x0000D78C
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

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0000F598 File Offset: 0x0000D798
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x0000F5A0 File Offset: 0x0000D7A0
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

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0000F5AC File Offset: 0x0000D7AC
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x0000F5B4 File Offset: 0x0000D7B4
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

		// Token: 0x0400025F RID: 607
		private LocalizableTextType displayNameField;

		// Token: 0x04000260 RID: 608
		private LocalizableTextType textField;

		// Token: 0x04000261 RID: 609
		private string colorField;

		// Token: 0x04000262 RID: 610
		private string technicalNameField;

		// Token: 0x04000263 RID: 611
		private string externalIdField;

		// Token: 0x04000264 RID: 612
		private string shortIdField;

		// Token: 0x04000265 RID: 613
		private FeaturesType featuresField;

		// Token: 0x04000266 RID: 614
		private PreviewImageType previewImageField;

		// Token: 0x04000267 RID: 615
		private string guidField;

		// Token: 0x04000268 RID: 616
		private string objectTemplateReferenceField;

		// Token: 0x04000269 RID: 617
		private string objectTemplateReferenceNameField;

		// Token: 0x0400026A RID: 618
		private float xField;

		// Token: 0x0400026B RID: 619
		private float yField;
	}
}
