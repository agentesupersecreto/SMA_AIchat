using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x0200018D RID: 397
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class NodeType
	{
		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x060011C3 RID: 4547 RVA: 0x0001A7E8 File Offset: 0x000189E8
		// (set) Token: 0x060011C4 RID: 4548 RVA: 0x0001A7F0 File Offset: 0x000189F0
		[XmlElement("Node")]
		public NodeType[] Node
		{
			get
			{
				return this.nodeField;
			}
			set
			{
				this.nodeField = value;
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x060011C5 RID: 4549 RVA: 0x0001A7FC File Offset: 0x000189FC
		// (set) Token: 0x060011C6 RID: 4550 RVA: 0x0001A804 File Offset: 0x00018A04
		[XmlText]
		public string[] Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x060011C7 RID: 4551 RVA: 0x0001A810 File Offset: 0x00018A10
		// (set) Token: 0x060011C8 RID: 4552 RVA: 0x0001A818 File Offset: 0x00018A18
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

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x060011C9 RID: 4553 RVA: 0x0001A824 File Offset: 0x00018A24
		// (set) Token: 0x060011CA RID: 4554 RVA: 0x0001A82C File Offset: 0x00018A2C
		[XmlAttribute]
		public string Type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}

		// Token: 0x040009CF RID: 2511
		private NodeType[] nodeField;

		// Token: 0x040009D0 RID: 2512
		private string[] textField;

		// Token: 0x040009D1 RID: 2513
		private string idRefField;

		// Token: 0x040009D2 RID: 2514
		private string typeField;
	}
}
