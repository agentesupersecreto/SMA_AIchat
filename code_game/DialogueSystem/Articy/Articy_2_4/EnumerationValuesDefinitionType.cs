using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000135 RID: 309
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class EnumerationValuesDefinitionType
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000D28 RID: 3368 RVA: 0x000168A4 File Offset: 0x00014AA4
		// (set) Token: 0x06000D29 RID: 3369 RVA: 0x000168AC File Offset: 0x00014AAC
		[XmlElement("EnumValue")]
		public EnumValueType[] EnumValue
		{
			get
			{
				return this.enumValueField;
			}
			set
			{
				this.enumValueField = value;
			}
		}

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000D2A RID: 3370 RVA: 0x000168B8 File Offset: 0x00014AB8
		// (set) Token: 0x06000D2B RID: 3371 RVA: 0x000168C0 File Offset: 0x00014AC0
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

		// Token: 0x04000713 RID: 1811
		private EnumValueType[] enumValueField;

		// Token: 0x04000714 RID: 1812
		private int countField;
	}
}
