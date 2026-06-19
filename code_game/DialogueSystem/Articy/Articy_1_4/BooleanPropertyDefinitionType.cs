using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009B RID: 155
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class BooleanPropertyDefinitionType
	{
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x00010510 File Offset: 0x0000E710
		// (set) Token: 0x06000610 RID: 1552 RVA: 0x00010518 File Offset: 0x0000E718
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

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000611 RID: 1553 RVA: 0x00010524 File Offset: 0x0000E724
		// (set) Token: 0x06000612 RID: 1554 RVA: 0x0001052C File Offset: 0x0000E72C
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

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x06000613 RID: 1555 RVA: 0x00010538 File Offset: 0x0000E738
		// (set) Token: 0x06000614 RID: 1556 RVA: 0x00010540 File Offset: 0x0000E740
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

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x06000615 RID: 1557 RVA: 0x0001054C File Offset: 0x0000E74C
		// (set) Token: 0x06000616 RID: 1558 RVA: 0x00010554 File Offset: 0x0000E754
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

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x00010560 File Offset: 0x0000E760
		// (set) Token: 0x06000618 RID: 1560 RVA: 0x00010568 File Offset: 0x0000E768
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

		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000619 RID: 1561 RVA: 0x00010574 File Offset: 0x0000E774
		// (set) Token: 0x0600061A RID: 1562 RVA: 0x0001057C File Offset: 0x0000E77C
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

		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600061B RID: 1563 RVA: 0x00010588 File Offset: 0x0000E788
		// (set) Token: 0x0600061C RID: 1564 RVA: 0x00010590 File Offset: 0x0000E790
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

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x0600061D RID: 1565 RVA: 0x0001059C File Offset: 0x0000E79C
		// (set) Token: 0x0600061E RID: 1566 RVA: 0x000105A4 File Offset: 0x0000E7A4
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

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x0600061F RID: 1567 RVA: 0x000105B0 File Offset: 0x0000E7B0
		// (set) Token: 0x06000620 RID: 1568 RVA: 0x000105B8 File Offset: 0x0000E7B8
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

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x06000621 RID: 1569 RVA: 0x000105C4 File Offset: 0x0000E7C4
		// (set) Token: 0x06000622 RID: 1570 RVA: 0x000105CC File Offset: 0x0000E7CC
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

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x000105D8 File Offset: 0x0000E7D8
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x000105E0 File Offset: 0x0000E7E0
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

		// Token: 0x17000206 RID: 518
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x000105EC File Offset: 0x0000E7EC
		// (set) Token: 0x06000626 RID: 1574 RVA: 0x000105F4 File Offset: 0x0000E7F4
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

		// Token: 0x0400032F RID: 815
		private LocalizableTextType displayNameField;

		// Token: 0x04000330 RID: 816
		private string technicalNameField;

		// Token: 0x04000331 RID: 817
		private string tooltipTextField;

		// Token: 0x04000332 RID: 818
		private int isMandatoryField;

		// Token: 0x04000333 RID: 819
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000334 RID: 820
		private int isLocalizedField;

		// Token: 0x04000335 RID: 821
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000336 RID: 822
		private string placeholderValueField;

		// Token: 0x04000337 RID: 823
		private int defaultValueField;

		// Token: 0x04000338 RID: 824
		private bool defaultValueFieldSpecified;

		// Token: 0x04000339 RID: 825
		private string guidField;

		// Token: 0x0400033A RID: 826
		private string basedOnField;
	}
}
