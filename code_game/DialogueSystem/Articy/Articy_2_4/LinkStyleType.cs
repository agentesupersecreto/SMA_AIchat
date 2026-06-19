using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000154 RID: 340
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LinkStyleType
	{
		// Token: 0x170005C7 RID: 1479
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0001761C File Offset: 0x0001581C
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x00017624 File Offset: 0x00015824
		[XmlAttribute]
		public LinkStyleKindType Kind
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

		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x00017630 File Offset: 0x00015830
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x00017638 File Offset: 0x00015838
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

		// Token: 0x040007E8 RID: 2024
		private LinkStyleKindType kindField;

		// Token: 0x040007E9 RID: 2025
		private SizeNamesType sizeField;
	}
}
