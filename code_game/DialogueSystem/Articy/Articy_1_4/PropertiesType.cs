using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006C RID: 108
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PropertiesType
	{
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x0000EDC4 File Offset: 0x0000CFC4
		// (set) Token: 0x060003B3 RID: 947 RVA: 0x0000EDCC File Offset: 0x0000CFCC
		[XmlElement("Number", typeof(NumberPropertyType))]
		[XmlElement("Boolean", typeof(BooleanPropertyType))]
		[XmlElement("LocalizableText", typeof(LocalizableTextPropertyType))]
		[XmlElement("NamedReference", typeof(ReferenceSlotPropertyType))]
		[XmlElement("References", typeof(ReferenceStripPropertyType))]
		[XmlElement("Enum", typeof(EnumPropertyType))]
		[XmlElement("String", typeof(StringPropertyType))]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x0000EDD8 File Offset: 0x0000CFD8
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
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

		// Token: 0x04000205 RID: 517
		private object[] itemsField;

		// Token: 0x04000206 RID: 518
		private int countField;
	}
}
