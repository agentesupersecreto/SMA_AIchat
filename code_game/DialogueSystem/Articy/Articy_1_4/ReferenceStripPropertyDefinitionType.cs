using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000093 RID: 147
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ReferenceStripPropertyDefinitionType
	{
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000598 RID: 1432 RVA: 0x00010078 File Offset: 0x0000E278
		// (set) Token: 0x06000599 RID: 1433 RVA: 0x00010080 File Offset: 0x0000E280
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

		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x0600059A RID: 1434 RVA: 0x0001008C File Offset: 0x0000E28C
		// (set) Token: 0x0600059B RID: 1435 RVA: 0x00010094 File Offset: 0x0000E294
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

		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x0600059C RID: 1436 RVA: 0x000100A0 File Offset: 0x0000E2A0
		// (set) Token: 0x0600059D RID: 1437 RVA: 0x000100A8 File Offset: 0x0000E2A8
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

		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x0600059E RID: 1438 RVA: 0x000100B4 File Offset: 0x0000E2B4
		// (set) Token: 0x0600059F RID: 1439 RVA: 0x000100BC File Offset: 0x0000E2BC
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

		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060005A0 RID: 1440 RVA: 0x000100C8 File Offset: 0x0000E2C8
		// (set) Token: 0x060005A1 RID: 1441 RVA: 0x000100D0 File Offset: 0x0000E2D0
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

		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x000100DC File Offset: 0x0000E2DC
		// (set) Token: 0x060005A3 RID: 1443 RVA: 0x000100E4 File Offset: 0x0000E2E4
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

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060005A4 RID: 1444 RVA: 0x000100F0 File Offset: 0x0000E2F0
		// (set) Token: 0x060005A5 RID: 1445 RVA: 0x000100F8 File Offset: 0x0000E2F8
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

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00010104 File Offset: 0x0000E304
		// (set) Token: 0x060005A7 RID: 1447 RVA: 0x0001010C File Offset: 0x0000E30C
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

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060005A8 RID: 1448 RVA: 0x00010118 File Offset: 0x0000E318
		// (set) Token: 0x060005A9 RID: 1449 RVA: 0x00010120 File Offset: 0x0000E320
		public int MaxReferenceCount
		{
			get
			{
				return this.maxReferenceCountField;
			}
			set
			{
				this.maxReferenceCountField = value;
			}
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060005AA RID: 1450 RVA: 0x0001012C File Offset: 0x0000E32C
		// (set) Token: 0x060005AB RID: 1451 RVA: 0x00010134 File Offset: 0x0000E334
		[XmlIgnore]
		public bool MaxReferenceCountSpecified
		{
			get
			{
				return this.maxReferenceCountFieldSpecified;
			}
			set
			{
				this.maxReferenceCountFieldSpecified = value;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00010140 File Offset: 0x0000E340
		// (set) Token: 0x060005AD RID: 1453 RVA: 0x00010148 File Offset: 0x0000E348
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

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060005AE RID: 1454 RVA: 0x00010154 File Offset: 0x0000E354
		// (set) Token: 0x060005AF RID: 1455 RVA: 0x0001015C File Offset: 0x0000E35C
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

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060005B0 RID: 1456 RVA: 0x00010168 File Offset: 0x0000E368
		// (set) Token: 0x060005B1 RID: 1457 RVA: 0x00010170 File Offset: 0x0000E370
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

		// Token: 0x040002F1 RID: 753
		private LocalizableTextType displayNameField;

		// Token: 0x040002F2 RID: 754
		private string technicalNameField;

		// Token: 0x040002F3 RID: 755
		private string tooltipTextField;

		// Token: 0x040002F4 RID: 756
		private int isMandatoryField;

		// Token: 0x040002F5 RID: 757
		private bool isMandatoryFieldSpecified;

		// Token: 0x040002F6 RID: 758
		private int isLocalizedField;

		// Token: 0x040002F7 RID: 759
		private bool isLocalizedFieldSpecified;

		// Token: 0x040002F8 RID: 760
		private string placeholderValueField;

		// Token: 0x040002F9 RID: 761
		private int maxReferenceCountField;

		// Token: 0x040002FA RID: 762
		private bool maxReferenceCountFieldSpecified;

		// Token: 0x040002FB RID: 763
		private ObjectTypes objectTypesField;

		// Token: 0x040002FC RID: 764
		private string guidField;

		// Token: 0x040002FD RID: 765
		private string basedOnField;
	}
}
