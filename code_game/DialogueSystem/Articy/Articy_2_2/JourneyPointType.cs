using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000CC RID: 204
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyPointType
	{
		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x000120C4 File Offset: 0x000102C4
		// (set) Token: 0x060007AA RID: 1962 RVA: 0x000120CC File Offset: 0x000102CC
		public JourneyRefType Target
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

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060007AB RID: 1963 RVA: 0x000120D8 File Offset: 0x000102D8
		// (set) Token: 0x060007AC RID: 1964 RVA: 0x000120E0 File Offset: 0x000102E0
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

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060007AD RID: 1965 RVA: 0x000120EC File Offset: 0x000102EC
		// (set) Token: 0x060007AE RID: 1966 RVA: 0x000120F4 File Offset: 0x000102F4
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

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060007AF RID: 1967 RVA: 0x00012100 File Offset: 0x00010300
		// (set) Token: 0x060007B0 RID: 1968 RVA: 0x00012108 File Offset: 0x00010308
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

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060007B1 RID: 1969 RVA: 0x00012114 File Offset: 0x00010314
		// (set) Token: 0x060007B2 RID: 1970 RVA: 0x0001211C File Offset: 0x0001031C
		public JourneyPointSettingsType Settings
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

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060007B3 RID: 1971 RVA: 0x00012128 File Offset: 0x00010328
		// (set) Token: 0x060007B4 RID: 1972 RVA: 0x00012130 File Offset: 0x00010330
		[XmlAttribute]
		public TypeOfJourneyPointType Type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060007B5 RID: 1973 RVA: 0x0001213C File Offset: 0x0001033C
		// (set) Token: 0x060007B6 RID: 1974 RVA: 0x00012144 File Offset: 0x00010344
		[XmlAttribute]
		public ReachedByType ReachedBy
		{
			get
			{
				return this.reachedByField;
			}
			set
			{
				this.reachedByField = value;
			}
		}

		// Token: 0x0400041F RID: 1055
		private JourneyRefType targetField;

		// Token: 0x04000420 RID: 1056
		private LocalizableTextType textField;

		// Token: 0x04000421 RID: 1057
		private string externalIdField;

		// Token: 0x04000422 RID: 1058
		private string shortIdField;

		// Token: 0x04000423 RID: 1059
		private JourneyPointSettingsType settingsField;

		// Token: 0x04000424 RID: 1060
		private TypeOfJourneyPointType typeField;

		// Token: 0x04000425 RID: 1061
		private ReachedByType reachedByField;
	}
}
