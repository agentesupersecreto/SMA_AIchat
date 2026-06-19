using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B4 RID: 436
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class EnumerationValuesDefinitionType
	{
		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x0600137A RID: 4986 RVA: 0x0001B8CC File Offset: 0x00019ACC
		// (set) Token: 0x0600137B RID: 4987 RVA: 0x0001B8D4 File Offset: 0x00019AD4
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

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x0600137C RID: 4988 RVA: 0x0001B8E0 File Offset: 0x00019AE0
		// (set) Token: 0x0600137D RID: 4989 RVA: 0x0001B8E8 File Offset: 0x00019AE8
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

		// Token: 0x04000A9F RID: 2719
		private EnumValueType[] enumValueField;

		// Token: 0x04000AA0 RID: 2720
		private int countField;
	}
}
