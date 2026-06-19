using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200010E RID: 270
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class NodeType
	{
		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000B71 RID: 2929 RVA: 0x000157C0 File Offset: 0x000139C0
		// (set) Token: 0x06000B72 RID: 2930 RVA: 0x000157C8 File Offset: 0x000139C8
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

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x000157D4 File Offset: 0x000139D4
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x000157DC File Offset: 0x000139DC
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

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x000157E8 File Offset: 0x000139E8
		// (set) Token: 0x06000B76 RID: 2934 RVA: 0x000157F0 File Offset: 0x000139F0
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

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x000157FC File Offset: 0x000139FC
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x00015804 File Offset: 0x00013A04
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

		// Token: 0x04000643 RID: 1603
		private NodeType[] nodeField;

		// Token: 0x04000644 RID: 1604
		private string[] textField;

		// Token: 0x04000645 RID: 1605
		private string idRefField;

		// Token: 0x04000646 RID: 1606
		private string typeField;
	}
}
