using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001BB RID: 443
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class InstructionType
	{
		// Token: 0x17000837 RID: 2103
		// (get) Token: 0x060013E3 RID: 5091 RVA: 0x0001BCD8 File Offset: 0x00019ED8
		// (set) Token: 0x060013E4 RID: 5092 RVA: 0x0001BCE0 File Offset: 0x00019EE0
		public string DisplayName
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

		// Token: 0x17000838 RID: 2104
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x0001BCEC File Offset: 0x00019EEC
		// (set) Token: 0x060013E6 RID: 5094 RVA: 0x0001BCF4 File Offset: 0x00019EF4
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

		// Token: 0x17000839 RID: 2105
		// (get) Token: 0x060013E7 RID: 5095 RVA: 0x0001BD00 File Offset: 0x00019F00
		// (set) Token: 0x060013E8 RID: 5096 RVA: 0x0001BD08 File Offset: 0x00019F08
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

		// Token: 0x1700083A RID: 2106
		// (get) Token: 0x060013E9 RID: 5097 RVA: 0x0001BD14 File Offset: 0x00019F14
		// (set) Token: 0x060013EA RID: 5098 RVA: 0x0001BD1C File Offset: 0x00019F1C
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

		// Token: 0x1700083B RID: 2107
		// (get) Token: 0x060013EB RID: 5099 RVA: 0x0001BD28 File Offset: 0x00019F28
		// (set) Token: 0x060013EC RID: 5100 RVA: 0x0001BD30 File Offset: 0x00019F30
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

		// Token: 0x1700083C RID: 2108
		// (get) Token: 0x060013ED RID: 5101 RVA: 0x0001BD3C File Offset: 0x00019F3C
		// (set) Token: 0x060013EE RID: 5102 RVA: 0x0001BD44 File Offset: 0x00019F44
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

		// Token: 0x1700083D RID: 2109
		// (get) Token: 0x060013EF RID: 5103 RVA: 0x0001BD50 File Offset: 0x00019F50
		// (set) Token: 0x060013F0 RID: 5104 RVA: 0x0001BD58 File Offset: 0x00019F58
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

		// Token: 0x1700083E RID: 2110
		// (get) Token: 0x060013F1 RID: 5105 RVA: 0x0001BD64 File Offset: 0x00019F64
		// (set) Token: 0x060013F2 RID: 5106 RVA: 0x0001BD6C File Offset: 0x00019F6C
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

		// Token: 0x1700083F RID: 2111
		// (get) Token: 0x060013F3 RID: 5107 RVA: 0x0001BD78 File Offset: 0x00019F78
		// (set) Token: 0x060013F4 RID: 5108 RVA: 0x0001BD80 File Offset: 0x00019F80
		public string Expression
		{
			get
			{
				return this.expressionField;
			}
			set
			{
				this.expressionField = value;
			}
		}

		// Token: 0x17000840 RID: 2112
		// (get) Token: 0x060013F5 RID: 5109 RVA: 0x0001BD8C File Offset: 0x00019F8C
		// (set) Token: 0x060013F6 RID: 5110 RVA: 0x0001BD94 File Offset: 0x00019F94
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

		// Token: 0x17000841 RID: 2113
		// (get) Token: 0x060013F7 RID: 5111 RVA: 0x0001BDA0 File Offset: 0x00019FA0
		// (set) Token: 0x060013F8 RID: 5112 RVA: 0x0001BDA8 File Offset: 0x00019FA8
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

		// Token: 0x17000842 RID: 2114
		// (get) Token: 0x060013F9 RID: 5113 RVA: 0x0001BDB4 File Offset: 0x00019FB4
		// (set) Token: 0x060013FA RID: 5114 RVA: 0x0001BDBC File Offset: 0x00019FBC
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

		// Token: 0x17000843 RID: 2115
		// (get) Token: 0x060013FB RID: 5115 RVA: 0x0001BDC8 File Offset: 0x00019FC8
		// (set) Token: 0x060013FC RID: 5116 RVA: 0x0001BDD0 File Offset: 0x00019FD0
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

		// Token: 0x17000844 RID: 2116
		// (get) Token: 0x060013FD RID: 5117 RVA: 0x0001BDDC File Offset: 0x00019FDC
		// (set) Token: 0x060013FE RID: 5118 RVA: 0x0001BDE4 File Offset: 0x00019FE4
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

		// Token: 0x17000845 RID: 2117
		// (get) Token: 0x060013FF RID: 5119 RVA: 0x0001BDF0 File Offset: 0x00019FF0
		// (set) Token: 0x06001400 RID: 5120 RVA: 0x0001BDF8 File Offset: 0x00019FF8
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

		// Token: 0x17000846 RID: 2118
		// (get) Token: 0x06001401 RID: 5121 RVA: 0x0001BE04 File Offset: 0x0001A004
		// (set) Token: 0x06001402 RID: 5122 RVA: 0x0001BE0C File Offset: 0x0001A00C
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

		// Token: 0x04000AD0 RID: 2768
		private string displayNameField;

		// Token: 0x04000AD1 RID: 2769
		private LocalizableTextType textField;

		// Token: 0x04000AD2 RID: 2770
		private string colorField;

		// Token: 0x04000AD3 RID: 2771
		private string technicalNameField;

		// Token: 0x04000AD4 RID: 2772
		private string externalIdField;

		// Token: 0x04000AD5 RID: 2773
		private string shortIdField;

		// Token: 0x04000AD6 RID: 2774
		private string urlField;

		// Token: 0x04000AD7 RID: 2775
		private FeaturesType featuresField;

		// Token: 0x04000AD8 RID: 2776
		private string expressionField;

		// Token: 0x04000AD9 RID: 2777
		private PinsType pinsField;

		// Token: 0x04000ADA RID: 2778
		private PointType positionField;

		// Token: 0x04000ADB RID: 2779
		private SizeType sizeField;

		// Token: 0x04000ADC RID: 2780
		private float zIndexField;

		// Token: 0x04000ADD RID: 2781
		private string idField;

		// Token: 0x04000ADE RID: 2782
		private string objectTemplateReferenceField;

		// Token: 0x04000ADF RID: 2783
		private string objectTemplateReferenceNameField;
	}
}
