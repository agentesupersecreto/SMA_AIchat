using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000069 RID: 105
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EntityType
	{
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0000EC44 File Offset: 0x0000CE44
		// (set) Token: 0x0600038C RID: 908 RVA: 0x0000EC4C File Offset: 0x0000CE4C
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

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000EC58 File Offset: 0x0000CE58
		// (set) Token: 0x0600038E RID: 910 RVA: 0x0000EC60 File Offset: 0x0000CE60
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

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x0600038F RID: 911 RVA: 0x0000EC6C File Offset: 0x0000CE6C
		// (set) Token: 0x06000390 RID: 912 RVA: 0x0000EC74 File Offset: 0x0000CE74
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

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000391 RID: 913 RVA: 0x0000EC80 File Offset: 0x0000CE80
		// (set) Token: 0x06000392 RID: 914 RVA: 0x0000EC88 File Offset: 0x0000CE88
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

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000393 RID: 915 RVA: 0x0000EC94 File Offset: 0x0000CE94
		// (set) Token: 0x06000394 RID: 916 RVA: 0x0000EC9C File Offset: 0x0000CE9C
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

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0000ECA8 File Offset: 0x0000CEA8
		// (set) Token: 0x06000396 RID: 918 RVA: 0x0000ECB0 File Offset: 0x0000CEB0
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

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000ECBC File Offset: 0x0000CEBC
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0000ECC4 File Offset: 0x0000CEC4
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

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000399 RID: 921 RVA: 0x0000ECD0 File Offset: 0x0000CED0
		// (set) Token: 0x0600039A RID: 922 RVA: 0x0000ECD8 File Offset: 0x0000CED8
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

		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000ECE4 File Offset: 0x0000CEE4
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000ECEC File Offset: 0x0000CEEC
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

		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000ECF8 File Offset: 0x0000CEF8
		// (set) Token: 0x0600039E RID: 926 RVA: 0x0000ED00 File Offset: 0x0000CF00
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

		// Token: 0x170000DA RID: 218
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0000ED0C File Offset: 0x0000CF0C
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x0000ED14 File Offset: 0x0000CF14
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

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000ED20 File Offset: 0x0000CF20
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x0000ED28 File Offset: 0x0000CF28
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

		// Token: 0x170000DC RID: 220
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000ED34 File Offset: 0x0000CF34
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x0000ED3C File Offset: 0x0000CF3C
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

		// Token: 0x040001F3 RID: 499
		private LocalizableTextType displayNameField;

		// Token: 0x040001F4 RID: 500
		private LocalizableTextType textField;

		// Token: 0x040001F5 RID: 501
		private string colorField;

		// Token: 0x040001F6 RID: 502
		private string technicalNameField;

		// Token: 0x040001F7 RID: 503
		private string externalIdField;

		// Token: 0x040001F8 RID: 504
		private string shortIdField;

		// Token: 0x040001F9 RID: 505
		private FeaturesType featuresField;

		// Token: 0x040001FA RID: 506
		private ReferencesType referencesField;

		// Token: 0x040001FB RID: 507
		private PreviewImageType previewImageField;

		// Token: 0x040001FC RID: 508
		private string[] text1Field;

		// Token: 0x040001FD RID: 509
		private string guidField;

		// Token: 0x040001FE RID: 510
		private string objectTemplateReferenceField;

		// Token: 0x040001FF RID: 511
		private string objectTemplateReferenceNameField;
	}
}
