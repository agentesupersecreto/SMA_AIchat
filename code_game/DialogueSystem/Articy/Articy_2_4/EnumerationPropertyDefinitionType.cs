using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000134 RID: 308
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class EnumerationPropertyDefinitionType
	{
		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x00016784 File Offset: 0x00014984
		// (set) Token: 0x06000D0C RID: 3340 RVA: 0x0001678C File Offset: 0x0001498C
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

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000D0D RID: 3341 RVA: 0x00016798 File Offset: 0x00014998
		// (set) Token: 0x06000D0E RID: 3342 RVA: 0x000167A0 File Offset: 0x000149A0
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

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000D0F RID: 3343 RVA: 0x000167AC File Offset: 0x000149AC
		// (set) Token: 0x06000D10 RID: 3344 RVA: 0x000167B4 File Offset: 0x000149B4
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

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000D11 RID: 3345 RVA: 0x000167C0 File Offset: 0x000149C0
		// (set) Token: 0x06000D12 RID: 3346 RVA: 0x000167C8 File Offset: 0x000149C8
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

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000D13 RID: 3347 RVA: 0x000167D4 File Offset: 0x000149D4
		// (set) Token: 0x06000D14 RID: 3348 RVA: 0x000167DC File Offset: 0x000149DC
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

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x000167E8 File Offset: 0x000149E8
		// (set) Token: 0x06000D16 RID: 3350 RVA: 0x000167F0 File Offset: 0x000149F0
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

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x000167FC File Offset: 0x000149FC
		// (set) Token: 0x06000D18 RID: 3352 RVA: 0x00016804 File Offset: 0x00014A04
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

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000D19 RID: 3353 RVA: 0x00016810 File Offset: 0x00014A10
		// (set) Token: 0x06000D1A RID: 3354 RVA: 0x00016818 File Offset: 0x00014A18
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

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00016824 File Offset: 0x00014A24
		// (set) Token: 0x06000D1C RID: 3356 RVA: 0x0001682C File Offset: 0x00014A2C
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

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00016838 File Offset: 0x00014A38
		// (set) Token: 0x06000D1E RID: 3358 RVA: 0x00016840 File Offset: 0x00014A40
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

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000D1F RID: 3359 RVA: 0x0001684C File Offset: 0x00014A4C
		// (set) Token: 0x06000D20 RID: 3360 RVA: 0x00016854 File Offset: 0x00014A54
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

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000D21 RID: 3361 RVA: 0x00016860 File Offset: 0x00014A60
		// (set) Token: 0x06000D22 RID: 3362 RVA: 0x00016868 File Offset: 0x00014A68
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

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000D23 RID: 3363 RVA: 0x00016874 File Offset: 0x00014A74
		// (set) Token: 0x06000D24 RID: 3364 RVA: 0x0001687C File Offset: 0x00014A7C
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

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000D25 RID: 3365 RVA: 0x00016888 File Offset: 0x00014A88
		// (set) Token: 0x06000D26 RID: 3366 RVA: 0x00016890 File Offset: 0x00014A90
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

		// Token: 0x04000705 RID: 1797
		private LocalizableTextType displayNameField;

		// Token: 0x04000706 RID: 1798
		private string colorField;

		// Token: 0x04000707 RID: 1799
		private string technicalNameField;

		// Token: 0x04000708 RID: 1800
		private string tooltipTextField;

		// Token: 0x04000709 RID: 1801
		private int isMandatoryField;

		// Token: 0x0400070A RID: 1802
		private bool isMandatoryFieldSpecified;

		// Token: 0x0400070B RID: 1803
		private int isLocalizedField;

		// Token: 0x0400070C RID: 1804
		private bool isLocalizedFieldSpecified;

		// Token: 0x0400070D RID: 1805
		private string placeholderValueField;

		// Token: 0x0400070E RID: 1806
		private int defaultValueField;

		// Token: 0x0400070F RID: 1807
		private bool defaultValueFieldSpecified;

		// Token: 0x04000710 RID: 1808
		private EnumerationValuesDefinitionType valuesField;

		// Token: 0x04000711 RID: 1809
		private string idField;

		// Token: 0x04000712 RID: 1810
		private string basedOnField;
	}
}
