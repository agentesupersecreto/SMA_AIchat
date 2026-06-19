using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x020000A0 RID: 160
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureDefinitionType
	{
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x0600065E RID: 1630 RVA: 0x0001081C File Offset: 0x0000EA1C
		// (set) Token: 0x0600065F RID: 1631 RVA: 0x00010824 File Offset: 0x0000EA24
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

		// Token: 0x17000221 RID: 545
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00010830 File Offset: 0x0000EA30
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00010838 File Offset: 0x0000EA38
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

		// Token: 0x17000222 RID: 546
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x00010844 File Offset: 0x0000EA44
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x0001084C File Offset: 0x0000EA4C
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

		// Token: 0x17000223 RID: 547
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x00010858 File Offset: 0x0000EA58
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x00010860 File Offset: 0x0000EA60
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

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0001086C File Offset: 0x0000EA6C
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x00010874 File Offset: 0x0000EA74
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

		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x00010880 File Offset: 0x0000EA80
		// (set) Token: 0x06000669 RID: 1641 RVA: 0x00010888 File Offset: 0x0000EA88
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

		// Token: 0x17000226 RID: 550
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00010894 File Offset: 0x0000EA94
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x0001089C File Offset: 0x0000EA9C
		public PropertyDefinitionsType PropertyDefinitions
		{
			get
			{
				return this.propertyDefinitionsField;
			}
			set
			{
				this.propertyDefinitionsField = value;
			}
		}

		// Token: 0x17000227 RID: 551
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x000108A8 File Offset: 0x0000EAA8
		// (set) Token: 0x0600066D RID: 1645 RVA: 0x000108B0 File Offset: 0x0000EAB0
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

		// Token: 0x17000228 RID: 552
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x000108BC File Offset: 0x0000EABC
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x000108C4 File Offset: 0x0000EAC4
		[XmlAttribute]
		public string BasedOn
		{
			get
			{
				return this.basedOnField;
			}
			set
			{
				this.basedOnField = value;
			}
		}

		// Token: 0x04000354 RID: 852
		private LocalizableTextType displayNameField;

		// Token: 0x04000355 RID: 853
		private LocalizableTextType textField;

		// Token: 0x04000356 RID: 854
		private string colorField;

		// Token: 0x04000357 RID: 855
		private string technicalNameField;

		// Token: 0x04000358 RID: 856
		private string externalIdField;

		// Token: 0x04000359 RID: 857
		private string shortIdField;

		// Token: 0x0400035A RID: 858
		private PropertyDefinitionsType propertyDefinitionsField;

		// Token: 0x0400035B RID: 859
		private string guidField;

		// Token: 0x0400035C RID: 860
		private string basedOnField;
	}
}
