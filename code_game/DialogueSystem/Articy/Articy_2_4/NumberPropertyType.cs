using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200011C RID: 284
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class NumberPropertyType
	{
		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000BD7 RID: 3031 RVA: 0x00015BA8 File Offset: 0x00013DA8
		// (set) Token: 0x06000BD8 RID: 3032 RVA: 0x00015BB0 File Offset: 0x00013DB0
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

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000BD9 RID: 3033 RVA: 0x00015BBC File Offset: 0x00013DBC
		// (set) Token: 0x06000BDA RID: 3034 RVA: 0x00015BC4 File Offset: 0x00013DC4
		[XmlText]
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

		// Token: 0x0400066F RID: 1647
		private string nameField;

		// Token: 0x04000670 RID: 1648
		private string valueField;
	}
}
