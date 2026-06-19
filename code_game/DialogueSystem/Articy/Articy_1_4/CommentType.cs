using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008C RID: 140
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class CommentType
	{
		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0000FD98 File Offset: 0x0000DF98
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0000FDA0 File Offset: 0x0000DFA0
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

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0000FDAC File Offset: 0x0000DFAC
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000FDB4 File Offset: 0x0000DFB4
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

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0000FDC0 File Offset: 0x0000DFC0
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x0000FDC8 File Offset: 0x0000DFC8
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

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x0000FDD4 File Offset: 0x0000DFD4
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x0000FDDC File Offset: 0x0000DFDC
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

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x0000FDE8 File Offset: 0x0000DFE8
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
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

		// Token: 0x040002CF RID: 719
		private LocalizableTextType textField;

		// Token: 0x040002D0 RID: 720
		private string colorField;

		// Token: 0x040002D1 RID: 721
		private DateTime createdOnField;

		// Token: 0x040002D2 RID: 722
		private string createdByField;

		// Token: 0x040002D3 RID: 723
		private string guidField;
	}
}
