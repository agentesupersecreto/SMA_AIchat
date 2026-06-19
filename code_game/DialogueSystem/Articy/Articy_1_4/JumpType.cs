using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000086 RID: 134
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JumpType
	{
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060004CD RID: 1229 RVA: 0x0000F8A4 File Offset: 0x0000DAA4
		// (set) Token: 0x060004CE RID: 1230 RVA: 0x0000F8AC File Offset: 0x0000DAAC
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

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060004CF RID: 1231 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
		// (set) Token: 0x060004D0 RID: 1232 RVA: 0x0000F8C0 File Offset: 0x0000DAC0
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

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x0000F8CC File Offset: 0x0000DACC
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x0000F8D4 File Offset: 0x0000DAD4
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

		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x0000F8E0 File Offset: 0x0000DAE0
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x0000F8E8 File Offset: 0x0000DAE8
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

		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x0000F8F4 File Offset: 0x0000DAF4
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x0000F8FC File Offset: 0x0000DAFC
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

		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x0000F908 File Offset: 0x0000DB08
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x0000F910 File Offset: 0x0000DB10
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

		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x0000F91C File Offset: 0x0000DB1C
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x0000F924 File Offset: 0x0000DB24
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

		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060004DB RID: 1243 RVA: 0x0000F930 File Offset: 0x0000DB30
		// (set) Token: 0x060004DC RID: 1244 RVA: 0x0000F938 File Offset: 0x0000DB38
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

		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060004DD RID: 1245 RVA: 0x0000F944 File Offset: 0x0000DB44
		// (set) Token: 0x060004DE RID: 1246 RVA: 0x0000F94C File Offset: 0x0000DB4C
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

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060004DF RID: 1247 RVA: 0x0000F958 File Offset: 0x0000DB58
		// (set) Token: 0x060004E0 RID: 1248 RVA: 0x0000F960 File Offset: 0x0000DB60
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060004E1 RID: 1249 RVA: 0x0000F96C File Offset: 0x0000DB6C
		// (set) Token: 0x060004E2 RID: 1250 RVA: 0x0000F974 File Offset: 0x0000DB74
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

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060004E3 RID: 1251 RVA: 0x0000F980 File Offset: 0x0000DB80
		// (set) Token: 0x060004E4 RID: 1252 RVA: 0x0000F988 File Offset: 0x0000DB88
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

		// Token: 0x04000292 RID: 658
		private string displayNameField;

		// Token: 0x04000293 RID: 659
		private LocalizableTextType textField;

		// Token: 0x04000294 RID: 660
		private string colorField;

		// Token: 0x04000295 RID: 661
		private string technicalNameField;

		// Token: 0x04000296 RID: 662
		private string externalIdField;

		// Token: 0x04000297 RID: 663
		private string shortIdField;

		// Token: 0x04000298 RID: 664
		private FeaturesType featuresField;

		// Token: 0x04000299 RID: 665
		private PinsType pinsField;

		// Token: 0x0400029A RID: 666
		private ConnectionRefType targetField;

		// Token: 0x0400029B RID: 667
		private string guidField;

		// Token: 0x0400029C RID: 668
		private string objectTemplateReferenceField;

		// Token: 0x0400029D RID: 669
		private string objectTemplateReferenceNameField;
	}
}
