using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000174 RID: 372
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ObjectType
	{
		// Token: 0x170006A8 RID: 1704
		// (get) Token: 0x0600105F RID: 4191 RVA: 0x00018890 File Offset: 0x00016A90
		// (set) Token: 0x06001060 RID: 4192 RVA: 0x00018898 File Offset: 0x00016A98
		[XmlElement("AllowedTemplate", typeof(AllowedTemplate))]
		[XmlElement("AllowedCategory", typeof(AllowedCategory))]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		// Token: 0x170006A9 RID: 1705
		// (get) Token: 0x06001061 RID: 4193 RVA: 0x000188A4 File Offset: 0x00016AA4
		// (set) Token: 0x06001062 RID: 4194 RVA: 0x000188AC File Offset: 0x00016AAC
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x170006AA RID: 1706
		// (get) Token: 0x06001063 RID: 4195 RVA: 0x000188B8 File Offset: 0x00016AB8
		// (set) Token: 0x06001064 RID: 4196 RVA: 0x000188C0 File Offset: 0x00016AC0
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

		// Token: 0x170006AB RID: 1707
		// (get) Token: 0x06001065 RID: 4197 RVA: 0x000188CC File Offset: 0x00016ACC
		// (set) Token: 0x06001066 RID: 4198 RVA: 0x000188D4 File Offset: 0x00016AD4
		[XmlAttribute]
		public int AllowUnsetTemplate
		{
			get
			{
				return this.allowUnsetTemplateField;
			}
			set
			{
				this.allowUnsetTemplateField = value;
			}
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x06001067 RID: 4199 RVA: 0x000188E0 File Offset: 0x00016AE0
		// (set) Token: 0x06001068 RID: 4200 RVA: 0x000188E8 File Offset: 0x00016AE8
		[XmlAttribute]
		public int AllowAllTemplates
		{
			get
			{
				return this.allowAllTemplatesField;
			}
			set
			{
				this.allowAllTemplatesField = value;
			}
		}

		// Token: 0x040008F0 RID: 2288
		private object[] itemsField;

		// Token: 0x040008F1 RID: 2289
		private int countField;

		// Token: 0x040008F2 RID: 2290
		private string typeField;

		// Token: 0x040008F3 RID: 2291
		private int allowUnsetTemplateField;

		// Token: 0x040008F4 RID: 2292
		private int allowAllTemplatesField;
	}
}
