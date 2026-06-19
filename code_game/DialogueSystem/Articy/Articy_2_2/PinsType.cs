using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E1 RID: 225
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PinsType
	{
		// Token: 0x1700033F RID: 831
		// (get) Token: 0x060008EE RID: 2286 RVA: 0x00012D58 File Offset: 0x00010F58
		// (set) Token: 0x060008EF RID: 2287 RVA: 0x00012D60 File Offset: 0x00010F60
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

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x060008F0 RID: 2288 RVA: 0x00012D6C File Offset: 0x00010F6C
		// (set) Token: 0x060008F1 RID: 2289 RVA: 0x00012D74 File Offset: 0x00010F74
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

		// Token: 0x040004DE RID: 1246
		private PinType[] pinField;

		// Token: 0x040004DF RID: 1247
		private int countField;
	}
}
