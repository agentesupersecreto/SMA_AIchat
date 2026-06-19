using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000066 RID: 102
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyType
	{
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000EB28 File Offset: 0x0000CD28
		// (set) Token: 0x0600036F RID: 879 RVA: 0x0000EB30 File Offset: 0x0000CD30
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

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000370 RID: 880 RVA: 0x0000EB3C File Offset: 0x0000CD3C
		// (set) Token: 0x06000371 RID: 881 RVA: 0x0000EB44 File Offset: 0x0000CD44
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

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000372 RID: 882 RVA: 0x0000EB50 File Offset: 0x0000CD50
		// (set) Token: 0x06000373 RID: 883 RVA: 0x0000EB58 File Offset: 0x0000CD58
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

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0000EB64 File Offset: 0x0000CD64
		// (set) Token: 0x06000375 RID: 885 RVA: 0x0000EB6C File Offset: 0x0000CD6C
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

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000376 RID: 886 RVA: 0x0000EB78 File Offset: 0x0000CD78
		// (set) Token: 0x06000377 RID: 887 RVA: 0x0000EB80 File Offset: 0x0000CD80
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

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000378 RID: 888 RVA: 0x0000EB8C File Offset: 0x0000CD8C
		// (set) Token: 0x06000379 RID: 889 RVA: 0x0000EB94 File Offset: 0x0000CD94
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

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x0600037A RID: 890 RVA: 0x0000EBA0 File Offset: 0x0000CDA0
		// (set) Token: 0x0600037B RID: 891 RVA: 0x0000EBA8 File Offset: 0x0000CDA8
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

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000EBB4 File Offset: 0x0000CDB4
		// (set) Token: 0x0600037D RID: 893 RVA: 0x0000EBBC File Offset: 0x0000CDBC
		public JourneySettingsType Settings
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

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x0600037E RID: 894 RVA: 0x0000EBC8 File Offset: 0x0000CDC8
		// (set) Token: 0x0600037F RID: 895 RVA: 0x0000EBD0 File Offset: 0x0000CDD0
		public JourneyPointsType JourneyPoints
		{
			get
			{
				return this.journeyPointsField;
			}
			set
			{
				this.journeyPointsField = value;
			}
		}

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000EBDC File Offset: 0x0000CDDC
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000EBE4 File Offset: 0x0000CDE4
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x040001E6 RID: 486
		private LocalizableTextType displayNameField;

		// Token: 0x040001E7 RID: 487
		private LocalizableTextType textField;

		// Token: 0x040001E8 RID: 488
		private string colorField;

		// Token: 0x040001E9 RID: 489
		private string technicalNameField;

		// Token: 0x040001EA RID: 490
		private string externalIdField;

		// Token: 0x040001EB RID: 491
		private string shortIdField;

		// Token: 0x040001EC RID: 492
		private ReferencesType referencesField;

		// Token: 0x040001ED RID: 493
		private JourneySettingsType settingsField;

		// Token: 0x040001EE RID: 494
		private JourneyPointsType journeyPointsField;

		// Token: 0x040001EF RID: 495
		private string guidField;
	}
}
