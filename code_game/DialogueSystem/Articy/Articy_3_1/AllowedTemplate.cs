using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F6 RID: 502
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class AllowedTemplate
	{
		// Token: 0x17000992 RID: 2450
		// (get) Token: 0x060016C1 RID: 5825 RVA: 0x0001D954 File Offset: 0x0001BB54
		// (set) Token: 0x060016C2 RID: 5826 RVA: 0x0001D95C File Offset: 0x0001BB5C
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

		// Token: 0x17000993 RID: 2451
		// (get) Token: 0x060016C3 RID: 5827 RVA: 0x0001D968 File Offset: 0x0001BB68
		// (set) Token: 0x060016C4 RID: 5828 RVA: 0x0001D970 File Offset: 0x0001BB70
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

		// Token: 0x04000C89 RID: 3209
		private string nameField;

		// Token: 0x04000C8A RID: 3210
		private string idRefField;
	}
}
