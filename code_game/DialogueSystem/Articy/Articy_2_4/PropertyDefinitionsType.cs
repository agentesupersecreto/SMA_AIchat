using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000138 RID: 312
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class PropertyDefinitionsType
	{
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000D43 RID: 3395 RVA: 0x000169AC File Offset: 0x00014BAC
		// (set) Token: 0x06000D44 RID: 3396 RVA: 0x000169B4 File Offset: 0x00014BB4
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

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x000169C0 File Offset: 0x00014BC0
		// (set) Token: 0x06000D46 RID: 3398 RVA: 0x000169C8 File Offset: 0x00014BC8
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

		// Token: 0x0400071F RID: 1823
		private PropertyDefinitionRefType[] propertyDefinitionRefField;

		// Token: 0x04000720 RID: 1824
		private int countField;
	}
}
