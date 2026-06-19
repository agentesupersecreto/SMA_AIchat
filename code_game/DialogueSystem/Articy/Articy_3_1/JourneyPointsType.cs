using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C6 RID: 454
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class JourneyPointsType
	{
		// Token: 0x17000860 RID: 2144
		// (get) Token: 0x0600143A RID: 5178 RVA: 0x0001C034 File Offset: 0x0001A234
		// (set) Token: 0x0600143B RID: 5179 RVA: 0x0001C03C File Offset: 0x0001A23C
		[XmlElement("JourneyPoint")]
		public JourneyPointType[] JourneyPoint
		{
			get
			{
				return this.journeyPointField;
			}
			set
			{
				this.journeyPointField = value;
			}
		}

		// Token: 0x17000861 RID: 2145
		// (get) Token: 0x0600143C RID: 5180 RVA: 0x0001C048 File Offset: 0x0001A248
		// (set) Token: 0x0600143D RID: 5181 RVA: 0x0001C050 File Offset: 0x0001A250
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x04000B0F RID: 2831
		private JourneyPointType[] journeyPointField;

		// Token: 0x04000B10 RID: 2832
		private int countField;
	}
}
