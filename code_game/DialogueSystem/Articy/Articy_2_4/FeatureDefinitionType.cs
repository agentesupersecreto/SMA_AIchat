using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000137 RID: 311
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureDefinitionType
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x00016918 File Offset: 0x00014B18
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x00016920 File Offset: 0x00014B20
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

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0001692C File Offset: 0x00014B2C
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x00016934 File Offset: 0x00014B34
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

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x00016940 File Offset: 0x00014B40
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x00016948 File Offset: 0x00014B48
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

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x00016954 File Offset: 0x00014B54
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x0001695C File Offset: 0x00014B5C
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

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x00016968 File Offset: 0x00014B68
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x00016970 File Offset: 0x00014B70
		public PropertyDefinitionsType PropertyDefinitions
		{
			get
			{
				return this.propertyDefinitionsField;
			}
			set
			{
				this.propertyDefinitionsField = value;
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000D3E RID: 3390 RVA: 0x0001697C File Offset: 0x00014B7C
		// (set) Token: 0x06000D3F RID: 3391 RVA: 0x00016984 File Offset: 0x00014B84
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

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000D40 RID: 3392 RVA: 0x00016990 File Offset: 0x00014B90
		// (set) Token: 0x06000D41 RID: 3393 RVA: 0x00016998 File Offset: 0x00014B98
		[XmlAttribute]
		public string BasedOn
		{
			get
			{
				return this.basedOnField;
			}
			set
			{
				this.basedOnField = value;
			}
		}

		// Token: 0x04000718 RID: 1816
		private LocalizableTextType displayNameField;

		// Token: 0x04000719 RID: 1817
		private string colorField;

		// Token: 0x0400071A RID: 1818
		private string technicalNameField;

		// Token: 0x0400071B RID: 1819
		private string urlField;

		// Token: 0x0400071C RID: 1820
		private PropertyDefinitionsType propertyDefinitionsField;

		// Token: 0x0400071D RID: 1821
		private string idField;

		// Token: 0x0400071E RID: 1822
		private string basedOnField;
	}
}
