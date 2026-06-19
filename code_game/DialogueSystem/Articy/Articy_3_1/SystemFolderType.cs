using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A3 RID: 419
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class SystemFolderType
	{
		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06001250 RID: 4688 RVA: 0x0001AD48 File Offset: 0x00018F48
		// (set) Token: 0x06001251 RID: 4689 RVA: 0x0001AD50 File Offset: 0x00018F50
		public string DisplayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06001252 RID: 4690 RVA: 0x0001AD5C File Offset: 0x00018F5C
		// (set) Token: 0x06001253 RID: 4691 RVA: 0x0001AD64 File Offset: 0x00018F64
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06001254 RID: 4692 RVA: 0x0001AD70 File Offset: 0x00018F70
		// (set) Token: 0x06001255 RID: 4693 RVA: 0x0001AD78 File Offset: 0x00018F78
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x04000A0F RID: 2575
		private string displayNameField;

		// Token: 0x04000A10 RID: 2576
		private string colorField;

		// Token: 0x04000A11 RID: 2577
		private string idField;
	}
}
