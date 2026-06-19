using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200007B RID: 123
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class VerticesType
	{
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x0600043A RID: 1082 RVA: 0x0000F2F8 File Offset: 0x0000D4F8
		// (set) Token: 0x0600043B RID: 1083 RVA: 0x0000F300 File Offset: 0x0000D500
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x0600043C RID: 1084 RVA: 0x0000F30C File Offset: 0x0000D50C
		// (set) Token: 0x0600043D RID: 1085 RVA: 0x0000F314 File Offset: 0x0000D514
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

		// Token: 0x04000246 RID: 582
		private int countField;

		// Token: 0x04000247 RID: 583
		private string valueField;
	}
}
