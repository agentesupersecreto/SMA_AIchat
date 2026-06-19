using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000161 RID: 353
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocationAnchorsType
	{
		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x06000F33 RID: 3891 RVA: 0x00017CF0 File Offset: 0x00015EF0
		// (set) Token: 0x06000F34 RID: 3892 RVA: 0x00017CF8 File Offset: 0x00015EF8
		[XmlElement("Anchor")]
		public LocationAnchorType[] Anchor
		{
			get
			{
				return this.anchorField;
			}
			set
			{
				this.anchorField = value;
			}
		}

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06000F35 RID: 3893 RVA: 0x00017D04 File Offset: 0x00015F04
		// (set) Token: 0x06000F36 RID: 3894 RVA: 0x00017D0C File Offset: 0x00015F0C
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

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x00017D18 File Offset: 0x00015F18
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x00017D20 File Offset: 0x00015F20
		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return this.countFieldSpecified;
			}
			set
			{
				this.countFieldSpecified = value;
			}
		}

		// Token: 0x04000852 RID: 2130
		private LocationAnchorType[] anchorField;

		// Token: 0x04000853 RID: 2131
		private int countField;

		// Token: 0x04000854 RID: 2132
		private bool countFieldSpecified;
	}
}
