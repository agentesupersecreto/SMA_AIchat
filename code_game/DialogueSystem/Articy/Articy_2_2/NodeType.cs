using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000AE RID: 174
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NodeType
	{
		// Token: 0x17000254 RID: 596
		// (get) Token: 0x060006F1 RID: 1777 RVA: 0x000119C4 File Offset: 0x0000FBC4
		// (set) Token: 0x060006F2 RID: 1778 RVA: 0x000119CC File Offset: 0x0000FBCC
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

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x000119D8 File Offset: 0x0000FBD8
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x000119E0 File Offset: 0x0000FBE0
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

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x060006F5 RID: 1781 RVA: 0x000119EC File Offset: 0x0000FBEC
		// (set) Token: 0x060006F6 RID: 1782 RVA: 0x000119F4 File Offset: 0x0000FBF4
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

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x060006F7 RID: 1783 RVA: 0x00011A00 File Offset: 0x0000FC00
		// (set) Token: 0x060006F8 RID: 1784 RVA: 0x00011A08 File Offset: 0x0000FC08
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

		// Token: 0x040003B9 RID: 953
		private NodeType[] nodeField;

		// Token: 0x040003BA RID: 954
		private string[] textField;

		// Token: 0x040003BB RID: 955
		private string idField;

		// Token: 0x040003BC RID: 956
		private string typeField;
	}
}
