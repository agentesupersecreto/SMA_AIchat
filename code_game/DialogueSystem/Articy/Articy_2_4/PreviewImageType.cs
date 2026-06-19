using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000121 RID: 289
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PreviewImageType
	{
		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00015C84 File Offset: 0x00013E84
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00015C8C File Offset: 0x00013E8C
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

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00015C98 File Offset: 0x00013E98
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x00015CA0 File Offset: 0x00013EA0
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

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00015CAC File Offset: 0x00013EAC
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x00015CB4 File Offset: 0x00013EB4
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

		// Token: 0x04000678 RID: 1656
		private RectangleType viewBoxField;

		// Token: 0x04000679 RID: 1657
		private string idRefField;

		// Token: 0x0400067A RID: 1658
		private ViewBoxModeType modeField;
	}
}
