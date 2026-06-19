using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000FF RID: 255
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class TextPropertyDefinitionValueType
	{
		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x00013FB0 File Offset: 0x000121B0
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x00013FB8 File Offset: 0x000121B8
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

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x06000ACB RID: 2763 RVA: 0x00013FC4 File Offset: 0x000121C4
		// (set) Token: 0x06000ACC RID: 2764 RVA: 0x00013FCC File Offset: 0x000121CC
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

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000ACD RID: 2765 RVA: 0x00013FD8 File Offset: 0x000121D8
		// (set) Token: 0x06000ACE RID: 2766 RVA: 0x00013FE0 File Offset: 0x000121E0
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

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000ACF RID: 2767 RVA: 0x00013FEC File Offset: 0x000121EC
		// (set) Token: 0x06000AD0 RID: 2768 RVA: 0x00013FF4 File Offset: 0x000121F4
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

		// Token: 0x040005CB RID: 1483
		private LocalizedStringType[] localizedStringField;

		// Token: 0x040005CC RID: 1484
		private string[] textField;

		// Token: 0x040005CD RID: 1485
		private int countField;

		// Token: 0x040005CE RID: 1486
		private bool countFieldSpecified;
	}
}
