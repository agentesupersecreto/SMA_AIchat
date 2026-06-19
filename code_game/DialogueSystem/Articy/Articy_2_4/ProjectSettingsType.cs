using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200016D RID: 365
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ProjectSettingsType
	{
		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06001004 RID: 4100 RVA: 0x00018510 File Offset: 0x00016710
		// (set) Token: 0x06001005 RID: 4101 RVA: 0x00018518 File Offset: 0x00016718
		public FlowSettingsType FlowSettings
		{
			get
			{
				return this.flowSettingsField;
			}
			set
			{
				this.flowSettingsField = value;
			}
		}

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x06001006 RID: 4102 RVA: 0x00018524 File Offset: 0x00016724
		// (set) Token: 0x06001007 RID: 4103 RVA: 0x0001852C File Offset: 0x0001672C
		public JourneySettingsType JourneySettings
		{
			get
			{
				return this.journeySettingsField;
			}
			set
			{
				this.journeySettingsField = value;
			}
		}

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06001008 RID: 4104 RVA: 0x00018538 File Offset: 0x00016738
		// (set) Token: 0x06001009 RID: 4105 RVA: 0x00018540 File Offset: 0x00016740
		public LocationSettingsType LocationSettings
		{
			get
			{
				return this.locationSettingsField;
			}
			set
			{
				this.locationSettingsField = value;
			}
		}

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x0600100A RID: 4106 RVA: 0x0001854C File Offset: 0x0001674C
		// (set) Token: 0x0600100B RID: 4107 RVA: 0x00018554 File Offset: 0x00016754
		public ExternalApplicationsType ExternalApplications
		{
			get
			{
				return this.externalApplicationsField;
			}
			set
			{
				this.externalApplicationsField = value;
			}
		}

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x0600100C RID: 4108 RVA: 0x00018560 File Offset: 0x00016760
		// (set) Token: 0x0600100D RID: 4109 RVA: 0x00018568 File Offset: 0x00016768
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

		// Token: 0x040008C6 RID: 2246
		private FlowSettingsType flowSettingsField;

		// Token: 0x040008C7 RID: 2247
		private JourneySettingsType journeySettingsField;

		// Token: 0x040008C8 RID: 2248
		private LocationSettingsType locationSettingsField;

		// Token: 0x040008C9 RID: 2249
		private ExternalApplicationsType externalApplicationsField;

		// Token: 0x040008CA RID: 2250
		private string idField;
	}
}
