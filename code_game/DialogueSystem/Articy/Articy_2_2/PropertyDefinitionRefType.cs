using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000101 RID: 257
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PropertyDefinitionRefType
	{
		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06000AF7 RID: 2807 RVA: 0x00014178 File Offset: 0x00012378
		// (set) Token: 0x06000AF8 RID: 2808 RVA: 0x00014180 File Offset: 0x00012380
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

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06000AF9 RID: 2809 RVA: 0x0001418C File Offset: 0x0001238C
		// (set) Token: 0x06000AFA RID: 2810 RVA: 0x00014194 File Offset: 0x00012394
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

		// Token: 0x040005E1 RID: 1505
		private string idRefField;

		// Token: 0x040005E2 RID: 1506
		private string valueField;
	}
}
