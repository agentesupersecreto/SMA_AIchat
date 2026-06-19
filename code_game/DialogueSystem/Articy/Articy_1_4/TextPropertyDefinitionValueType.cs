using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009C RID: 156
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class TextPropertyDefinitionValueType
	{
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x00010608 File Offset: 0x0000E808
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x00010610 File Offset: 0x0000E810
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

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0001061C File Offset: 0x0000E81C
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x00010624 File Offset: 0x0000E824
		[XmlText]
		public string[] Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x00010630 File Offset: 0x0000E830
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x00010638 File Offset: 0x0000E838
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

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00010644 File Offset: 0x0000E844
		// (set) Token: 0x0600062F RID: 1583 RVA: 0x0001064C File Offset: 0x0000E84C
		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return this.countFieldSpecified;
			}
			set
			{
				this.countFieldSpecified = value;
			}
		}

		// Token: 0x0400033B RID: 827
		private LocalizedStringType[] localizedStringField;

		// Token: 0x0400033C RID: 828
		private string[] textField;

		// Token: 0x0400033D RID: 829
		private int countField;

		// Token: 0x0400033E RID: 830
		private bool countFieldSpecified;
	}
}
