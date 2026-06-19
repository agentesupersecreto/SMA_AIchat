using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000FD RID: 253
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class NumberPropertyDefinitionType
	{
		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000A81 RID: 2689 RVA: 0x00013CE4 File Offset: 0x00011EE4
		// (set) Token: 0x06000A82 RID: 2690 RVA: 0x00013CEC File Offset: 0x00011EEC
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

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00013CF8 File Offset: 0x00011EF8
		// (set) Token: 0x06000A84 RID: 2692 RVA: 0x00013D00 File Offset: 0x00011F00
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

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06000A85 RID: 2693 RVA: 0x00013D0C File Offset: 0x00011F0C
		// (set) Token: 0x06000A86 RID: 2694 RVA: 0x00013D14 File Offset: 0x00011F14
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

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x00013D20 File Offset: 0x00011F20
		// (set) Token: 0x06000A88 RID: 2696 RVA: 0x00013D28 File Offset: 0x00011F28
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

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000A89 RID: 2697 RVA: 0x00013D34 File Offset: 0x00011F34
		// (set) Token: 0x06000A8A RID: 2698 RVA: 0x00013D3C File Offset: 0x00011F3C
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

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06000A8B RID: 2699 RVA: 0x00013D48 File Offset: 0x00011F48
		// (set) Token: 0x06000A8C RID: 2700 RVA: 0x00013D50 File Offset: 0x00011F50
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

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06000A8D RID: 2701 RVA: 0x00013D5C File Offset: 0x00011F5C
		// (set) Token: 0x06000A8E RID: 2702 RVA: 0x00013D64 File Offset: 0x00011F64
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

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000A8F RID: 2703 RVA: 0x00013D70 File Offset: 0x00011F70
		// (set) Token: 0x06000A90 RID: 2704 RVA: 0x00013D78 File Offset: 0x00011F78
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

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x00013D84 File Offset: 0x00011F84
		// (set) Token: 0x06000A92 RID: 2706 RVA: 0x00013D8C File Offset: 0x00011F8C
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

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00013D98 File Offset: 0x00011F98
		// (set) Token: 0x06000A94 RID: 2708 RVA: 0x00013DA0 File Offset: 0x00011FA0
		public decimal DefaultValue
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

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00013DAC File Offset: 0x00011FAC
		// (set) Token: 0x06000A96 RID: 2710 RVA: 0x00013DB4 File Offset: 0x00011FB4
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

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000A97 RID: 2711 RVA: 0x00013DC0 File Offset: 0x00011FC0
		// (set) Token: 0x06000A98 RID: 2712 RVA: 0x00013DC8 File Offset: 0x00011FC8
		public decimal MinValue
		{
			get
			{
				return this.minValueField;
			}
			set
			{
				this.minValueField = value;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000A99 RID: 2713 RVA: 0x00013DD4 File Offset: 0x00011FD4
		// (set) Token: 0x06000A9A RID: 2714 RVA: 0x00013DDC File Offset: 0x00011FDC
		[XmlIgnore]
		public bool MinValueSpecified
		{
			get
			{
				return this.minValueFieldSpecified;
			}
			set
			{
				this.minValueFieldSpecified = value;
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00013DE8 File Offset: 0x00011FE8
		// (set) Token: 0x06000A9C RID: 2716 RVA: 0x00013DF0 File Offset: 0x00011FF0
		public decimal MaxValue
		{
			get
			{
				return this.maxValueField;
			}
			set
			{
				this.maxValueField = value;
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00013DFC File Offset: 0x00011FFC
		// (set) Token: 0x06000A9E RID: 2718 RVA: 0x00013E04 File Offset: 0x00012004
		[XmlIgnore]
		public bool MaxValueSpecified
		{
			get
			{
				return this.maxValueFieldSpecified;
			}
			set
			{
				this.maxValueFieldSpecified = value;
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00013E10 File Offset: 0x00012010
		// (set) Token: 0x06000AA0 RID: 2720 RVA: 0x00013E18 File Offset: 0x00012018
		public int Precision
		{
			get
			{
				return this.precisionField;
			}
			set
			{
				this.precisionField = value;
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000AA1 RID: 2721 RVA: 0x00013E24 File Offset: 0x00012024
		// (set) Token: 0x06000AA2 RID: 2722 RVA: 0x00013E2C File Offset: 0x0001202C
		[XmlIgnore]
		public bool PrecisionSpecified
		{
			get
			{
				return this.precisionFieldSpecified;
			}
			set
			{
				this.precisionFieldSpecified = value;
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x00013E38 File Offset: 0x00012038
		// (set) Token: 0x06000AA4 RID: 2724 RVA: 0x00013E40 File Offset: 0x00012040
		public string Unit
		{
			get
			{
				return this.unitField;
			}
			set
			{
				this.unitField = value;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00013E4C File Offset: 0x0001204C
		// (set) Token: 0x06000AA6 RID: 2726 RVA: 0x00013E54 File Offset: 0x00012054
		public int DisplayThousandsSeparator
		{
			get
			{
				return this.displayThousandsSeparatorField;
			}
			set
			{
				this.displayThousandsSeparatorField = value;
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x00013E60 File Offset: 0x00012060
		// (set) Token: 0x06000AA8 RID: 2728 RVA: 0x00013E68 File Offset: 0x00012068
		[XmlIgnore]
		public bool DisplayThousandsSeparatorSpecified
		{
			get
			{
				return this.displayThousandsSeparatorFieldSpecified;
			}
			set
			{
				this.displayThousandsSeparatorFieldSpecified = value;
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x06000AA9 RID: 2729 RVA: 0x00013E74 File Offset: 0x00012074
		// (set) Token: 0x06000AAA RID: 2730 RVA: 0x00013E7C File Offset: 0x0001207C
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

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000AAB RID: 2731 RVA: 0x00013E88 File Offset: 0x00012088
		// (set) Token: 0x06000AAC RID: 2732 RVA: 0x00013E90 File Offset: 0x00012090
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

		// Token: 0x040005A8 RID: 1448
		private LocalizableTextType displayNameField;

		// Token: 0x040005A9 RID: 1449
		private string colorField;

		// Token: 0x040005AA RID: 1450
		private string technicalNameField;

		// Token: 0x040005AB RID: 1451
		private string tooltipTextField;

		// Token: 0x040005AC RID: 1452
		private int isMandatoryField;

		// Token: 0x040005AD RID: 1453
		private bool isMandatoryFieldSpecified;

		// Token: 0x040005AE RID: 1454
		private int isLocalizedField;

		// Token: 0x040005AF RID: 1455
		private bool isLocalizedFieldSpecified;

		// Token: 0x040005B0 RID: 1456
		private string placeholderValueField;

		// Token: 0x040005B1 RID: 1457
		private decimal defaultValueField;

		// Token: 0x040005B2 RID: 1458
		private bool defaultValueFieldSpecified;

		// Token: 0x040005B3 RID: 1459
		private decimal minValueField;

		// Token: 0x040005B4 RID: 1460
		private bool minValueFieldSpecified;

		// Token: 0x040005B5 RID: 1461
		private decimal maxValueField;

		// Token: 0x040005B6 RID: 1462
		private bool maxValueFieldSpecified;

		// Token: 0x040005B7 RID: 1463
		private int precisionField;

		// Token: 0x040005B8 RID: 1464
		private bool precisionFieldSpecified;

		// Token: 0x040005B9 RID: 1465
		private string unitField;

		// Token: 0x040005BA RID: 1466
		private int displayThousandsSeparatorField;

		// Token: 0x040005BB RID: 1467
		private bool displayThousandsSeparatorFieldSpecified;

		// Token: 0x040005BC RID: 1468
		private string idField;

		// Token: 0x040005BD RID: 1469
		private string basedOnField;
	}
}
