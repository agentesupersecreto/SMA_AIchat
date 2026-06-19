using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000091 RID: 145
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class EnumerationValuesDefinitionType
	{
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06000578 RID: 1400 RVA: 0x0000FF3C File Offset: 0x0000E13C
		// (set) Token: 0x06000579 RID: 1401 RVA: 0x0000FF44 File Offset: 0x0000E144
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

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x0600057A RID: 1402 RVA: 0x0000FF50 File Offset: 0x0000E150
		// (set) Token: 0x0600057B RID: 1403 RVA: 0x0000FF58 File Offset: 0x0000E158
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

		// Token: 0x040002E2 RID: 738
		private EnumValueType[] enumValueField;

		// Token: 0x040002E3 RID: 739
		private int countField;
	}
}
