using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000100 RID: 256
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class TextPropertyDefinitionType
	{
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x00014008 File Offset: 0x00012208
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x00014010 File Offset: 0x00012210
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

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0001401C File Offset: 0x0001221C
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x00014024 File Offset: 0x00012224
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

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x00014030 File Offset: 0x00012230
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x00014038 File Offset: 0x00012238
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

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x00014044 File Offset: 0x00012244
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x0001404C File Offset: 0x0001224C
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

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x00014058 File Offset: 0x00012258
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x00014060 File Offset: 0x00012260
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

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0001406C File Offset: 0x0001226C
		// (set) Token: 0x06000ADD RID: 2781 RVA: 0x00014074 File Offset: 0x00012274
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

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x00014080 File Offset: 0x00012280
		// (set) Token: 0x06000ADF RID: 2783 RVA: 0x00014088 File Offset: 0x00012288
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

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x00014094 File Offset: 0x00012294
		// (set) Token: 0x06000AE1 RID: 2785 RVA: 0x0001409C File Offset: 0x0001229C
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

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x000140A8 File Offset: 0x000122A8
		// (set) Token: 0x06000AE3 RID: 2787 RVA: 0x000140B0 File Offset: 0x000122B0
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

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x000140BC File Offset: 0x000122BC
		// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x000140C4 File Offset: 0x000122C4
		public TextPropertyDefinitionValueType DefaultValue
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

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x000140D0 File Offset: 0x000122D0
		// (set) Token: 0x06000AE7 RID: 2791 RVA: 0x000140D8 File Offset: 0x000122D8
		public decimal DisallowedChars
		{
			get
			{
				return this.disallowedCharsField;
			}
			set
			{
				this.disallowedCharsField = value;
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x000140E4 File Offset: 0x000122E4
		// (set) Token: 0x06000AE9 RID: 2793 RVA: 0x000140EC File Offset: 0x000122EC
		[XmlIgnore]
		public bool DisallowedCharsSpecified
		{
			get
			{
				return this.disallowedCharsFieldSpecified;
			}
			set
			{
				this.disallowedCharsFieldSpecified = value;
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x000140F8 File Offset: 0x000122F8
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x00014100 File Offset: 0x00012300
		public int MaxLength
		{
			get
			{
				return this.maxLengthField;
			}
			set
			{
				this.maxLengthField = value;
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0001410C File Offset: 0x0001230C
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x00014114 File Offset: 0x00012314
		[XmlIgnore]
		public bool MaxLengthSpecified
		{
			get
			{
				return this.maxLengthFieldSpecified;
			}
			set
			{
				this.maxLengthFieldSpecified = value;
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x00014120 File Offset: 0x00012320
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x00014128 File Offset: 0x00012328
		public int AllowsLinebreaks
		{
			get
			{
				return this.allowsLinebreaksField;
			}
			set
			{
				this.allowsLinebreaksField = value;
			}
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00014134 File Offset: 0x00012334
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x0001413C File Offset: 0x0001233C
		[XmlIgnore]
		public bool AllowsLinebreaksSpecified
		{
			get
			{
				return this.allowsLinebreaksFieldSpecified;
			}
			set
			{
				this.allowsLinebreaksFieldSpecified = value;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x00014148 File Offset: 0x00012348
		// (set) Token: 0x06000AF3 RID: 2803 RVA: 0x00014150 File Offset: 0x00012350
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

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0001415C File Offset: 0x0001235C
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x00014164 File Offset: 0x00012364
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

		// Token: 0x040005CF RID: 1487
		private LocalizableTextType displayNameField;

		// Token: 0x040005D0 RID: 1488
		private string colorField;

		// Token: 0x040005D1 RID: 1489
		private string technicalNameField;

		// Token: 0x040005D2 RID: 1490
		private string tooltipTextField;

		// Token: 0x040005D3 RID: 1491
		private int isMandatoryField;

		// Token: 0x040005D4 RID: 1492
		private bool isMandatoryFieldSpecified;

		// Token: 0x040005D5 RID: 1493
		private int isLocalizedField;

		// Token: 0x040005D6 RID: 1494
		private bool isLocalizedFieldSpecified;

		// Token: 0x040005D7 RID: 1495
		private string placeholderValueField;

		// Token: 0x040005D8 RID: 1496
		private TextPropertyDefinitionValueType defaultValueField;

		// Token: 0x040005D9 RID: 1497
		private decimal disallowedCharsField;

		// Token: 0x040005DA RID: 1498
		private bool disallowedCharsFieldSpecified;

		// Token: 0x040005DB RID: 1499
		private int maxLengthField;

		// Token: 0x040005DC RID: 1500
		private bool maxLengthFieldSpecified;

		// Token: 0x040005DD RID: 1501
		private int allowsLinebreaksField;

		// Token: 0x040005DE RID: 1502
		private bool allowsLinebreaksFieldSpecified;

		// Token: 0x040005DF RID: 1503
		private string idField;

		// Token: 0x040005E0 RID: 1504
		private string basedOnField;
	}
}
