using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000198 RID: 408
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class LocalizableTextPropertyType
	{
		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x0001AB40 File Offset: 0x00018D40
		// (set) Token: 0x0600121B RID: 4635 RVA: 0x0001AB48 File Offset: 0x00018D48
		[XmlElement("LocalizedString")]
		public LocalizedStringType[] LocalizedString
		{
			get
			{
				return this.localizedStringField;
			}
			set
			{
				this.localizedStringField = value;
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x0001AB54 File Offset: 0x00018D54
		// (set) Token: 0x0600121D RID: 4637 RVA: 0x0001AB5C File Offset: 0x00018D5C
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

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x0001AB68 File Offset: 0x00018D68
		// (set) Token: 0x0600121F RID: 4639 RVA: 0x0001AB70 File Offset: 0x00018D70
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x040009F5 RID: 2549
		private LocalizedStringType[] localizedStringField;

		// Token: 0x040009F6 RID: 2550
		private string nameField;

		// Token: 0x040009F7 RID: 2551
		private int countField;
	}
}
