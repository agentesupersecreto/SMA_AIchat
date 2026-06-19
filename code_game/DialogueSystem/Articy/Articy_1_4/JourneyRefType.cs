using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200005F RID: 95
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyRefType
	{
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000E978 File Offset: 0x0000CB78
		// (set) Token: 0x06000343 RID: 835 RVA: 0x0000E980 File Offset: 0x0000CB80
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

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000E98C File Offset: 0x0000CB8C
		// (set) Token: 0x06000345 RID: 837 RVA: 0x0000E994 File Offset: 0x0000CB94
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

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000346 RID: 838 RVA: 0x0000E9A0 File Offset: 0x0000CBA0
		// (set) Token: 0x06000347 RID: 839 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
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

		// Token: 0x040001BA RID: 442
		private string guidRefField;

		// Token: 0x040001BB RID: 443
		private string pinRefField;

		// Token: 0x040001BC RID: 444
		private string valueField;
	}
}
