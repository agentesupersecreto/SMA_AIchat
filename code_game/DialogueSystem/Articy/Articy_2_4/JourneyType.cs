using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200013D RID: 317
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyType
	{
		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x00016DF8 File Offset: 0x00014FF8
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x00016E00 File Offset: 0x00015000
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

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00016E0C File Offset: 0x0001500C
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00016E14 File Offset: 0x00015014
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

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x00016E20 File Offset: 0x00015020
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00016E28 File Offset: 0x00015028
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

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x00016E34 File Offset: 0x00015034
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x00016E3C File Offset: 0x0001503C
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

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x00016E48 File Offset: 0x00015048
		// (set) Token: 0x06000DBB RID: 3515 RVA: 0x00016E50 File Offset: 0x00015050
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

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x00016E5C File Offset: 0x0001505C
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x00016E64 File Offset: 0x00015064
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

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x00016E70 File Offset: 0x00015070
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x00016E78 File Offset: 0x00015078
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

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00016E84 File Offset: 0x00015084
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x00016E8C File Offset: 0x0001508C
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

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x00016E98 File Offset: 0x00015098
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x00016EA0 File Offset: 0x000150A0
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

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00016EAC File Offset: 0x000150AC
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x00016EB4 File Offset: 0x000150B4
		public VariableValuesListType InitialVariableValues
		{
			get
			{
				return this.initialVariableValuesField;
			}
			set
			{
				this.initialVariableValuesField = value;
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00016EC0 File Offset: 0x000150C0
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x00016EC8 File Offset: 0x000150C8
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

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00016ED4 File Offset: 0x000150D4
		// (set) Token: 0x06000DC9 RID: 3529 RVA: 0x00016EDC File Offset: 0x000150DC
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

		// Token: 0x04000754 RID: 1876
		private LocalizableTextType displayNameField;

		// Token: 0x04000755 RID: 1877
		private LocalizableTextType textField;

		// Token: 0x04000756 RID: 1878
		private string colorField;

		// Token: 0x04000757 RID: 1879
		private string technicalNameField;

		// Token: 0x04000758 RID: 1880
		private string externalIdField;

		// Token: 0x04000759 RID: 1881
		private string shortIdField;

		// Token: 0x0400075A RID: 1882
		private string urlField;

		// Token: 0x0400075B RID: 1883
		private ReferencesType referencesField;

		// Token: 0x0400075C RID: 1884
		private JourneySettingsType settingsField;

		// Token: 0x0400075D RID: 1885
		private VariableValuesListType initialVariableValuesField;

		// Token: 0x0400075E RID: 1886
		private JourneyPointsType journeyPointsField;

		// Token: 0x0400075F RID: 1887
		private string idField;
	}
}
