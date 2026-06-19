using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200016C RID: 364
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ProjectType
	{
		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x000184CC File Offset: 0x000166CC
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x000184D4 File Offset: 0x000166D4
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

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x000184E0 File Offset: 0x000166E0
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x000184E8 File Offset: 0x000166E8
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

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x000184F4 File Offset: 0x000166F4
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x000184FC File Offset: 0x000166FC
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

		// Token: 0x040008C3 RID: 2243
		private string displayNameField;

		// Token: 0x040008C4 RID: 2244
		private string urlField;

		// Token: 0x040008C5 RID: 2245
		private string idField;
	}
}
