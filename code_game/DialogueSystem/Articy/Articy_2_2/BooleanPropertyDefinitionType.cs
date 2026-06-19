using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000FE RID: 254
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class BooleanPropertyDefinitionType
	{
		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06000AAE RID: 2734 RVA: 0x00013EA4 File Offset: 0x000120A4
		// (set) Token: 0x06000AAF RID: 2735 RVA: 0x00013EAC File Offset: 0x000120AC
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

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x00013EB8 File Offset: 0x000120B8
		// (set) Token: 0x06000AB1 RID: 2737 RVA: 0x00013EC0 File Offset: 0x000120C0
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

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x00013ECC File Offset: 0x000120CC
		// (set) Token: 0x06000AB3 RID: 2739 RVA: 0x00013ED4 File Offset: 0x000120D4
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

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x00013EE0 File Offset: 0x000120E0
		// (set) Token: 0x06000AB5 RID: 2741 RVA: 0x00013EE8 File Offset: 0x000120E8
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

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00013EF4 File Offset: 0x000120F4
		// (set) Token: 0x06000AB7 RID: 2743 RVA: 0x00013EFC File Offset: 0x000120FC
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

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x00013F08 File Offset: 0x00012108
		// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x00013F10 File Offset: 0x00012110
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

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000ABA RID: 2746 RVA: 0x00013F1C File Offset: 0x0001211C
		// (set) Token: 0x06000ABB RID: 2747 RVA: 0x00013F24 File Offset: 0x00012124
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

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000ABC RID: 2748 RVA: 0x00013F30 File Offset: 0x00012130
		// (set) Token: 0x06000ABD RID: 2749 RVA: 0x00013F38 File Offset: 0x00012138
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

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06000ABE RID: 2750 RVA: 0x00013F44 File Offset: 0x00012144
		// (set) Token: 0x06000ABF RID: 2751 RVA: 0x00013F4C File Offset: 0x0001214C
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

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x00013F58 File Offset: 0x00012158
		// (set) Token: 0x06000AC1 RID: 2753 RVA: 0x00013F60 File Offset: 0x00012160
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

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x00013F6C File Offset: 0x0001216C
		// (set) Token: 0x06000AC3 RID: 2755 RVA: 0x00013F74 File Offset: 0x00012174
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

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x00013F80 File Offset: 0x00012180
		// (set) Token: 0x06000AC5 RID: 2757 RVA: 0x00013F88 File Offset: 0x00012188
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

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06000AC6 RID: 2758 RVA: 0x00013F94 File Offset: 0x00012194
		// (set) Token: 0x06000AC7 RID: 2759 RVA: 0x00013F9C File Offset: 0x0001219C
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

		// Token: 0x040005BE RID: 1470
		private LocalizableTextType displayNameField;

		// Token: 0x040005BF RID: 1471
		private string colorField;

		// Token: 0x040005C0 RID: 1472
		private string technicalNameField;

		// Token: 0x040005C1 RID: 1473
		private string tooltipTextField;

		// Token: 0x040005C2 RID: 1474
		private int isMandatoryField;

		// Token: 0x040005C3 RID: 1475
		private bool isMandatoryFieldSpecified;

		// Token: 0x040005C4 RID: 1476
		private int isLocalizedField;

		// Token: 0x040005C5 RID: 1477
		private bool isLocalizedFieldSpecified;

		// Token: 0x040005C6 RID: 1478
		private string placeholderValueField;

		// Token: 0x040005C7 RID: 1479
		private int defaultValueField;

		// Token: 0x040005C8 RID: 1480
		private bool defaultValueFieldSpecified;

		// Token: 0x040005C9 RID: 1481
		private string idField;

		// Token: 0x040005CA RID: 1482
		private string basedOnField;
	}
}
