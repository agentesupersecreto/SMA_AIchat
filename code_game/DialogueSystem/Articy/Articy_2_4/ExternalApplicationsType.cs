using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200016F RID: 367
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ExternalApplicationsType
	{
		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x000185FC File Offset: 0x000167FC
		// (set) Token: 0x0600101D RID: 4125 RVA: 0x00018604 File Offset: 0x00016804
		[XmlElement("ApplicationDefinition")]
		public ApplicationDefinitionType[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		// Token: 0x040008D1 RID: 2257
		private ApplicationDefinitionType[] itemsField;
	}
}
