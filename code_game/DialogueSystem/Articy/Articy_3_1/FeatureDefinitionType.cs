using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B6 RID: 438
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[Serializable]
	public class FeatureDefinitionType
	{
		// Token: 0x1700080B RID: 2059
		// (get) Token: 0x06001386 RID: 4998 RVA: 0x0001B940 File Offset: 0x00019B40
		// (set) Token: 0x06001387 RID: 4999 RVA: 0x0001B948 File Offset: 0x00019B48
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

		// Token: 0x1700080C RID: 2060
		// (get) Token: 0x06001388 RID: 5000 RVA: 0x0001B954 File Offset: 0x00019B54
		// (set) Token: 0x06001389 RID: 5001 RVA: 0x0001B95C File Offset: 0x00019B5C
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

		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x0600138A RID: 5002 RVA: 0x0001B968 File Offset: 0x00019B68
		// (set) Token: 0x0600138B RID: 5003 RVA: 0x0001B970 File Offset: 0x00019B70
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

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x0001B97C File Offset: 0x00019B7C
		// (set) Token: 0x0600138D RID: 5005 RVA: 0x0001B984 File Offset: 0x00019B84
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

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x0600138E RID: 5006 RVA: 0x0001B990 File Offset: 0x00019B90
		// (set) Token: 0x0600138F RID: 5007 RVA: 0x0001B998 File Offset: 0x00019B98
		public PropertyDefinitionsType PropertyDefinitions
		{
			get
			{
				return this.propertyDefinitionsField;
			}
			set
			{
				this.propertyDefinitionsField = value;
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001390 RID: 5008 RVA: 0x0001B9A4 File Offset: 0x00019BA4
		// (set) Token: 0x06001391 RID: 5009 RVA: 0x0001B9AC File Offset: 0x00019BAC
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

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x06001392 RID: 5010 RVA: 0x0001B9B8 File Offset: 0x00019BB8
		// (set) Token: 0x06001393 RID: 5011 RVA: 0x0001B9C0 File Offset: 0x00019BC0
		[XmlAttribute]
		public string BasedOn
		{
			get
			{
				return this.basedOnField;
			}
			set
			{
				this.basedOnField = value;
			}
		}

		// Token: 0x04000AA4 RID: 2724
		private LocalizableTextType displayNameField;

		// Token: 0x04000AA5 RID: 2725
		private string colorField;

		// Token: 0x04000AA6 RID: 2726
		private string technicalNameField;

		// Token: 0x04000AA7 RID: 2727
		private string urlField;

		// Token: 0x04000AA8 RID: 2728
		private PropertyDefinitionsType propertyDefinitionsField;

		// Token: 0x04000AA9 RID: 2729
		private string idField;

		// Token: 0x04000AAA RID: 2730
		private string basedOnField;
	}
}
