using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E7 RID: 231
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ConnectionRefType
	{
		// Token: 0x17000369 RID: 873
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x000130C8 File Offset: 0x000112C8
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x000130D0 File Offset: 0x000112D0
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

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x000130DC File Offset: 0x000112DC
		// (set) Token: 0x0600094A RID: 2378 RVA: 0x000130E4 File Offset: 0x000112E4
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

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x000130F0 File Offset: 0x000112F0
		// (set) Token: 0x0600094C RID: 2380 RVA: 0x000130F8 File Offset: 0x000112F8
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

		// Token: 0x0400050B RID: 1291
		private string idRefField;

		// Token: 0x0400050C RID: 1292
		private string pinRefField;

		// Token: 0x0400050D RID: 1293
		private string valueField;
	}
}
