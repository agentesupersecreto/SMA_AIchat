using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200019B RID: 411
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NumberPropertyType
	{
		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x06001229 RID: 4649 RVA: 0x0001ABD0 File Offset: 0x00018DD0
		// (set) Token: 0x0600122A RID: 4650 RVA: 0x0001ABD8 File Offset: 0x00018DD8
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x0600122B RID: 4651 RVA: 0x0001ABE4 File Offset: 0x00018DE4
		// (set) Token: 0x0600122C RID: 4652 RVA: 0x0001ABEC File Offset: 0x00018DEC
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x040009FB RID: 2555
		private string nameField;

		// Token: 0x040009FC RID: 2556
		private string valueField;
	}
}
