using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001D6 RID: 470
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class LocationType
	{
		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x060014DC RID: 5340 RVA: 0x0001C674 File Offset: 0x0001A874
		// (set) Token: 0x060014DD RID: 5341 RVA: 0x0001C67C File Offset: 0x0001A87C
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

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x060014DE RID: 5342 RVA: 0x0001C688 File Offset: 0x0001A888
		// (set) Token: 0x060014DF RID: 5343 RVA: 0x0001C690 File Offset: 0x0001A890
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

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x0001C69C File Offset: 0x0001A89C
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x0001C6A4 File Offset: 0x0001A8A4
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

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x060014E2 RID: 5346 RVA: 0x0001C6B0 File Offset: 0x0001A8B0
		// (set) Token: 0x060014E3 RID: 5347 RVA: 0x0001C6B8 File Offset: 0x0001A8B8
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

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x0001C6C4 File Offset: 0x0001A8C4
		// (set) Token: 0x060014E5 RID: 5349 RVA: 0x0001C6CC File Offset: 0x0001A8CC
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

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x060014E6 RID: 5350 RVA: 0x0001C6D8 File Offset: 0x0001A8D8
		// (set) Token: 0x060014E7 RID: 5351 RVA: 0x0001C6E0 File Offset: 0x0001A8E0
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

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x060014E8 RID: 5352 RVA: 0x0001C6EC File Offset: 0x0001A8EC
		// (set) Token: 0x060014E9 RID: 5353 RVA: 0x0001C6F4 File Offset: 0x0001A8F4
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

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x060014EA RID: 5354 RVA: 0x0001C700 File Offset: 0x0001A900
		// (set) Token: 0x060014EB RID: 5355 RVA: 0x0001C708 File Offset: 0x0001A908
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

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x060014EC RID: 5356 RVA: 0x0001C714 File Offset: 0x0001A914
		// (set) Token: 0x060014ED RID: 5357 RVA: 0x0001C71C File Offset: 0x0001A91C
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

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x060014EE RID: 5358 RVA: 0x0001C728 File Offset: 0x0001A928
		// (set) Token: 0x060014EF RID: 5359 RVA: 0x0001C730 File Offset: 0x0001A930
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

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x060014F0 RID: 5360 RVA: 0x0001C73C File Offset: 0x0001A93C
		// (set) Token: 0x060014F1 RID: 5361 RVA: 0x0001C744 File Offset: 0x0001A944
		public LocationSettingsType Settings
		{
			get
			{
				return this.settingsField;
			}
			set
			{
				this.settingsField = value;
			}
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x060014F2 RID: 5362 RVA: 0x0001C750 File Offset: 0x0001A950
		// (set) Token: 0x060014F3 RID: 5363 RVA: 0x0001C758 File Offset: 0x0001A958
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

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x060014F4 RID: 5364 RVA: 0x0001C764 File Offset: 0x0001A964
		// (set) Token: 0x060014F5 RID: 5365 RVA: 0x0001C76C File Offset: 0x0001A96C
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

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x060014F6 RID: 5366 RVA: 0x0001C778 File Offset: 0x0001A978
		// (set) Token: 0x060014F7 RID: 5367 RVA: 0x0001C780 File Offset: 0x0001A980
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

		// Token: 0x04000B80 RID: 2944
		private LocalizableTextType displayNameField;

		// Token: 0x04000B81 RID: 2945
		private LocalizableTextType textField;

		// Token: 0x04000B82 RID: 2946
		private string colorField;

		// Token: 0x04000B83 RID: 2947
		private string technicalNameField;

		// Token: 0x04000B84 RID: 2948
		private string externalIdField;

		// Token: 0x04000B85 RID: 2949
		private string shortIdField;

		// Token: 0x04000B86 RID: 2950
		private string urlField;

		// Token: 0x04000B87 RID: 2951
		private FeaturesType featuresField;

		// Token: 0x04000B88 RID: 2952
		private ReferencesType referencesField;

		// Token: 0x04000B89 RID: 2953
		private PreviewImageType previewImageField;

		// Token: 0x04000B8A RID: 2954
		private LocationSettingsType settingsField;

		// Token: 0x04000B8B RID: 2955
		private string idField;

		// Token: 0x04000B8C RID: 2956
		private string objectTemplateReferenceField;

		// Token: 0x04000B8D RID: 2957
		private string objectTemplateReferenceNameField;
	}
}
