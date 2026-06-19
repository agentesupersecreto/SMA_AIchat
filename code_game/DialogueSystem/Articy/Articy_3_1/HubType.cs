using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001BA RID: 442
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HubType
	{
		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x0001BB90 File Offset: 0x00019D90
		// (set) Token: 0x060013C3 RID: 5059 RVA: 0x0001BB98 File Offset: 0x00019D98
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

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x060013C4 RID: 5060 RVA: 0x0001BBA4 File Offset: 0x00019DA4
		// (set) Token: 0x060013C5 RID: 5061 RVA: 0x0001BBAC File Offset: 0x00019DAC
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

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x060013C6 RID: 5062 RVA: 0x0001BBB8 File Offset: 0x00019DB8
		// (set) Token: 0x060013C7 RID: 5063 RVA: 0x0001BBC0 File Offset: 0x00019DC0
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

		// Token: 0x1700082A RID: 2090
		// (get) Token: 0x060013C8 RID: 5064 RVA: 0x0001BBCC File Offset: 0x00019DCC
		// (set) Token: 0x060013C9 RID: 5065 RVA: 0x0001BBD4 File Offset: 0x00019DD4
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

		// Token: 0x1700082B RID: 2091
		// (get) Token: 0x060013CA RID: 5066 RVA: 0x0001BBE0 File Offset: 0x00019DE0
		// (set) Token: 0x060013CB RID: 5067 RVA: 0x0001BBE8 File Offset: 0x00019DE8
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

		// Token: 0x1700082C RID: 2092
		// (get) Token: 0x060013CC RID: 5068 RVA: 0x0001BBF4 File Offset: 0x00019DF4
		// (set) Token: 0x060013CD RID: 5069 RVA: 0x0001BBFC File Offset: 0x00019DFC
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

		// Token: 0x1700082D RID: 2093
		// (get) Token: 0x060013CE RID: 5070 RVA: 0x0001BC08 File Offset: 0x00019E08
		// (set) Token: 0x060013CF RID: 5071 RVA: 0x0001BC10 File Offset: 0x00019E10
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

		// Token: 0x1700082E RID: 2094
		// (get) Token: 0x060013D0 RID: 5072 RVA: 0x0001BC1C File Offset: 0x00019E1C
		// (set) Token: 0x060013D1 RID: 5073 RVA: 0x0001BC24 File Offset: 0x00019E24
		public FeaturesType Features
		{
			get
			{
				return this.featuresField;
			}
			set
			{
				this.featuresField = value;
			}
		}

		// Token: 0x1700082F RID: 2095
		// (get) Token: 0x060013D2 RID: 5074 RVA: 0x0001BC30 File Offset: 0x00019E30
		// (set) Token: 0x060013D3 RID: 5075 RVA: 0x0001BC38 File Offset: 0x00019E38
		public PinsType Pins
		{
			get
			{
				return this.pinsField;
			}
			set
			{
				this.pinsField = value;
			}
		}

		// Token: 0x17000830 RID: 2096
		// (get) Token: 0x060013D4 RID: 5076 RVA: 0x0001BC44 File Offset: 0x00019E44
		// (set) Token: 0x060013D5 RID: 5077 RVA: 0x0001BC4C File Offset: 0x00019E4C
		public PointType Position
		{
			get
			{
				return this.positionField;
			}
			set
			{
				this.positionField = value;
			}
		}

		// Token: 0x17000831 RID: 2097
		// (get) Token: 0x060013D6 RID: 5078 RVA: 0x0001BC58 File Offset: 0x00019E58
		// (set) Token: 0x060013D7 RID: 5079 RVA: 0x0001BC60 File Offset: 0x00019E60
		public SizeType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x17000832 RID: 2098
		// (get) Token: 0x060013D8 RID: 5080 RVA: 0x0001BC6C File Offset: 0x00019E6C
		// (set) Token: 0x060013D9 RID: 5081 RVA: 0x0001BC74 File Offset: 0x00019E74
		public float ZIndex
		{
			get
			{
				return this.zIndexField;
			}
			set
			{
				this.zIndexField = value;
			}
		}

		// Token: 0x17000833 RID: 2099
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x0001BC80 File Offset: 0x00019E80
		// (set) Token: 0x060013DB RID: 5083 RVA: 0x0001BC88 File Offset: 0x00019E88
		[XmlText]
		public string[] Text1
		{
			get
			{
				return this.text1Field;
			}
			set
			{
				this.text1Field = value;
			}
		}

		// Token: 0x17000834 RID: 2100
		// (get) Token: 0x060013DC RID: 5084 RVA: 0x0001BC94 File Offset: 0x00019E94
		// (set) Token: 0x060013DD RID: 5085 RVA: 0x0001BC9C File Offset: 0x00019E9C
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

		// Token: 0x17000835 RID: 2101
		// (get) Token: 0x060013DE RID: 5086 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		// (set) Token: 0x060013DF RID: 5087 RVA: 0x0001BCB0 File Offset: 0x00019EB0
		[XmlAttribute]
		public string ObjectTemplateReference
		{
			get
			{
				return this.objectTemplateReferenceField;
			}
			set
			{
				this.objectTemplateReferenceField = value;
			}
		}

		// Token: 0x17000836 RID: 2102
		// (get) Token: 0x060013E0 RID: 5088 RVA: 0x0001BCBC File Offset: 0x00019EBC
		// (set) Token: 0x060013E1 RID: 5089 RVA: 0x0001BCC4 File Offset: 0x00019EC4
		[XmlAttribute]
		public string ObjectTemplateReferenceName
		{
			get
			{
				return this.objectTemplateReferenceNameField;
			}
			set
			{
				this.objectTemplateReferenceNameField = value;
			}
		}

		// Token: 0x04000AC0 RID: 2752
		private LocalizableTextType displayNameField;

		// Token: 0x04000AC1 RID: 2753
		private LocalizableTextType textField;

		// Token: 0x04000AC2 RID: 2754
		private string colorField;

		// Token: 0x04000AC3 RID: 2755
		private string technicalNameField;

		// Token: 0x04000AC4 RID: 2756
		private string externalIdField;

		// Token: 0x04000AC5 RID: 2757
		private string shortIdField;

		// Token: 0x04000AC6 RID: 2758
		private string urlField;

		// Token: 0x04000AC7 RID: 2759
		private FeaturesType featuresField;

		// Token: 0x04000AC8 RID: 2760
		private PinsType pinsField;

		// Token: 0x04000AC9 RID: 2761
		private PointType positionField;

		// Token: 0x04000ACA RID: 2762
		private SizeType sizeField;

		// Token: 0x04000ACB RID: 2763
		private float zIndexField;

		// Token: 0x04000ACC RID: 2764
		private string[] text1Field;

		// Token: 0x04000ACD RID: 2765
		private string idField;

		// Token: 0x04000ACE RID: 2766
		private string objectTemplateReferenceField;

		// Token: 0x04000ACF RID: 2767
		private string objectTemplateReferenceNameField;
	}
}
