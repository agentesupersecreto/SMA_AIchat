using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000082 RID: 130
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class HubType
	{
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060004A6 RID: 1190 RVA: 0x0000F724 File Offset: 0x0000D924
		// (set) Token: 0x060004A7 RID: 1191 RVA: 0x0000F72C File Offset: 0x0000D92C
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

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x0000F738 File Offset: 0x0000D938
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x0000F740 File Offset: 0x0000D940
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

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060004AA RID: 1194 RVA: 0x0000F74C File Offset: 0x0000D94C
		// (set) Token: 0x060004AB RID: 1195 RVA: 0x0000F754 File Offset: 0x0000D954
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

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060004AC RID: 1196 RVA: 0x0000F760 File Offset: 0x0000D960
		// (set) Token: 0x060004AD RID: 1197 RVA: 0x0000F768 File Offset: 0x0000D968
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

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060004AE RID: 1198 RVA: 0x0000F774 File Offset: 0x0000D974
		// (set) Token: 0x060004AF RID: 1199 RVA: 0x0000F77C File Offset: 0x0000D97C
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

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060004B0 RID: 1200 RVA: 0x0000F788 File Offset: 0x0000D988
		// (set) Token: 0x060004B1 RID: 1201 RVA: 0x0000F790 File Offset: 0x0000D990
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

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060004B2 RID: 1202 RVA: 0x0000F79C File Offset: 0x0000D99C
		// (set) Token: 0x060004B3 RID: 1203 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
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

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060004B4 RID: 1204 RVA: 0x0000F7B0 File Offset: 0x0000D9B0
		// (set) Token: 0x060004B5 RID: 1205 RVA: 0x0000F7B8 File Offset: 0x0000D9B8
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

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x0000F7C4 File Offset: 0x0000D9C4
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x0000F7CC File Offset: 0x0000D9CC
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

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060004B8 RID: 1208 RVA: 0x0000F7D8 File Offset: 0x0000D9D8
		// (set) Token: 0x060004B9 RID: 1209 RVA: 0x0000F7E0 File Offset: 0x0000D9E0
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

		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060004BA RID: 1210 RVA: 0x0000F7EC File Offset: 0x0000D9EC
		// (set) Token: 0x060004BB RID: 1211 RVA: 0x0000F7F4 File Offset: 0x0000D9F4
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

		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060004BC RID: 1212 RVA: 0x0000F800 File Offset: 0x0000DA00
		// (set) Token: 0x060004BD RID: 1213 RVA: 0x0000F808 File Offset: 0x0000DA08
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

		// Token: 0x0400027D RID: 637
		private LocalizableTextType displayNameField;

		// Token: 0x0400027E RID: 638
		private LocalizableTextType textField;

		// Token: 0x0400027F RID: 639
		private string colorField;

		// Token: 0x04000280 RID: 640
		private string technicalNameField;

		// Token: 0x04000281 RID: 641
		private string externalIdField;

		// Token: 0x04000282 RID: 642
		private string shortIdField;

		// Token: 0x04000283 RID: 643
		private FeaturesType featuresField;

		// Token: 0x04000284 RID: 644
		private PinsType pinsField;

		// Token: 0x04000285 RID: 645
		private string[] text1Field;

		// Token: 0x04000286 RID: 646
		private string guidField;

		// Token: 0x04000287 RID: 647
		private string objectTemplateReferenceField;

		// Token: 0x04000288 RID: 648
		private string objectTemplateReferenceNameField;
	}
}
