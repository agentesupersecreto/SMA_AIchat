using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F4 RID: 244
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EnumerationPropertyDefinitionType
	{
		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060009FB RID: 2555 RVA: 0x000137B8 File Offset: 0x000119B8
		// (set) Token: 0x060009FC RID: 2556 RVA: 0x000137C0 File Offset: 0x000119C0
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

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060009FD RID: 2557 RVA: 0x000137CC File Offset: 0x000119CC
		// (set) Token: 0x060009FE RID: 2558 RVA: 0x000137D4 File Offset: 0x000119D4
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

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060009FF RID: 2559 RVA: 0x000137E0 File Offset: 0x000119E0
		// (set) Token: 0x06000A00 RID: 2560 RVA: 0x000137E8 File Offset: 0x000119E8
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

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x000137F4 File Offset: 0x000119F4
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x000137FC File Offset: 0x000119FC
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

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x00013808 File Offset: 0x00011A08
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x00013810 File Offset: 0x00011A10
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

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x0001381C File Offset: 0x00011A1C
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x00013824 File Offset: 0x00011A24
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

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00013830 File Offset: 0x00011A30
		// (set) Token: 0x06000A08 RID: 2568 RVA: 0x00013838 File Offset: 0x00011A38
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

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x00013844 File Offset: 0x00011A44
		// (set) Token: 0x06000A0A RID: 2570 RVA: 0x0001384C File Offset: 0x00011A4C
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

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00013858 File Offset: 0x00011A58
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x00013860 File Offset: 0x00011A60
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

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x0001386C File Offset: 0x00011A6C
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x00013874 File Offset: 0x00011A74
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

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x00013880 File Offset: 0x00011A80
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x00013888 File Offset: 0x00011A88
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

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000A11 RID: 2577 RVA: 0x00013894 File Offset: 0x00011A94
		// (set) Token: 0x06000A12 RID: 2578 RVA: 0x0001389C File Offset: 0x00011A9C
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

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000A13 RID: 2579 RVA: 0x000138A8 File Offset: 0x00011AA8
		// (set) Token: 0x06000A14 RID: 2580 RVA: 0x000138B0 File Offset: 0x00011AB0
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

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000A15 RID: 2581 RVA: 0x000138BC File Offset: 0x00011ABC
		// (set) Token: 0x06000A16 RID: 2582 RVA: 0x000138C4 File Offset: 0x00011AC4
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

		// Token: 0x04000563 RID: 1379
		private LocalizableTextType displayNameField;

		// Token: 0x04000564 RID: 1380
		private string colorField;

		// Token: 0x04000565 RID: 1381
		private string technicalNameField;

		// Token: 0x04000566 RID: 1382
		private string tooltipTextField;

		// Token: 0x04000567 RID: 1383
		private int isMandatoryField;

		// Token: 0x04000568 RID: 1384
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000569 RID: 1385
		private int isLocalizedField;

		// Token: 0x0400056A RID: 1386
		private bool isLocalizedFieldSpecified;

		// Token: 0x0400056B RID: 1387
		private string placeholderValueField;

		// Token: 0x0400056C RID: 1388
		private int defaultValueField;

		// Token: 0x0400056D RID: 1389
		private bool defaultValueFieldSpecified;

		// Token: 0x0400056E RID: 1390
		private EnumerationValuesDefinitionType valuesField;

		// Token: 0x0400056F RID: 1391
		private string idField;

		// Token: 0x04000570 RID: 1392
		private string basedOnField;
	}
}
