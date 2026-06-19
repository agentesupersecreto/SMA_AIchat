using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B3 RID: 435
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumerationPropertyDefinitionType
	{
		// Token: 0x170007F8 RID: 2040
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x0001B7AC File Offset: 0x000199AC
		// (set) Token: 0x0600135E RID: 4958 RVA: 0x0001B7B4 File Offset: 0x000199B4
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

		// Token: 0x170007F9 RID: 2041
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x0001B7C0 File Offset: 0x000199C0
		// (set) Token: 0x06001360 RID: 4960 RVA: 0x0001B7C8 File Offset: 0x000199C8
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

		// Token: 0x170007FA RID: 2042
		// (get) Token: 0x06001361 RID: 4961 RVA: 0x0001B7D4 File Offset: 0x000199D4
		// (set) Token: 0x06001362 RID: 4962 RVA: 0x0001B7DC File Offset: 0x000199DC
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

		// Token: 0x170007FB RID: 2043
		// (get) Token: 0x06001363 RID: 4963 RVA: 0x0001B7E8 File Offset: 0x000199E8
		// (set) Token: 0x06001364 RID: 4964 RVA: 0x0001B7F0 File Offset: 0x000199F0
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

		// Token: 0x170007FC RID: 2044
		// (get) Token: 0x06001365 RID: 4965 RVA: 0x0001B7FC File Offset: 0x000199FC
		// (set) Token: 0x06001366 RID: 4966 RVA: 0x0001B804 File Offset: 0x00019A04
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

		// Token: 0x170007FD RID: 2045
		// (get) Token: 0x06001367 RID: 4967 RVA: 0x0001B810 File Offset: 0x00019A10
		// (set) Token: 0x06001368 RID: 4968 RVA: 0x0001B818 File Offset: 0x00019A18
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

		// Token: 0x170007FE RID: 2046
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x0001B824 File Offset: 0x00019A24
		// (set) Token: 0x0600136A RID: 4970 RVA: 0x0001B82C File Offset: 0x00019A2C
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

		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x0001B838 File Offset: 0x00019A38
		// (set) Token: 0x0600136C RID: 4972 RVA: 0x0001B840 File Offset: 0x00019A40
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

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x0001B84C File Offset: 0x00019A4C
		// (set) Token: 0x0600136E RID: 4974 RVA: 0x0001B854 File Offset: 0x00019A54
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

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x0600136F RID: 4975 RVA: 0x0001B860 File Offset: 0x00019A60
		// (set) Token: 0x06001370 RID: 4976 RVA: 0x0001B868 File Offset: 0x00019A68
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

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001371 RID: 4977 RVA: 0x0001B874 File Offset: 0x00019A74
		// (set) Token: 0x06001372 RID: 4978 RVA: 0x0001B87C File Offset: 0x00019A7C
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

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06001373 RID: 4979 RVA: 0x0001B888 File Offset: 0x00019A88
		// (set) Token: 0x06001374 RID: 4980 RVA: 0x0001B890 File Offset: 0x00019A90
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

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06001375 RID: 4981 RVA: 0x0001B89C File Offset: 0x00019A9C
		// (set) Token: 0x06001376 RID: 4982 RVA: 0x0001B8A4 File Offset: 0x00019AA4
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

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06001377 RID: 4983 RVA: 0x0001B8B0 File Offset: 0x00019AB0
		// (set) Token: 0x06001378 RID: 4984 RVA: 0x0001B8B8 File Offset: 0x00019AB8
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

		// Token: 0x04000A91 RID: 2705
		private LocalizableTextType displayNameField;

		// Token: 0x04000A92 RID: 2706
		private string colorField;

		// Token: 0x04000A93 RID: 2707
		private string technicalNameField;

		// Token: 0x04000A94 RID: 2708
		private string tooltipTextField;

		// Token: 0x04000A95 RID: 2709
		private int isMandatoryField;

		// Token: 0x04000A96 RID: 2710
		private bool isMandatoryFieldSpecified;

		// Token: 0x04000A97 RID: 2711
		private int isLocalizedField;

		// Token: 0x04000A98 RID: 2712
		private bool isLocalizedFieldSpecified;

		// Token: 0x04000A99 RID: 2713
		private string placeholderValueField;

		// Token: 0x04000A9A RID: 2714
		private int defaultValueField;

		// Token: 0x04000A9B RID: 2715
		private bool defaultValueFieldSpecified;

		// Token: 0x04000A9C RID: 2716
		private EnumerationValuesDefinitionType valuesField;

		// Token: 0x04000A9D RID: 2717
		private string idField;

		// Token: 0x04000A9E RID: 2718
		private string basedOnField;
	}
}
