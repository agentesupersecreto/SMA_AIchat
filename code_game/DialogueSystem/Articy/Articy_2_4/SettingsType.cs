using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200010A RID: 266
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class SettingsType
	{
		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000B60 RID: 2912 RVA: 0x00015714 File Offset: 0x00013914
		// (set) Token: 0x06000B61 RID: 2913 RVA: 0x0001571C File Offset: 0x0001391C
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

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000B62 RID: 2914 RVA: 0x00015728 File Offset: 0x00013928
		// (set) Token: 0x06000B63 RID: 2915 RVA: 0x00015730 File Offset: 0x00013930
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

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000B64 RID: 2916 RVA: 0x0001573C File Offset: 0x0001393C
		// (set) Token: 0x06000B65 RID: 2917 RVA: 0x00015744 File Offset: 0x00013944
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

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000B66 RID: 2918 RVA: 0x00015750 File Offset: 0x00013950
		// (set) Token: 0x06000B67 RID: 2919 RVA: 0x00015758 File Offset: 0x00013958
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

		// Token: 0x04000639 RID: 1593
		private bool exportMarkupField;

		// Token: 0x0400063A RID: 1594
		private bool exportQueriesField;

		// Token: 0x0400063B RID: 1595
		private bool writeNamespaceField;

		// Token: 0x0400063C RID: 1596
		private bool writeAllVariablesField;
	}
}
