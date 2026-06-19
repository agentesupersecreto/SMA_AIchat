using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000150 RID: 336
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LayerFolderType
	{
		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06000E45 RID: 3653 RVA: 0x000173A0 File Offset: 0x000155A0
		// (set) Token: 0x06000E46 RID: 3654 RVA: 0x000173A8 File Offset: 0x000155A8
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

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x000173B4 File Offset: 0x000155B4
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x000173BC File Offset: 0x000155BC
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

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06000E49 RID: 3657 RVA: 0x000173C8 File Offset: 0x000155C8
		// (set) Token: 0x06000E4A RID: 3658 RVA: 0x000173D0 File Offset: 0x000155D0
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

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x000173DC File Offset: 0x000155DC
		// (set) Token: 0x06000E4C RID: 3660 RVA: 0x000173E4 File Offset: 0x000155E4
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

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x000173F0 File Offset: 0x000155F0
		// (set) Token: 0x06000E4E RID: 3662 RVA: 0x000173F8 File Offset: 0x000155F8
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

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x00017404 File Offset: 0x00015604
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x0001740C File Offset: 0x0001560C
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

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00017418 File Offset: 0x00015618
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x00017420 File Offset: 0x00015620
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

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x0001742C File Offset: 0x0001562C
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00017434 File Offset: 0x00015634
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

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x00017440 File Offset: 0x00015640
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x00017448 File Offset: 0x00015648
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

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x00017454 File Offset: 0x00015654
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x0001745C File Offset: 0x0001565C
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

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x00017468 File Offset: 0x00015668
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x00017470 File Offset: 0x00015670
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

		// Token: 0x040007C3 RID: 1987
		private LocalizableTextType displayNameField;

		// Token: 0x040007C4 RID: 1988
		private LocalizableTextType textField;

		// Token: 0x040007C5 RID: 1989
		private string colorField;

		// Token: 0x040007C6 RID: 1990
		private string technicalNameField;

		// Token: 0x040007C7 RID: 1991
		private string externalIdField;

		// Token: 0x040007C8 RID: 1992
		private string shortIdField;

		// Token: 0x040007C9 RID: 1993
		private string urlField;

		// Token: 0x040007CA RID: 1994
		private VisibilityType visibilityField;

		// Token: 0x040007CB RID: 1995
		private SelectabilityType selectabilityField;

		// Token: 0x040007CC RID: 1996
		private float zIndexField;

		// Token: 0x040007CD RID: 1997
		private string idField;
	}
}
