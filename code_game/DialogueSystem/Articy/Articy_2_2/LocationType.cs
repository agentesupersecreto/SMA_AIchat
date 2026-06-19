using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000DF RID: 223
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class LocationType
	{
		// Token: 0x17000322 RID: 802
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00012B04 File Offset: 0x00010D04
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x00012B0C File Offset: 0x00010D0C
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

		// Token: 0x17000323 RID: 803
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00012B18 File Offset: 0x00010D18
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x00012B20 File Offset: 0x00010D20
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

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x00012B2C File Offset: 0x00010D2C
		// (set) Token: 0x060008B7 RID: 2231 RVA: 0x00012B34 File Offset: 0x00010D34
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

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00012B40 File Offset: 0x00010D40
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x00012B48 File Offset: 0x00010D48
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

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x00012B54 File Offset: 0x00010D54
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x00012B5C File Offset: 0x00010D5C
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

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x00012B68 File Offset: 0x00010D68
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x00012B70 File Offset: 0x00010D70
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

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x00012B7C File Offset: 0x00010D7C
		// (set) Token: 0x060008BF RID: 2239 RVA: 0x00012B84 File Offset: 0x00010D84
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

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x00012B90 File Offset: 0x00010D90
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x00012B98 File Offset: 0x00010D98
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

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x00012BA4 File Offset: 0x00010DA4
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x00012BAC File Offset: 0x00010DAC
		public PreviewImageType PreviewImage
		{
			get
			{
				return this.previewImageField;
			}
			set
			{
				this.previewImageField = value;
			}
		}

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x00012BB8 File Offset: 0x00010DB8
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x00012BC0 File Offset: 0x00010DC0
		public ReferenceType BackgroundImage
		{
			get
			{
				return this.backgroundImageField;
			}
			set
			{
				this.backgroundImageField = value;
			}
		}

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x060008C6 RID: 2246 RVA: 0x00012BCC File Offset: 0x00010DCC
		// (set) Token: 0x060008C7 RID: 2247 RVA: 0x00012BD4 File Offset: 0x00010DD4
		public short BackgroundWidth
		{
			get
			{
				return this.backgroundWidthField;
			}
			set
			{
				this.backgroundWidthField = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060008C8 RID: 2248 RVA: 0x00012BE0 File Offset: 0x00010DE0
		// (set) Token: 0x060008C9 RID: 2249 RVA: 0x00012BE8 File Offset: 0x00010DE8
		[XmlIgnore]
		public bool BackgroundWidthSpecified
		{
			get
			{
				return this.backgroundWidthFieldSpecified;
			}
			set
			{
				this.backgroundWidthFieldSpecified = value;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x00012BF4 File Offset: 0x00010DF4
		// (set) Token: 0x060008CB RID: 2251 RVA: 0x00012BFC File Offset: 0x00010DFC
		public short BackgroundHeight
		{
			get
			{
				return this.backgroundHeightField;
			}
			set
			{
				this.backgroundHeightField = value;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x00012C08 File Offset: 0x00010E08
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x00012C10 File Offset: 0x00010E10
		[XmlIgnore]
		public bool BackgroundHeightSpecified
		{
			get
			{
				return this.backgroundHeightFieldSpecified;
			}
			set
			{
				this.backgroundHeightFieldSpecified = value;
			}
		}

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x00012C1C File Offset: 0x00010E1C
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x00012C24 File Offset: 0x00010E24
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

		// Token: 0x17000331 RID: 817
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x00012C30 File Offset: 0x00010E30
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x00012C38 File Offset: 0x00010E38
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

		// Token: 0x17000332 RID: 818
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x00012C44 File Offset: 0x00010E44
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x00012C4C File Offset: 0x00010E4C
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

		// Token: 0x040004C1 RID: 1217
		private LocalizableTextType displayNameField;

		// Token: 0x040004C2 RID: 1218
		private LocalizableTextType textField;

		// Token: 0x040004C3 RID: 1219
		private string colorField;

		// Token: 0x040004C4 RID: 1220
		private string technicalNameField;

		// Token: 0x040004C5 RID: 1221
		private string externalIdField;

		// Token: 0x040004C6 RID: 1222
		private string shortIdField;

		// Token: 0x040004C7 RID: 1223
		private FeaturesType featuresField;

		// Token: 0x040004C8 RID: 1224
		private ReferencesType referencesField;

		// Token: 0x040004C9 RID: 1225
		private PreviewImageType previewImageField;

		// Token: 0x040004CA RID: 1226
		private ReferenceType backgroundImageField;

		// Token: 0x040004CB RID: 1227
		private short backgroundWidthField;

		// Token: 0x040004CC RID: 1228
		private bool backgroundWidthFieldSpecified;

		// Token: 0x040004CD RID: 1229
		private short backgroundHeightField;

		// Token: 0x040004CE RID: 1230
		private bool backgroundHeightFieldSpecified;

		// Token: 0x040004CF RID: 1231
		private string idField;

		// Token: 0x040004D0 RID: 1232
		private string objectTemplateReferenceField;

		// Token: 0x040004D1 RID: 1233
		private string objectTemplateReferenceNameField;
	}
}
