using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000060 RID: 96
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneyPointType
	{
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x06000349 RID: 841 RVA: 0x0000E9BC File Offset: 0x0000CBBC
		// (set) Token: 0x0600034A RID: 842 RVA: 0x0000E9C4 File Offset: 0x0000CBC4
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

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x0600034B RID: 843 RVA: 0x0000E9D0 File Offset: 0x0000CBD0
		// (set) Token: 0x0600034C RID: 844 RVA: 0x0000E9D8 File Offset: 0x0000CBD8
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

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x0600034D RID: 845 RVA: 0x0000E9E4 File Offset: 0x0000CBE4
		// (set) Token: 0x0600034E RID: 846 RVA: 0x0000E9EC File Offset: 0x0000CBEC
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

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600034F RID: 847 RVA: 0x0000E9F8 File Offset: 0x0000CBF8
		// (set) Token: 0x06000350 RID: 848 RVA: 0x0000EA00 File Offset: 0x0000CC00
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

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000EA0C File Offset: 0x0000CC0C
		// (set) Token: 0x06000352 RID: 850 RVA: 0x0000EA14 File Offset: 0x0000CC14
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

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000EA20 File Offset: 0x0000CC20
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0000EA28 File Offset: 0x0000CC28
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

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x06000355 RID: 853 RVA: 0x0000EA34 File Offset: 0x0000CC34
		// (set) Token: 0x06000356 RID: 854 RVA: 0x0000EA3C File Offset: 0x0000CC3C
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

		// Token: 0x040001BD RID: 445
		private JourneyRefType targetField;

		// Token: 0x040001BE RID: 446
		private LocalizableTextType textField;

		// Token: 0x040001BF RID: 447
		private string externalIdField;

		// Token: 0x040001C0 RID: 448
		private string shortIdField;

		// Token: 0x040001C1 RID: 449
		private JourneyPointSettingsType settingsField;

		// Token: 0x040001C2 RID: 450
		private TypeOfJourneyPointType typeField;

		// Token: 0x040001C3 RID: 451
		private ReachedByType reachedByField;
	}
}
