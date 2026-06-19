using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000144 RID: 324
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VariableValuesListType
	{
		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00016F98 File Offset: 0x00015198
		// (set) Token: 0x06000DDD RID: 3549 RVA: 0x00016FA0 File Offset: 0x000151A0
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

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06000DDE RID: 3550 RVA: 0x00016FAC File Offset: 0x000151AC
		// (set) Token: 0x06000DDF RID: 3551 RVA: 0x00016FB4 File Offset: 0x000151B4
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

		// Token: 0x0400077A RID: 1914
		private JourneyVariable[] variableField;

		// Token: 0x0400077B RID: 1915
		private int countField;
	}
}
