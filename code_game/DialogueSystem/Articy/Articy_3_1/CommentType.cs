using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A6 RID: 422
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[Serializable]
	public class CommentType
	{
		// Token: 0x17000791 RID: 1937
		// (get) Token: 0x06001283 RID: 4739 RVA: 0x0001AF40 File Offset: 0x00019140
		// (set) Token: 0x06001284 RID: 4740 RVA: 0x0001AF48 File Offset: 0x00019148
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

		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x06001285 RID: 4741 RVA: 0x0001AF54 File Offset: 0x00019154
		// (set) Token: 0x06001286 RID: 4742 RVA: 0x0001AF5C File Offset: 0x0001915C
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

		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x06001287 RID: 4743 RVA: 0x0001AF68 File Offset: 0x00019168
		// (set) Token: 0x06001288 RID: 4744 RVA: 0x0001AF70 File Offset: 0x00019170
		public string Url
		{
			get
			{
				return this.urlField;
			}
			set
			{
				this.urlField = value;
			}
		}

		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x06001289 RID: 4745 RVA: 0x0001AF7C File Offset: 0x0001917C
		// (set) Token: 0x0600128A RID: 4746 RVA: 0x0001AF84 File Offset: 0x00019184
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

		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x0600128B RID: 4747 RVA: 0x0001AF90 File Offset: 0x00019190
		// (set) Token: 0x0600128C RID: 4748 RVA: 0x0001AF98 File Offset: 0x00019198
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

		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x0600128D RID: 4749 RVA: 0x0001AFA4 File Offset: 0x000191A4
		// (set) Token: 0x0600128E RID: 4750 RVA: 0x0001AFAC File Offset: 0x000191AC
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

		// Token: 0x04000A27 RID: 2599
		private LocalizableTextType textField;

		// Token: 0x04000A28 RID: 2600
		private string colorField;

		// Token: 0x04000A29 RID: 2601
		private string urlField;

		// Token: 0x04000A2A RID: 2602
		private DateTime createdOnField;

		// Token: 0x04000A2B RID: 2603
		private string createdByField;

		// Token: 0x04000A2C RID: 2604
		private string idField;
	}
}
