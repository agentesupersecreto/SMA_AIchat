using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000180 RID: 384
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VariableSetType
	{
		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001123 RID: 4387 RVA: 0x00019024 File Offset: 0x00017224
		// (set) Token: 0x06001124 RID: 4388 RVA: 0x0001902C File Offset: 0x0001722C
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

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001125 RID: 4389 RVA: 0x00019038 File Offset: 0x00017238
		// (set) Token: 0x06001126 RID: 4390 RVA: 0x00019040 File Offset: 0x00017240
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

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001127 RID: 4391 RVA: 0x0001904C File Offset: 0x0001724C
		// (set) Token: 0x06001128 RID: 4392 RVA: 0x00019054 File Offset: 0x00017254
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

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001129 RID: 4393 RVA: 0x00019060 File Offset: 0x00017260
		// (set) Token: 0x0600112A RID: 4394 RVA: 0x00019068 File Offset: 0x00017268
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

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x0600112B RID: 4395 RVA: 0x00019074 File Offset: 0x00017274
		// (set) Token: 0x0600112C RID: 4396 RVA: 0x0001907C File Offset: 0x0001727C
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

		// Token: 0x04000957 RID: 2391
		private string urlField;

		// Token: 0x04000958 RID: 2392
		private string technicalNameField;

		// Token: 0x04000959 RID: 2393
		private LocalizableTextType descriptionField;

		// Token: 0x0400095A RID: 2394
		private VariablesType variablesField;

		// Token: 0x0400095B RID: 2395
		private string idField;
	}
}
