using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000124 RID: 292
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class SystemFolderType
	{
		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x00015D20 File Offset: 0x00013F20
		// (set) Token: 0x06000BFF RID: 3071 RVA: 0x00015D28 File Offset: 0x00013F28
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

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x00015D34 File Offset: 0x00013F34
		// (set) Token: 0x06000C01 RID: 3073 RVA: 0x00015D3C File Offset: 0x00013F3C
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

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x00015D48 File Offset: 0x00013F48
		// (set) Token: 0x06000C03 RID: 3075 RVA: 0x00015D50 File Offset: 0x00013F50
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

		// Token: 0x04000683 RID: 1667
		private string displayNameField;

		// Token: 0x04000684 RID: 1668
		private string colorField;

		// Token: 0x04000685 RID: 1669
		private string idField;
	}
}
