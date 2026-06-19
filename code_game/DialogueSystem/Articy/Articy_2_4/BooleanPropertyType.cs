using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000117 RID: 279
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class BooleanPropertyType
	{
		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x06000BBE RID: 3006 RVA: 0x00015AB8 File Offset: 0x00013CB8
		// (set) Token: 0x06000BBF RID: 3007 RVA: 0x00015AC0 File Offset: 0x00013CC0
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

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06000BC0 RID: 3008 RVA: 0x00015ACC File Offset: 0x00013CCC
		// (set) Token: 0x06000BC1 RID: 3009 RVA: 0x00015AD4 File Offset: 0x00013CD4
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

		// Token: 0x04000665 RID: 1637
		private string nameField;

		// Token: 0x04000666 RID: 1638
		private string valueField;
	}
}
