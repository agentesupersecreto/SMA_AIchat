using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B5 RID: 437
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class EnumValueType
	{
		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x0600137F RID: 4991 RVA: 0x0001B8FC File Offset: 0x00019AFC
		// (set) Token: 0x06001380 RID: 4992 RVA: 0x0001B904 File Offset: 0x00019B04
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

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06001381 RID: 4993 RVA: 0x0001B910 File Offset: 0x00019B10
		// (set) Token: 0x06001382 RID: 4994 RVA: 0x0001B918 File Offset: 0x00019B18
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

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06001383 RID: 4995 RVA: 0x0001B924 File Offset: 0x00019B24
		// (set) Token: 0x06001384 RID: 4996 RVA: 0x0001B92C File Offset: 0x00019B2C
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

		// Token: 0x04000AA1 RID: 2721
		private int valueField;

		// Token: 0x04000AA2 RID: 2722
		private string technicalNameField;

		// Token: 0x04000AA3 RID: 2723
		private LocalizableTextType displayNameField;
	}
}
