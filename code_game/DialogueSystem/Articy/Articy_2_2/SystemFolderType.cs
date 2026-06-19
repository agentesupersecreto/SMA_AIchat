using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000105 RID: 261
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class SystemFolderType
	{
		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x000142EC File Offset: 0x000124EC
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x000142F4 File Offset: 0x000124F4
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

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x00014300 File Offset: 0x00012500
		// (set) Token: 0x06000B20 RID: 2848 RVA: 0x00014308 File Offset: 0x00012508
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

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x00014314 File Offset: 0x00012514
		// (set) Token: 0x06000B22 RID: 2850 RVA: 0x0001431C File Offset: 0x0001251C
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

		// Token: 0x040005F2 RID: 1522
		private string displayNameField;

		// Token: 0x040005F3 RID: 1523
		private string colorField;

		// Token: 0x040005F4 RID: 1524
		private string idField;
	}
}
