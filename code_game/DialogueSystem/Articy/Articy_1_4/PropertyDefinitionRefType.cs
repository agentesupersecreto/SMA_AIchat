using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009E RID: 158
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PropertyDefinitionRefType
	{
		// Token: 0x1700021C RID: 540
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x000107BC File Offset: 0x0000E9BC
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x000107C4 File Offset: 0x0000E9C4
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

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x000107D0 File Offset: 0x0000E9D0
		// (set) Token: 0x06000657 RID: 1623 RVA: 0x000107D8 File Offset: 0x0000E9D8
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

		// Token: 0x04000350 RID: 848
		private string guidRefField;

		// Token: 0x04000351 RID: 849
		private string valueField;
	}
}
