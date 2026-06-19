using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x02000102 RID: 258
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PropertyDefinitionsType
	{
		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x000141A8 File Offset: 0x000123A8
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x000141B0 File Offset: 0x000123B0
		[XmlElement("PropertyDefinitionRef")]
		public PropertyDefinitionRefType[] PropertyDefinitionRef
		{
			get
			{
				return this.propertyDefinitionRefField;
			}
			set
			{
				this.propertyDefinitionRefField = value;
			}
		}

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x000141BC File Offset: 0x000123BC
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x000141C4 File Offset: 0x000123C4
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x040005E3 RID: 1507
		private PropertyDefinitionRefType[] propertyDefinitionRefField;

		// Token: 0x040005E4 RID: 1508
		private int countField;
	}
}
