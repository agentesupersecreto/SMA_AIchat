using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000177 RID: 375
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class AllowedTemplate
	{
		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x00018918 File Offset: 0x00016B18
		// (set) Token: 0x0600106E RID: 4206 RVA: 0x00018920 File Offset: 0x00016B20
		[XmlAttribute]
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

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x0001892C File Offset: 0x00016B2C
		// (set) Token: 0x06001070 RID: 4208 RVA: 0x00018934 File Offset: 0x00016B34
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x040008FC RID: 2300
		private string nameField;

		// Token: 0x040008FD RID: 2301
		private string idRefField;
	}
}
