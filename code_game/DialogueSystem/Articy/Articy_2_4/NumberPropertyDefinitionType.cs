using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000166 RID: 358
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NumberPropertyDefinitionType
	{
		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06000F7A RID: 3962 RVA: 0x00017FB8 File Offset: 0x000161B8
		// (set) Token: 0x06000F7B RID: 3963 RVA: 0x00017FC0 File Offset: 0x000161C0
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

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06000F7C RID: 3964 RVA: 0x00017FCC File Offset: 0x000161CC
		// (set) Token: 0x06000F7D RID: 3965 RVA: 0x00017FD4 File Offset: 0x000161D4
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

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x06000F7E RID: 3966 RVA: 0x00017FE0 File Offset: 0x000161E0
		// (set) Token: 0x06000F7F RID: 3967 RVA: 0x00017FE8 File Offset: 0x000161E8
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

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x06000F80 RID: 3968 RVA: 0x00017FF4 File Offset: 0x000161F4
		// (set) Token: 0x06000F81 RID: 3969 RVA: 0x00017FFC File Offset: 0x000161FC
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

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x00018008 File Offset: 0x00016208
		// (set) Token: 0x06000F83 RID: 3971 RVA: 0x00018010 File Offset: 0x00016210
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

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x0001801C File Offset: 0x0001621C
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x00018024 File Offset: 0x00016224
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

		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x00018030 File Offset: 0x00016230
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x00018038 File Offset: 0x00016238
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

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x00018044 File Offset: 0x00016244
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0001804C File Offset: 0x0001624C
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

		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x00018058 File Offset: 0x00016258
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x00018060 File Offset: 0x00016260
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

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x0001806C File Offset: 0x0001626C
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x00018074 File Offset: 0x00016274
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

		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x00018080 File Offset: 0x00016280
		// (set) Token: 0x06000F8F RID: 3983 RVA: 0x00018088 File Offset: 0x00016288
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

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x00018094 File Offset: 0x00016294
		// (set) Token: 0x06000F91 RID: 3985 RVA: 0x0001809C File Offset: 0x0001629C
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

		// Token: 0x17000648 RID: 1608
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x000180A8 File Offset: 0x000162A8
		// (set) Token: 0x06000F93 RID: 3987 RVA: 0x000180B0 File Offset: 0x000162B0
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

		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06000F94 RID: 3988 RVA: 0x000180BC File Offset: 0x000162BC
		// (set) Token: 0x06000F95 RID: 3989 RVA: 0x000180C4 File Offset: 0x000162C4
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

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x06000F96 RID: 3990 RVA: 0x000180D0 File Offset: 0x000162D0
		// (set) Token: 0x06000F97 RID: 3991 RVA: 0x000180D8 File Offset: 0x000162D8
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

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x06000F98 RID: 3992 RVA: 0x000180E4 File Offset: 0x000162E4
		// (set) Token: 0x06000F99 RID: 3993 RVA: 0x000180EC File Offset: 0x000162EC
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

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x06000F9A RID: 3994 RVA: 0x000180F8 File Offset: 0x000162F8
		// (set) Token: 0x06000F9B RID: 3995 RVA: 0x00018100 File Offset: 0x00016300
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

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06000F9C RID: 3996 RVA: 0x0001810C File Offset: 0x0001630C
		// (set) Token: 0x06000F9D RID: 3997 RVA: 0x00018114 File Offset: 0x00016314
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

		// Token: 0x1700064E RID: 1614
		// (get) Token: 0x06000F9E RID: 3998 RVA: 0x00018120 File Offset: 0x00016320
		// (set) Token: 0x06000F9F RID: 3999 RVA: 0x00018128 File Offset: 0x00016328
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

		// Token: 0x1700064F RID: 1615
		// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x00018134 File Offset: 0x00016334
		// (set) Token: 0x06000FA1 RID: 4001 RVA: 0x0001813C File Offset: 0x0001633C
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

		// Token: 0x17000650 RID: 1616
		// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x00018148 File Offset: 0x00016348
		// (set) Token: 0x06000FA3 RID: 4003 RVA: 0x00018150 File Offset: 0x00016350
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

		// Token: 0x17000651 RID: 1617
		// (get) Token: 0x06000FA4 RID: 4004 RVA: 0x0001815C File Offset: 0x0001635C
		// (set) Token: 0x06000FA5 RID: 4005 RVA: 0x00018164 File Offset: 0x00016364
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

		// Token: 0x0400087C RID: 2172
		private LocalizableTextType displayNameField;

		// Token: 0x0400087D RID: 2173
		private string colorField;

		// Token: 0x0400087E RID: 2174
		private string technicalNameField;

		// Token: 0x0400087F RID: 2175
		private string tooltipTextField;

		// Token: 0x04000880 RID: 2176
		private int isMandatoryField;

		// Token: 0x04000881 RID: 2177
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000882 RID: 2178
		private int isLocalizedField;

		// Token: 0x04000883 RID: 2179
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000884 RID: 2180
		private string placeholderValueField;

		// Token: 0x04000885 RID: 2181
		private decimal defaultValueField;

		// Token: 0x04000886 RID: 2182
		private bool defaultValueFieldSpecified;

		// Token: 0x04000887 RID: 2183
		private decimal minValueField;

		// Token: 0x04000888 RID: 2184
		private bool minValueFieldSpecified;

		// Token: 0x04000889 RID: 2185
		private decimal maxValueField;

		// Token: 0x0400088A RID: 2186
		private bool maxValueFieldSpecified;

		// Token: 0x0400088B RID: 2187
		private int precisionField;

		// Token: 0x0400088C RID: 2188
		private bool precisionFieldSpecified;

		// Token: 0x0400088D RID: 2189
		private string unitField;

		// Token: 0x0400088E RID: 2190
		private int displayThousandsSeparatorField;

		// Token: 0x0400088F RID: 2191
		private bool displayThousandsSeparatorFieldSpecified;

		// Token: 0x04000890 RID: 2192
		private string idField;

		// Token: 0x04000891 RID: 2193
		private string basedOnField;
	}
}
