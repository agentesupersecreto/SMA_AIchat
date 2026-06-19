using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000063 RID: 99
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyPointsType
	{
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000358 RID: 856 RVA: 0x0000EA50 File Offset: 0x0000CC50
		// (set) Token: 0x06000359 RID: 857 RVA: 0x0000EA58 File Offset: 0x0000CC58
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

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x0600035A RID: 858 RVA: 0x0000EA64 File Offset: 0x0000CC64
		// (set) Token: 0x0600035B RID: 859 RVA: 0x0000EA6C File Offset: 0x0000CC6C
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

		// Token: 0x040001D9 RID: 473
		private JourneyPointType[] journeyPointField;

		// Token: 0x040001DA RID: 474
		private int countField;
	}
}
