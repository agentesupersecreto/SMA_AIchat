using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000EA RID: 234
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FlowFragmentType
	{
		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00013338 File Offset: 0x00011538
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00013340 File Offset: 0x00011540
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

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0001334C File Offset: 0x0001154C
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00013354 File Offset: 0x00011554
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

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00013360 File Offset: 0x00011560
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00013368 File Offset: 0x00011568
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

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x00013374 File Offset: 0x00011574
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x0001337C File Offset: 0x0001157C
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

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x00013388 File Offset: 0x00011588
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x00013390 File Offset: 0x00011590
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

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x0001339C File Offset: 0x0001159C
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x000133A4 File Offset: 0x000115A4
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

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x06000992 RID: 2450 RVA: 0x000133B0 File Offset: 0x000115B0
		// (set) Token: 0x06000993 RID: 2451 RVA: 0x000133B8 File Offset: 0x000115B8
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

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x000133C4 File Offset: 0x000115C4
		// (set) Token: 0x06000995 RID: 2453 RVA: 0x000133CC File Offset: 0x000115CC
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

		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000996 RID: 2454 RVA: 0x000133D8 File Offset: 0x000115D8
		// (set) Token: 0x06000997 RID: 2455 RVA: 0x000133E0 File Offset: 0x000115E0
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

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x000133EC File Offset: 0x000115EC
		// (set) Token: 0x06000999 RID: 2457 RVA: 0x000133F4 File Offset: 0x000115F4
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

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x0600099A RID: 2458 RVA: 0x00013400 File Offset: 0x00011600
		// (set) Token: 0x0600099B RID: 2459 RVA: 0x00013408 File Offset: 0x00011608
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

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x0600099C RID: 2460 RVA: 0x00013414 File Offset: 0x00011614
		// (set) Token: 0x0600099D RID: 2461 RVA: 0x0001341C File Offset: 0x0001161C
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

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x0600099E RID: 2462 RVA: 0x00013428 File Offset: 0x00011628
		// (set) Token: 0x0600099F RID: 2463 RVA: 0x00013430 File Offset: 0x00011630
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

		// Token: 0x04000529 RID: 1321
		private LocalizableTextType displayNameField;

		// Token: 0x0400052A RID: 1322
		private LocalizableTextType textField;

		// Token: 0x0400052B RID: 1323
		private string colorField;

		// Token: 0x0400052C RID: 1324
		private string technicalNameField;

		// Token: 0x0400052D RID: 1325
		private string externalIdField;

		// Token: 0x0400052E RID: 1326
		private string shortIdField;

		// Token: 0x0400052F RID: 1327
		private FeaturesType featuresField;

		// Token: 0x04000530 RID: 1328
		private ReferencesType referencesField;

		// Token: 0x04000531 RID: 1329
		private PreviewImageType previewImageField;

		// Token: 0x04000532 RID: 1330
		private PinsType pinsField;

		// Token: 0x04000533 RID: 1331
		private string idField;

		// Token: 0x04000534 RID: 1332
		private string objectTemplateReferenceField;

		// Token: 0x04000535 RID: 1333
		private string objectTemplateReferenceNameField;
	}
}
