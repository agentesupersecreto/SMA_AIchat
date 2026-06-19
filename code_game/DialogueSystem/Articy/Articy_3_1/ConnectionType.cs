using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001AD RID: 429
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class ConnectionType
	{
		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x060012C9 RID: 4809 RVA: 0x0001B1F0 File Offset: 0x000193F0
		// (set) Token: 0x060012CA RID: 4810 RVA: 0x0001B1F8 File Offset: 0x000193F8
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

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x060012CB RID: 4811 RVA: 0x0001B204 File Offset: 0x00019404
		// (set) Token: 0x060012CC RID: 4812 RVA: 0x0001B20C File Offset: 0x0001940C
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

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x060012CD RID: 4813 RVA: 0x0001B218 File Offset: 0x00019418
		// (set) Token: 0x060012CE RID: 4814 RVA: 0x0001B220 File Offset: 0x00019420
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

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x060012CF RID: 4815 RVA: 0x0001B22C File Offset: 0x0001942C
		// (set) Token: 0x060012D0 RID: 4816 RVA: 0x0001B234 File Offset: 0x00019434
		public LocalizableTextType Label
		{
			get
			{
				return this.labelField;
			}
			set
			{
				this.labelField = value;
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x060012D1 RID: 4817 RVA: 0x0001B240 File Offset: 0x00019440
		// (set) Token: 0x060012D2 RID: 4818 RVA: 0x0001B248 File Offset: 0x00019448
		public ConnectionRefType Source
		{
			get
			{
				return this.sourceField;
			}
			set
			{
				this.sourceField = value;
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x060012D3 RID: 4819 RVA: 0x0001B254 File Offset: 0x00019454
		// (set) Token: 0x060012D4 RID: 4820 RVA: 0x0001B25C File Offset: 0x0001945C
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x060012D5 RID: 4821 RVA: 0x0001B268 File Offset: 0x00019468
		// (set) Token: 0x060012D6 RID: 4822 RVA: 0x0001B270 File Offset: 0x00019470
		public bool ShowLabel
		{
			get
			{
				return this.showLabelField;
			}
			set
			{
				this.showLabelField = value;
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x060012D7 RID: 4823 RVA: 0x0001B27C File Offset: 0x0001947C
		// (set) Token: 0x060012D8 RID: 4824 RVA: 0x0001B284 File Offset: 0x00019484
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

		// Token: 0x04000A4A RID: 2634
		private string colorField;

		// Token: 0x04000A4B RID: 2635
		private string technicalNameField;

		// Token: 0x04000A4C RID: 2636
		private string urlField;

		// Token: 0x04000A4D RID: 2637
		private LocalizableTextType labelField;

		// Token: 0x04000A4E RID: 2638
		private ConnectionRefType sourceField;

		// Token: 0x04000A4F RID: 2639
		private ConnectionRefType targetField;

		// Token: 0x04000A50 RID: 2640
		private bool showLabelField;

		// Token: 0x04000A51 RID: 2641
		private string idField;
	}
}
