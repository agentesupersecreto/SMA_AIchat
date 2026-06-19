using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001EE RID: 494
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[Serializable]
	public class ExternalApplicationsType
	{
		// Token: 0x1700096D RID: 2413
		// (get) Token: 0x06001670 RID: 5744 RVA: 0x0001D638 File Offset: 0x0001B838
		// (set) Token: 0x06001671 RID: 5745 RVA: 0x0001D640 File Offset: 0x0001B840
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

		// Token: 0x04000C5E RID: 3166
		private ApplicationDefinitionType[] itemsField;
	}
}
