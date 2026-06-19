using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019F RID: 415
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class StringPropertyType
	{
		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x0001AC7C File Offset: 0x00018E7C
		// (set) Token: 0x0600123C RID: 4668 RVA: 0x0001AC84 File Offset: 0x00018E84
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

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x0600123D RID: 4669 RVA: 0x0001AC90 File Offset: 0x00018E90
		// (set) Token: 0x0600123E RID: 4670 RVA: 0x0001AC98 File Offset: 0x00018E98
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

		// Token: 0x04000A02 RID: 2562
		private string nameField;

		// Token: 0x04000A03 RID: 2563
		private string valueField;
	}
}
