using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000090 RID: 144
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class EnumValueType
	{
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000571 RID: 1393 RVA: 0x0000FEF8 File Offset: 0x0000E0F8
		// (set) Token: 0x06000572 RID: 1394 RVA: 0x0000FF00 File Offset: 0x0000E100
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

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000573 RID: 1395 RVA: 0x0000FF0C File Offset: 0x0000E10C
		// (set) Token: 0x06000574 RID: 1396 RVA: 0x0000FF14 File Offset: 0x0000E114
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

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x06000575 RID: 1397 RVA: 0x0000FF20 File Offset: 0x0000E120
		// (set) Token: 0x06000576 RID: 1398 RVA: 0x0000FF28 File Offset: 0x0000E128
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

		// Token: 0x040002DF RID: 735
		private int valueField;

		// Token: 0x040002E0 RID: 736
		private string technicalNameField;

		// Token: 0x040002E1 RID: 737
		private LocalizableTextType displayNameField;
	}
}
