using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000195 RID: 405
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class PropertiesType
	{
		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x0600120B RID: 4619 RVA: 0x0001AAB0 File Offset: 0x00018CB0
		// (set) Token: 0x0600120C RID: 4620 RVA: 0x0001AAB8 File Offset: 0x00018CB8
		[XmlElement("References", typeof(ReferenceStripPropertyType))]
		[XmlElement("String", typeof(StringPropertyType))]
		[XmlElement("Enum", typeof(EnumPropertyType))]
		[XmlElement("LocalizableText", typeof(LocalizableTextPropertyType))]
		[XmlElement("Number", typeof(NumberPropertyType))]
		[XmlElement("Boolean", typeof(BooleanPropertyType))]
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

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x0600120D RID: 4621 RVA: 0x0001AAC4 File Offset: 0x00018CC4
		// (set) Token: 0x0600120E RID: 4622 RVA: 0x0001AACC File Offset: 0x00018CCC
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

		// Token: 0x040009EF RID: 2543
		private object[] itemsField;

		// Token: 0x040009F0 RID: 2544
		private int countField;
	}
}
