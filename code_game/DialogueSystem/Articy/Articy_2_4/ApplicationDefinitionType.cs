using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000170 RID: 368
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ApplicationDefinitionType
	{
		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x00018618 File Offset: 0x00016818
		// (set) Token: 0x06001020 RID: 4128 RVA: 0x00018620 File Offset: 0x00016820
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x0001862C File Offset: 0x0001682C
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x00018634 File Offset: 0x00016834
		public string Command
		{
			get
			{
				return this.commandField;
			}
			set
			{
				this.commandField = value;
			}
		}

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001023 RID: 4131 RVA: 0x00018640 File Offset: 0x00016840
		// (set) Token: 0x06001024 RID: 4132 RVA: 0x00018648 File Offset: 0x00016848
		public string WorkingDirectory
		{
			get
			{
				return this.workingDirectoryField;
			}
			set
			{
				this.workingDirectoryField = value;
			}
		}

		// Token: 0x040008D2 RID: 2258
		private string nameField;

		// Token: 0x040008D3 RID: 2259
		private string commandField;

		// Token: 0x040008D4 RID: 2260
		private string workingDirectoryField;
	}
}
