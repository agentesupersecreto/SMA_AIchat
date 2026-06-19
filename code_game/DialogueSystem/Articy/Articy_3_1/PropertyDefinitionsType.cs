using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B7 RID: 439
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PropertyDefinitionsType
	{
		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06001395 RID: 5013 RVA: 0x0001B9D4 File Offset: 0x00019BD4
		// (set) Token: 0x06001396 RID: 5014 RVA: 0x0001B9DC File Offset: 0x00019BDC
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

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06001397 RID: 5015 RVA: 0x0001B9E8 File Offset: 0x00019BE8
		// (set) Token: 0x06001398 RID: 5016 RVA: 0x0001B9F0 File Offset: 0x00019BF0
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

		// Token: 0x04000AAB RID: 2731
		private PropertyDefinitionRefType[] propertyDefinitionRefField;

		// Token: 0x04000AAC RID: 2732
		private int countField;
	}
}
