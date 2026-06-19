using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E0 RID: 224
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class InstructionType
	{
		// Token: 0x17000333 RID: 819
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x00012C60 File Offset: 0x00010E60
		// (set) Token: 0x060008D6 RID: 2262 RVA: 0x00012C68 File Offset: 0x00010E68
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

		// Token: 0x17000334 RID: 820
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x00012C74 File Offset: 0x00010E74
		// (set) Token: 0x060008D8 RID: 2264 RVA: 0x00012C7C File Offset: 0x00010E7C
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

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x00012C88 File Offset: 0x00010E88
		// (set) Token: 0x060008DA RID: 2266 RVA: 0x00012C90 File Offset: 0x00010E90
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

		// Token: 0x17000336 RID: 822
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x00012C9C File Offset: 0x00010E9C
		// (set) Token: 0x060008DC RID: 2268 RVA: 0x00012CA4 File Offset: 0x00010EA4
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

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x00012CB0 File Offset: 0x00010EB0
		// (set) Token: 0x060008DE RID: 2270 RVA: 0x00012CB8 File Offset: 0x00010EB8
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

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x00012CC4 File Offset: 0x00010EC4
		// (set) Token: 0x060008E0 RID: 2272 RVA: 0x00012CCC File Offset: 0x00010ECC
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

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x00012CD8 File Offset: 0x00010ED8
		// (set) Token: 0x060008E2 RID: 2274 RVA: 0x00012CE0 File Offset: 0x00010EE0
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

		// Token: 0x1700033A RID: 826
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x00012CEC File Offset: 0x00010EEC
		// (set) Token: 0x060008E4 RID: 2276 RVA: 0x00012CF4 File Offset: 0x00010EF4
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

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x00012D00 File Offset: 0x00010F00
		// (set) Token: 0x060008E6 RID: 2278 RVA: 0x00012D08 File Offset: 0x00010F08
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

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x00012D14 File Offset: 0x00010F14
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x00012D1C File Offset: 0x00010F1C
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

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x00012D28 File Offset: 0x00010F28
		// (set) Token: 0x060008EA RID: 2282 RVA: 0x00012D30 File Offset: 0x00010F30
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

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x060008EB RID: 2283 RVA: 0x00012D3C File Offset: 0x00010F3C
		// (set) Token: 0x060008EC RID: 2284 RVA: 0x00012D44 File Offset: 0x00010F44
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

		// Token: 0x040004D2 RID: 1234
		private LocalizableTextType displayNameField;

		// Token: 0x040004D3 RID: 1235
		private LocalizableTextType textField;

		// Token: 0x040004D4 RID: 1236
		private string colorField;

		// Token: 0x040004D5 RID: 1237
		private string technicalNameField;

		// Token: 0x040004D6 RID: 1238
		private string externalIdField;

		// Token: 0x040004D7 RID: 1239
		private string shortIdField;

		// Token: 0x040004D8 RID: 1240
		private FeaturesType featuresField;

		// Token: 0x040004D9 RID: 1241
		private string expressionField;

		// Token: 0x040004DA RID: 1242
		private PinsType pinsField;

		// Token: 0x040004DB RID: 1243
		private string idField;

		// Token: 0x040004DC RID: 1244
		private string objectTemplateReferenceField;

		// Token: 0x040004DD RID: 1245
		private string objectTemplateReferenceNameField;
	}
}
