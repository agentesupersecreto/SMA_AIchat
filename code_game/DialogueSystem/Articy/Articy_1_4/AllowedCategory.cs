using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000096 RID: 150
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class AllowedCategory
	{
		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x060005C3 RID: 1475 RVA: 0x00010220 File Offset: 0x0000E420
		// (set) Token: 0x060005C4 RID: 1476 RVA: 0x00010228 File Offset: 0x0000E428
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

		// Token: 0x04000305 RID: 773
		private AssetCategoryType nameField;
	}
}
