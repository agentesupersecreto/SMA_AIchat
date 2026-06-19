using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001BC RID: 444
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneyType
	{
		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x06001404 RID: 5124 RVA: 0x0001BE20 File Offset: 0x0001A020
		// (set) Token: 0x06001405 RID: 5125 RVA: 0x0001BE28 File Offset: 0x0001A028
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

		// Token: 0x17000848 RID: 2120
		// (get) Token: 0x06001406 RID: 5126 RVA: 0x0001BE34 File Offset: 0x0001A034
		// (set) Token: 0x06001407 RID: 5127 RVA: 0x0001BE3C File Offset: 0x0001A03C
		public LocalizableTextType Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x17000849 RID: 2121
		// (get) Token: 0x06001408 RID: 5128 RVA: 0x0001BE48 File Offset: 0x0001A048
		// (set) Token: 0x06001409 RID: 5129 RVA: 0x0001BE50 File Offset: 0x0001A050
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

		// Token: 0x1700084A RID: 2122
		// (get) Token: 0x0600140A RID: 5130 RVA: 0x0001BE5C File Offset: 0x0001A05C
		// (set) Token: 0x0600140B RID: 5131 RVA: 0x0001BE64 File Offset: 0x0001A064
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

		// Token: 0x1700084B RID: 2123
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x0001BE70 File Offset: 0x0001A070
		// (set) Token: 0x0600140D RID: 5133 RVA: 0x0001BE78 File Offset: 0x0001A078
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x1700084C RID: 2124
		// (get) Token: 0x0600140E RID: 5134 RVA: 0x0001BE84 File Offset: 0x0001A084
		// (set) Token: 0x0600140F RID: 5135 RVA: 0x0001BE8C File Offset: 0x0001A08C
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x1700084D RID: 2125
		// (get) Token: 0x06001410 RID: 5136 RVA: 0x0001BE98 File Offset: 0x0001A098
		// (set) Token: 0x06001411 RID: 5137 RVA: 0x0001BEA0 File Offset: 0x0001A0A0
		public string Url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		// Token: 0x1700084E RID: 2126
		// (get) Token: 0x06001412 RID: 5138 RVA: 0x0001BEAC File Offset: 0x0001A0AC
		// (set) Token: 0x06001413 RID: 5139 RVA: 0x0001BEB4 File Offset: 0x0001A0B4
		public ReferencesType References
		{
			get
			{
				return this.referencesField;
			}
			set
			{
				this.referencesField = value;
			}
		}

		// Token: 0x1700084F RID: 2127
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x0001BEC0 File Offset: 0x0001A0C0
		// (set) Token: 0x06001415 RID: 5141 RVA: 0x0001BEC8 File Offset: 0x0001A0C8
		public JourneySettingsType Settings
		{
			get
			{
				return this.settingsField;
			}
			set
			{
				this.settingsField = value;
			}
		}

		// Token: 0x17000850 RID: 2128
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x0001BED4 File Offset: 0x0001A0D4
		// (set) Token: 0x06001417 RID: 5143 RVA: 0x0001BEDC File Offset: 0x0001A0DC
		public VariableValuesListType InitialVariableValues
		{
			get
			{
				return this.initialVariableValuesField;
			}
			set
			{
				this.initialVariableValuesField = value;
			}
		}

		// Token: 0x17000851 RID: 2129
		// (get) Token: 0x06001418 RID: 5144 RVA: 0x0001BEE8 File Offset: 0x0001A0E8
		// (set) Token: 0x06001419 RID: 5145 RVA: 0x0001BEF0 File Offset: 0x0001A0F0
		public JourneyPointsType JourneyPoints
		{
			get
			{
				return this.journeyPointsField;
			}
			set
			{
				this.journeyPointsField = value;
			}
		}

		// Token: 0x17000852 RID: 2130
		// (get) Token: 0x0600141A RID: 5146 RVA: 0x0001BEFC File Offset: 0x0001A0FC
		// (set) Token: 0x0600141B RID: 5147 RVA: 0x0001BF04 File Offset: 0x0001A104
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

		// Token: 0x04000AE0 RID: 2784
		private LocalizableTextType displayNameField;

		// Token: 0x04000AE1 RID: 2785
		private LocalizableTextType textField;

		// Token: 0x04000AE2 RID: 2786
		private string colorField;

		// Token: 0x04000AE3 RID: 2787
		private string technicalNameField;

		// Token: 0x04000AE4 RID: 2788
		private string externalIdField;

		// Token: 0x04000AE5 RID: 2789
		private string shortIdField;

		// Token: 0x04000AE6 RID: 2790
		private string urlField;

		// Token: 0x04000AE7 RID: 2791
		private ReferencesType referencesField;

		// Token: 0x04000AE8 RID: 2792
		private JourneySettingsType settingsField;

		// Token: 0x04000AE9 RID: 2793
		private VariableValuesListType initialVariableValuesField;

		// Token: 0x04000AEA RID: 2794
		private JourneyPointsType journeyPointsField;

		// Token: 0x04000AEB RID: 2795
		private string idField;
	}
}
