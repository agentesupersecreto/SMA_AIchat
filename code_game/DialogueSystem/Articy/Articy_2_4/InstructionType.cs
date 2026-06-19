using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200013C RID: 316
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class InstructionType
	{
		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x00016CB0 File Offset: 0x00014EB0
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x00016CB8 File Offset: 0x00014EB8
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

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x00016CC4 File Offset: 0x00014EC4
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x00016CCC File Offset: 0x00014ECC
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

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00016CD8 File Offset: 0x00014ED8
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x00016CE0 File Offset: 0x00014EE0
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

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x00016CEC File Offset: 0x00014EEC
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x00016CF4 File Offset: 0x00014EF4
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

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x00016D00 File Offset: 0x00014F00
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00016D08 File Offset: 0x00014F08
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

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x00016D14 File Offset: 0x00014F14
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x00016D1C File Offset: 0x00014F1C
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

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x00016D28 File Offset: 0x00014F28
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x00016D30 File Offset: 0x00014F30
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

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00016D3C File Offset: 0x00014F3C
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x00016D44 File Offset: 0x00014F44
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

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06000DA1 RID: 3489 RVA: 0x00016D50 File Offset: 0x00014F50
		// (set) Token: 0x06000DA2 RID: 3490 RVA: 0x00016D58 File Offset: 0x00014F58
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

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00016D64 File Offset: 0x00014F64
		// (set) Token: 0x06000DA4 RID: 3492 RVA: 0x00016D6C File Offset: 0x00014F6C
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

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06000DA5 RID: 3493 RVA: 0x00016D78 File Offset: 0x00014F78
		// (set) Token: 0x06000DA6 RID: 3494 RVA: 0x00016D80 File Offset: 0x00014F80
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

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x00016D8C File Offset: 0x00014F8C
		// (set) Token: 0x06000DA8 RID: 3496 RVA: 0x00016D94 File Offset: 0x00014F94
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

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00016DA0 File Offset: 0x00014FA0
		// (set) Token: 0x06000DAA RID: 3498 RVA: 0x00016DA8 File Offset: 0x00014FA8
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

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00016DB4 File Offset: 0x00014FB4
		// (set) Token: 0x06000DAC RID: 3500 RVA: 0x00016DBC File Offset: 0x00014FBC
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

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00016DC8 File Offset: 0x00014FC8
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00016DD0 File Offset: 0x00014FD0
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

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00016DDC File Offset: 0x00014FDC
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00016DE4 File Offset: 0x00014FE4
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

		// Token: 0x04000744 RID: 1860
		private string displayNameField;

		// Token: 0x04000745 RID: 1861
		private LocalizableTextType textField;

		// Token: 0x04000746 RID: 1862
		private string colorField;

		// Token: 0x04000747 RID: 1863
		private string technicalNameField;

		// Token: 0x04000748 RID: 1864
		private string externalIdField;

		// Token: 0x04000749 RID: 1865
		private string shortIdField;

		// Token: 0x0400074A RID: 1866
		private string urlField;

		// Token: 0x0400074B RID: 1867
		private FeaturesType featuresField;

		// Token: 0x0400074C RID: 1868
		private string expressionField;

		// Token: 0x0400074D RID: 1869
		private PinsType pinsField;

		// Token: 0x0400074E RID: 1870
		private PointType positionField;

		// Token: 0x0400074F RID: 1871
		private SizeType sizeField;

		// Token: 0x04000750 RID: 1872
		private float zIndexField;

		// Token: 0x04000751 RID: 1873
		private string idField;

		// Token: 0x04000752 RID: 1874
		private string objectTemplateReferenceField;

		// Token: 0x04000753 RID: 1875
		private string objectTemplateReferenceNameField;
	}
}
