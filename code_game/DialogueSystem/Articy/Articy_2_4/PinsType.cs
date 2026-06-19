using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000129 RID: 297
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PinsType
	{
		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x000160E0 File Offset: 0x000142E0
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x000160E8 File Offset: 0x000142E8
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

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x000160F4 File Offset: 0x000142F4
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x000160FC File Offset: 0x000142FC
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

		// Token: 0x040006B1 RID: 1713
		private PinType[] pinField;

		// Token: 0x040006B2 RID: 1714
		private int countField;
	}
}
