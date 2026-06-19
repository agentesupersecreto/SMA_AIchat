using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F3 RID: 243
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumerationValuesDefinitionType
	{
		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060009F6 RID: 2550 RVA: 0x00013788 File Offset: 0x00011988
		// (set) Token: 0x060009F7 RID: 2551 RVA: 0x00013790 File Offset: 0x00011990
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

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060009F8 RID: 2552 RVA: 0x0001379C File Offset: 0x0001199C
		// (set) Token: 0x060009F9 RID: 2553 RVA: 0x000137A4 File Offset: 0x000119A4
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

		// Token: 0x04000561 RID: 1377
		private EnumValueType[] enumValueField;

		// Token: 0x04000562 RID: 1378
		private int countField;
	}
}
