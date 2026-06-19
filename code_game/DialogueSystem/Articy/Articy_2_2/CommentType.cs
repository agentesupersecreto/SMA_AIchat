using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000EC RID: 236
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class CommentType
	{
		// Token: 0x1700039A RID: 922
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x000134C4 File Offset: 0x000116C4
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x000134CC File Offset: 0x000116CC
		public LocalizableTextType Text
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

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x000134D8 File Offset: 0x000116D8
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x000134E0 File Offset: 0x000116E0
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

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x000134EC File Offset: 0x000116EC
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x000134F4 File Offset: 0x000116F4
		public DateTime CreatedOn
		{
			get
			{
				return this.createdOnField;
			}
			set
			{
				this.createdOnField = value;
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x00013500 File Offset: 0x00011700
		// (set) Token: 0x060009B5 RID: 2485 RVA: 0x00013508 File Offset: 0x00011708
		public string CreatedBy
		{
			get
			{
				return this.createdByField;
			}
			set
			{
				this.createdByField = value;
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x00013514 File Offset: 0x00011714
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x0001351C File Offset: 0x0001171C
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

		// Token: 0x0400053C RID: 1340
		private LocalizableTextType textField;

		// Token: 0x0400053D RID: 1341
		private string colorField;

		// Token: 0x0400053E RID: 1342
		private DateTime createdOnField;

		// Token: 0x0400053F RID: 1343
		private string createdByField;

		// Token: 0x04000540 RID: 1344
		private string idField;
	}
}
