using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FE RID: 510
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class TextPropertyDefinitionValueType
	{
		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x0600176C RID: 5996 RVA: 0x0001DFF4 File Offset: 0x0001C1F4
		// (set) Token: 0x0600176D RID: 5997 RVA: 0x0001DFFC File Offset: 0x0001C1FC
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

		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x0001E008 File Offset: 0x0001C208
		// (set) Token: 0x0600176F RID: 5999 RVA: 0x0001E010 File Offset: 0x0001C210
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

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x0001E01C File Offset: 0x0001C21C
		// (set) Token: 0x06001771 RID: 6001 RVA: 0x0001E024 File Offset: 0x0001C224
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

		// Token: 0x170009E7 RID: 2535
		// (get) Token: 0x06001772 RID: 6002 RVA: 0x0001E030 File Offset: 0x0001C230
		// (set) Token: 0x06001773 RID: 6003 RVA: 0x0001E038 File Offset: 0x0001C238
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

		// Token: 0x04000CDF RID: 3295
		private LocalizedStringType[] localizedStringField;

		// Token: 0x04000CE0 RID: 3296
		private string[] textField;

		// Token: 0x04000CE1 RID: 3297
		private int countField;

		// Token: 0x04000CE2 RID: 3298
		private bool countFieldSpecified;
	}
}
