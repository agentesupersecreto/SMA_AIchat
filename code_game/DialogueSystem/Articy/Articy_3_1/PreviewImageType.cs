using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A0 RID: 416
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PreviewImageType
	{
		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06001240 RID: 4672 RVA: 0x0001ACAC File Offset: 0x00018EAC
		// (set) Token: 0x06001241 RID: 4673 RVA: 0x0001ACB4 File Offset: 0x00018EB4
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

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x0001ACC0 File Offset: 0x00018EC0
		// (set) Token: 0x06001243 RID: 4675 RVA: 0x0001ACC8 File Offset: 0x00018EC8
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

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06001244 RID: 4676 RVA: 0x0001ACD4 File Offset: 0x00018ED4
		// (set) Token: 0x06001245 RID: 4677 RVA: 0x0001ACDC File Offset: 0x00018EDC
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

		// Token: 0x04000A04 RID: 2564
		private RectangleType viewBoxField;

		// Token: 0x04000A05 RID: 2565
		private string idRefField;

		// Token: 0x04000A06 RID: 2566
		private ViewBoxModeType modeField;
	}
}
