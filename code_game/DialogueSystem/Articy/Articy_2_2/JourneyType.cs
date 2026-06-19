using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D2 RID: 210
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class JourneyType
	{
		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x060007CE RID: 1998 RVA: 0x00012230 File Offset: 0x00010430
		// (set) Token: 0x060007CF RID: 1999 RVA: 0x00012238 File Offset: 0x00010438
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

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x060007D0 RID: 2000 RVA: 0x00012244 File Offset: 0x00010444
		// (set) Token: 0x060007D1 RID: 2001 RVA: 0x0001224C File Offset: 0x0001044C
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

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x060007D2 RID: 2002 RVA: 0x00012258 File Offset: 0x00010458
		// (set) Token: 0x060007D3 RID: 2003 RVA: 0x00012260 File Offset: 0x00010460
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

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0001226C File Offset: 0x0001046C
		// (set) Token: 0x060007D5 RID: 2005 RVA: 0x00012274 File Offset: 0x00010474
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

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x00012280 File Offset: 0x00010480
		// (set) Token: 0x060007D7 RID: 2007 RVA: 0x00012288 File Offset: 0x00010488
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

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x060007D8 RID: 2008 RVA: 0x00012294 File Offset: 0x00010494
		// (set) Token: 0x060007D9 RID: 2009 RVA: 0x0001229C File Offset: 0x0001049C
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

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x060007DA RID: 2010 RVA: 0x000122A8 File Offset: 0x000104A8
		// (set) Token: 0x060007DB RID: 2011 RVA: 0x000122B0 File Offset: 0x000104B0
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

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x060007DC RID: 2012 RVA: 0x000122BC File Offset: 0x000104BC
		// (set) Token: 0x060007DD RID: 2013 RVA: 0x000122C4 File Offset: 0x000104C4
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

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x000122D0 File Offset: 0x000104D0
		// (set) Token: 0x060007DF RID: 2015 RVA: 0x000122D8 File Offset: 0x000104D8
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

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x000122E4 File Offset: 0x000104E4
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x000122EC File Offset: 0x000104EC
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

		// Token: 0x0400044A RID: 1098
		private LocalizableTextType displayNameField;

		// Token: 0x0400044B RID: 1099
		private LocalizableTextType textField;

		// Token: 0x0400044C RID: 1100
		private string colorField;

		// Token: 0x0400044D RID: 1101
		private string technicalNameField;

		// Token: 0x0400044E RID: 1102
		private string externalIdField;

		// Token: 0x0400044F RID: 1103
		private string shortIdField;

		// Token: 0x04000450 RID: 1104
		private ReferencesType referencesField;

		// Token: 0x04000451 RID: 1105
		private JourneySettingsType settingsField;

		// Token: 0x04000452 RID: 1106
		private JourneyPointsType journeyPointsField;

		// Token: 0x04000453 RID: 1107
		private string idField;
	}
}
