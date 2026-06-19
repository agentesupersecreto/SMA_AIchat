using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E6 RID: 230
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JumpType
	{
		// Token: 0x1700035D RID: 861
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x00012FD0 File Offset: 0x000111D0
		// (set) Token: 0x0600092F RID: 2351 RVA: 0x00012FD8 File Offset: 0x000111D8
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

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x00012FE4 File Offset: 0x000111E4
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x00012FEC File Offset: 0x000111EC
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

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x00012FF8 File Offset: 0x000111F8
		// (set) Token: 0x06000933 RID: 2355 RVA: 0x00013000 File Offset: 0x00011200
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

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0001300C File Offset: 0x0001120C
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x00013014 File Offset: 0x00011214
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

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x00013020 File Offset: 0x00011220
		// (set) Token: 0x06000937 RID: 2359 RVA: 0x00013028 File Offset: 0x00011228
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

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x00013034 File Offset: 0x00011234
		// (set) Token: 0x06000939 RID: 2361 RVA: 0x0001303C File Offset: 0x0001123C
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

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x0600093A RID: 2362 RVA: 0x00013048 File Offset: 0x00011248
		// (set) Token: 0x0600093B RID: 2363 RVA: 0x00013050 File Offset: 0x00011250
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

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x0600093C RID: 2364 RVA: 0x0001305C File Offset: 0x0001125C
		// (set) Token: 0x0600093D RID: 2365 RVA: 0x00013064 File Offset: 0x00011264
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

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x0600093E RID: 2366 RVA: 0x00013070 File Offset: 0x00011270
		// (set) Token: 0x0600093F RID: 2367 RVA: 0x00013078 File Offset: 0x00011278
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000940 RID: 2368 RVA: 0x00013084 File Offset: 0x00011284
		// (set) Token: 0x06000941 RID: 2369 RVA: 0x0001308C File Offset: 0x0001128C
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

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000942 RID: 2370 RVA: 0x00013098 File Offset: 0x00011298
		// (set) Token: 0x06000943 RID: 2371 RVA: 0x000130A0 File Offset: 0x000112A0
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

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x000130AC File Offset: 0x000112AC
		// (set) Token: 0x06000945 RID: 2373 RVA: 0x000130B4 File Offset: 0x000112B4
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

		// Token: 0x040004FF RID: 1279
		private string displayNameField;

		// Token: 0x04000500 RID: 1280
		private LocalizableTextType textField;

		// Token: 0x04000501 RID: 1281
		private string colorField;

		// Token: 0x04000502 RID: 1282
		private string technicalNameField;

		// Token: 0x04000503 RID: 1283
		private string externalIdField;

		// Token: 0x04000504 RID: 1284
		private string shortIdField;

		// Token: 0x04000505 RID: 1285
		private FeaturesType featuresField;

		// Token: 0x04000506 RID: 1286
		private PinsType pinsField;

		// Token: 0x04000507 RID: 1287
		private ConnectionRefType targetField;

		// Token: 0x04000508 RID: 1288
		private string idField;

		// Token: 0x04000509 RID: 1289
		private string objectTemplateReferenceField;

		// Token: 0x0400050A RID: 1290
		private string objectTemplateReferenceNameField;
	}
}
