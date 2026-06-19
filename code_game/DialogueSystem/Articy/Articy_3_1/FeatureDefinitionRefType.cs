using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E8 RID: 488
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class FeatureDefinitionRefType
	{
		// Token: 0x17000940 RID: 2368
		// (get) Token: 0x06001611 RID: 5649 RVA: 0x0001D28C File Offset: 0x0001B48C
		// (set) Token: 0x06001612 RID: 5650 RVA: 0x0001D294 File Offset: 0x0001B494
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

		// Token: 0x17000941 RID: 2369
		// (get) Token: 0x06001613 RID: 5651 RVA: 0x0001D2A0 File Offset: 0x0001B4A0
		// (set) Token: 0x06001614 RID: 5652 RVA: 0x0001D2A8 File Offset: 0x0001B4A8
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x04000C29 RID: 3113
		private string idRefField;

		// Token: 0x04000C2A RID: 3114
		private string valueField;
	}
}
