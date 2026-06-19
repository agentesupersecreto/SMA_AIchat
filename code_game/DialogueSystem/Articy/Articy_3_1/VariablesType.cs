using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000200 RID: 512
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class VariablesType
	{
		// Token: 0x170009ED RID: 2541
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0001E0B8 File Offset: 0x0001C2B8
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0001E0C0 File Offset: 0x0001C2C0
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

		// Token: 0x170009EE RID: 2542
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0001E0CC File Offset: 0x0001C2CC
		// (set) Token: 0x06001783 RID: 6019 RVA: 0x0001E0D4 File Offset: 0x0001C2D4
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

		// Token: 0x04000CE8 RID: 3304
		private VariableType[] variableField;

		// Token: 0x04000CE9 RID: 3305
		private int countField;
	}
}
