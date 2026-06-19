using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000175 RID: 373
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class AllowedCategory
	{
		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x0600106A RID: 4202 RVA: 0x000188FC File Offset: 0x00016AFC
		// (set) Token: 0x0600106B RID: 4203 RVA: 0x00018904 File Offset: 0x00016B04
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

		// Token: 0x040008F5 RID: 2293
		private AssetCategoryType nameField;
	}
}
