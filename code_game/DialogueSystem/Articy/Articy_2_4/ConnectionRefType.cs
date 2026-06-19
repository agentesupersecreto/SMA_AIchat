using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200012F RID: 303
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ConnectionRefType
	{
		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000C88 RID: 3208 RVA: 0x00016270 File Offset: 0x00014470
		// (set) Token: 0x06000C89 RID: 3209 RVA: 0x00016278 File Offset: 0x00014478
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

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000C8A RID: 3210 RVA: 0x00016284 File Offset: 0x00014484
		// (set) Token: 0x06000C8B RID: 3211 RVA: 0x0001628C File Offset: 0x0001448C
		[XmlAttribute]
		public string PinRef
		{
			get
			{
				return this.pinRefField;
			}
			set
			{
				this.pinRefField = value;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000C8C RID: 3212 RVA: 0x00016298 File Offset: 0x00014498
		// (set) Token: 0x06000C8D RID: 3213 RVA: 0x000162A0 File Offset: 0x000144A0
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

		// Token: 0x040006C6 RID: 1734
		private string idRefField;

		// Token: 0x040006C7 RID: 1735
		private string pinRefField;

		// Token: 0x040006C8 RID: 1736
		private string valueField;
	}
}
