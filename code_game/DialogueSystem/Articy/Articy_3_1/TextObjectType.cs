using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FC RID: 508
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class TextObjectType
	{
		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x0600172E RID: 5934 RVA: 0x0001DD8C File Offset: 0x0001BF8C
		// (set) Token: 0x0600172F RID: 5935 RVA: 0x0001DD94 File Offset: 0x0001BF94
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

		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06001730 RID: 5936 RVA: 0x0001DDA0 File Offset: 0x0001BFA0
		// (set) Token: 0x06001731 RID: 5937 RVA: 0x0001DDA8 File Offset: 0x0001BFA8
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

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06001732 RID: 5938 RVA: 0x0001DDB4 File Offset: 0x0001BFB4
		// (set) Token: 0x06001733 RID: 5939 RVA: 0x0001DDBC File Offset: 0x0001BFBC
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

		// Token: 0x170009C9 RID: 2505
		// (get) Token: 0x06001734 RID: 5940 RVA: 0x0001DDC8 File Offset: 0x0001BFC8
		// (set) Token: 0x06001735 RID: 5941 RVA: 0x0001DDD0 File Offset: 0x0001BFD0
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

		// Token: 0x170009CA RID: 2506
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x0001DDDC File Offset: 0x0001BFDC
		// (set) Token: 0x06001737 RID: 5943 RVA: 0x0001DDE4 File Offset: 0x0001BFE4
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

		// Token: 0x170009CB RID: 2507
		// (get) Token: 0x06001738 RID: 5944 RVA: 0x0001DDF0 File Offset: 0x0001BFF0
		// (set) Token: 0x06001739 RID: 5945 RVA: 0x0001DDF8 File Offset: 0x0001BFF8
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

		// Token: 0x170009CC RID: 2508
		// (get) Token: 0x0600173A RID: 5946 RVA: 0x0001DE04 File Offset: 0x0001C004
		// (set) Token: 0x0600173B RID: 5947 RVA: 0x0001DE0C File Offset: 0x0001C00C
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

		// Token: 0x170009CD RID: 2509
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0001DE18 File Offset: 0x0001C018
		// (set) Token: 0x0600173D RID: 5949 RVA: 0x0001DE20 File Offset: 0x0001C020
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

		// Token: 0x170009CE RID: 2510
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0001DE2C File Offset: 0x0001C02C
		// (set) Token: 0x0600173F RID: 5951 RVA: 0x0001DE34 File Offset: 0x0001C034
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

		// Token: 0x170009CF RID: 2511
		// (get) Token: 0x06001740 RID: 5952 RVA: 0x0001DE40 File Offset: 0x0001C040
		// (set) Token: 0x06001741 RID: 5953 RVA: 0x0001DE48 File Offset: 0x0001C048
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

		// Token: 0x170009D0 RID: 2512
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x0001DE54 File Offset: 0x0001C054
		// (set) Token: 0x06001743 RID: 5955 RVA: 0x0001DE5C File Offset: 0x0001C05C
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

		// Token: 0x170009D1 RID: 2513
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x0001DE68 File Offset: 0x0001C068
		// (set) Token: 0x06001745 RID: 5957 RVA: 0x0001DE70 File Offset: 0x0001C070
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

		// Token: 0x170009D2 RID: 2514
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x0001DE7C File Offset: 0x0001C07C
		// (set) Token: 0x06001747 RID: 5959 RVA: 0x0001DE84 File Offset: 0x0001C084
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

		// Token: 0x04000CC1 RID: 3265
		private LocalizableTextType displayNameField;

		// Token: 0x04000CC2 RID: 3266
		private LocalizableTextType textField;

		// Token: 0x04000CC3 RID: 3267
		private string colorField;

		// Token: 0x04000CC4 RID: 3268
		private string technicalNameField;

		// Token: 0x04000CC5 RID: 3269
		private string externalIdField;

		// Token: 0x04000CC6 RID: 3270
		private string shortIdField;

		// Token: 0x04000CC7 RID: 3271
		private string urlField;

		// Token: 0x04000CC8 RID: 3272
		private FeaturesType featuresField;

		// Token: 0x04000CC9 RID: 3273
		private ReferencesType referencesField;

		// Token: 0x04000CCA RID: 3274
		private PreviewImageType previewImageField;

		// Token: 0x04000CCB RID: 3275
		private string idField;

		// Token: 0x04000CCC RID: 3276
		private string objectTemplateReferenceField;

		// Token: 0x04000CCD RID: 3277
		private string objectTemplateReferenceNameField;
	}
}
