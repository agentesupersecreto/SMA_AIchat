using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001AB RID: 427
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class PointType
	{
		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x0001B190 File Offset: 0x00019390
		// (set) Token: 0x060012C0 RID: 4800 RVA: 0x0001B198 File Offset: 0x00019398
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

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x060012C1 RID: 4801 RVA: 0x0001B1A4 File Offset: 0x000193A4
		// (set) Token: 0x060012C2 RID: 4802 RVA: 0x0001B1AC File Offset: 0x000193AC
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

		// Token: 0x04000A46 RID: 2630
		private float xField;

		// Token: 0x04000A47 RID: 2631
		private float yField;
	}
}
