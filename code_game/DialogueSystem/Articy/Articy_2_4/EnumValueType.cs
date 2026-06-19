using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000136 RID: 310
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumValueType
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000D2D RID: 3373 RVA: 0x000168D4 File Offset: 0x00014AD4
		// (set) Token: 0x06000D2E RID: 3374 RVA: 0x000168DC File Offset: 0x00014ADC
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

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06000D2F RID: 3375 RVA: 0x000168E8 File Offset: 0x00014AE8
		// (set) Token: 0x06000D30 RID: 3376 RVA: 0x000168F0 File Offset: 0x00014AF0
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

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06000D31 RID: 3377 RVA: 0x000168FC File Offset: 0x00014AFC
		// (set) Token: 0x06000D32 RID: 3378 RVA: 0x00016904 File Offset: 0x00014B04
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

		// Token: 0x04000715 RID: 1813
		private int valueField;

		// Token: 0x04000716 RID: 1814
		private string technicalNameField;

		// Token: 0x04000717 RID: 1815
		private LocalizableTextType displayNameField;
	}
}
