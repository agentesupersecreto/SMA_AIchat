using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E6 RID: 486
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectTemplateDefinitionType
	{
		// Token: 0x17000935 RID: 2357
		// (get) Token: 0x060015F9 RID: 5625 RVA: 0x0001D1A0 File Offset: 0x0001B3A0
		// (set) Token: 0x060015FA RID: 5626 RVA: 0x0001D1A8 File Offset: 0x0001B3A8
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

		// Token: 0x17000936 RID: 2358
		// (get) Token: 0x060015FB RID: 5627 RVA: 0x0001D1B4 File Offset: 0x0001B3B4
		// (set) Token: 0x060015FC RID: 5628 RVA: 0x0001D1BC File Offset: 0x0001B3BC
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

		// Token: 0x17000937 RID: 2359
		// (get) Token: 0x060015FD RID: 5629 RVA: 0x0001D1C8 File Offset: 0x0001B3C8
		// (set) Token: 0x060015FE RID: 5630 RVA: 0x0001D1D0 File Offset: 0x0001B3D0
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

		// Token: 0x17000938 RID: 2360
		// (get) Token: 0x060015FF RID: 5631 RVA: 0x0001D1DC File Offset: 0x0001B3DC
		// (set) Token: 0x06001600 RID: 5632 RVA: 0x0001D1E4 File Offset: 0x0001B3E4
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

		// Token: 0x17000939 RID: 2361
		// (get) Token: 0x06001601 RID: 5633 RVA: 0x0001D1F0 File Offset: 0x0001B3F0
		// (set) Token: 0x06001602 RID: 5634 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
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

		// Token: 0x1700093A RID: 2362
		// (get) Token: 0x06001603 RID: 5635 RVA: 0x0001D204 File Offset: 0x0001B404
		// (set) Token: 0x06001604 RID: 5636 RVA: 0x0001D20C File Offset: 0x0001B40C
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

		// Token: 0x1700093B RID: 2363
		// (get) Token: 0x06001605 RID: 5637 RVA: 0x0001D218 File Offset: 0x0001B418
		// (set) Token: 0x06001606 RID: 5638 RVA: 0x0001D220 File Offset: 0x0001B420
		public FeatureDefinitionsType FeatureDefinitions
		{
			get
			{
				return this.featureDefinitionsField;
			}
			set
			{
				this.featureDefinitionsField = value;
			}
		}

		// Token: 0x1700093C RID: 2364
		// (get) Token: 0x06001607 RID: 5639 RVA: 0x0001D22C File Offset: 0x0001B42C
		// (set) Token: 0x06001608 RID: 5640 RVA: 0x0001D234 File Offset: 0x0001B434
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

		// Token: 0x04000C1E RID: 3102
		private LocalizableTextType displayNameField;

		// Token: 0x04000C1F RID: 3103
		private string colorField;

		// Token: 0x04000C20 RID: 3104
		private string technicalNameField;

		// Token: 0x04000C21 RID: 3105
		private string externalIdField;

		// Token: 0x04000C22 RID: 3106
		private string shortIdField;

		// Token: 0x04000C23 RID: 3107
		private string urlField;

		// Token: 0x04000C24 RID: 3108
		private FeatureDefinitionsType featureDefinitionsField;

		// Token: 0x04000C25 RID: 3109
		private string idField;
	}
}
