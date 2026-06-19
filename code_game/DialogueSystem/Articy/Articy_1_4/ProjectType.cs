using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x020000A3 RID: 163
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ProjectType
	{
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x000109B0 File Offset: 0x0000EBB0
		// (set) Token: 0x06000688 RID: 1672 RVA: 0x000109B8 File Offset: 0x0000EBB8
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

		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x000109C4 File Offset: 0x0000EBC4
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x000109CC File Offset: 0x0000EBCC
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x04000367 RID: 871
		private string displayNameField;

		// Token: 0x04000368 RID: 872
		private string guidField;
	}
}
