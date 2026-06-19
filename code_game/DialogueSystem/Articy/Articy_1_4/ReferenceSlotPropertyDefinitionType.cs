using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000099 RID: 153
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceSlotPropertyDefinitionType
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x060005CB RID: 1483 RVA: 0x0001026C File Offset: 0x0000E46C
		// (set) Token: 0x060005CC RID: 1484 RVA: 0x00010274 File Offset: 0x0000E474
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

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00010280 File Offset: 0x0000E480
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x00010288 File Offset: 0x0000E488
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

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x00010294 File Offset: 0x0000E494
		// (set) Token: 0x060005D0 RID: 1488 RVA: 0x0001029C File Offset: 0x0000E49C
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

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x060005D1 RID: 1489 RVA: 0x000102A8 File Offset: 0x0000E4A8
		// (set) Token: 0x060005D2 RID: 1490 RVA: 0x000102B0 File Offset: 0x0000E4B0
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

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000102BC File Offset: 0x0000E4BC
		// (set) Token: 0x060005D4 RID: 1492 RVA: 0x000102C4 File Offset: 0x0000E4C4
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

		// Token: 0x170001DF RID: 479
		// (get) Token: 0x060005D5 RID: 1493 RVA: 0x000102D0 File Offset: 0x0000E4D0
		// (set) Token: 0x060005D6 RID: 1494 RVA: 0x000102D8 File Offset: 0x0000E4D8
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

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x060005D7 RID: 1495 RVA: 0x000102E4 File Offset: 0x0000E4E4
		// (set) Token: 0x060005D8 RID: 1496 RVA: 0x000102EC File Offset: 0x0000E4EC
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

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x060005D9 RID: 1497 RVA: 0x000102F8 File Offset: 0x0000E4F8
		// (set) Token: 0x060005DA RID: 1498 RVA: 0x00010300 File Offset: 0x0000E500
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

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x060005DB RID: 1499 RVA: 0x0001030C File Offset: 0x0000E50C
		// (set) Token: 0x060005DC RID: 1500 RVA: 0x00010314 File Offset: 0x0000E514
		public ReferenceType DefaultValue
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

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x060005DD RID: 1501 RVA: 0x00010320 File Offset: 0x0000E520
		// (set) Token: 0x060005DE RID: 1502 RVA: 0x00010328 File Offset: 0x0000E528
		public ObjectTypes ObjectTypes
		{
			get
			{
				return this.objectTypesField;
			}
			set
			{
				this.objectTypesField = value;
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x060005DF RID: 1503 RVA: 0x00010334 File Offset: 0x0000E534
		// (set) Token: 0x060005E0 RID: 1504 RVA: 0x0001033C File Offset: 0x0000E53C
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

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x060005E1 RID: 1505 RVA: 0x00010348 File Offset: 0x0000E548
		// (set) Token: 0x060005E2 RID: 1506 RVA: 0x00010350 File Offset: 0x0000E550
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

		// Token: 0x0400030E RID: 782
		private LocalizableTextType displayNameField;

		// Token: 0x0400030F RID: 783
		private string technicalNameField;

		// Token: 0x04000310 RID: 784
		private string tooltipTextField;

		// Token: 0x04000311 RID: 785
		private int isMandatoryField;

		// Token: 0x04000312 RID: 786
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000313 RID: 787
		private int isLocalizedField;

		// Token: 0x04000314 RID: 788
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000315 RID: 789
		private string placeholderValueField;

		// Token: 0x04000316 RID: 790
		private ReferenceType defaultValueField;

		// Token: 0x04000317 RID: 791
		private ObjectTypes objectTypesField;

		// Token: 0x04000318 RID: 792
		private string guidField;

		// Token: 0x04000319 RID: 793
		private string basedOnField;
	}
}
