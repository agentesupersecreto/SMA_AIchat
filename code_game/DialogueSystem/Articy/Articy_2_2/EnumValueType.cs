using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F2 RID: 242
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumValueType
	{
		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x00013744 File Offset: 0x00011944
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x0001374C File Offset: 0x0001194C
		public int Value
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

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x00013758 File Offset: 0x00011958
		// (set) Token: 0x060009F2 RID: 2546 RVA: 0x00013760 File Offset: 0x00011960
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0001376C File Offset: 0x0001196C
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x00013774 File Offset: 0x00011974
		public LocalizableTextType DisplayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		// Token: 0x0400055E RID: 1374
		private int valueField;

		// Token: 0x0400055F RID: 1375
		private string technicalNameField;

		// Token: 0x04000560 RID: 1376
		private LocalizableTextType displayNameField;
	}
}
