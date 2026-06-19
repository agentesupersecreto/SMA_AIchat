using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001D2 RID: 466
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[Serializable]
	public class LinkType
	{
		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x060014AE RID: 5294 RVA: 0x0001C4AC File Offset: 0x0001A6AC
		// (set) Token: 0x060014AF RID: 5295 RVA: 0x0001C4B4 File Offset: 0x0001A6B4
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

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x060014B0 RID: 5296 RVA: 0x0001C4C0 File Offset: 0x0001A6C0
		// (set) Token: 0x060014B1 RID: 5297 RVA: 0x0001C4C8 File Offset: 0x0001A6C8
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

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060014B2 RID: 5298 RVA: 0x0001C4D4 File Offset: 0x0001A6D4
		// (set) Token: 0x060014B3 RID: 5299 RVA: 0x0001C4DC File Offset: 0x0001A6DC
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

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060014B4 RID: 5300 RVA: 0x0001C4E8 File Offset: 0x0001A6E8
		// (set) Token: 0x060014B5 RID: 5301 RVA: 0x0001C4F0 File Offset: 0x0001A6F0
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

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0001C4FC File Offset: 0x0001A6FC
		// (set) Token: 0x060014B7 RID: 5303 RVA: 0x0001C504 File Offset: 0x0001A704
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

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x060014B8 RID: 5304 RVA: 0x0001C510 File Offset: 0x0001A710
		// (set) Token: 0x060014B9 RID: 5305 RVA: 0x0001C518 File Offset: 0x0001A718
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

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x060014BA RID: 5306 RVA: 0x0001C524 File Offset: 0x0001A724
		// (set) Token: 0x060014BB RID: 5307 RVA: 0x0001C52C File Offset: 0x0001A72C
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

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x060014BC RID: 5308 RVA: 0x0001C538 File Offset: 0x0001A738
		// (set) Token: 0x060014BD RID: 5309 RVA: 0x0001C540 File Offset: 0x0001A740
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

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x060014BE RID: 5310 RVA: 0x0001C54C File Offset: 0x0001A74C
		// (set) Token: 0x060014BF RID: 5311 RVA: 0x0001C554 File Offset: 0x0001A754
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

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x060014C0 RID: 5312 RVA: 0x0001C560 File Offset: 0x0001A760
		// (set) Token: 0x060014C1 RID: 5313 RVA: 0x0001C568 File Offset: 0x0001A768
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

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x0001C574 File Offset: 0x0001A774
		// (set) Token: 0x060014C3 RID: 5315 RVA: 0x0001C57C File Offset: 0x0001A77C
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

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x0001C588 File Offset: 0x0001A788
		// (set) Token: 0x060014C5 RID: 5317 RVA: 0x0001C590 File Offset: 0x0001A790
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

		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x060014C6 RID: 5318 RVA: 0x0001C59C File Offset: 0x0001A79C
		// (set) Token: 0x060014C7 RID: 5319 RVA: 0x0001C5A4 File Offset: 0x0001A7A4
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

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x0001C5B0 File Offset: 0x0001A7B0
		// (set) Token: 0x060014C9 RID: 5321 RVA: 0x0001C5B8 File Offset: 0x0001A7B8
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

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x0001C5C4 File Offset: 0x0001A7C4
		// (set) Token: 0x060014CB RID: 5323 RVA: 0x0001C5CC File Offset: 0x0001A7CC
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

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x060014CC RID: 5324 RVA: 0x0001C5D8 File Offset: 0x0001A7D8
		// (set) Token: 0x060014CD RID: 5325 RVA: 0x0001C5E0 File Offset: 0x0001A7E0
		public ReferenceType Target
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

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x060014CE RID: 5326 RVA: 0x0001C5EC File Offset: 0x0001A7EC
		// (set) Token: 0x060014CF RID: 5327 RVA: 0x0001C5F4 File Offset: 0x0001A7F4
		public LinkStyleType Style
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

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x060014D0 RID: 5328 RVA: 0x0001C600 File Offset: 0x0001A800
		// (set) Token: 0x060014D1 RID: 5329 RVA: 0x0001C608 File Offset: 0x0001A808
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

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x060014D2 RID: 5330 RVA: 0x0001C614 File Offset: 0x0001A814
		// (set) Token: 0x060014D3 RID: 5331 RVA: 0x0001C61C File Offset: 0x0001A81C
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

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x060014D4 RID: 5332 RVA: 0x0001C628 File Offset: 0x0001A828
		// (set) Token: 0x060014D5 RID: 5333 RVA: 0x0001C630 File Offset: 0x0001A830
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

		// Token: 0x04000B60 RID: 2912
		private string displayNameField;

		// Token: 0x04000B61 RID: 2913
		private LocalizableTextType textField;

		// Token: 0x04000B62 RID: 2914
		private string colorField;

		// Token: 0x04000B63 RID: 2915
		private string technicalNameField;

		// Token: 0x04000B64 RID: 2916
		private string externalIdField;

		// Token: 0x04000B65 RID: 2917
		private string shortIdField;

		// Token: 0x04000B66 RID: 2918
		private string urlField;

		// Token: 0x04000B67 RID: 2919
		private FeaturesType featuresField;

		// Token: 0x04000B68 RID: 2920
		private VisibilityType visibilityField;

		// Token: 0x04000B69 RID: 2921
		private SelectabilityType selectabilityField;

		// Token: 0x04000B6A RID: 2922
		private PointType positionField;

		// Token: 0x04000B6B RID: 2923
		private float zIndexField;

		// Token: 0x04000B6C RID: 2924
		private bool showDisplayNameField;

		// Token: 0x04000B6D RID: 2925
		private string displayNameColorField;

		// Token: 0x04000B6E RID: 2926
		private bool dropShadowField;

		// Token: 0x04000B6F RID: 2927
		private ReferenceType targetField;

		// Token: 0x04000B70 RID: 2928
		private LinkStyleType styleField;

		// Token: 0x04000B71 RID: 2929
		private string idField;

		// Token: 0x04000B72 RID: 2930
		private string objectTemplateReferenceField;

		// Token: 0x04000B73 RID: 2931
		private string objectTemplateReferenceNameField;
	}
}
