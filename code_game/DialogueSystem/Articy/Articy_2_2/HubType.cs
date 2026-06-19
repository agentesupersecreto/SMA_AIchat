using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E5 RID: 229
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class HubType
	{
		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x00012ED8 File Offset: 0x000110D8
		// (set) Token: 0x06000916 RID: 2326 RVA: 0x00012EE0 File Offset: 0x000110E0
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

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x00012EEC File Offset: 0x000110EC
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x00012EF4 File Offset: 0x000110F4
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

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x00012F00 File Offset: 0x00011100
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x00012F08 File Offset: 0x00011108
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

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x00012F14 File Offset: 0x00011114
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x00012F1C File Offset: 0x0001111C
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

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x00012F28 File Offset: 0x00011128
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x00012F30 File Offset: 0x00011130
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

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00012F3C File Offset: 0x0001113C
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x00012F44 File Offset: 0x00011144
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

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x00012F50 File Offset: 0x00011150
		// (set) Token: 0x06000922 RID: 2338 RVA: 0x00012F58 File Offset: 0x00011158
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

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x00012F64 File Offset: 0x00011164
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x00012F6C File Offset: 0x0001116C
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

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000925 RID: 2341 RVA: 0x00012F78 File Offset: 0x00011178
		// (set) Token: 0x06000926 RID: 2342 RVA: 0x00012F80 File Offset: 0x00011180
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

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000927 RID: 2343 RVA: 0x00012F8C File Offset: 0x0001118C
		// (set) Token: 0x06000928 RID: 2344 RVA: 0x00012F94 File Offset: 0x00011194
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

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000929 RID: 2345 RVA: 0x00012FA0 File Offset: 0x000111A0
		// (set) Token: 0x0600092A RID: 2346 RVA: 0x00012FA8 File Offset: 0x000111A8
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

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x00012FB4 File Offset: 0x000111B4
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x00012FBC File Offset: 0x000111BC
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

		// Token: 0x040004F3 RID: 1267
		private LocalizableTextType displayNameField;

		// Token: 0x040004F4 RID: 1268
		private LocalizableTextType textField;

		// Token: 0x040004F5 RID: 1269
		private string colorField;

		// Token: 0x040004F6 RID: 1270
		private string technicalNameField;

		// Token: 0x040004F7 RID: 1271
		private string externalIdField;

		// Token: 0x040004F8 RID: 1272
		private string shortIdField;

		// Token: 0x040004F9 RID: 1273
		private FeaturesType featuresField;

		// Token: 0x040004FA RID: 1274
		private PinsType pinsField;

		// Token: 0x040004FB RID: 1275
		private string[] text1Field;

		// Token: 0x040004FC RID: 1276
		private string idField;

		// Token: 0x040004FD RID: 1277
		private string objectTemplateReferenceField;

		// Token: 0x040004FE RID: 1278
		private string objectTemplateReferenceNameField;
	}
}
