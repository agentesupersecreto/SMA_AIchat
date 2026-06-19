using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D3 RID: 211
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EntityType
	{
		// Token: 0x170002BF RID: 703
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00012300 File Offset: 0x00010500
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00012308 File Offset: 0x00010508
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

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x00012314 File Offset: 0x00010514
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0001231C File Offset: 0x0001051C
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

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x00012328 File Offset: 0x00010528
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x00012330 File Offset: 0x00010530
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

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x0001233C File Offset: 0x0001053C
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x00012344 File Offset: 0x00010544
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

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x00012350 File Offset: 0x00010550
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x00012358 File Offset: 0x00010558
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

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x060007ED RID: 2029 RVA: 0x00012364 File Offset: 0x00010564
		// (set) Token: 0x060007EE RID: 2030 RVA: 0x0001236C File Offset: 0x0001056C
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

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00012378 File Offset: 0x00010578
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00012380 File Offset: 0x00010580
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

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x0001238C File Offset: 0x0001058C
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00012394 File Offset: 0x00010594
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

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x060007F3 RID: 2035 RVA: 0x000123A0 File Offset: 0x000105A0
		// (set) Token: 0x060007F4 RID: 2036 RVA: 0x000123A8 File Offset: 0x000105A8
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

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x000123B4 File Offset: 0x000105B4
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x000123BC File Offset: 0x000105BC
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

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x000123C8 File Offset: 0x000105C8
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x000123D0 File Offset: 0x000105D0
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

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x000123DC File Offset: 0x000105DC
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x000123E4 File Offset: 0x000105E4
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

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x000123F0 File Offset: 0x000105F0
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x000123F8 File Offset: 0x000105F8
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

		// Token: 0x04000454 RID: 1108
		private LocalizableTextType displayNameField;

		// Token: 0x04000455 RID: 1109
		private LocalizableTextType textField;

		// Token: 0x04000456 RID: 1110
		private string colorField;

		// Token: 0x04000457 RID: 1111
		private string technicalNameField;

		// Token: 0x04000458 RID: 1112
		private string externalIdField;

		// Token: 0x04000459 RID: 1113
		private string shortIdField;

		// Token: 0x0400045A RID: 1114
		private FeaturesType featuresField;

		// Token: 0x0400045B RID: 1115
		private ReferencesType referencesField;

		// Token: 0x0400045C RID: 1116
		private PreviewImageType previewImageField;

		// Token: 0x0400045D RID: 1117
		private string[] text1Field;

		// Token: 0x0400045E RID: 1118
		private string idField;

		// Token: 0x0400045F RID: 1119
		private string objectTemplateReferenceField;

		// Token: 0x04000460 RID: 1120
		private string objectTemplateReferenceNameField;
	}
}
