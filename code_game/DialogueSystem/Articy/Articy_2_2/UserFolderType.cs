using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000104 RID: 260
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class UserFolderType
	{
		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x00014258 File Offset: 0x00012458
		// (set) Token: 0x06000B0F RID: 2831 RVA: 0x00014260 File Offset: 0x00012460
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

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x0001426C File Offset: 0x0001246C
		// (set) Token: 0x06000B11 RID: 2833 RVA: 0x00014274 File Offset: 0x00012474
		public LocalizableTextType Text
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

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000B12 RID: 2834 RVA: 0x00014280 File Offset: 0x00012480
		// (set) Token: 0x06000B13 RID: 2835 RVA: 0x00014288 File Offset: 0x00012488
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x00014294 File Offset: 0x00012494
		// (set) Token: 0x06000B15 RID: 2837 RVA: 0x0001429C File Offset: 0x0001249C
		[XmlElement(DataType = "token")]
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

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000B16 RID: 2838 RVA: 0x000142A8 File Offset: 0x000124A8
		// (set) Token: 0x06000B17 RID: 2839 RVA: 0x000142B0 File Offset: 0x000124B0
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000B18 RID: 2840 RVA: 0x000142BC File Offset: 0x000124BC
		// (set) Token: 0x06000B19 RID: 2841 RVA: 0x000142C4 File Offset: 0x000124C4
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000B1A RID: 2842 RVA: 0x000142D0 File Offset: 0x000124D0
		// (set) Token: 0x06000B1B RID: 2843 RVA: 0x000142D8 File Offset: 0x000124D8
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x040005EB RID: 1515
		private LocalizableTextType displayNameField;

		// Token: 0x040005EC RID: 1516
		private LocalizableTextType textField;

		// Token: 0x040005ED RID: 1517
		private string colorField;

		// Token: 0x040005EE RID: 1518
		private string technicalNameField;

		// Token: 0x040005EF RID: 1519
		private string externalIdField;

		// Token: 0x040005F0 RID: 1520
		private string shortIdField;

		// Token: 0x040005F1 RID: 1521
		private string idField;
	}
}
