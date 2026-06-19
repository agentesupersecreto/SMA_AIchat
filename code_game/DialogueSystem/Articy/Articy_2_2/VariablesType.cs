using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B2 RID: 178
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class VariablesType
	{
		// Token: 0x1700025D RID: 605
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x00011A90 File Offset: 0x0000FC90
		// (set) Token: 0x06000707 RID: 1799 RVA: 0x00011A98 File Offset: 0x0000FC98
		[XmlElement("Variable")]
		public VariableType[] Variable
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

		// Token: 0x1700025E RID: 606
		// (get) Token: 0x06000708 RID: 1800 RVA: 0x00011AA4 File Offset: 0x0000FCA4
		// (set) Token: 0x06000709 RID: 1801 RVA: 0x00011AAC File Offset: 0x0000FCAC
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

		// Token: 0x040003C5 RID: 965
		private VariableType[] variableField;

		// Token: 0x040003C6 RID: 966
		private int countField;
	}
}
