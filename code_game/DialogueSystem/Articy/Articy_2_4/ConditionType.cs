using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000128 RID: 296
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ConditionType
	{
		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x00015F98 File Offset: 0x00014198
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x00015FA0 File Offset: 0x000141A0
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

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00015FAC File Offset: 0x000141AC
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00015FB4 File Offset: 0x000141B4
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

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x00015FC0 File Offset: 0x000141C0
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00015FC8 File Offset: 0x000141C8
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

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00015FD4 File Offset: 0x000141D4
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00015FDC File Offset: 0x000141DC
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

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x00015FE8 File Offset: 0x000141E8
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00015FF0 File Offset: 0x000141F0
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

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00015FFC File Offset: 0x000141FC
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x00016004 File Offset: 0x00014204
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

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x00016010 File Offset: 0x00014210
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x00016018 File Offset: 0x00014218
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

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x00016024 File Offset: 0x00014224
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x0001602C File Offset: 0x0001422C
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

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x00016038 File Offset: 0x00014238
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00016040 File Offset: 0x00014240
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

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x0001604C File Offset: 0x0001424C
		// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00016054 File Offset: 0x00014254
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

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x00016060 File Offset: 0x00014260
		// (set) Token: 0x06000C53 RID: 3155 RVA: 0x00016068 File Offset: 0x00014268
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

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x00016074 File Offset: 0x00014274
		// (set) Token: 0x06000C55 RID: 3157 RVA: 0x0001607C File Offset: 0x0001427C
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

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x00016088 File Offset: 0x00014288
		// (set) Token: 0x06000C57 RID: 3159 RVA: 0x00016090 File Offset: 0x00014290
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

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000C58 RID: 3160 RVA: 0x0001609C File Offset: 0x0001429C
		// (set) Token: 0x06000C59 RID: 3161 RVA: 0x000160A4 File Offset: 0x000142A4
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

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x000160B0 File Offset: 0x000142B0
		// (set) Token: 0x06000C5B RID: 3163 RVA: 0x000160B8 File Offset: 0x000142B8
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

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x000160C4 File Offset: 0x000142C4
		// (set) Token: 0x06000C5D RID: 3165 RVA: 0x000160CC File Offset: 0x000142CC
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

		// Token: 0x040006A1 RID: 1697
		private string displayNameField;

		// Token: 0x040006A2 RID: 1698
		private LocalizableTextType textField;

		// Token: 0x040006A3 RID: 1699
		private string colorField;

		// Token: 0x040006A4 RID: 1700
		private string technicalNameField;

		// Token: 0x040006A5 RID: 1701
		private string externalIdField;

		// Token: 0x040006A6 RID: 1702
		private string shortIdField;

		// Token: 0x040006A7 RID: 1703
		private string urlField;

		// Token: 0x040006A8 RID: 1704
		private FeaturesType featuresField;

		// Token: 0x040006A9 RID: 1705
		private string expressionField;

		// Token: 0x040006AA RID: 1706
		private PinsType pinsField;

		// Token: 0x040006AB RID: 1707
		private PointType positionField;

		// Token: 0x040006AC RID: 1708
		private SizeType sizeField;

		// Token: 0x040006AD RID: 1709
		private float zIndexField;

		// Token: 0x040006AE RID: 1710
		private string idField;

		// Token: 0x040006AF RID: 1711
		private string objectTemplateReferenceField;

		// Token: 0x040006B0 RID: 1712
		private string objectTemplateReferenceNameField;
	}
}
