using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200011F RID: 287
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ReferenceType
	{
		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00015C24 File Offset: 0x00013E24
		// (set) Token: 0x06000BE5 RID: 3045 RVA: 0x00015C2C File Offset: 0x00013E2C
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

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x00015C38 File Offset: 0x00013E38
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x00015C40 File Offset: 0x00013E40
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

		// Token: 0x04000674 RID: 1652
		private string idRefField;

		// Token: 0x04000675 RID: 1653
		private string valueField;
	}
}
