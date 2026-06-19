using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000EF RID: 239
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectTemplateDefinitionType
	{
		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x000135A4 File Offset: 0x000117A4
		// (set) Token: 0x060009C6 RID: 2502 RVA: 0x000135AC File Offset: 0x000117AC
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

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x000135B8 File Offset: 0x000117B8
		// (set) Token: 0x060009C8 RID: 2504 RVA: 0x000135C0 File Offset: 0x000117C0
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

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x000135CC File Offset: 0x000117CC
		// (set) Token: 0x060009CA RID: 2506 RVA: 0x000135D4 File Offset: 0x000117D4
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

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x000135E0 File Offset: 0x000117E0
		// (set) Token: 0x060009CC RID: 2508 RVA: 0x000135E8 File Offset: 0x000117E8
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

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x000135F4 File Offset: 0x000117F4
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x000135FC File Offset: 0x000117FC
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

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x060009CF RID: 2511 RVA: 0x00013608 File Offset: 0x00011808
		// (set) Token: 0x060009D0 RID: 2512 RVA: 0x00013610 File Offset: 0x00011810
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

		// Token: 0x04000546 RID: 1350
		private LocalizableTextType displayNameField;

		// Token: 0x04000547 RID: 1351
		private string colorField;

		// Token: 0x04000548 RID: 1352
		private string externalIdField;

		// Token: 0x04000549 RID: 1353
		private string shortIdField;

		// Token: 0x0400054A RID: 1354
		private FeatureDefinitionsType featureDefinitionsField;

		// Token: 0x0400054B RID: 1355
		private string idField;
	}
}
