using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001AC RID: 428
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class SizeType
	{
		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x060012C4 RID: 4804 RVA: 0x0001B1C0 File Offset: 0x000193C0
		// (set) Token: 0x060012C5 RID: 4805 RVA: 0x0001B1C8 File Offset: 0x000193C8
		[XmlAttribute]
		public float Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x060012C6 RID: 4806 RVA: 0x0001B1D4 File Offset: 0x000193D4
		// (set) Token: 0x060012C7 RID: 4807 RVA: 0x0001B1DC File Offset: 0x000193DC
		[XmlAttribute]
		public float Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		// Token: 0x04000A48 RID: 2632
		private float widthField;

		// Token: 0x04000A49 RID: 2633
		private float heightField;
	}
}
