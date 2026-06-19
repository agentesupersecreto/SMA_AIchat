using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A1 RID: 417
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class RectangleType
	{
		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06001247 RID: 4679 RVA: 0x0001ACF0 File Offset: 0x00018EF0
		// (set) Token: 0x06001248 RID: 4680 RVA: 0x0001ACF8 File Offset: 0x00018EF8
		[XmlAttribute]
		public float MinX
		{
			get
			{
				return this.minXField;
			}
			set
			{
				this.minXField = value;
			}
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001249 RID: 4681 RVA: 0x0001AD04 File Offset: 0x00018F04
		// (set) Token: 0x0600124A RID: 4682 RVA: 0x0001AD0C File Offset: 0x00018F0C
		[XmlAttribute]
		public float MinY
		{
			get
			{
				return this.minYField;
			}
			set
			{
				this.minYField = value;
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x0600124B RID: 4683 RVA: 0x0001AD18 File Offset: 0x00018F18
		// (set) Token: 0x0600124C RID: 4684 RVA: 0x0001AD20 File Offset: 0x00018F20
		[XmlAttribute]
		public float MaxX
		{
			get
			{
				return this.maxXField;
			}
			set
			{
				this.maxXField = value;
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x0600124D RID: 4685 RVA: 0x0001AD2C File Offset: 0x00018F2C
		// (set) Token: 0x0600124E RID: 4686 RVA: 0x0001AD34 File Offset: 0x00018F34
		[XmlAttribute]
		public float MaxY
		{
			get
			{
				return this.maxYField;
			}
			set
			{
				this.maxYField = value;
			}
		}

		// Token: 0x04000A07 RID: 2567
		private float minXField;

		// Token: 0x04000A08 RID: 2568
		private float minYField;

		// Token: 0x04000A09 RID: 2569
		private float maxXField;

		// Token: 0x04000A0A RID: 2570
		private float maxYField;
	}
}
