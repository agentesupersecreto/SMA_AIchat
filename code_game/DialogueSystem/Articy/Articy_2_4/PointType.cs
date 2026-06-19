using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200012C RID: 300
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PointType
	{
		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x00016168 File Offset: 0x00014368
		// (set) Token: 0x06000C6E RID: 3182 RVA: 0x00016170 File Offset: 0x00014370
		[XmlAttribute]
		public float X
		{
			get
			{
				return this.xField;
			}
			set
			{
				this.xField = value;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000C6F RID: 3183 RVA: 0x0001617C File Offset: 0x0001437C
		// (set) Token: 0x06000C70 RID: 3184 RVA: 0x00016184 File Offset: 0x00014384
		[XmlAttribute]
		public float Y
		{
			get
			{
				return this.yField;
			}
			set
			{
				this.yField = value;
			}
		}

		// Token: 0x040006BA RID: 1722
		private float xField;

		// Token: 0x040006BB RID: 1723
		private float yField;
	}
}
