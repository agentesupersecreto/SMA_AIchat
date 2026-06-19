using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200017D RID: 381
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class TextObjectType
	{
		// Token: 0x170006E2 RID: 1762
		// (get) Token: 0x060010DA RID: 4314 RVA: 0x00018D50 File Offset: 0x00016F50
		// (set) Token: 0x060010DB RID: 4315 RVA: 0x00018D58 File Offset: 0x00016F58
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

		// Token: 0x170006E3 RID: 1763
		// (get) Token: 0x060010DC RID: 4316 RVA: 0x00018D64 File Offset: 0x00016F64
		// (set) Token: 0x060010DD RID: 4317 RVA: 0x00018D6C File Offset: 0x00016F6C
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

		// Token: 0x170006E4 RID: 1764
		// (get) Token: 0x060010DE RID: 4318 RVA: 0x00018D78 File Offset: 0x00016F78
		// (set) Token: 0x060010DF RID: 4319 RVA: 0x00018D80 File Offset: 0x00016F80
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

		// Token: 0x170006E5 RID: 1765
		// (get) Token: 0x060010E0 RID: 4320 RVA: 0x00018D8C File Offset: 0x00016F8C
		// (set) Token: 0x060010E1 RID: 4321 RVA: 0x00018D94 File Offset: 0x00016F94
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

		// Token: 0x170006E6 RID: 1766
		// (get) Token: 0x060010E2 RID: 4322 RVA: 0x00018DA0 File Offset: 0x00016FA0
		// (set) Token: 0x060010E3 RID: 4323 RVA: 0x00018DA8 File Offset: 0x00016FA8
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

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060010E4 RID: 4324 RVA: 0x00018DB4 File Offset: 0x00016FB4
		// (set) Token: 0x060010E5 RID: 4325 RVA: 0x00018DBC File Offset: 0x00016FBC
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

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x060010E6 RID: 4326 RVA: 0x00018DC8 File Offset: 0x00016FC8
		// (set) Token: 0x060010E7 RID: 4327 RVA: 0x00018DD0 File Offset: 0x00016FD0
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

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x060010E8 RID: 4328 RVA: 0x00018DDC File Offset: 0x00016FDC
		// (set) Token: 0x060010E9 RID: 4329 RVA: 0x00018DE4 File Offset: 0x00016FE4
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

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x060010EA RID: 4330 RVA: 0x00018DF0 File Offset: 0x00016FF0
		// (set) Token: 0x060010EB RID: 4331 RVA: 0x00018DF8 File Offset: 0x00016FF8
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

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x060010EC RID: 4332 RVA: 0x00018E04 File Offset: 0x00017004
		// (set) Token: 0x060010ED RID: 4333 RVA: 0x00018E0C File Offset: 0x0001700C
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

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x060010EE RID: 4334 RVA: 0x00018E18 File Offset: 0x00017018
		// (set) Token: 0x060010EF RID: 4335 RVA: 0x00018E20 File Offset: 0x00017020
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

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x060010F0 RID: 4336 RVA: 0x00018E2C File Offset: 0x0001702C
		// (set) Token: 0x060010F1 RID: 4337 RVA: 0x00018E34 File Offset: 0x00017034
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

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x060010F2 RID: 4338 RVA: 0x00018E40 File Offset: 0x00017040
		// (set) Token: 0x060010F3 RID: 4339 RVA: 0x00018E48 File Offset: 0x00017048
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

		// Token: 0x04000934 RID: 2356
		private LocalizableTextType displayNameField;

		// Token: 0x04000935 RID: 2357
		private LocalizableTextType textField;

		// Token: 0x04000936 RID: 2358
		private string colorField;

		// Token: 0x04000937 RID: 2359
		private string technicalNameField;

		// Token: 0x04000938 RID: 2360
		private string externalIdField;

		// Token: 0x04000939 RID: 2361
		private string shortIdField;

		// Token: 0x0400093A RID: 2362
		private string urlField;

		// Token: 0x0400093B RID: 2363
		private FeaturesType featuresField;

		// Token: 0x0400093C RID: 2364
		private ReferencesType referencesField;

		// Token: 0x0400093D RID: 2365
		private PreviewImageType previewImageField;

		// Token: 0x0400093E RID: 2366
		private string idField;

		// Token: 0x0400093F RID: 2367
		private string objectTemplateReferenceField;

		// Token: 0x04000940 RID: 2368
		private string objectTemplateReferenceNameField;
	}
}
