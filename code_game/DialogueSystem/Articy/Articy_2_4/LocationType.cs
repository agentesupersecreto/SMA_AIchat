using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000157 RID: 343
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocationType
	{
		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x0001764C File Offset: 0x0001584C
		// (set) Token: 0x06000E8B RID: 3723 RVA: 0x00017654 File Offset: 0x00015854
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

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x06000E8C RID: 3724 RVA: 0x00017660 File Offset: 0x00015860
		// (set) Token: 0x06000E8D RID: 3725 RVA: 0x00017668 File Offset: 0x00015868
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

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x06000E8E RID: 3726 RVA: 0x00017674 File Offset: 0x00015874
		// (set) Token: 0x06000E8F RID: 3727 RVA: 0x0001767C File Offset: 0x0001587C
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

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06000E90 RID: 3728 RVA: 0x00017688 File Offset: 0x00015888
		// (set) Token: 0x06000E91 RID: 3729 RVA: 0x00017690 File Offset: 0x00015890
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

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06000E92 RID: 3730 RVA: 0x0001769C File Offset: 0x0001589C
		// (set) Token: 0x06000E93 RID: 3731 RVA: 0x000176A4 File Offset: 0x000158A4
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

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x000176B0 File Offset: 0x000158B0
		// (set) Token: 0x06000E95 RID: 3733 RVA: 0x000176B8 File Offset: 0x000158B8
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

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06000E96 RID: 3734 RVA: 0x000176C4 File Offset: 0x000158C4
		// (set) Token: 0x06000E97 RID: 3735 RVA: 0x000176CC File Offset: 0x000158CC
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

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06000E98 RID: 3736 RVA: 0x000176D8 File Offset: 0x000158D8
		// (set) Token: 0x06000E99 RID: 3737 RVA: 0x000176E0 File Offset: 0x000158E0
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

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x000176EC File Offset: 0x000158EC
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x000176F4 File Offset: 0x000158F4
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

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00017700 File Offset: 0x00015900
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x00017708 File Offset: 0x00015908
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

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06000E9E RID: 3742 RVA: 0x00017714 File Offset: 0x00015914
		// (set) Token: 0x06000E9F RID: 3743 RVA: 0x0001771C File Offset: 0x0001591C
		public LocationSettingsType Settings
		{
			get
			{
				return this.settingsField;
			}
			set
			{
				this.settingsField = value;
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06000EA0 RID: 3744 RVA: 0x00017728 File Offset: 0x00015928
		// (set) Token: 0x06000EA1 RID: 3745 RVA: 0x00017730 File Offset: 0x00015930
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

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x06000EA2 RID: 3746 RVA: 0x0001773C File Offset: 0x0001593C
		// (set) Token: 0x06000EA3 RID: 3747 RVA: 0x00017744 File Offset: 0x00015944
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

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x06000EA4 RID: 3748 RVA: 0x00017750 File Offset: 0x00015950
		// (set) Token: 0x06000EA5 RID: 3749 RVA: 0x00017758 File Offset: 0x00015958
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

		// Token: 0x040007F4 RID: 2036
		private LocalizableTextType displayNameField;

		// Token: 0x040007F5 RID: 2037
		private LocalizableTextType textField;

		// Token: 0x040007F6 RID: 2038
		private string colorField;

		// Token: 0x040007F7 RID: 2039
		private string technicalNameField;

		// Token: 0x040007F8 RID: 2040
		private string externalIdField;

		// Token: 0x040007F9 RID: 2041
		private string shortIdField;

		// Token: 0x040007FA RID: 2042
		private string urlField;

		// Token: 0x040007FB RID: 2043
		private FeaturesType featuresField;

		// Token: 0x040007FC RID: 2044
		private ReferencesType referencesField;

		// Token: 0x040007FD RID: 2045
		private PreviewImageType previewImageField;

		// Token: 0x040007FE RID: 2046
		private LocationSettingsType settingsField;

		// Token: 0x040007FF RID: 2047
		private string idField;

		// Token: 0x04000800 RID: 2048
		private string objectTemplateReferenceField;

		// Token: 0x04000801 RID: 2049
		private string objectTemplateReferenceNameField;
	}
}
