using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001AE RID: 430
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ConnectionRefType
	{
		// Token: 0x170007B9 RID: 1977
		// (get) Token: 0x060012DA RID: 4826 RVA: 0x0001B298 File Offset: 0x00019498
		// (set) Token: 0x060012DB RID: 4827 RVA: 0x0001B2A0 File Offset: 0x000194A0
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

		// Token: 0x170007BA RID: 1978
		// (get) Token: 0x060012DC RID: 4828 RVA: 0x0001B2AC File Offset: 0x000194AC
		// (set) Token: 0x060012DD RID: 4829 RVA: 0x0001B2B4 File Offset: 0x000194B4
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

		// Token: 0x170007BB RID: 1979
		// (get) Token: 0x060012DE RID: 4830 RVA: 0x0001B2C0 File Offset: 0x000194C0
		// (set) Token: 0x060012DF RID: 4831 RVA: 0x0001B2C8 File Offset: 0x000194C8
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

		// Token: 0x04000A52 RID: 2642
		private string idRefField;

		// Token: 0x04000A53 RID: 2643
		private string pinRefField;

		// Token: 0x04000A54 RID: 2644
		private string valueField;
	}
}
