using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200009F RID: 159
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PropertyDefinitionsType
	{
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x06000659 RID: 1625 RVA: 0x000107EC File Offset: 0x0000E9EC
		// (set) Token: 0x0600065A RID: 1626 RVA: 0x000107F4 File Offset: 0x0000E9F4
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

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x00010800 File Offset: 0x0000EA00
		// (set) Token: 0x0600065C RID: 1628 RVA: 0x00010808 File Offset: 0x0000EA08
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

		// Token: 0x04000352 RID: 850
		private PropertyDefinitionRefType[] propertyDefinitionRefField;

		// Token: 0x04000353 RID: 851
		private int countField;
	}
}
