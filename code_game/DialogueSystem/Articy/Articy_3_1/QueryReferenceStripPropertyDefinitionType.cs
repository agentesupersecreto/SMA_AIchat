using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F0 RID: 496
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class QueryReferenceStripPropertyDefinitionType
	{
		// Token: 0x17000971 RID: 2417
		// (get) Token: 0x0600167A RID: 5754 RVA: 0x0001D698 File Offset: 0x0001B898
		// (set) Token: 0x0600167B RID: 5755 RVA: 0x0001D6A0 File Offset: 0x0001B8A0
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

		// Token: 0x17000972 RID: 2418
		// (get) Token: 0x0600167C RID: 5756 RVA: 0x0001D6AC File Offset: 0x0001B8AC
		// (set) Token: 0x0600167D RID: 5757 RVA: 0x0001D6B4 File Offset: 0x0001B8B4
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

		// Token: 0x17000973 RID: 2419
		// (get) Token: 0x0600167E RID: 5758 RVA: 0x0001D6C0 File Offset: 0x0001B8C0
		// (set) Token: 0x0600167F RID: 5759 RVA: 0x0001D6C8 File Offset: 0x0001B8C8
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

		// Token: 0x17000974 RID: 2420
		// (get) Token: 0x06001680 RID: 5760 RVA: 0x0001D6D4 File Offset: 0x0001B8D4
		// (set) Token: 0x06001681 RID: 5761 RVA: 0x0001D6DC File Offset: 0x0001B8DC
		public string TooltipText
		{
			get
			{
				return this.tooltipTextField;
			}
			set
			{
				this.tooltipTextField = value;
			}
		}

		// Token: 0x17000975 RID: 2421
		// (get) Token: 0x06001682 RID: 5762 RVA: 0x0001D6E8 File Offset: 0x0001B8E8
		// (set) Token: 0x06001683 RID: 5763 RVA: 0x0001D6F0 File Offset: 0x0001B8F0
		public int IsMandatory
		{
			get
			{
				return this.isMandatoryField;
			}
			set
			{
				this.isMandatoryField = value;
			}
		}

		// Token: 0x17000976 RID: 2422
		// (get) Token: 0x06001684 RID: 5764 RVA: 0x0001D6FC File Offset: 0x0001B8FC
		// (set) Token: 0x06001685 RID: 5765 RVA: 0x0001D704 File Offset: 0x0001B904
		[XmlIgnore]
		public bool IsMandatorySpecified
		{
			get
			{
				return this.isMandatoryFieldSpecified;
			}
			set
			{
				this.isMandatoryFieldSpecified = value;
			}
		}

		// Token: 0x17000977 RID: 2423
		// (get) Token: 0x06001686 RID: 5766 RVA: 0x0001D710 File Offset: 0x0001B910
		// (set) Token: 0x06001687 RID: 5767 RVA: 0x0001D718 File Offset: 0x0001B918
		public int IsLocalized
		{
			get
			{
				return this.isLocalizedField;
			}
			set
			{
				this.isLocalizedField = value;
			}
		}

		// Token: 0x17000978 RID: 2424
		// (get) Token: 0x06001688 RID: 5768 RVA: 0x0001D724 File Offset: 0x0001B924
		// (set) Token: 0x06001689 RID: 5769 RVA: 0x0001D72C File Offset: 0x0001B92C
		[XmlIgnore]
		public bool IsLocalizedSpecified
		{
			get
			{
				return this.isLocalizedFieldSpecified;
			}
			set
			{
				this.isLocalizedFieldSpecified = value;
			}
		}

		// Token: 0x17000979 RID: 2425
		// (get) Token: 0x0600168A RID: 5770 RVA: 0x0001D738 File Offset: 0x0001B938
		// (set) Token: 0x0600168B RID: 5771 RVA: 0x0001D740 File Offset: 0x0001B940
		public string PlaceholderValue
		{
			get
			{
				return this.placeholderValueField;
			}
			set
			{
				this.placeholderValueField = value;
			}
		}

		// Token: 0x1700097A RID: 2426
		// (get) Token: 0x0600168C RID: 5772 RVA: 0x0001D74C File Offset: 0x0001B94C
		// (set) Token: 0x0600168D RID: 5773 RVA: 0x0001D754 File Offset: 0x0001B954
		public string DefaultValue
		{
			get
			{
				return this.defaultValueField;
			}
			set
			{
				this.defaultValueField = value;
			}
		}

		// Token: 0x1700097B RID: 2427
		// (get) Token: 0x0600168E RID: 5774 RVA: 0x0001D760 File Offset: 0x0001B960
		// (set) Token: 0x0600168F RID: 5775 RVA: 0x0001D768 File Offset: 0x0001B968
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

		// Token: 0x1700097C RID: 2428
		// (get) Token: 0x06001690 RID: 5776 RVA: 0x0001D774 File Offset: 0x0001B974
		// (set) Token: 0x06001691 RID: 5777 RVA: 0x0001D77C File Offset: 0x0001B97C
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

		// Token: 0x04000C62 RID: 3170
		private LocalizableTextType displayNameField;

		// Token: 0x04000C63 RID: 3171
		private string colorField;

		// Token: 0x04000C64 RID: 3172
		private string technicalNameField;

		// Token: 0x04000C65 RID: 3173
		private string tooltipTextField;

		// Token: 0x04000C66 RID: 3174
		private int isMandatoryField;

		// Token: 0x04000C67 RID: 3175
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000C68 RID: 3176
		private int isLocalizedField;

		// Token: 0x04000C69 RID: 3177
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000C6A RID: 3178
		private string placeholderValueField;

		// Token: 0x04000C6B RID: 3179
		private string defaultValueField;

		// Token: 0x04000C6C RID: 3180
		private string idField;

		// Token: 0x04000C6D RID: 3181
		private string basedOnField;
	}
}
