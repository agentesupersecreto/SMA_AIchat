using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B2 RID: 434
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class EntityType
	{
		// Token: 0x170007EA RID: 2026
		// (get) Token: 0x06001340 RID: 4928 RVA: 0x0001B68C File Offset: 0x0001988C
		// (set) Token: 0x06001341 RID: 4929 RVA: 0x0001B694 File Offset: 0x00019894
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

		// Token: 0x170007EB RID: 2027
		// (get) Token: 0x06001342 RID: 4930 RVA: 0x0001B6A0 File Offset: 0x000198A0
		// (set) Token: 0x06001343 RID: 4931 RVA: 0x0001B6A8 File Offset: 0x000198A8
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

		// Token: 0x170007EC RID: 2028
		// (get) Token: 0x06001344 RID: 4932 RVA: 0x0001B6B4 File Offset: 0x000198B4
		// (set) Token: 0x06001345 RID: 4933 RVA: 0x0001B6BC File Offset: 0x000198BC
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

		// Token: 0x170007ED RID: 2029
		// (get) Token: 0x06001346 RID: 4934 RVA: 0x0001B6C8 File Offset: 0x000198C8
		// (set) Token: 0x06001347 RID: 4935 RVA: 0x0001B6D0 File Offset: 0x000198D0
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

		// Token: 0x170007EE RID: 2030
		// (get) Token: 0x06001348 RID: 4936 RVA: 0x0001B6DC File Offset: 0x000198DC
		// (set) Token: 0x06001349 RID: 4937 RVA: 0x0001B6E4 File Offset: 0x000198E4
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

		// Token: 0x170007EF RID: 2031
		// (get) Token: 0x0600134A RID: 4938 RVA: 0x0001B6F0 File Offset: 0x000198F0
		// (set) Token: 0x0600134B RID: 4939 RVA: 0x0001B6F8 File Offset: 0x000198F8
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

		// Token: 0x170007F0 RID: 2032
		// (get) Token: 0x0600134C RID: 4940 RVA: 0x0001B704 File Offset: 0x00019904
		// (set) Token: 0x0600134D RID: 4941 RVA: 0x0001B70C File Offset: 0x0001990C
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

		// Token: 0x170007F1 RID: 2033
		// (get) Token: 0x0600134E RID: 4942 RVA: 0x0001B718 File Offset: 0x00019918
		// (set) Token: 0x0600134F RID: 4943 RVA: 0x0001B720 File Offset: 0x00019920
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

		// Token: 0x170007F2 RID: 2034
		// (get) Token: 0x06001350 RID: 4944 RVA: 0x0001B72C File Offset: 0x0001992C
		// (set) Token: 0x06001351 RID: 4945 RVA: 0x0001B734 File Offset: 0x00019934
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

		// Token: 0x170007F3 RID: 2035
		// (get) Token: 0x06001352 RID: 4946 RVA: 0x0001B740 File Offset: 0x00019940
		// (set) Token: 0x06001353 RID: 4947 RVA: 0x0001B748 File Offset: 0x00019948
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

		// Token: 0x170007F4 RID: 2036
		// (get) Token: 0x06001354 RID: 4948 RVA: 0x0001B754 File Offset: 0x00019954
		// (set) Token: 0x06001355 RID: 4949 RVA: 0x0001B75C File Offset: 0x0001995C
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

		// Token: 0x170007F5 RID: 2037
		// (get) Token: 0x06001356 RID: 4950 RVA: 0x0001B768 File Offset: 0x00019968
		// (set) Token: 0x06001357 RID: 4951 RVA: 0x0001B770 File Offset: 0x00019970
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

		// Token: 0x170007F6 RID: 2038
		// (get) Token: 0x06001358 RID: 4952 RVA: 0x0001B77C File Offset: 0x0001997C
		// (set) Token: 0x06001359 RID: 4953 RVA: 0x0001B784 File Offset: 0x00019984
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

		// Token: 0x170007F7 RID: 2039
		// (get) Token: 0x0600135A RID: 4954 RVA: 0x0001B790 File Offset: 0x00019990
		// (set) Token: 0x0600135B RID: 4955 RVA: 0x0001B798 File Offset: 0x00019998
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

		// Token: 0x04000A83 RID: 2691
		private LocalizableTextType displayNameField;

		// Token: 0x04000A84 RID: 2692
		private LocalizableTextType textField;

		// Token: 0x04000A85 RID: 2693
		private string colorField;

		// Token: 0x04000A86 RID: 2694
		private string technicalNameField;

		// Token: 0x04000A87 RID: 2695
		private string externalIdField;

		// Token: 0x04000A88 RID: 2696
		private string shortIdField;

		// Token: 0x04000A89 RID: 2697
		private string urlField;

		// Token: 0x04000A8A RID: 2698
		private FeaturesType featuresField;

		// Token: 0x04000A8B RID: 2699
		private ReferencesType referencesField;

		// Token: 0x04000A8C RID: 2700
		private PreviewImageType previewImageField;

		// Token: 0x04000A8D RID: 2701
		private string[] text1Field;

		// Token: 0x04000A8E RID: 2702
		private string idField;

		// Token: 0x04000A8F RID: 2703
		private string objectTemplateReferenceField;

		// Token: 0x04000A90 RID: 2704
		private string objectTemplateReferenceNameField;
	}
}
