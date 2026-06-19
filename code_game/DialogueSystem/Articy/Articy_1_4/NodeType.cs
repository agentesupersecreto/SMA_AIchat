using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000057 RID: 87
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class NodeType
	{
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000E840 File Offset: 0x0000CA40
		// (set) Token: 0x06000323 RID: 803 RVA: 0x0000E848 File Offset: 0x0000CA48
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

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000324 RID: 804 RVA: 0x0000E854 File Offset: 0x0000CA54
		// (set) Token: 0x06000325 RID: 805 RVA: 0x0000E85C File Offset: 0x0000CA5C
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

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000326 RID: 806 RVA: 0x0000E868 File Offset: 0x0000CA68
		// (set) Token: 0x06000327 RID: 807 RVA: 0x0000E870 File Offset: 0x0000CA70
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

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000E87C File Offset: 0x0000CA7C
		// (set) Token: 0x06000329 RID: 809 RVA: 0x0000E884 File Offset: 0x0000CA84
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

		// Token: 0x0400019D RID: 413
		private NodeType[] nodeField;

		// Token: 0x0400019E RID: 414
		private string[] textField;

		// Token: 0x0400019F RID: 415
		private string guidField;

		// Token: 0x040001A0 RID: 416
		private string typeField;
	}
}
