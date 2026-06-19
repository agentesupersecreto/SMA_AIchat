using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F4 RID: 500
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class AllowedCategory
	{
		// Token: 0x17000991 RID: 2449
		// (get) Token: 0x060016BE RID: 5822 RVA: 0x0001D938 File Offset: 0x0001BB38
		// (set) Token: 0x060016BF RID: 5823 RVA: 0x0001D940 File Offset: 0x0001BB40
		[XmlAttribute]
		public AssetCategoryType Name
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

		// Token: 0x04000C82 RID: 3202
		private AssetCategoryType nameField;
	}
}
