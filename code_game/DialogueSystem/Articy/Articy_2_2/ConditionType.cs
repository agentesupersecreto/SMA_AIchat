using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E4 RID: 228
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class ConditionType
	{
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x00012DE0 File Offset: 0x00010FE0
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x00012DE8 File Offset: 0x00010FE8
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

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00012DF4 File Offset: 0x00010FF4
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x00012DFC File Offset: 0x00010FFC
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

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00012E08 File Offset: 0x00011008
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x00012E10 File Offset: 0x00011010
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

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x00012E1C File Offset: 0x0001101C
		// (set) Token: 0x06000903 RID: 2307 RVA: 0x00012E24 File Offset: 0x00011024
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

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00012E30 File Offset: 0x00011030
		// (set) Token: 0x06000905 RID: 2309 RVA: 0x00012E38 File Offset: 0x00011038
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

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x00012E44 File Offset: 0x00011044
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x00012E4C File Offset: 0x0001104C
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

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x00012E58 File Offset: 0x00011058
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x00012E60 File Offset: 0x00011060
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

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x00012E6C File Offset: 0x0001106C
		// (set) Token: 0x0600090B RID: 2315 RVA: 0x00012E74 File Offset: 0x00011074
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

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x0600090C RID: 2316 RVA: 0x00012E80 File Offset: 0x00011080
		// (set) Token: 0x0600090D RID: 2317 RVA: 0x00012E88 File Offset: 0x00011088
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

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x00012E94 File Offset: 0x00011094
		// (set) Token: 0x0600090F RID: 2319 RVA: 0x00012E9C File Offset: 0x0001109C
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

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x00012EA8 File Offset: 0x000110A8
		// (set) Token: 0x06000911 RID: 2321 RVA: 0x00012EB0 File Offset: 0x000110B0
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

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x00012EBC File Offset: 0x000110BC
		// (set) Token: 0x06000913 RID: 2323 RVA: 0x00012EC4 File Offset: 0x000110C4
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

		// Token: 0x040004E7 RID: 1255
		private LocalizableTextType displayNameField;

		// Token: 0x040004E8 RID: 1256
		private LocalizableTextType textField;

		// Token: 0x040004E9 RID: 1257
		private string colorField;

		// Token: 0x040004EA RID: 1258
		private string technicalNameField;

		// Token: 0x040004EB RID: 1259
		private string externalIdField;

		// Token: 0x040004EC RID: 1260
		private string shortIdField;

		// Token: 0x040004ED RID: 1261
		private FeaturesType featuresField;

		// Token: 0x040004EE RID: 1262
		private string expressionField;

		// Token: 0x040004EF RID: 1263
		private PinsType pinsField;

		// Token: 0x040004F0 RID: 1264
		private string idField;

		// Token: 0x040004F1 RID: 1265
		private string objectTemplateReferenceField;

		// Token: 0x040004F2 RID: 1266
		private string objectTemplateReferenceNameField;
	}
}
