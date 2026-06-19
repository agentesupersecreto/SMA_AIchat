using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000167 RID: 359
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectTemplateDefinitionType
	{
		// Token: 0x17000652 RID: 1618
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x00018178 File Offset: 0x00016378
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x00018180 File Offset: 0x00016380
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

		// Token: 0x17000653 RID: 1619
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x0001818C File Offset: 0x0001638C
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x00018194 File Offset: 0x00016394
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

		// Token: 0x17000654 RID: 1620
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x000181A0 File Offset: 0x000163A0
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x000181A8 File Offset: 0x000163A8
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

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x000181B4 File Offset: 0x000163B4
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x000181BC File Offset: 0x000163BC
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

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x06000FAF RID: 4015 RVA: 0x000181C8 File Offset: 0x000163C8
		// (set) Token: 0x06000FB0 RID: 4016 RVA: 0x000181D0 File Offset: 0x000163D0
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

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x06000FB1 RID: 4017 RVA: 0x000181DC File Offset: 0x000163DC
		// (set) Token: 0x06000FB2 RID: 4018 RVA: 0x000181E4 File Offset: 0x000163E4
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

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x000181F0 File Offset: 0x000163F0
		// (set) Token: 0x06000FB4 RID: 4020 RVA: 0x000181F8 File Offset: 0x000163F8
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

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x00018204 File Offset: 0x00016404
		// (set) Token: 0x06000FB6 RID: 4022 RVA: 0x0001820C File Offset: 0x0001640C
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

		// Token: 0x04000892 RID: 2194
		private LocalizableTextType displayNameField;

		// Token: 0x04000893 RID: 2195
		private string colorField;

		// Token: 0x04000894 RID: 2196
		private string technicalNameField;

		// Token: 0x04000895 RID: 2197
		private string externalIdField;

		// Token: 0x04000896 RID: 2198
		private string shortIdField;

		// Token: 0x04000897 RID: 2199
		private string urlField;

		// Token: 0x04000898 RID: 2200
		private FeatureDefinitionsType featureDefinitionsField;

		// Token: 0x04000899 RID: 2201
		private string idField;
	}
}
