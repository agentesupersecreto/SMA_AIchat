using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019A RID: 410
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlInclude(typeof(ReferenceSlotPropertyType))]
	[Serializable]
	public class NamedReferenceType
	{
		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06001222 RID: 4642 RVA: 0x0001AB8C File Offset: 0x00018D8C
		// (set) Token: 0x06001223 RID: 4643 RVA: 0x0001AB94 File Offset: 0x00018D94
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06001224 RID: 4644 RVA: 0x0001ABA0 File Offset: 0x00018DA0
		// (set) Token: 0x06001225 RID: 4645 RVA: 0x0001ABA8 File Offset: 0x00018DA8
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

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x06001226 RID: 4646 RVA: 0x0001ABB4 File Offset: 0x00018DB4
		// (set) Token: 0x06001227 RID: 4647 RVA: 0x0001ABBC File Offset: 0x00018DBC
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

		// Token: 0x040009F8 RID: 2552
		private string nameField;

		// Token: 0x040009F9 RID: 2553
		private string idRefField;

		// Token: 0x040009FA RID: 2554
		private string valueField;
	}
}
