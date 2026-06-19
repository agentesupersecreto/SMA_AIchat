using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CB RID: 459
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyMethodReturnValueType
	{
		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x0600146F RID: 5231 RVA: 0x0001C23C File Offset: 0x0001A43C
		// (set) Token: 0x06001470 RID: 5232 RVA: 0x0001C244 File Offset: 0x0001A444
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

		// Token: 0x17000879 RID: 2169
		// (get) Token: 0x06001471 RID: 5233 RVA: 0x0001C250 File Offset: 0x0001A450
		// (set) Token: 0x06001472 RID: 5234 RVA: 0x0001C258 File Offset: 0x0001A458
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

		// Token: 0x1700087A RID: 2170
		// (get) Token: 0x06001473 RID: 5235 RVA: 0x0001C264 File Offset: 0x0001A464
		// (set) Token: 0x06001474 RID: 5236 RVA: 0x0001C26C File Offset: 0x0001A46C
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

		// Token: 0x04000B27 RID: 2855
		private string nameField;

		// Token: 0x04000B28 RID: 2856
		private VariableDataTypeType dataTypeField;

		// Token: 0x04000B29 RID: 2857
		private string valueField;
	}
}
