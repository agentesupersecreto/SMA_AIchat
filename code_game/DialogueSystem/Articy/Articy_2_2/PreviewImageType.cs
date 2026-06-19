using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C2 RID: 194
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PreviewImageType
	{
		// Token: 0x17000289 RID: 649
		// (get) Token: 0x0600076E RID: 1902 RVA: 0x00011E80 File Offset: 0x00010080
		// (set) Token: 0x0600076F RID: 1903 RVA: 0x00011E88 File Offset: 0x00010088
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

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x00011E94 File Offset: 0x00010094
		// (set) Token: 0x06000771 RID: 1905 RVA: 0x00011E9C File Offset: 0x0001009C
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x00011EA8 File Offset: 0x000100A8
		// (set) Token: 0x06000773 RID: 1907 RVA: 0x00011EB0 File Offset: 0x000100B0
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

		// Token: 0x040003F1 RID: 1009
		private RectangleType viewBoxField;

		// Token: 0x040003F2 RID: 1010
		private string idRefField;

		// Token: 0x040003F3 RID: 1011
		private ViewBoxModeType modeField;
	}
}
