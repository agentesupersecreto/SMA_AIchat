using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000103 RID: 259
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class FeatureDefinitionType
	{
		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06000B01 RID: 2817 RVA: 0x000141D8 File Offset: 0x000123D8
		// (set) Token: 0x06000B02 RID: 2818 RVA: 0x000141E0 File Offset: 0x000123E0
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

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x000141EC File Offset: 0x000123EC
		// (set) Token: 0x06000B04 RID: 2820 RVA: 0x000141F4 File Offset: 0x000123F4
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

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06000B05 RID: 2821 RVA: 0x00014200 File Offset: 0x00012400
		// (set) Token: 0x06000B06 RID: 2822 RVA: 0x00014208 File Offset: 0x00012408
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

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06000B07 RID: 2823 RVA: 0x00014214 File Offset: 0x00012414
		// (set) Token: 0x06000B08 RID: 2824 RVA: 0x0001421C File Offset: 0x0001241C
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

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06000B09 RID: 2825 RVA: 0x00014228 File Offset: 0x00012428
		// (set) Token: 0x06000B0A RID: 2826 RVA: 0x00014230 File Offset: 0x00012430
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

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000B0B RID: 2827 RVA: 0x0001423C File Offset: 0x0001243C
		// (set) Token: 0x06000B0C RID: 2828 RVA: 0x00014244 File Offset: 0x00012444
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

		// Token: 0x040005E5 RID: 1509
		private LocalizableTextType displayNameField;

		// Token: 0x040005E6 RID: 1510
		private string colorField;

		// Token: 0x040005E7 RID: 1511
		private string technicalNameField;

		// Token: 0x040005E8 RID: 1512
		private PropertyDefinitionsType propertyDefinitionsField;

		// Token: 0x040005E9 RID: 1513
		private string idField;

		// Token: 0x040005EA RID: 1514
		private string basedOnField;
	}
}
