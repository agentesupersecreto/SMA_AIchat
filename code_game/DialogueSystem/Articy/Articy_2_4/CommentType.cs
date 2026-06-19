using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000127 RID: 295
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class CommentType
	{
		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000C31 RID: 3121 RVA: 0x00015F18 File Offset: 0x00014118
		// (set) Token: 0x06000C32 RID: 3122 RVA: 0x00015F20 File Offset: 0x00014120
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

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000C33 RID: 3123 RVA: 0x00015F2C File Offset: 0x0001412C
		// (set) Token: 0x06000C34 RID: 3124 RVA: 0x00015F34 File Offset: 0x00014134
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

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000C35 RID: 3125 RVA: 0x00015F40 File Offset: 0x00014140
		// (set) Token: 0x06000C36 RID: 3126 RVA: 0x00015F48 File Offset: 0x00014148
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

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000C37 RID: 3127 RVA: 0x00015F54 File Offset: 0x00014154
		// (set) Token: 0x06000C38 RID: 3128 RVA: 0x00015F5C File Offset: 0x0001415C
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

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000C39 RID: 3129 RVA: 0x00015F68 File Offset: 0x00014168
		// (set) Token: 0x06000C3A RID: 3130 RVA: 0x00015F70 File Offset: 0x00014170
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

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000C3B RID: 3131 RVA: 0x00015F7C File Offset: 0x0001417C
		// (set) Token: 0x06000C3C RID: 3132 RVA: 0x00015F84 File Offset: 0x00014184
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

		// Token: 0x0400069B RID: 1691
		private LocalizableTextType textField;

		// Token: 0x0400069C RID: 1692
		private string colorField;

		// Token: 0x0400069D RID: 1693
		private string urlField;

		// Token: 0x0400069E RID: 1694
		private DateTime createdOnField;

		// Token: 0x0400069F RID: 1695
		private string createdByField;

		// Token: 0x040006A0 RID: 1696
		private string idField;
	}
}
