using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000181 RID: 385
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class VariablesType
	{
		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x0600112E RID: 4398 RVA: 0x00019090 File Offset: 0x00017290
		// (set) Token: 0x0600112F RID: 4399 RVA: 0x00019098 File Offset: 0x00017298
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

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x06001130 RID: 4400 RVA: 0x000190A4 File Offset: 0x000172A4
		// (set) Token: 0x06001131 RID: 4401 RVA: 0x000190AC File Offset: 0x000172AC
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

		// Token: 0x0400095C RID: 2396
		private VariableType[] variableField;

		// Token: 0x0400095D RID: 2397
		private int countField;
	}
}
