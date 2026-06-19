using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009D RID: 157
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class TextPropertyDefinitionType
	{
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00010660 File Offset: 0x0000E860
		// (set) Token: 0x06000632 RID: 1586 RVA: 0x00010668 File Offset: 0x0000E868
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

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x00010674 File Offset: 0x0000E874
		// (set) Token: 0x06000634 RID: 1588 RVA: 0x0001067C File Offset: 0x0000E87C
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

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x00010688 File Offset: 0x0000E888
		// (set) Token: 0x06000636 RID: 1590 RVA: 0x00010690 File Offset: 0x0000E890
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

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0001069C File Offset: 0x0000E89C
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x000106A4 File Offset: 0x0000E8A4
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

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x000106B0 File Offset: 0x0000E8B0
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x000106B8 File Offset: 0x0000E8B8
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

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x000106C4 File Offset: 0x0000E8C4
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x000106CC File Offset: 0x0000E8CC
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

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x000106D8 File Offset: 0x0000E8D8
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x000106E0 File Offset: 0x0000E8E0
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

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x000106EC File Offset: 0x0000E8EC
		// (set) Token: 0x06000640 RID: 1600 RVA: 0x000106F4 File Offset: 0x0000E8F4
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

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00010700 File Offset: 0x0000E900
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x00010708 File Offset: 0x0000E908
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

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x00010714 File Offset: 0x0000E914
		// (set) Token: 0x06000644 RID: 1604 RVA: 0x0001071C File Offset: 0x0000E91C
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

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x00010728 File Offset: 0x0000E928
		// (set) Token: 0x06000646 RID: 1606 RVA: 0x00010730 File Offset: 0x0000E930
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

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0001073C File Offset: 0x0000E93C
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00010744 File Offset: 0x0000E944
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

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x00010750 File Offset: 0x0000E950
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x00010758 File Offset: 0x0000E958
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

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00010764 File Offset: 0x0000E964
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x0001076C File Offset: 0x0000E96C
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

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x00010778 File Offset: 0x0000E978
		// (set) Token: 0x0600064E RID: 1614 RVA: 0x00010780 File Offset: 0x0000E980
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

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x0001078C File Offset: 0x0000E98C
		// (set) Token: 0x06000650 RID: 1616 RVA: 0x00010794 File Offset: 0x0000E994
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

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x000107A0 File Offset: 0x0000E9A0
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x000107A8 File Offset: 0x0000E9A8
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

		// Token: 0x0400033F RID: 831
		private LocalizableTextType displayNameField;

		// Token: 0x04000340 RID: 832
		private string technicalNameField;

		// Token: 0x04000341 RID: 833
		private string tooltipTextField;

		// Token: 0x04000342 RID: 834
		private int isMandatoryField;

		// Token: 0x04000343 RID: 835
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000344 RID: 836
		private int isLocalizedField;

		// Token: 0x04000345 RID: 837
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000346 RID: 838
		private string placeholderValueField;

		// Token: 0x04000347 RID: 839
		private TextPropertyDefinitionValueType defaultValueField;

		// Token: 0x04000348 RID: 840
		private decimal disallowedCharsField;

		// Token: 0x04000349 RID: 841
		private bool disallowedCharsFieldSpecified;

		// Token: 0x0400034A RID: 842
		private int maxLengthField;

		// Token: 0x0400034B RID: 843
		private bool maxLengthFieldSpecified;

		// Token: 0x0400034C RID: 844
		private int allowsLinebreaksField;

		// Token: 0x0400034D RID: 845
		private bool allowsLinebreaksFieldSpecified;

		// Token: 0x0400034E RID: 846
		private string guidField;

		// Token: 0x0400034F RID: 847
		private string basedOnField;
	}
}
