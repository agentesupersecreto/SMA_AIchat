using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001EC RID: 492
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ProjectSettingsType
	{
		// Token: 0x17000962 RID: 2402
		// (get) Token: 0x06001658 RID: 5720 RVA: 0x0001D54C File Offset: 0x0001B74C
		// (set) Token: 0x06001659 RID: 5721 RVA: 0x0001D554 File Offset: 0x0001B754
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

		// Token: 0x17000963 RID: 2403
		// (get) Token: 0x0600165A RID: 5722 RVA: 0x0001D560 File Offset: 0x0001B760
		// (set) Token: 0x0600165B RID: 5723 RVA: 0x0001D568 File Offset: 0x0001B768
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

		// Token: 0x17000964 RID: 2404
		// (get) Token: 0x0600165C RID: 5724 RVA: 0x0001D574 File Offset: 0x0001B774
		// (set) Token: 0x0600165D RID: 5725 RVA: 0x0001D57C File Offset: 0x0001B77C
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

		// Token: 0x17000965 RID: 2405
		// (get) Token: 0x0600165E RID: 5726 RVA: 0x0001D588 File Offset: 0x0001B788
		// (set) Token: 0x0600165F RID: 5727 RVA: 0x0001D590 File Offset: 0x0001B790
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

		// Token: 0x17000966 RID: 2406
		// (get) Token: 0x06001660 RID: 5728 RVA: 0x0001D59C File Offset: 0x0001B79C
		// (set) Token: 0x06001661 RID: 5729 RVA: 0x0001D5A4 File Offset: 0x0001B7A4
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

		// Token: 0x04000C53 RID: 3155
		private FlowSettingsType flowSettingsField;

		// Token: 0x04000C54 RID: 3156
		private JourneySettingsType journeySettingsField;

		// Token: 0x04000C55 RID: 3157
		private LocationSettingsType locationSettingsField;

		// Token: 0x04000C56 RID: 3158
		private ExternalApplicationsType externalApplicationsField;

		// Token: 0x04000C57 RID: 3159
		private string idField;
	}
}
