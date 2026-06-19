using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CF RID: 463
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LayerFolderType
	{
		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x0001C3C8 File Offset: 0x0001A5C8
		// (set) Token: 0x06001498 RID: 5272 RVA: 0x0001C3D0 File Offset: 0x0001A5D0
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

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x06001499 RID: 5273 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		// (set) Token: 0x0600149A RID: 5274 RVA: 0x0001C3E4 File Offset: 0x0001A5E4
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

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x0600149B RID: 5275 RVA: 0x0001C3F0 File Offset: 0x0001A5F0
		// (set) Token: 0x0600149C RID: 5276 RVA: 0x0001C3F8 File Offset: 0x0001A5F8
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

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x0600149D RID: 5277 RVA: 0x0001C404 File Offset: 0x0001A604
		// (set) Token: 0x0600149E RID: 5278 RVA: 0x0001C40C File Offset: 0x0001A60C
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

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x0001C418 File Offset: 0x0001A618
		// (set) Token: 0x060014A0 RID: 5280 RVA: 0x0001C420 File Offset: 0x0001A620
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

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x060014A1 RID: 5281 RVA: 0x0001C42C File Offset: 0x0001A62C
		// (set) Token: 0x060014A2 RID: 5282 RVA: 0x0001C434 File Offset: 0x0001A634
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

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x060014A3 RID: 5283 RVA: 0x0001C440 File Offset: 0x0001A640
		// (set) Token: 0x060014A4 RID: 5284 RVA: 0x0001C448 File Offset: 0x0001A648
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

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x060014A5 RID: 5285 RVA: 0x0001C454 File Offset: 0x0001A654
		// (set) Token: 0x060014A6 RID: 5286 RVA: 0x0001C45C File Offset: 0x0001A65C
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

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x0001C468 File Offset: 0x0001A668
		// (set) Token: 0x060014A8 RID: 5288 RVA: 0x0001C470 File Offset: 0x0001A670
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

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x0001C47C File Offset: 0x0001A67C
		// (set) Token: 0x060014AA RID: 5290 RVA: 0x0001C484 File Offset: 0x0001A684
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

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x0001C490 File Offset: 0x0001A690
		// (set) Token: 0x060014AC RID: 5292 RVA: 0x0001C498 File Offset: 0x0001A698
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

		// Token: 0x04000B4F RID: 2895
		private LocalizableTextType displayNameField;

		// Token: 0x04000B50 RID: 2896
		private LocalizableTextType textField;

		// Token: 0x04000B51 RID: 2897
		private string colorField;

		// Token: 0x04000B52 RID: 2898
		private string technicalNameField;

		// Token: 0x04000B53 RID: 2899
		private string externalIdField;

		// Token: 0x04000B54 RID: 2900
		private string shortIdField;

		// Token: 0x04000B55 RID: 2901
		private string urlField;

		// Token: 0x04000B56 RID: 2902
		private VisibilityType visibilityField;

		// Token: 0x04000B57 RID: 2903
		private SelectabilityType selectabilityField;

		// Token: 0x04000B58 RID: 2904
		private float zIndexField;

		// Token: 0x04000B59 RID: 2905
		private string idField;
	}
}
