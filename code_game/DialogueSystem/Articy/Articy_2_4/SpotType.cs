using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200017B RID: 379
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class SpotType
	{
		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x060010AC RID: 4268 RVA: 0x00018B88 File Offset: 0x00016D88
		// (set) Token: 0x060010AD RID: 4269 RVA: 0x00018B90 File Offset: 0x00016D90
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

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x060010AE RID: 4270 RVA: 0x00018B9C File Offset: 0x00016D9C
		// (set) Token: 0x060010AF RID: 4271 RVA: 0x00018BA4 File Offset: 0x00016DA4
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

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x060010B0 RID: 4272 RVA: 0x00018BB0 File Offset: 0x00016DB0
		// (set) Token: 0x060010B1 RID: 4273 RVA: 0x00018BB8 File Offset: 0x00016DB8
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

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x060010B2 RID: 4274 RVA: 0x00018BC4 File Offset: 0x00016DC4
		// (set) Token: 0x060010B3 RID: 4275 RVA: 0x00018BCC File Offset: 0x00016DCC
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

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x00018BD8 File Offset: 0x00016DD8
		// (set) Token: 0x060010B5 RID: 4277 RVA: 0x00018BE0 File Offset: 0x00016DE0
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

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x00018BEC File Offset: 0x00016DEC
		// (set) Token: 0x060010B7 RID: 4279 RVA: 0x00018BF4 File Offset: 0x00016DF4
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

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00018C00 File Offset: 0x00016E00
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x00018C08 File Offset: 0x00016E08
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

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x00018C14 File Offset: 0x00016E14
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x00018C1C File Offset: 0x00016E1C
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

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x00018C28 File Offset: 0x00016E28
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x00018C30 File Offset: 0x00016E30
		public VisibilityType Visibility
		{
			get
			{
				return this.visibilityField;
			}
			set
			{
				this.visibilityField = value;
			}
		}

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x00018C3C File Offset: 0x00016E3C
		// (set) Token: 0x060010BF RID: 4287 RVA: 0x00018C44 File Offset: 0x00016E44
		public SelectabilityType Selectability
		{
			get
			{
				return this.selectabilityField;
			}
			set
			{
				this.selectabilityField = value;
			}
		}

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060010C0 RID: 4288 RVA: 0x00018C50 File Offset: 0x00016E50
		// (set) Token: 0x060010C1 RID: 4289 RVA: 0x00018C58 File Offset: 0x00016E58
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

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x00018C64 File Offset: 0x00016E64
		// (set) Token: 0x060010C3 RID: 4291 RVA: 0x00018C6C File Offset: 0x00016E6C
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

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00018C78 File Offset: 0x00016E78
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00018C80 File Offset: 0x00016E80
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

		// Token: 0x170006D9 RID: 1753
		// (get) Token: 0x060010C6 RID: 4294 RVA: 0x00018C8C File Offset: 0x00016E8C
		// (set) Token: 0x060010C7 RID: 4295 RVA: 0x00018C94 File Offset: 0x00016E94
		public bool ShowDisplayName
		{
			get
			{
				return this.showDisplayNameField;
			}
			set
			{
				this.showDisplayNameField = value;
			}
		}

		// Token: 0x170006DA RID: 1754
		// (get) Token: 0x060010C8 RID: 4296 RVA: 0x00018CA0 File Offset: 0x00016EA0
		// (set) Token: 0x060010C9 RID: 4297 RVA: 0x00018CA8 File Offset: 0x00016EA8
		public string DisplayNameColor
		{
			get
			{
				return this.displayNameColorField;
			}
			set
			{
				this.displayNameColorField = value;
			}
		}

		// Token: 0x170006DB RID: 1755
		// (get) Token: 0x060010CA RID: 4298 RVA: 0x00018CB4 File Offset: 0x00016EB4
		// (set) Token: 0x060010CB RID: 4299 RVA: 0x00018CBC File Offset: 0x00016EBC
		public bool DropShadow
		{
			get
			{
				return this.dropShadowField;
			}
			set
			{
				this.dropShadowField = value;
			}
		}

		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x00018CC8 File Offset: 0x00016EC8
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x00018CD0 File Offset: 0x00016ED0
		public SpotStyleType Style
		{
			get
			{
				return this.styleField;
			}
			set
			{
				this.styleField = value;
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x00018CDC File Offset: 0x00016EDC
		// (set) Token: 0x060010CF RID: 4303 RVA: 0x00018CE4 File Offset: 0x00016EE4
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

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x00018CF0 File Offset: 0x00016EF0
		// (set) Token: 0x060010D1 RID: 4305 RVA: 0x00018CF8 File Offset: 0x00016EF8
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

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x00018D04 File Offset: 0x00016F04
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x00018D0C File Offset: 0x00016F0C
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

		// Token: 0x0400091E RID: 2334
		private LocalizableTextType displayNameField;

		// Token: 0x0400091F RID: 2335
		private LocalizableTextType textField;

		// Token: 0x04000920 RID: 2336
		private string colorField;

		// Token: 0x04000921 RID: 2337
		private string technicalNameField;

		// Token: 0x04000922 RID: 2338
		private string externalIdField;

		// Token: 0x04000923 RID: 2339
		private string shortIdField;

		// Token: 0x04000924 RID: 2340
		private string urlField;

		// Token: 0x04000925 RID: 2341
		private FeaturesType featuresField;

		// Token: 0x04000926 RID: 2342
		private VisibilityType visibilityField;

		// Token: 0x04000927 RID: 2343
		private SelectabilityType selectabilityField;

		// Token: 0x04000928 RID: 2344
		private PreviewImageType previewImageField;

		// Token: 0x04000929 RID: 2345
		private PointType positionField;

		// Token: 0x0400092A RID: 2346
		private float zIndexField;

		// Token: 0x0400092B RID: 2347
		private bool showDisplayNameField;

		// Token: 0x0400092C RID: 2348
		private string displayNameColorField;

		// Token: 0x0400092D RID: 2349
		private bool dropShadowField;

		// Token: 0x0400092E RID: 2350
		private SpotStyleType styleField;

		// Token: 0x0400092F RID: 2351
		private string idField;

		// Token: 0x04000930 RID: 2352
		private string objectTemplateReferenceField;

		// Token: 0x04000931 RID: 2353
		private string objectTemplateReferenceNameField;
	}
}
