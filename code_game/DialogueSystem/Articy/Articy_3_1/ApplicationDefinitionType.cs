using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001EF RID: 495
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[Serializable]
	public class ApplicationDefinitionType
	{
		// Token: 0x1700096E RID: 2414
		// (get) Token: 0x06001673 RID: 5747 RVA: 0x0001D654 File Offset: 0x0001B854
		// (set) Token: 0x06001674 RID: 5748 RVA: 0x0001D65C File Offset: 0x0001B85C
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

		// Token: 0x1700096F RID: 2415
		// (get) Token: 0x06001675 RID: 5749 RVA: 0x0001D668 File Offset: 0x0001B868
		// (set) Token: 0x06001676 RID: 5750 RVA: 0x0001D670 File Offset: 0x0001B870
		public string Command
		{
			get
			{
				return this.commandField;
			}
			set
			{
				this.commandField = value;
			}
		}

		// Token: 0x17000970 RID: 2416
		// (get) Token: 0x06001677 RID: 5751 RVA: 0x0001D67C File Offset: 0x0001B87C
		// (set) Token: 0x06001678 RID: 5752 RVA: 0x0001D684 File Offset: 0x0001B884
		public string WorkingDirectory
		{
			get
			{
				return this.workingDirectoryField;
			}
			set
			{
				this.workingDirectoryField = value;
			}
		}

		// Token: 0x04000C5F RID: 3167
		private string nameField;

		// Token: 0x04000C60 RID: 3168
		private string commandField;

		// Token: 0x04000C61 RID: 3169
		private string workingDirectoryField;
	}
}
