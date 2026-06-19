using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000CF RID: 207
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyPointsType
	{
		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060007B8 RID: 1976 RVA: 0x00012158 File Offset: 0x00010358
		// (set) Token: 0x060007B9 RID: 1977 RVA: 0x00012160 File Offset: 0x00010360
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

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0001216C File Offset: 0x0001036C
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x00012174 File Offset: 0x00010374
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

		// Token: 0x0400043D RID: 1085
		private JourneyPointType[] journeyPointField;

		// Token: 0x0400043E RID: 1086
		private int countField;
	}
}
