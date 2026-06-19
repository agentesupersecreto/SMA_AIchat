using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000CB RID: 203
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyRefType
	{
		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060007A2 RID: 1954 RVA: 0x00012080 File Offset: 0x00010280
		// (set) Token: 0x060007A3 RID: 1955 RVA: 0x00012088 File Offset: 0x00010288
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

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x00012094 File Offset: 0x00010294
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x0001209C File Offset: 0x0001029C
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

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060007A6 RID: 1958 RVA: 0x000120A8 File Offset: 0x000102A8
		// (set) Token: 0x060007A7 RID: 1959 RVA: 0x000120B0 File Offset: 0x000102B0
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

		// Token: 0x0400041C RID: 1052
		private string idRefField;

		// Token: 0x0400041D RID: 1053
		private string pinRefField;

		// Token: 0x0400041E RID: 1054
		private string valueField;
	}
}
