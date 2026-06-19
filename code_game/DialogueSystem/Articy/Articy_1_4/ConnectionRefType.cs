using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000087 RID: 135
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ConnectionRefType
	{
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000F99C File Offset: 0x0000DB9C
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0000F9A4 File Offset: 0x0000DBA4
		[XmlAttribute]
		public string GuidRef
		{
			get
			{
				return this.guidRefField;
			}
			set
			{
				this.guidRefField = value;
			}
		}

		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0000F9B0 File Offset: 0x0000DBB0
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x0000F9B8 File Offset: 0x0000DBB8
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

		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000F9C4 File Offset: 0x0000DBC4
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x0000F9CC File Offset: 0x0000DBCC
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

		// Token: 0x0400029E RID: 670
		private string guidRefField;

		// Token: 0x0400029F RID: 671
		private string pinRefField;

		// Token: 0x040002A0 RID: 672
		private string valueField;
	}
}
