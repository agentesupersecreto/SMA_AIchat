using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000092 RID: 146
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EnumerationPropertyDefinitionType
	{
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x0600057D RID: 1405 RVA: 0x0000FF6C File Offset: 0x0000E16C
		// (set) Token: 0x0600057E RID: 1406 RVA: 0x0000FF74 File Offset: 0x0000E174
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

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000FF80 File Offset: 0x0000E180
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x0000FF88 File Offset: 0x0000E188
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

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x06000581 RID: 1409 RVA: 0x0000FF94 File Offset: 0x0000E194
		// (set) Token: 0x06000582 RID: 1410 RVA: 0x0000FF9C File Offset: 0x0000E19C
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

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06000583 RID: 1411 RVA: 0x0000FFA8 File Offset: 0x0000E1A8
		// (set) Token: 0x06000584 RID: 1412 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
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

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x06000585 RID: 1413 RVA: 0x0000FFBC File Offset: 0x0000E1BC
		// (set) Token: 0x06000586 RID: 1414 RVA: 0x0000FFC4 File Offset: 0x0000E1C4
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

		// Token: 0x170001BB RID: 443
		// (get) Token: 0x06000587 RID: 1415 RVA: 0x0000FFD0 File Offset: 0x0000E1D0
		// (set) Token: 0x06000588 RID: 1416 RVA: 0x0000FFD8 File Offset: 0x0000E1D8
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

		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000589 RID: 1417 RVA: 0x0000FFE4 File Offset: 0x0000E1E4
		// (set) Token: 0x0600058A RID: 1418 RVA: 0x0000FFEC File Offset: 0x0000E1EC
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

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000FFF8 File Offset: 0x0000E1F8
		// (set) Token: 0x0600058C RID: 1420 RVA: 0x00010000 File Offset: 0x0000E200
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

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x0600058D RID: 1421 RVA: 0x0001000C File Offset: 0x0000E20C
		// (set) Token: 0x0600058E RID: 1422 RVA: 0x00010014 File Offset: 0x0000E214
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

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600058F RID: 1423 RVA: 0x00010020 File Offset: 0x0000E220
		// (set) Token: 0x06000590 RID: 1424 RVA: 0x00010028 File Offset: 0x0000E228
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

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x06000591 RID: 1425 RVA: 0x00010034 File Offset: 0x0000E234
		// (set) Token: 0x06000592 RID: 1426 RVA: 0x0001003C File Offset: 0x0000E23C
		public EnumerationValuesDefinitionType Values
		{
			get
			{
				return this.valuesField;
			}
			set
			{
				this.valuesField = value;
			}
		}

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x06000593 RID: 1427 RVA: 0x00010048 File Offset: 0x0000E248
		// (set) Token: 0x06000594 RID: 1428 RVA: 0x00010050 File Offset: 0x0000E250
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

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000595 RID: 1429 RVA: 0x0001005C File Offset: 0x0000E25C
		// (set) Token: 0x06000596 RID: 1430 RVA: 0x00010064 File Offset: 0x0000E264
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

		// Token: 0x040002E4 RID: 740
		private LocalizableTextType displayNameField;

		// Token: 0x040002E5 RID: 741
		private string technicalNameField;

		// Token: 0x040002E6 RID: 742
		private string tooltipTextField;

		// Token: 0x040002E7 RID: 743
		private int isMandatoryField;

		// Token: 0x040002E8 RID: 744
		private bool isMandatoryFieldSpecified;

		// Token: 0x040002E9 RID: 745
		private int isLocalizedField;

		// Token: 0x040002EA RID: 746
		private bool isLocalizedFieldSpecified;

		// Token: 0x040002EB RID: 747
		private string placeholderValueField;

		// Token: 0x040002EC RID: 748
		private int defaultValueField;

		// Token: 0x040002ED RID: 749
		private bool defaultValueFieldSpecified;

		// Token: 0x040002EE RID: 750
		private EnumerationValuesDefinitionType valuesField;

		// Token: 0x040002EF RID: 751
		private string guidField;

		// Token: 0x040002F0 RID: 752
		private string basedOnField;
	}
}
