using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000171 RID: 369
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class QueryReferenceStripPropertyDefinitionType
	{
		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001026 RID: 4134 RVA: 0x0001865C File Offset: 0x0001685C
		// (set) Token: 0x06001027 RID: 4135 RVA: 0x00018664 File Offset: 0x00016864
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

		// Token: 0x1700068E RID: 1678
		// (get) Token: 0x06001028 RID: 4136 RVA: 0x00018670 File Offset: 0x00016870
		// (set) Token: 0x06001029 RID: 4137 RVA: 0x00018678 File Offset: 0x00016878
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

		// Token: 0x1700068F RID: 1679
		// (get) Token: 0x0600102A RID: 4138 RVA: 0x00018684 File Offset: 0x00016884
		// (set) Token: 0x0600102B RID: 4139 RVA: 0x0001868C File Offset: 0x0001688C
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

		// Token: 0x17000690 RID: 1680
		// (get) Token: 0x0600102C RID: 4140 RVA: 0x00018698 File Offset: 0x00016898
		// (set) Token: 0x0600102D RID: 4141 RVA: 0x000186A0 File Offset: 0x000168A0
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

		// Token: 0x17000691 RID: 1681
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x000186AC File Offset: 0x000168AC
		// (set) Token: 0x0600102F RID: 4143 RVA: 0x000186B4 File Offset: 0x000168B4
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

		// Token: 0x17000692 RID: 1682
		// (get) Token: 0x06001030 RID: 4144 RVA: 0x000186C0 File Offset: 0x000168C0
		// (set) Token: 0x06001031 RID: 4145 RVA: 0x000186C8 File Offset: 0x000168C8
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

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x06001032 RID: 4146 RVA: 0x000186D4 File Offset: 0x000168D4
		// (set) Token: 0x06001033 RID: 4147 RVA: 0x000186DC File Offset: 0x000168DC
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

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x06001034 RID: 4148 RVA: 0x000186E8 File Offset: 0x000168E8
		// (set) Token: 0x06001035 RID: 4149 RVA: 0x000186F0 File Offset: 0x000168F0
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

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x06001036 RID: 4150 RVA: 0x000186FC File Offset: 0x000168FC
		// (set) Token: 0x06001037 RID: 4151 RVA: 0x00018704 File Offset: 0x00016904
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

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x06001038 RID: 4152 RVA: 0x00018710 File Offset: 0x00016910
		// (set) Token: 0x06001039 RID: 4153 RVA: 0x00018718 File Offset: 0x00016918
		public string DefaultValue
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

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x0600103A RID: 4154 RVA: 0x00018724 File Offset: 0x00016924
		// (set) Token: 0x0600103B RID: 4155 RVA: 0x0001872C File Offset: 0x0001692C
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

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x0600103C RID: 4156 RVA: 0x00018738 File Offset: 0x00016938
		// (set) Token: 0x0600103D RID: 4157 RVA: 0x00018740 File Offset: 0x00016940
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

		// Token: 0x040008D5 RID: 2261
		private LocalizableTextType displayNameField;

		// Token: 0x040008D6 RID: 2262
		private string colorField;

		// Token: 0x040008D7 RID: 2263
		private string technicalNameField;

		// Token: 0x040008D8 RID: 2264
		private string tooltipTextField;

		// Token: 0x040008D9 RID: 2265
		private int isMandatoryField;

		// Token: 0x040008DA RID: 2266
		private bool isMandatoryFieldSpecified;

		// Token: 0x040008DB RID: 2267
		private int isLocalizedField;

		// Token: 0x040008DC RID: 2268
		private bool isLocalizedFieldSpecified;

		// Token: 0x040008DD RID: 2269
		private string placeholderValueField;

		// Token: 0x040008DE RID: 2270
		private string defaultValueField;

		// Token: 0x040008DF RID: 2271
		private string idField;

		// Token: 0x040008E0 RID: 2272
		private string basedOnField;
	}
}
