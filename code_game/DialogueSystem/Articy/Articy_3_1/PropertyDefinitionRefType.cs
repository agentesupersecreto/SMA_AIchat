using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001B8 RID: 440
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class PropertyDefinitionRefType
	{
		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x0600139A RID: 5018 RVA: 0x0001BA04 File Offset: 0x00019C04
		// (set) Token: 0x0600139B RID: 5019 RVA: 0x0001BA0C File Offset: 0x00019C0C
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x0600139C RID: 5020 RVA: 0x0001BA18 File Offset: 0x00019C18
		// (set) Token: 0x0600139D RID: 5021 RVA: 0x0001BA20 File Offset: 0x00019C20
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

		// Token: 0x04000AAD RID: 2733
		private string idRefField;

		// Token: 0x04000AAE RID: 2734
		private string valueField;
	}
}
