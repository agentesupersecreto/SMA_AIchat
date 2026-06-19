using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000139 RID: 313
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class PropertyDefinitionRefType
	{
		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000D48 RID: 3400 RVA: 0x000169DC File Offset: 0x00014BDC
		// (set) Token: 0x06000D49 RID: 3401 RVA: 0x000169E4 File Offset: 0x00014BE4
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000D4A RID: 3402 RVA: 0x000169F0 File Offset: 0x00014BF0
		// (set) Token: 0x06000D4B RID: 3403 RVA: 0x000169F8 File Offset: 0x00014BF8
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

		// Token: 0x04000721 RID: 1825
		private string idRefField;

		// Token: 0x04000722 RID: 1826
		private string valueField;
	}
}
