using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001D3 RID: 467
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class LinkStyleType
	{
		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x060014D7 RID: 5335 RVA: 0x0001C644 File Offset: 0x0001A844
		// (set) Token: 0x060014D8 RID: 5336 RVA: 0x0001C64C File Offset: 0x0001A84C
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

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x060014D9 RID: 5337 RVA: 0x0001C658 File Offset: 0x0001A858
		// (set) Token: 0x060014DA RID: 5338 RVA: 0x0001C660 File Offset: 0x0001A860
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

		// Token: 0x04000B74 RID: 2932
		private LinkStyleKindType kindField;

		// Token: 0x04000B75 RID: 2933
		private SizeNamesType sizeField;
	}
}
