using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000189 RID: 393
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class SettingsType
	{
		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x060011B2 RID: 4530 RVA: 0x0001A73C File Offset: 0x0001893C
		// (set) Token: 0x060011B3 RID: 4531 RVA: 0x0001A744 File Offset: 0x00018944
		public bool ExportMarkup
		{
			get
			{
				return this.exportMarkupField;
			}
			set
			{
				this.exportMarkupField = value;
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x060011B4 RID: 4532 RVA: 0x0001A750 File Offset: 0x00018950
		// (set) Token: 0x060011B5 RID: 4533 RVA: 0x0001A758 File Offset: 0x00018958
		public bool ExportQueries
		{
			get
			{
				return this.exportQueriesField;
			}
			set
			{
				this.exportQueriesField = value;
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x060011B6 RID: 4534 RVA: 0x0001A764 File Offset: 0x00018964
		// (set) Token: 0x060011B7 RID: 4535 RVA: 0x0001A76C File Offset: 0x0001896C
		public bool WriteNamespace
		{
			get
			{
				return this.writeNamespaceField;
			}
			set
			{
				this.writeNamespaceField = value;
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x060011B8 RID: 4536 RVA: 0x0001A778 File Offset: 0x00018978
		// (set) Token: 0x060011B9 RID: 4537 RVA: 0x0001A780 File Offset: 0x00018980
		public bool WriteAllVariables
		{
			get
			{
				return this.writeAllVariablesField;
			}
			set
			{
				this.writeAllVariablesField = value;
			}
		}

		// Token: 0x040009C5 RID: 2501
		private bool exportMarkupField;

		// Token: 0x040009C6 RID: 2502
		private bool exportQueriesField;

		// Token: 0x040009C7 RID: 2503
		private bool writeNamespaceField;

		// Token: 0x040009C8 RID: 2504
		private bool writeAllVariablesField;
	}
}
