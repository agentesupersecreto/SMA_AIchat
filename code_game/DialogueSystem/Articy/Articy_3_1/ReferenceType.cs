using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019E RID: 414
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceType
	{
		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06001236 RID: 4662 RVA: 0x0001AC4C File Offset: 0x00018E4C
		// (set) Token: 0x06001237 RID: 4663 RVA: 0x0001AC54 File Offset: 0x00018E54
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

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06001238 RID: 4664 RVA: 0x0001AC60 File Offset: 0x00018E60
		// (set) Token: 0x06001239 RID: 4665 RVA: 0x0001AC68 File Offset: 0x00018E68
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

		// Token: 0x04000A00 RID: 2560
		private string idRefField;

		// Token: 0x04000A01 RID: 2561
		private string valueField;
	}
}
