using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000083 RID: 131
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PinsType
	{
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060004BF RID: 1215 RVA: 0x0000F81C File Offset: 0x0000DA1C
		// (set) Token: 0x060004C0 RID: 1216 RVA: 0x0000F824 File Offset: 0x0000DA24
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

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x0000F830 File Offset: 0x0000DA30
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x0000F838 File Offset: 0x0000DA38
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

		// Token: 0x04000289 RID: 649
		private PinType[] pinField;

		// Token: 0x0400028A RID: 650
		private int countField;
	}
}
