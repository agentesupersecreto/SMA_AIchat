using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000A8 RID: 168
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class AssetType
	{
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x000117D4 File Offset: 0x0000F9D4
		// (set) Token: 0x060006C1 RID: 1729 RVA: 0x000117DC File Offset: 0x0000F9DC
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

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x000117E8 File Offset: 0x0000F9E8
		// (set) Token: 0x060006C3 RID: 1731 RVA: 0x000117F0 File Offset: 0x0000F9F0
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

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x000117FC File Offset: 0x0000F9FC
		// (set) Token: 0x060006C5 RID: 1733 RVA: 0x00011804 File Offset: 0x0000FA04
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

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00011810 File Offset: 0x0000FA10
		// (set) Token: 0x060006C7 RID: 1735 RVA: 0x00011818 File Offset: 0x0000FA18
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

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x00011824 File Offset: 0x0000FA24
		// (set) Token: 0x060006C9 RID: 1737 RVA: 0x0001182C File Offset: 0x0000FA2C
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

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00011838 File Offset: 0x0000FA38
		// (set) Token: 0x060006CB RID: 1739 RVA: 0x00011840 File Offset: 0x0000FA40
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

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x0001184C File Offset: 0x0000FA4C
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x00011854 File Offset: 0x0000FA54
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

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x00011860 File Offset: 0x0000FA60
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x00011868 File Offset: 0x0000FA68
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

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00011874 File Offset: 0x0000FA74
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x0001187C File Offset: 0x0000FA7C
		public string AssetFilename
		{
			get
			{
				return this.assetFilenameField;
			}
			set
			{
				this.assetFilenameField = value;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00011888 File Offset: 0x0000FA88
		// (set) Token: 0x060006D3 RID: 1747 RVA: 0x00011890 File Offset: 0x0000FA90
		public string AssetPath
		{
			get
			{
				return this.assetPathField;
			}
			set
			{
				this.assetPathField = value;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x0001189C File Offset: 0x0000FA9C
		// (set) Token: 0x060006D5 RID: 1749 RVA: 0x000118A4 File Offset: 0x0000FAA4
		public string OriginalSource
		{
			get
			{
				return this.originalSourceField;
			}
			set
			{
				this.originalSourceField = value;
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x060006D6 RID: 1750 RVA: 0x000118B0 File Offset: 0x0000FAB0
		// (set) Token: 0x060006D7 RID: 1751 RVA: 0x000118B8 File Offset: 0x0000FAB8
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

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x060006D8 RID: 1752 RVA: 0x000118C4 File Offset: 0x0000FAC4
		// (set) Token: 0x060006D9 RID: 1753 RVA: 0x000118CC File Offset: 0x0000FACC
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

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x000118D8 File Offset: 0x0000FAD8
		// (set) Token: 0x060006DB RID: 1755 RVA: 0x000118E0 File Offset: 0x0000FAE0
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

		// Token: 0x040003A0 RID: 928
		private LocalizableTextType displayNameField;

		// Token: 0x040003A1 RID: 929
		private LocalizableTextType textField;

		// Token: 0x040003A2 RID: 930
		private string colorField;

		// Token: 0x040003A3 RID: 931
		private string technicalNameField;

		// Token: 0x040003A4 RID: 932
		private string externalIdField;

		// Token: 0x040003A5 RID: 933
		private string shortIdField;

		// Token: 0x040003A6 RID: 934
		private FeaturesType featuresField;

		// Token: 0x040003A7 RID: 935
		private PreviewImageType previewImageField;

		// Token: 0x040003A8 RID: 936
		private string assetFilenameField;

		// Token: 0x040003A9 RID: 937
		private string assetPathField;

		// Token: 0x040003AA RID: 938
		private string originalSourceField;

		// Token: 0x040003AB RID: 939
		private string idField;

		// Token: 0x040003AC RID: 940
		private string objectTemplateReferenceField;

		// Token: 0x040003AD RID: 941
		private string objectTemplateReferenceNameField;
	}
}
