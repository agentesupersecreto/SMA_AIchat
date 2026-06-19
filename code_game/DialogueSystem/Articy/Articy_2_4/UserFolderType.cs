using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000125 RID: 293
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class UserFolderType
	{
		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x00015D64 File Offset: 0x00013F64
		// (set) Token: 0x06000C06 RID: 3078 RVA: 0x00015D6C File Offset: 0x00013F6C
		public LocalizableTextType DisplayName
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

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000C07 RID: 3079 RVA: 0x00015D78 File Offset: 0x00013F78
		// (set) Token: 0x06000C08 RID: 3080 RVA: 0x00015D80 File Offset: 0x00013F80
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

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000C09 RID: 3081 RVA: 0x00015D8C File Offset: 0x00013F8C
		// (set) Token: 0x06000C0A RID: 3082 RVA: 0x00015D94 File Offset: 0x00013F94
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

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x00015DA0 File Offset: 0x00013FA0
		// (set) Token: 0x06000C0C RID: 3084 RVA: 0x00015DA8 File Offset: 0x00013FA8
		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x00015DB4 File Offset: 0x00013FB4
		// (set) Token: 0x06000C0E RID: 3086 RVA: 0x00015DBC File Offset: 0x00013FBC
		public string ExternalId
		{
			get
			{
				return this.externalIdField;
			}
			set
			{
				this.externalIdField = value;
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000C0F RID: 3087 RVA: 0x00015DC8 File Offset: 0x00013FC8
		// (set) Token: 0x06000C10 RID: 3088 RVA: 0x00015DD0 File Offset: 0x00013FD0
		public string ShortId
		{
			get
			{
				return this.shortIdField;
			}
			set
			{
				this.shortIdField = value;
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000C11 RID: 3089 RVA: 0x00015DDC File Offset: 0x00013FDC
		// (set) Token: 0x06000C12 RID: 3090 RVA: 0x00015DE4 File Offset: 0x00013FE4
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

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x00015DF0 File Offset: 0x00013FF0
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x00015DF8 File Offset: 0x00013FF8
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

		// Token: 0x04000686 RID: 1670
		private LocalizableTextType displayNameField;

		// Token: 0x04000687 RID: 1671
		private LocalizableTextType textField;

		// Token: 0x04000688 RID: 1672
		private string colorField;

		// Token: 0x04000689 RID: 1673
		private string technicalNameField;

		// Token: 0x0400068A RID: 1674
		private string externalIdField;

		// Token: 0x0400068B RID: 1675
		private string shortIdField;

		// Token: 0x0400068C RID: 1676
		private string urlField;

		// Token: 0x0400068D RID: 1677
		private string idField;
	}
}
