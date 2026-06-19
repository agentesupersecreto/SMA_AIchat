using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B7 RID: 183
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PropertiesType
	{
		// Token: 0x17000274 RID: 628
		// (get) Token: 0x06000739 RID: 1849 RVA: 0x00011C84 File Offset: 0x0000FE84
		// (set) Token: 0x0600073A RID: 1850 RVA: 0x00011C8C File Offset: 0x0000FE8C
		[XmlElement("References", typeof(ReferenceStripPropertyType))]
		[XmlElement("Number", typeof(NumberPropertyType))]
		[XmlElement("NamedReference", typeof(ReferenceSlotPropertyType))]
		[XmlElement("Boolean", typeof(BooleanPropertyType))]
		[XmlElement("Enum", typeof(EnumPropertyType))]
		[XmlElement("LocalizableText", typeof(LocalizableTextPropertyType))]
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

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x0600073B RID: 1851 RVA: 0x00011C98 File Offset: 0x0000FE98
		// (set) Token: 0x0600073C RID: 1852 RVA: 0x00011CA0 File Offset: 0x0000FEA0
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

		// Token: 0x040003DC RID: 988
		private object[] itemsField;

		// Token: 0x040003DD RID: 989
		private int countField;
	}
}
