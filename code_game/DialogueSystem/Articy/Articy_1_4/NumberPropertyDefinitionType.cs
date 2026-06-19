using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009A RID: 154
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NumberPropertyDefinitionType
	{
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00010364 File Offset: 0x0000E564
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x0001036C File Offset: 0x0000E56C
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

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00010378 File Offset: 0x0000E578
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00010380 File Offset: 0x0000E580
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

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0001038C File Offset: 0x0000E58C
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00010394 File Offset: 0x0000E594
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

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x000103A0 File Offset: 0x0000E5A0
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x000103A8 File Offset: 0x0000E5A8
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

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x000103B4 File Offset: 0x0000E5B4
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x000103BC File Offset: 0x0000E5BC
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

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x000103C8 File Offset: 0x0000E5C8
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x000103D0 File Offset: 0x0000E5D0
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

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x000103DC File Offset: 0x0000E5DC
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x000103E4 File Offset: 0x0000E5E4
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

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x000103F0 File Offset: 0x0000E5F0
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x000103F8 File Offset: 0x0000E5F8
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

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x00010404 File Offset: 0x0000E604
		// (set) Token: 0x060005F5 RID: 1525 RVA: 0x0001040C File Offset: 0x0000E60C
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

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x00010418 File Offset: 0x0000E618
		// (set) Token: 0x060005F7 RID: 1527 RVA: 0x00010420 File Offset: 0x0000E620
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

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x0001042C File Offset: 0x0000E62C
		// (set) Token: 0x060005F9 RID: 1529 RVA: 0x00010434 File Offset: 0x0000E634
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

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x00010440 File Offset: 0x0000E640
		// (set) Token: 0x060005FB RID: 1531 RVA: 0x00010448 File Offset: 0x0000E648
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

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x00010454 File Offset: 0x0000E654
		// (set) Token: 0x060005FD RID: 1533 RVA: 0x0001045C File Offset: 0x0000E65C
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

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x00010468 File Offset: 0x0000E668
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x00010470 File Offset: 0x0000E670
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

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000600 RID: 1536 RVA: 0x0001047C File Offset: 0x0000E67C
		// (set) Token: 0x06000601 RID: 1537 RVA: 0x00010484 File Offset: 0x0000E684
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

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000602 RID: 1538 RVA: 0x00010490 File Offset: 0x0000E690
		// (set) Token: 0x06000603 RID: 1539 RVA: 0x00010498 File Offset: 0x0000E698
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

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x000104A4 File Offset: 0x0000E6A4
		// (set) Token: 0x06000605 RID: 1541 RVA: 0x000104AC File Offset: 0x0000E6AC
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

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000606 RID: 1542 RVA: 0x000104B8 File Offset: 0x0000E6B8
		// (set) Token: 0x06000607 RID: 1543 RVA: 0x000104C0 File Offset: 0x0000E6C0
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

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06000608 RID: 1544 RVA: 0x000104CC File Offset: 0x0000E6CC
		// (set) Token: 0x06000609 RID: 1545 RVA: 0x000104D4 File Offset: 0x0000E6D4
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

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600060A RID: 1546 RVA: 0x000104E0 File Offset: 0x0000E6E0
		// (set) Token: 0x0600060B RID: 1547 RVA: 0x000104E8 File Offset: 0x0000E6E8
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

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x000104F4 File Offset: 0x0000E6F4
		// (set) Token: 0x0600060D RID: 1549 RVA: 0x000104FC File Offset: 0x0000E6FC
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

		// Token: 0x0400031A RID: 794
		private LocalizableTextType displayNameField;

		// Token: 0x0400031B RID: 795
		private string technicalNameField;

		// Token: 0x0400031C RID: 796
		private string tooltipTextField;

		// Token: 0x0400031D RID: 797
		private int isMandatoryField;

		// Token: 0x0400031E RID: 798
		private bool isMandatoryFieldSpecified;

		// Token: 0x0400031F RID: 799
		private int isLocalizedField;

		// Token: 0x04000320 RID: 800
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000321 RID: 801
		private string placeholderValueField;

		// Token: 0x04000322 RID: 802
		private decimal defaultValueField;

		// Token: 0x04000323 RID: 803
		private bool defaultValueFieldSpecified;

		// Token: 0x04000324 RID: 804
		private decimal minValueField;

		// Token: 0x04000325 RID: 805
		private bool minValueFieldSpecified;

		// Token: 0x04000326 RID: 806
		private decimal maxValueField;

		// Token: 0x04000327 RID: 807
		private bool maxValueFieldSpecified;

		// Token: 0x04000328 RID: 808
		private int precisionField;

		// Token: 0x04000329 RID: 809
		private bool precisionFieldSpecified;

		// Token: 0x0400032A RID: 810
		private string unitField;

		// Token: 0x0400032B RID: 811
		private int displayThousandsSeparatorField;

		// Token: 0x0400032C RID: 812
		private bool displayThousandsSeparatorFieldSpecified;

		// Token: 0x0400032D RID: 813
		private string guidField;

		// Token: 0x0400032E RID: 814
		private string basedOnField;
	}
}
