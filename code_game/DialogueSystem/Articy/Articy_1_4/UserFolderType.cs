using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x020000A1 RID: 161
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class UserFolderType
	{
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x000108D8 File Offset: 0x0000EAD8
		// (set) Token: 0x06000672 RID: 1650 RVA: 0x000108E0 File Offset: 0x0000EAE0
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

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000673 RID: 1651 RVA: 0x000108EC File Offset: 0x0000EAEC
		// (set) Token: 0x06000674 RID: 1652 RVA: 0x000108F4 File Offset: 0x0000EAF4
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

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x00010900 File Offset: 0x0000EB00
		// (set) Token: 0x06000676 RID: 1654 RVA: 0x00010908 File Offset: 0x0000EB08
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

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000677 RID: 1655 RVA: 0x00010914 File Offset: 0x0000EB14
		// (set) Token: 0x06000678 RID: 1656 RVA: 0x0001091C File Offset: 0x0000EB1C
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

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x00010928 File Offset: 0x0000EB28
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x00010930 File Offset: 0x0000EB30
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

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x0001093C File Offset: 0x0000EB3C
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00010944 File Offset: 0x0000EB44
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

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00010950 File Offset: 0x0000EB50
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00010958 File Offset: 0x0000EB58
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x0400035D RID: 861
		private LocalizableTextType displayNameField;

		// Token: 0x0400035E RID: 862
		private LocalizableTextType textField;

		// Token: 0x0400035F RID: 863
		private string colorField;

		// Token: 0x04000360 RID: 864
		private string technicalNameField;

		// Token: 0x04000361 RID: 865
		private string externalIdField;

		// Token: 0x04000362 RID: 866
		private string shortIdField;

		// Token: 0x04000363 RID: 867
		private string guidField;
	}
}
