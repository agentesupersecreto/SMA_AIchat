using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A8 RID: 424
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class PinsType
	{
		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x0001B108 File Offset: 0x00019308
		// (set) Token: 0x060012B2 RID: 4786 RVA: 0x0001B110 File Offset: 0x00019310
		[XmlElement("Pin")]
		public PinType[] Pin
		{
			get
			{
				return this.pinField;
			}
			set
			{
				this.pinField = value;
			}
		}

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x060012B3 RID: 4787 RVA: 0x0001B11C File Offset: 0x0001931C
		// (set) Token: 0x060012B4 RID: 4788 RVA: 0x0001B124 File Offset: 0x00019324
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x04000A3D RID: 2621
		private PinType[] pinField;

		// Token: 0x04000A3E RID: 2622
		private int countField;
	}
}
