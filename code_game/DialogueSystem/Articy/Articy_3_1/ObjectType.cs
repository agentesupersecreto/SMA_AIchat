using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F3 RID: 499
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectType
	{
		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x060016B3 RID: 5811 RVA: 0x0001D8CC File Offset: 0x0001BACC
		// (set) Token: 0x060016B4 RID: 5812 RVA: 0x0001D8D4 File Offset: 0x0001BAD4
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

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x060016B5 RID: 5813 RVA: 0x0001D8E0 File Offset: 0x0001BAE0
		// (set) Token: 0x060016B6 RID: 5814 RVA: 0x0001D8E8 File Offset: 0x0001BAE8
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

		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x060016B7 RID: 5815 RVA: 0x0001D8F4 File Offset: 0x0001BAF4
		// (set) Token: 0x060016B8 RID: 5816 RVA: 0x0001D8FC File Offset: 0x0001BAFC
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

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x060016B9 RID: 5817 RVA: 0x0001D908 File Offset: 0x0001BB08
		// (set) Token: 0x060016BA RID: 5818 RVA: 0x0001D910 File Offset: 0x0001BB10
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

		// Token: 0x17000990 RID: 2448
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x0001D91C File Offset: 0x0001BB1C
		// (set) Token: 0x060016BC RID: 5820 RVA: 0x0001D924 File Offset: 0x0001BB24
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

		// Token: 0x04000C7D RID: 3197
		private object[] itemsField;

		// Token: 0x04000C7E RID: 3198
		private int countField;

		// Token: 0x04000C7F RID: 3199
		private string typeField;

		// Token: 0x04000C80 RID: 3200
		private int allowUnsetTemplateField;

		// Token: 0x04000C81 RID: 3201
		private int allowAllTemplatesField;
	}
}
