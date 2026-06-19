using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014F RID: 335
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JumpType
	{
		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x00017258 File Offset: 0x00015458
		// (set) Token: 0x06000E25 RID: 3621 RVA: 0x00017260 File Offset: 0x00015460
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

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x0001726C File Offset: 0x0001546C
		// (set) Token: 0x06000E27 RID: 3623 RVA: 0x00017274 File Offset: 0x00015474
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

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x00017280 File Offset: 0x00015480
		// (set) Token: 0x06000E29 RID: 3625 RVA: 0x00017288 File Offset: 0x00015488
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

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00017294 File Offset: 0x00015494
		// (set) Token: 0x06000E2B RID: 3627 RVA: 0x0001729C File Offset: 0x0001549C
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

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06000E2C RID: 3628 RVA: 0x000172A8 File Offset: 0x000154A8
		// (set) Token: 0x06000E2D RID: 3629 RVA: 0x000172B0 File Offset: 0x000154B0
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

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06000E2E RID: 3630 RVA: 0x000172BC File Offset: 0x000154BC
		// (set) Token: 0x06000E2F RID: 3631 RVA: 0x000172C4 File Offset: 0x000154C4
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

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06000E30 RID: 3632 RVA: 0x000172D0 File Offset: 0x000154D0
		// (set) Token: 0x06000E31 RID: 3633 RVA: 0x000172D8 File Offset: 0x000154D8
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

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06000E32 RID: 3634 RVA: 0x000172E4 File Offset: 0x000154E4
		// (set) Token: 0x06000E33 RID: 3635 RVA: 0x000172EC File Offset: 0x000154EC
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

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06000E34 RID: 3636 RVA: 0x000172F8 File Offset: 0x000154F8
		// (set) Token: 0x06000E35 RID: 3637 RVA: 0x00017300 File Offset: 0x00015500
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

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06000E36 RID: 3638 RVA: 0x0001730C File Offset: 0x0001550C
		// (set) Token: 0x06000E37 RID: 3639 RVA: 0x00017314 File Offset: 0x00015514
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

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06000E38 RID: 3640 RVA: 0x00017320 File Offset: 0x00015520
		// (set) Token: 0x06000E39 RID: 3641 RVA: 0x00017328 File Offset: 0x00015528
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

		// Token: 0x170005A3 RID: 1443
		// (get) Token: 0x06000E3A RID: 3642 RVA: 0x00017334 File Offset: 0x00015534
		// (set) Token: 0x06000E3B RID: 3643 RVA: 0x0001733C File Offset: 0x0001553C
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

		// Token: 0x170005A4 RID: 1444
		// (get) Token: 0x06000E3C RID: 3644 RVA: 0x00017348 File Offset: 0x00015548
		// (set) Token: 0x06000E3D RID: 3645 RVA: 0x00017350 File Offset: 0x00015550
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

		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x06000E3E RID: 3646 RVA: 0x0001735C File Offset: 0x0001555C
		// (set) Token: 0x06000E3F RID: 3647 RVA: 0x00017364 File Offset: 0x00015564
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

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06000E40 RID: 3648 RVA: 0x00017370 File Offset: 0x00015570
		// (set) Token: 0x06000E41 RID: 3649 RVA: 0x00017378 File Offset: 0x00015578
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

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00017384 File Offset: 0x00015584
		// (set) Token: 0x06000E43 RID: 3651 RVA: 0x0001738C File Offset: 0x0001558C
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

		// Token: 0x040007B3 RID: 1971
		private string displayNameField;

		// Token: 0x040007B4 RID: 1972
		private LocalizableTextType textField;

		// Token: 0x040007B5 RID: 1973
		private string colorField;

		// Token: 0x040007B6 RID: 1974
		private string technicalNameField;

		// Token: 0x040007B7 RID: 1975
		private string externalIdField;

		// Token: 0x040007B8 RID: 1976
		private string shortIdField;

		// Token: 0x040007B9 RID: 1977
		private string urlField;

		// Token: 0x040007BA RID: 1978
		private FeaturesType featuresField;

		// Token: 0x040007BB RID: 1979
		private PinsType pinsField;

		// Token: 0x040007BC RID: 1980
		private PointType positionField;

		// Token: 0x040007BD RID: 1981
		private SizeType sizeField;

		// Token: 0x040007BE RID: 1982
		private float zIndexField;

		// Token: 0x040007BF RID: 1983
		private ConnectionRefType targetField;

		// Token: 0x040007C0 RID: 1984
		private string idField;

		// Token: 0x040007C1 RID: 1985
		private string objectTemplateReferenceField;

		// Token: 0x040007C2 RID: 1986
		private string objectTemplateReferenceNameField;
	}
}
