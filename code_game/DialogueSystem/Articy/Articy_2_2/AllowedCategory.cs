using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F9 RID: 249
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class AllowedCategory
	{
		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x00013B8C File Offset: 0x00011D8C
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x00013B94 File Offset: 0x00011D94
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

		// Token: 0x04000592 RID: 1426
		private AssetCategoryType nameField;
	}
}
