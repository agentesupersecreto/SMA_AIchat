using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B1 RID: 433
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class DocumentType
	{
		// Token: 0x170007DF RID: 2015
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x0001B5A8 File Offset: 0x000197A8
		// (set) Token: 0x0600132A RID: 4906 RVA: 0x0001B5B0 File Offset: 0x000197B0
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

		// Token: 0x170007E0 RID: 2016
		// (get) Token: 0x0600132B RID: 4907 RVA: 0x0001B5BC File Offset: 0x000197BC
		// (set) Token: 0x0600132C RID: 4908 RVA: 0x0001B5C4 File Offset: 0x000197C4
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

		// Token: 0x170007E1 RID: 2017
		// (get) Token: 0x0600132D RID: 4909 RVA: 0x0001B5D0 File Offset: 0x000197D0
		// (set) Token: 0x0600132E RID: 4910 RVA: 0x0001B5D8 File Offset: 0x000197D8
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

		// Token: 0x170007E2 RID: 2018
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x0001B5E4 File Offset: 0x000197E4
		// (set) Token: 0x06001330 RID: 4912 RVA: 0x0001B5EC File Offset: 0x000197EC
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

		// Token: 0x170007E3 RID: 2019
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x0001B5F8 File Offset: 0x000197F8
		// (set) Token: 0x06001332 RID: 4914 RVA: 0x0001B600 File Offset: 0x00019800
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

		// Token: 0x170007E4 RID: 2020
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x0001B60C File Offset: 0x0001980C
		// (set) Token: 0x06001334 RID: 4916 RVA: 0x0001B614 File Offset: 0x00019814
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

		// Token: 0x170007E5 RID: 2021
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x0001B620 File Offset: 0x00019820
		// (set) Token: 0x06001336 RID: 4918 RVA: 0x0001B628 File Offset: 0x00019828
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

		// Token: 0x170007E6 RID: 2022
		// (get) Token: 0x06001337 RID: 4919 RVA: 0x0001B634 File Offset: 0x00019834
		// (set) Token: 0x06001338 RID: 4920 RVA: 0x0001B63C File Offset: 0x0001983C
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

		// Token: 0x170007E7 RID: 2023
		// (get) Token: 0x06001339 RID: 4921 RVA: 0x0001B648 File Offset: 0x00019848
		// (set) Token: 0x0600133A RID: 4922 RVA: 0x0001B650 File Offset: 0x00019850
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

		// Token: 0x170007E8 RID: 2024
		// (get) Token: 0x0600133B RID: 4923 RVA: 0x0001B65C File Offset: 0x0001985C
		// (set) Token: 0x0600133C RID: 4924 RVA: 0x0001B664 File Offset: 0x00019864
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

		// Token: 0x170007E9 RID: 2025
		// (get) Token: 0x0600133D RID: 4925 RVA: 0x0001B670 File Offset: 0x00019870
		// (set) Token: 0x0600133E RID: 4926 RVA: 0x0001B678 File Offset: 0x00019878
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

		// Token: 0x04000A78 RID: 2680
		private LocalizableTextType displayNameField;

		// Token: 0x04000A79 RID: 2681
		private LocalizableTextType textField;

		// Token: 0x04000A7A RID: 2682
		private string colorField;

		// Token: 0x04000A7B RID: 2683
		private string technicalNameField;

		// Token: 0x04000A7C RID: 2684
		private string externalIdField;

		// Token: 0x04000A7D RID: 2685
		private string shortIdField;

		// Token: 0x04000A7E RID: 2686
		private string urlField;

		// Token: 0x04000A7F RID: 2687
		private FeaturesType featuresField;

		// Token: 0x04000A80 RID: 2688
		private string idField;

		// Token: 0x04000A81 RID: 2689
		private string objectTemplateReferenceField;

		// Token: 0x04000A82 RID: 2690
		private string objectTemplateReferenceNameField;
	}
}
