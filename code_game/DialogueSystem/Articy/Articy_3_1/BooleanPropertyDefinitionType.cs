using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A5 RID: 421
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class BooleanPropertyDefinitionType
	{
		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06001268 RID: 4712 RVA: 0x0001AE34 File Offset: 0x00019034
		// (set) Token: 0x06001269 RID: 4713 RVA: 0x0001AE3C File Offset: 0x0001903C
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

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x0600126A RID: 4714 RVA: 0x0001AE48 File Offset: 0x00019048
		// (set) Token: 0x0600126B RID: 4715 RVA: 0x0001AE50 File Offset: 0x00019050
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

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x0600126C RID: 4716 RVA: 0x0001AE5C File Offset: 0x0001905C
		// (set) Token: 0x0600126D RID: 4717 RVA: 0x0001AE64 File Offset: 0x00019064
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

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x0600126E RID: 4718 RVA: 0x0001AE70 File Offset: 0x00019070
		// (set) Token: 0x0600126F RID: 4719 RVA: 0x0001AE78 File Offset: 0x00019078
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

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06001270 RID: 4720 RVA: 0x0001AE84 File Offset: 0x00019084
		// (set) Token: 0x06001271 RID: 4721 RVA: 0x0001AE8C File Offset: 0x0001908C
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

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06001272 RID: 4722 RVA: 0x0001AE98 File Offset: 0x00019098
		// (set) Token: 0x06001273 RID: 4723 RVA: 0x0001AEA0 File Offset: 0x000190A0
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

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06001274 RID: 4724 RVA: 0x0001AEAC File Offset: 0x000190AC
		// (set) Token: 0x06001275 RID: 4725 RVA: 0x0001AEB4 File Offset: 0x000190B4
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

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06001276 RID: 4726 RVA: 0x0001AEC0 File Offset: 0x000190C0
		// (set) Token: 0x06001277 RID: 4727 RVA: 0x0001AEC8 File Offset: 0x000190C8
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

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06001278 RID: 4728 RVA: 0x0001AED4 File Offset: 0x000190D4
		// (set) Token: 0x06001279 RID: 4729 RVA: 0x0001AEDC File Offset: 0x000190DC
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

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x0600127A RID: 4730 RVA: 0x0001AEE8 File Offset: 0x000190E8
		// (set) Token: 0x0600127B RID: 4731 RVA: 0x0001AEF0 File Offset: 0x000190F0
		public int DefaultValue
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

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x0600127C RID: 4732 RVA: 0x0001AEFC File Offset: 0x000190FC
		// (set) Token: 0x0600127D RID: 4733 RVA: 0x0001AF04 File Offset: 0x00019104
		[XmlIgnore]
		public bool DefaultValueSpecified
		{
			get
			{
				return this.defaultValueFieldSpecified;
			}
			set
			{
				this.defaultValueFieldSpecified = value;
			}
		}

		// Token: 0x1700078F RID: 1935
		// (get) Token: 0x0600127E RID: 4734 RVA: 0x0001AF10 File Offset: 0x00019110
		// (set) Token: 0x0600127F RID: 4735 RVA: 0x0001AF18 File Offset: 0x00019118
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

		// Token: 0x17000790 RID: 1936
		// (get) Token: 0x06001280 RID: 4736 RVA: 0x0001AF24 File Offset: 0x00019124
		// (set) Token: 0x06001281 RID: 4737 RVA: 0x0001AF2C File Offset: 0x0001912C
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

		// Token: 0x04000A1A RID: 2586
		private LocalizableTextType displayNameField;

		// Token: 0x04000A1B RID: 2587
		private string colorField;

		// Token: 0x04000A1C RID: 2588
		private string technicalNameField;

		// Token: 0x04000A1D RID: 2589
		private string tooltipTextField;

		// Token: 0x04000A1E RID: 2590
		private int isMandatoryField;

		// Token: 0x04000A1F RID: 2591
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000A20 RID: 2592
		private int isLocalizedField;

		// Token: 0x04000A21 RID: 2593
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000A22 RID: 2594
		private string placeholderValueField;

		// Token: 0x04000A23 RID: 2595
		private int defaultValueField;

		// Token: 0x04000A24 RID: 2596
		private bool defaultValueFieldSpecified;

		// Token: 0x04000A25 RID: 2597
		private string idField;

		// Token: 0x04000A26 RID: 2598
		private string basedOnField;
	}
}
