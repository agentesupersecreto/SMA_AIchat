using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x020000A2 RID: 162
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class SystemFolderType
	{
		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000680 RID: 1664 RVA: 0x0001096C File Offset: 0x0000EB6C
		// (set) Token: 0x06000681 RID: 1665 RVA: 0x00010974 File Offset: 0x0000EB74
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

		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000682 RID: 1666 RVA: 0x00010980 File Offset: 0x0000EB80
		// (set) Token: 0x06000683 RID: 1667 RVA: 0x00010988 File Offset: 0x0000EB88
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

		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00010994 File Offset: 0x0000EB94
		// (set) Token: 0x06000685 RID: 1669 RVA: 0x0001099C File Offset: 0x0000EB9C
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x04000364 RID: 868
		private string displayNameField;

		// Token: 0x04000365 RID: 869
		private string colorField;

		// Token: 0x04000366 RID: 870
		private string guidField;
	}
}
