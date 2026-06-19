using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006D RID: 109
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class BooleanPropertyType
	{
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0000EDF4 File Offset: 0x0000CFF4
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x0000EDFC File Offset: 0x0000CFFC
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

		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0000EE08 File Offset: 0x0000D008
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0000EE10 File Offset: 0x0000D010
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

		// Token: 0x04000207 RID: 519
		private string nameField;

		// Token: 0x04000208 RID: 520
		private string valueField;
	}
}
