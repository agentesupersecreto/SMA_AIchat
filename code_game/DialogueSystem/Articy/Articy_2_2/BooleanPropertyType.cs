using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B8 RID: 184
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class BooleanPropertyType
	{
		// Token: 0x17000276 RID: 630
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00011CB4 File Offset: 0x0000FEB4
		// (set) Token: 0x0600073F RID: 1855 RVA: 0x00011CBC File Offset: 0x0000FEBC
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

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x06000740 RID: 1856 RVA: 0x00011CC8 File Offset: 0x0000FEC8
		// (set) Token: 0x06000741 RID: 1857 RVA: 0x00011CD0 File Offset: 0x0000FED0
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

		// Token: 0x040003DE RID: 990
		private string nameField;

		// Token: 0x040003DF RID: 991
		private string valueField;
	}
}
