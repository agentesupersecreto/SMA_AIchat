using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000147 RID: 327
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneyPointsType
	{
		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06000DE8 RID: 3560 RVA: 0x0001700C File Offset: 0x0001520C
		// (set) Token: 0x06000DE9 RID: 3561 RVA: 0x00017014 File Offset: 0x00015214
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

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06000DEA RID: 3562 RVA: 0x00017020 File Offset: 0x00015220
		// (set) Token: 0x06000DEB RID: 3563 RVA: 0x00017028 File Offset: 0x00015228
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

		// Token: 0x04000783 RID: 1923
		private JourneyPointType[] journeyPointField;

		// Token: 0x04000784 RID: 1924
		private int countField;
	}
}
