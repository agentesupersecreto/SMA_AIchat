using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000106 RID: 262
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ProjectType
	{
		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000B24 RID: 2852 RVA: 0x00014330 File Offset: 0x00012530
		// (set) Token: 0x06000B25 RID: 2853 RVA: 0x00014338 File Offset: 0x00012538
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

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000B26 RID: 2854 RVA: 0x00014344 File Offset: 0x00012544
		// (set) Token: 0x06000B27 RID: 2855 RVA: 0x0001434C File Offset: 0x0001254C
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

		// Token: 0x040005F5 RID: 1525
		private string displayNameField;

		// Token: 0x040005F6 RID: 1526
		private string idField;
	}
}
