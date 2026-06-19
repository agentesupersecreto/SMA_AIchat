using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000116 RID: 278
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PropertiesType
	{
		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x06000BB9 RID: 3001 RVA: 0x00015A88 File Offset: 0x00013C88
		// (set) Token: 0x06000BBA RID: 3002 RVA: 0x00015A90 File Offset: 0x00013C90
		[XmlElement("Boolean", typeof(BooleanPropertyType))]
		[XmlElement("Enum", typeof(EnumPropertyType))]
		[XmlElement("LocalizableText", typeof(LocalizableTextPropertyType))]
		[XmlElement("Number", typeof(NumberPropertyType))]
		[XmlElement("References", typeof(ReferenceStripPropertyType))]
		[XmlElement("String", typeof(StringPropertyType))]
		[XmlElement("NamedReference", typeof(ReferenceSlotPropertyType))]
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

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x06000BBB RID: 3003 RVA: 0x00015A9C File Offset: 0x00013C9C
		// (set) Token: 0x06000BBC RID: 3004 RVA: 0x00015AA4 File Offset: 0x00013CA4
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

		// Token: 0x04000663 RID: 1635
		private object[] itemsField;

		// Token: 0x04000664 RID: 1636
		private int countField;
	}
}
