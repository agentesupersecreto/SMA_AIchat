using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FF RID: 511
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class VariableSetType
	{
		// Token: 0x170009E8 RID: 2536
		// (get) Token: 0x06001775 RID: 6005 RVA: 0x0001E04C File Offset: 0x0001C24C
		// (set) Token: 0x06001776 RID: 6006 RVA: 0x0001E054 File Offset: 0x0001C254
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

		// Token: 0x170009E9 RID: 2537
		// (get) Token: 0x06001777 RID: 6007 RVA: 0x0001E060 File Offset: 0x0001C260
		// (set) Token: 0x06001778 RID: 6008 RVA: 0x0001E068 File Offset: 0x0001C268
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

		// Token: 0x170009EA RID: 2538
		// (get) Token: 0x06001779 RID: 6009 RVA: 0x0001E074 File Offset: 0x0001C274
		// (set) Token: 0x0600177A RID: 6010 RVA: 0x0001E07C File Offset: 0x0001C27C
		public LocalizableTextType Description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		// Token: 0x170009EB RID: 2539
		// (get) Token: 0x0600177B RID: 6011 RVA: 0x0001E088 File Offset: 0x0001C288
		// (set) Token: 0x0600177C RID: 6012 RVA: 0x0001E090 File Offset: 0x0001C290
		public VariablesType Variables
		{
			get
			{
				return this.variablesField;
			}
			set
			{
				this.variablesField = value;
			}
		}

		// Token: 0x170009EC RID: 2540
		// (get) Token: 0x0600177D RID: 6013 RVA: 0x0001E09C File Offset: 0x0001C29C
		// (set) Token: 0x0600177E RID: 6014 RVA: 0x0001E0A4 File Offset: 0x0001C2A4
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

		// Token: 0x04000CE3 RID: 3299
		private string urlField;

		// Token: 0x04000CE4 RID: 3300
		private string technicalNameField;

		// Token: 0x04000CE5 RID: 3301
		private LocalizableTextType descriptionField;

		// Token: 0x04000CE6 RID: 3302
		private VariablesType variablesField;

		// Token: 0x04000CE7 RID: 3303
		private string idField;
	}
}
