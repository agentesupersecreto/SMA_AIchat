using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200012E RID: 302
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ConnectionType
	{
		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06000C77 RID: 3191 RVA: 0x000161C8 File Offset: 0x000143C8
		// (set) Token: 0x06000C78 RID: 3192 RVA: 0x000161D0 File Offset: 0x000143D0
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

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000C79 RID: 3193 RVA: 0x000161DC File Offset: 0x000143DC
		// (set) Token: 0x06000C7A RID: 3194 RVA: 0x000161E4 File Offset: 0x000143E4
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

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000C7B RID: 3195 RVA: 0x000161F0 File Offset: 0x000143F0
		// (set) Token: 0x06000C7C RID: 3196 RVA: 0x000161F8 File Offset: 0x000143F8
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

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000C7D RID: 3197 RVA: 0x00016204 File Offset: 0x00014404
		// (set) Token: 0x06000C7E RID: 3198 RVA: 0x0001620C File Offset: 0x0001440C
		public LocalizableTextType Label
		{
			get
			{
				return this.labelField;
			}
			set
			{
				this.labelField = value;
			}
		}

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00016218 File Offset: 0x00014418
		// (set) Token: 0x06000C80 RID: 3200 RVA: 0x00016220 File Offset: 0x00014420
		public ConnectionRefType Source
		{
			get
			{
				return this.sourceField;
			}
			set
			{
				this.sourceField = value;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06000C81 RID: 3201 RVA: 0x0001622C File Offset: 0x0001442C
		// (set) Token: 0x06000C82 RID: 3202 RVA: 0x00016234 File Offset: 0x00014434
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06000C83 RID: 3203 RVA: 0x00016240 File Offset: 0x00014440
		// (set) Token: 0x06000C84 RID: 3204 RVA: 0x00016248 File Offset: 0x00014448
		public bool ShowLabel
		{
			get
			{
				return this.showLabelField;
			}
			set
			{
				this.showLabelField = value;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06000C85 RID: 3205 RVA: 0x00016254 File Offset: 0x00014454
		// (set) Token: 0x06000C86 RID: 3206 RVA: 0x0001625C File Offset: 0x0001445C
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

		// Token: 0x040006BE RID: 1726
		private string colorField;

		// Token: 0x040006BF RID: 1727
		private string technicalNameField;

		// Token: 0x040006C0 RID: 1728
		private string urlField;

		// Token: 0x040006C1 RID: 1729
		private LocalizableTextType labelField;

		// Token: 0x040006C2 RID: 1730
		private ConnectionRefType sourceField;

		// Token: 0x040006C3 RID: 1731
		private ConnectionRefType targetField;

		// Token: 0x040006C4 RID: 1732
		private bool showLabelField;

		// Token: 0x040006C5 RID: 1733
		private string idField;
	}
}
