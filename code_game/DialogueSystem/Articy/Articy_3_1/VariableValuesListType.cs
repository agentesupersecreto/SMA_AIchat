using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C3 RID: 451
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class VariableValuesListType
	{
		// Token: 0x1700085B RID: 2139
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x0001BFC0 File Offset: 0x0001A1C0
		// (set) Token: 0x0600142F RID: 5167 RVA: 0x0001BFC8 File Offset: 0x0001A1C8
		[XmlElement("Variable")]
		public JourneyVariable[] Variable
		{
			get
			{
				return this.variableField;
			}
			set
			{
				this.variableField = value;
			}
		}

		// Token: 0x1700085C RID: 2140
		// (get) Token: 0x06001430 RID: 5168 RVA: 0x0001BFD4 File Offset: 0x0001A1D4
		// (set) Token: 0x06001431 RID: 5169 RVA: 0x0001BFDC File Offset: 0x0001A1DC
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

		// Token: 0x04000B06 RID: 2822
		private JourneyVariable[] variableField;

		// Token: 0x04000B07 RID: 2823
		private int countField;
	}
}
