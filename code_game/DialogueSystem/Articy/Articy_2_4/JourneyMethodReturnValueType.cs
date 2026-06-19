using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014C RID: 332
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyMethodReturnValueType
	{
		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x06000E1D RID: 3613 RVA: 0x00017214 File Offset: 0x00015414
		// (set) Token: 0x06000E1E RID: 3614 RVA: 0x0001721C File Offset: 0x0001541C
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06000E1F RID: 3615 RVA: 0x00017228 File Offset: 0x00015428
		// (set) Token: 0x06000E20 RID: 3616 RVA: 0x00017230 File Offset: 0x00015430
		[XmlAttribute]
		public VariableDataTypeType DataType
		{
			get
			{
				return this.dataTypeField;
			}
			set
			{
				this.dataTypeField = value;
			}
		}

		// Token: 0x17000597 RID: 1431
		// (get) Token: 0x06000E21 RID: 3617 RVA: 0x0001723C File Offset: 0x0001543C
		// (set) Token: 0x06000E22 RID: 3618 RVA: 0x00017244 File Offset: 0x00015444
		[XmlAttribute]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x0400079B RID: 1947
		private string nameField;

		// Token: 0x0400079C RID: 1948
		private VariableDataTypeType dataTypeField;

		// Token: 0x0400079D RID: 1949
		private string valueField;
	}
}
