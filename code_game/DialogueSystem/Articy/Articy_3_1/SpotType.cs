using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FA RID: 506
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class SpotType
	{
		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x0001DBC4 File Offset: 0x0001BDC4
		// (set) Token: 0x06001701 RID: 5889 RVA: 0x0001DBCC File Offset: 0x0001BDCC
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

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x0001DBD8 File Offset: 0x0001BDD8
		// (set) Token: 0x06001703 RID: 5891 RVA: 0x0001DBE0 File Offset: 0x0001BDE0
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

		// Token: 0x170009B2 RID: 2482
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0001DBEC File Offset: 0x0001BDEC
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x0001DBF4 File Offset: 0x0001BDF4
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

		// Token: 0x170009B3 RID: 2483
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x0001DC00 File Offset: 0x0001BE00
		// (set) Token: 0x06001707 RID: 5895 RVA: 0x0001DC08 File Offset: 0x0001BE08
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

		// Token: 0x170009B4 RID: 2484
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0001DC14 File Offset: 0x0001BE14
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x0001DC1C File Offset: 0x0001BE1C
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

		// Token: 0x170009B5 RID: 2485
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x0001DC28 File Offset: 0x0001BE28
		// (set) Token: 0x0600170B RID: 5899 RVA: 0x0001DC30 File Offset: 0x0001BE30
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

		// Token: 0x170009B6 RID: 2486
		// (get) Token: 0x0600170C RID: 5900 RVA: 0x0001DC3C File Offset: 0x0001BE3C
		// (set) Token: 0x0600170D RID: 5901 RVA: 0x0001DC44 File Offset: 0x0001BE44
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

		// Token: 0x170009B7 RID: 2487
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x0001DC50 File Offset: 0x0001BE50
		// (set) Token: 0x0600170F RID: 5903 RVA: 0x0001DC58 File Offset: 0x0001BE58
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

		// Token: 0x170009B8 RID: 2488
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x0001DC64 File Offset: 0x0001BE64
		// (set) Token: 0x06001711 RID: 5905 RVA: 0x0001DC6C File Offset: 0x0001BE6C
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

		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0001DC78 File Offset: 0x0001BE78
		// (set) Token: 0x06001713 RID: 5907 RVA: 0x0001DC80 File Offset: 0x0001BE80
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

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0001DC8C File Offset: 0x0001BE8C
		// (set) Token: 0x06001715 RID: 5909 RVA: 0x0001DC94 File Offset: 0x0001BE94
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

		// Token: 0x170009BB RID: 2491
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0001DCA0 File Offset: 0x0001BEA0
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x0001DCA8 File Offset: 0x0001BEA8
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

		// Token: 0x170009BC RID: 2492
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0001DCB4 File Offset: 0x0001BEB4
		// (set) Token: 0x06001719 RID: 5913 RVA: 0x0001DCBC File Offset: 0x0001BEBC
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

		// Token: 0x170009BD RID: 2493
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x0001DCC8 File Offset: 0x0001BEC8
		// (set) Token: 0x0600171B RID: 5915 RVA: 0x0001DCD0 File Offset: 0x0001BED0
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

		// Token: 0x170009BE RID: 2494
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0001DCDC File Offset: 0x0001BEDC
		// (set) Token: 0x0600171D RID: 5917 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
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

		// Token: 0x170009BF RID: 2495
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0001DCF0 File Offset: 0x0001BEF0
		// (set) Token: 0x0600171F RID: 5919 RVA: 0x0001DCF8 File Offset: 0x0001BEF8
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

		// Token: 0x170009C0 RID: 2496
		// (get) Token: 0x06001720 RID: 5920 RVA: 0x0001DD04 File Offset: 0x0001BF04
		// (set) Token: 0x06001721 RID: 5921 RVA: 0x0001DD0C File Offset: 0x0001BF0C
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

		// Token: 0x170009C1 RID: 2497
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0001DD18 File Offset: 0x0001BF18
		// (set) Token: 0x06001723 RID: 5923 RVA: 0x0001DD20 File Offset: 0x0001BF20
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

		// Token: 0x170009C2 RID: 2498
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0001DD2C File Offset: 0x0001BF2C
		// (set) Token: 0x06001725 RID: 5925 RVA: 0x0001DD34 File Offset: 0x0001BF34
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

		// Token: 0x170009C3 RID: 2499
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x0001DD40 File Offset: 0x0001BF40
		// (set) Token: 0x06001727 RID: 5927 RVA: 0x0001DD48 File Offset: 0x0001BF48
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

		// Token: 0x04000CAB RID: 3243
		private LocalizableTextType displayNameField;

		// Token: 0x04000CAC RID: 3244
		private LocalizableTextType textField;

		// Token: 0x04000CAD RID: 3245
		private string colorField;

		// Token: 0x04000CAE RID: 3246
		private string technicalNameField;

		// Token: 0x04000CAF RID: 3247
		private string externalIdField;

		// Token: 0x04000CB0 RID: 3248
		private string shortIdField;

		// Token: 0x04000CB1 RID: 3249
		private string urlField;

		// Token: 0x04000CB2 RID: 3250
		private FeaturesType featuresField;

		// Token: 0x04000CB3 RID: 3251
		private VisibilityType visibilityField;

		// Token: 0x04000CB4 RID: 3252
		private SelectabilityType selectabilityField;

		// Token: 0x04000CB5 RID: 3253
		private PreviewImageType previewImageField;

		// Token: 0x04000CB6 RID: 3254
		private PointType positionField;

		// Token: 0x04000CB7 RID: 3255
		private float zIndexField;

		// Token: 0x04000CB8 RID: 3256
		private bool showDisplayNameField;

		// Token: 0x04000CB9 RID: 3257
		private string displayNameColorField;

		// Token: 0x04000CBA RID: 3258
		private bool dropShadowField;

		// Token: 0x04000CBB RID: 3259
		private SpotStyleType styleField;

		// Token: 0x04000CBC RID: 3260
		private string idField;

		// Token: 0x04000CBD RID: 3261
		private string objectTemplateReferenceField;

		// Token: 0x04000CBE RID: 3262
		private string objectTemplateReferenceNameField;
	}
}
