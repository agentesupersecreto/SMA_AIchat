using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001EB RID: 491
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ProjectType
	{
		// Token: 0x1700095E RID: 2398
		// (get) Token: 0x0600164F RID: 5711 RVA: 0x0001D4F4 File Offset: 0x0001B6F4
		// (set) Token: 0x06001650 RID: 5712 RVA: 0x0001D4FC File Offset: 0x0001B6FC
		public string DisplayName
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

		// Token: 0x1700095F RID: 2399
		// (get) Token: 0x06001651 RID: 5713 RVA: 0x0001D508 File Offset: 0x0001B708
		// (set) Token: 0x06001652 RID: 5714 RVA: 0x0001D510 File Offset: 0x0001B710
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

		// Token: 0x17000960 RID: 2400
		// (get) Token: 0x06001653 RID: 5715 RVA: 0x0001D51C File Offset: 0x0001B71C
		// (set) Token: 0x06001654 RID: 5716 RVA: 0x0001D524 File Offset: 0x0001B724
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

		// Token: 0x17000961 RID: 2401
		// (get) Token: 0x06001655 RID: 5717 RVA: 0x0001D530 File Offset: 0x0001B730
		// (set) Token: 0x06001656 RID: 5718 RVA: 0x0001D538 File Offset: 0x0001B738
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

		// Token: 0x04000C4F RID: 3151
		private string displayNameField;

		// Token: 0x04000C50 RID: 3152
		private string technicalNameField;

		// Token: 0x04000C51 RID: 3153
		private string urlField;

		// Token: 0x04000C52 RID: 3154
		private string idField;
	}
}
