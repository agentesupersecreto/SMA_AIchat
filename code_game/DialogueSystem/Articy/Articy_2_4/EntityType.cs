using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000133 RID: 307
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class EntityType
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000CEE RID: 3310 RVA: 0x00016664 File Offset: 0x00014864
		// (set) Token: 0x06000CEF RID: 3311 RVA: 0x0001666C File Offset: 0x0001486C
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

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000CF0 RID: 3312 RVA: 0x00016678 File Offset: 0x00014878
		// (set) Token: 0x06000CF1 RID: 3313 RVA: 0x00016680 File Offset: 0x00014880
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

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x0001668C File Offset: 0x0001488C
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x00016694 File Offset: 0x00014894
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

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x000166A0 File Offset: 0x000148A0
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x000166A8 File Offset: 0x000148A8
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

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x000166B4 File Offset: 0x000148B4
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x000166BC File Offset: 0x000148BC
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

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x000166C8 File Offset: 0x000148C8
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x000166D0 File Offset: 0x000148D0
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

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x000166DC File Offset: 0x000148DC
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x000166E4 File Offset: 0x000148E4
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

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x000166F0 File Offset: 0x000148F0
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x000166F8 File Offset: 0x000148F8
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

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x00016704 File Offset: 0x00014904
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0001670C File Offset: 0x0001490C
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

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x00016718 File Offset: 0x00014918
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x00016720 File Offset: 0x00014920
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

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x0001672C File Offset: 0x0001492C
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x00016734 File Offset: 0x00014934
		[XmlText]
		public string[] Text1
		{
			get
			{
				return this.text1Field;
			}
			set
			{
				this.text1Field = value;
			}
		}

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x00016740 File Offset: 0x00014940
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x00016748 File Offset: 0x00014948
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

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x00016754 File Offset: 0x00014954
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x0001675C File Offset: 0x0001495C
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

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00016768 File Offset: 0x00014968
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x00016770 File Offset: 0x00014970
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

		// Token: 0x040006F7 RID: 1783
		private LocalizableTextType displayNameField;

		// Token: 0x040006F8 RID: 1784
		private LocalizableTextType textField;

		// Token: 0x040006F9 RID: 1785
		private string colorField;

		// Token: 0x040006FA RID: 1786
		private string technicalNameField;

		// Token: 0x040006FB RID: 1787
		private string externalIdField;

		// Token: 0x040006FC RID: 1788
		private string shortIdField;

		// Token: 0x040006FD RID: 1789
		private string urlField;

		// Token: 0x040006FE RID: 1790
		private FeaturesType featuresField;

		// Token: 0x040006FF RID: 1791
		private ReferencesType referencesField;

		// Token: 0x04000700 RID: 1792
		private PreviewImageType previewImageField;

		// Token: 0x04000701 RID: 1793
		private string[] text1Field;

		// Token: 0x04000702 RID: 1794
		private string idField;

		// Token: 0x04000703 RID: 1795
		private string objectTemplateReferenceField;

		// Token: 0x04000704 RID: 1796
		private string objectTemplateReferenceNameField;
	}
}
