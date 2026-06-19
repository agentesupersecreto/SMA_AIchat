using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000149 RID: 329
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyRefType
	{
		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x000170F8 File Offset: 0x000152F8
		// (set) Token: 0x06000E01 RID: 3585 RVA: 0x00017100 File Offset: 0x00015300
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

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x0001710C File Offset: 0x0001530C
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00017114 File Offset: 0x00015314
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

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x00017120 File Offset: 0x00015320
		// (set) Token: 0x06000E05 RID: 3589 RVA: 0x00017128 File Offset: 0x00015328
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

		// Token: 0x0400078E RID: 1934
		private string idRefField;

		// Token: 0x0400078F RID: 1935
		private string pinRefField;

		// Token: 0x04000790 RID: 1936
		private string valueField;
	}
}
