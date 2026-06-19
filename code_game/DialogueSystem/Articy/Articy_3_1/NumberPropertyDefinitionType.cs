using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E5 RID: 485
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class NumberPropertyDefinitionType
	{
		// Token: 0x1700091F RID: 2335
		// (get) Token: 0x060015CC RID: 5580 RVA: 0x0001CFE0 File Offset: 0x0001B1E0
		// (set) Token: 0x060015CD RID: 5581 RVA: 0x0001CFE8 File Offset: 0x0001B1E8
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

		// Token: 0x17000920 RID: 2336
		// (get) Token: 0x060015CE RID: 5582 RVA: 0x0001CFF4 File Offset: 0x0001B1F4
		// (set) Token: 0x060015CF RID: 5583 RVA: 0x0001CFFC File Offset: 0x0001B1FC
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

		// Token: 0x17000921 RID: 2337
		// (get) Token: 0x060015D0 RID: 5584 RVA: 0x0001D008 File Offset: 0x0001B208
		// (set) Token: 0x060015D1 RID: 5585 RVA: 0x0001D010 File Offset: 0x0001B210
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

		// Token: 0x17000922 RID: 2338
		// (get) Token: 0x060015D2 RID: 5586 RVA: 0x0001D01C File Offset: 0x0001B21C
		// (set) Token: 0x060015D3 RID: 5587 RVA: 0x0001D024 File Offset: 0x0001B224
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

		// Token: 0x17000923 RID: 2339
		// (get) Token: 0x060015D4 RID: 5588 RVA: 0x0001D030 File Offset: 0x0001B230
		// (set) Token: 0x060015D5 RID: 5589 RVA: 0x0001D038 File Offset: 0x0001B238
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

		// Token: 0x17000924 RID: 2340
		// (get) Token: 0x060015D6 RID: 5590 RVA: 0x0001D044 File Offset: 0x0001B244
		// (set) Token: 0x060015D7 RID: 5591 RVA: 0x0001D04C File Offset: 0x0001B24C
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

		// Token: 0x17000925 RID: 2341
		// (get) Token: 0x060015D8 RID: 5592 RVA: 0x0001D058 File Offset: 0x0001B258
		// (set) Token: 0x060015D9 RID: 5593 RVA: 0x0001D060 File Offset: 0x0001B260
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

		// Token: 0x17000926 RID: 2342
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x0001D06C File Offset: 0x0001B26C
		// (set) Token: 0x060015DB RID: 5595 RVA: 0x0001D074 File Offset: 0x0001B274
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

		// Token: 0x17000927 RID: 2343
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x0001D080 File Offset: 0x0001B280
		// (set) Token: 0x060015DD RID: 5597 RVA: 0x0001D088 File Offset: 0x0001B288
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

		// Token: 0x17000928 RID: 2344
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x0001D094 File Offset: 0x0001B294
		// (set) Token: 0x060015DF RID: 5599 RVA: 0x0001D09C File Offset: 0x0001B29C
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

		// Token: 0x17000929 RID: 2345
		// (get) Token: 0x060015E0 RID: 5600 RVA: 0x0001D0A8 File Offset: 0x0001B2A8
		// (set) Token: 0x060015E1 RID: 5601 RVA: 0x0001D0B0 File Offset: 0x0001B2B0
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

		// Token: 0x1700092A RID: 2346
		// (get) Token: 0x060015E2 RID: 5602 RVA: 0x0001D0BC File Offset: 0x0001B2BC
		// (set) Token: 0x060015E3 RID: 5603 RVA: 0x0001D0C4 File Offset: 0x0001B2C4
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

		// Token: 0x1700092B RID: 2347
		// (get) Token: 0x060015E4 RID: 5604 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		// (set) Token: 0x060015E5 RID: 5605 RVA: 0x0001D0D8 File Offset: 0x0001B2D8
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

		// Token: 0x1700092C RID: 2348
		// (get) Token: 0x060015E6 RID: 5606 RVA: 0x0001D0E4 File Offset: 0x0001B2E4
		// (set) Token: 0x060015E7 RID: 5607 RVA: 0x0001D0EC File Offset: 0x0001B2EC
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

		// Token: 0x1700092D RID: 2349
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x0001D0F8 File Offset: 0x0001B2F8
		// (set) Token: 0x060015E9 RID: 5609 RVA: 0x0001D100 File Offset: 0x0001B300
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

		// Token: 0x1700092E RID: 2350
		// (get) Token: 0x060015EA RID: 5610 RVA: 0x0001D10C File Offset: 0x0001B30C
		// (set) Token: 0x060015EB RID: 5611 RVA: 0x0001D114 File Offset: 0x0001B314
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

		// Token: 0x1700092F RID: 2351
		// (get) Token: 0x060015EC RID: 5612 RVA: 0x0001D120 File Offset: 0x0001B320
		// (set) Token: 0x060015ED RID: 5613 RVA: 0x0001D128 File Offset: 0x0001B328
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

		// Token: 0x17000930 RID: 2352
		// (get) Token: 0x060015EE RID: 5614 RVA: 0x0001D134 File Offset: 0x0001B334
		// (set) Token: 0x060015EF RID: 5615 RVA: 0x0001D13C File Offset: 0x0001B33C
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

		// Token: 0x17000931 RID: 2353
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x0001D148 File Offset: 0x0001B348
		// (set) Token: 0x060015F1 RID: 5617 RVA: 0x0001D150 File Offset: 0x0001B350
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

		// Token: 0x17000932 RID: 2354
		// (get) Token: 0x060015F2 RID: 5618 RVA: 0x0001D15C File Offset: 0x0001B35C
		// (set) Token: 0x060015F3 RID: 5619 RVA: 0x0001D164 File Offset: 0x0001B364
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

		// Token: 0x17000933 RID: 2355
		// (get) Token: 0x060015F4 RID: 5620 RVA: 0x0001D170 File Offset: 0x0001B370
		// (set) Token: 0x060015F5 RID: 5621 RVA: 0x0001D178 File Offset: 0x0001B378
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

		// Token: 0x17000934 RID: 2356
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x0001D184 File Offset: 0x0001B384
		// (set) Token: 0x060015F7 RID: 5623 RVA: 0x0001D18C File Offset: 0x0001B38C
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

		// Token: 0x04000C08 RID: 3080
		private LocalizableTextType displayNameField;

		// Token: 0x04000C09 RID: 3081
		private string colorField;

		// Token: 0x04000C0A RID: 3082
		private string technicalNameField;

		// Token: 0x04000C0B RID: 3083
		private string tooltipTextField;

		// Token: 0x04000C0C RID: 3084
		private int isMandatoryField;

		// Token: 0x04000C0D RID: 3085
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000C0E RID: 3086
		private int isLocalizedField;

		// Token: 0x04000C0F RID: 3087
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000C10 RID: 3088
		private string placeholderValueField;

		// Token: 0x04000C11 RID: 3089
		private decimal defaultValueField;

		// Token: 0x04000C12 RID: 3090
		private bool defaultValueFieldSpecified;

		// Token: 0x04000C13 RID: 3091
		private decimal minValueField;

		// Token: 0x04000C14 RID: 3092
		private bool minValueFieldSpecified;

		// Token: 0x04000C15 RID: 3093
		private decimal maxValueField;

		// Token: 0x04000C16 RID: 3094
		private bool maxValueFieldSpecified;

		// Token: 0x04000C17 RID: 3095
		private int precisionField;

		// Token: 0x04000C18 RID: 3096
		private bool precisionFieldSpecified;

		// Token: 0x04000C19 RID: 3097
		private string unitField;

		// Token: 0x04000C1A RID: 3098
		private int displayThousandsSeparatorField;

		// Token: 0x04000C1B RID: 3099
		private bool displayThousandsSeparatorFieldSpecified;

		// Token: 0x04000C1C RID: 3100
		private string idField;

		// Token: 0x04000C1D RID: 3101
		private string basedOnField;
	}
}
