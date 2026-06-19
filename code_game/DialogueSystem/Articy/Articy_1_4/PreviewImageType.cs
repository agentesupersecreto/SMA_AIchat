using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000074 RID: 116
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PreviewImageType
	{
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000EF44 File Offset: 0x0000D144
		// (set) Token: 0x060003DB RID: 987 RVA: 0x0000EF4C File Offset: 0x0000D14C
		public RectangleType ViewBox
		{
			get
			{
				return this.viewBoxField;
			}
			set
			{
				this.viewBoxField = value;
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x060003DC RID: 988 RVA: 0x0000EF58 File Offset: 0x0000D158
		// (set) Token: 0x060003DD RID: 989 RVA: 0x0000EF60 File Offset: 0x0000D160
		[XmlAttribute]
		public string GuidRef
		{
			get
			{
				return this.guidRefField;
			}
			set
			{
				this.guidRefField = value;
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x060003DE RID: 990 RVA: 0x0000EF6C File Offset: 0x0000D16C
		// (set) Token: 0x060003DF RID: 991 RVA: 0x0000EF74 File Offset: 0x0000D174
		[XmlAttribute]
		public ViewBoxModeType Mode
		{
			get
			{
				return this.modeField;
			}
			set
			{
				this.modeField = value;
			}
		}

		// Token: 0x04000215 RID: 533
		private RectangleType viewBoxField;

		// Token: 0x04000216 RID: 534
		private string guidRefField;

		// Token: 0x04000217 RID: 535
		private ViewBoxModeType modeField;
	}
}
