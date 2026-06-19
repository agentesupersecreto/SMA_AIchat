using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E8 RID: 232
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class DialogueFragmentType
	{
		// Token: 0x1700036C RID: 876
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x0001310C File Offset: 0x0001130C
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x00013114 File Offset: 0x00011314
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

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06000950 RID: 2384 RVA: 0x00013120 File Offset: 0x00011320
		// (set) Token: 0x06000951 RID: 2385 RVA: 0x00013128 File Offset: 0x00011328
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

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x00013134 File Offset: 0x00011334
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x0001313C File Offset: 0x0001133C
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

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x00013148 File Offset: 0x00011348
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x00013150 File Offset: 0x00011350
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

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x0001315C File Offset: 0x0001135C
		// (set) Token: 0x06000957 RID: 2391 RVA: 0x00013164 File Offset: 0x00011364
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

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x00013170 File Offset: 0x00011370
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x00013178 File Offset: 0x00011378
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

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x0600095A RID: 2394 RVA: 0x00013184 File Offset: 0x00011384
		// (set) Token: 0x0600095B RID: 2395 RVA: 0x0001318C File Offset: 0x0001138C
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

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00013198 File Offset: 0x00011398
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x000131A0 File Offset: 0x000113A0
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

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x0600095E RID: 2398 RVA: 0x000131AC File Offset: 0x000113AC
		// (set) Token: 0x0600095F RID: 2399 RVA: 0x000131B4 File Offset: 0x000113B4
		public ReferenceType Speaker
		{
			get
			{
				return this.speakerField;
			}
			set
			{
				this.speakerField = value;
			}
		}

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x000131C0 File Offset: 0x000113C0
		// (set) Token: 0x06000961 RID: 2401 RVA: 0x000131C8 File Offset: 0x000113C8
		public LocalizableTextType StageDirections
		{
			get
			{
				return this.stageDirectionsField;
			}
			set
			{
				this.stageDirectionsField = value;
			}
		}

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000962 RID: 2402 RVA: 0x000131D4 File Offset: 0x000113D4
		// (set) Token: 0x06000963 RID: 2403 RVA: 0x000131DC File Offset: 0x000113DC
		public LocalizableTextType MenuText
		{
			get
			{
				return this.menuTextField;
			}
			set
			{
				this.menuTextField = value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x000131E8 File Offset: 0x000113E8
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x000131F0 File Offset: 0x000113F0
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

		// Token: 0x17000378 RID: 888
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x000131FC File Offset: 0x000113FC
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00013204 File Offset: 0x00011404
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

		// Token: 0x17000379 RID: 889
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00013210 File Offset: 0x00011410
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00013218 File Offset: 0x00011418
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

		// Token: 0x0400050E RID: 1294
		private string displayNameField;

		// Token: 0x0400050F RID: 1295
		private LocalizableTextType textField;

		// Token: 0x04000510 RID: 1296
		private string colorField;

		// Token: 0x04000511 RID: 1297
		private string technicalNameField;

		// Token: 0x04000512 RID: 1298
		private string externalIdField;

		// Token: 0x04000513 RID: 1299
		private string shortIdField;

		// Token: 0x04000514 RID: 1300
		private FeaturesType featuresField;

		// Token: 0x04000515 RID: 1301
		private PinsType pinsField;

		// Token: 0x04000516 RID: 1302
		private ReferenceType speakerField;

		// Token: 0x04000517 RID: 1303
		private LocalizableTextType stageDirectionsField;

		// Token: 0x04000518 RID: 1304
		private LocalizableTextType menuTextField;

		// Token: 0x04000519 RID: 1305
		private string idField;

		// Token: 0x0400051A RID: 1306
		private string objectTemplateReferenceField;

		// Token: 0x0400051B RID: 1307
		private string objectTemplateReferenceNameField;
	}
}
