using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C4 RID: 452
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class JourneyVariable
	{
		// Token: 0x1700085D RID: 2141
		// (get) Token: 0x06001433 RID: 5171 RVA: 0x0001BFF0 File Offset: 0x0001A1F0
		// (set) Token: 0x06001434 RID: 5172 RVA: 0x0001BFF8 File Offset: 0x0001A1F8
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

		// Token: 0x1700085E RID: 2142
		// (get) Token: 0x06001435 RID: 5173 RVA: 0x0001C004 File Offset: 0x0001A204
		// (set) Token: 0x06001436 RID: 5174 RVA: 0x0001C00C File Offset: 0x0001A20C
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

		// Token: 0x1700085F RID: 2143
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x0001C018 File Offset: 0x0001A218
		// (set) Token: 0x06001438 RID: 5176 RVA: 0x0001C020 File Offset: 0x0001A220
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

		// Token: 0x04000B08 RID: 2824
		private string nameField;

		// Token: 0x04000B09 RID: 2825
		private VariableDataTypeType dataTypeField;

		// Token: 0x04000B0A RID: 2826
		private string valueField;
	}
}
