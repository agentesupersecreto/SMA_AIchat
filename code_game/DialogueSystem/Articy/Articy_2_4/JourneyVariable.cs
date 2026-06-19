using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000145 RID: 325
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyVariable
	{
		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06000DE1 RID: 3553 RVA: 0x00016FC8 File Offset: 0x000151C8
		// (set) Token: 0x06000DE2 RID: 3554 RVA: 0x00016FD0 File Offset: 0x000151D0
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

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x00016FDC File Offset: 0x000151DC
		// (set) Token: 0x06000DE4 RID: 3556 RVA: 0x00016FE4 File Offset: 0x000151E4
		[XmlAttribute]
		public VariableDataTypeType DataType
		{
			get
			{
				return this.dataTypeField;
			}
			set
			{
				this.dataTypeField = value;
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00016FF0 File Offset: 0x000151F0
		// (set) Token: 0x06000DE6 RID: 3558 RVA: 0x00016FF8 File Offset: 0x000151F8
		[XmlAttribute]
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

		// Token: 0x0400077C RID: 1916
		private string nameField;

		// Token: 0x0400077D RID: 1917
		private VariableDataTypeType dataTypeField;

		// Token: 0x0400077E RID: 1918
		private string valueField;
	}
}
