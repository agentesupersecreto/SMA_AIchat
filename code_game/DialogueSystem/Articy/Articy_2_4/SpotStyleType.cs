using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200017C RID: 380
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class SpotStyleType
	{
		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00018D20 File Offset: 0x00016F20
		// (set) Token: 0x060010D6 RID: 4310 RVA: 0x00018D28 File Offset: 0x00016F28
		[XmlAttribute]
		public SpotStyleKindType Kind
		{
			get
			{
				return this.kindField;
			}
			set
			{
				this.kindField = value;
			}
		}

		// Token: 0x170006E1 RID: 1761
		// (get) Token: 0x060010D7 RID: 4311 RVA: 0x00018D34 File Offset: 0x00016F34
		// (set) Token: 0x060010D8 RID: 4312 RVA: 0x00018D3C File Offset: 0x00016F3C
		[XmlAttribute]
		public SizeNamesType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x04000932 RID: 2354
		private SpotStyleKindType kindField;

		// Token: 0x04000933 RID: 2355
		private SizeNamesType sizeField;
	}
}
