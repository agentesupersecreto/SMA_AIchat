using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001DA RID: 474
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class FillType
	{
		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x06001565 RID: 5477 RVA: 0x0001CBD0 File Offset: 0x0001ADD0
		// (set) Token: 0x06001566 RID: 5478 RVA: 0x0001CBD8 File Offset: 0x0001ADD8
		[XmlAttribute]
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x04000BC7 RID: 3015
		private string colorField;
	}
}
