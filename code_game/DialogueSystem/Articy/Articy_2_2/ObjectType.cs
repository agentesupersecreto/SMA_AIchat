using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F8 RID: 248
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class ObjectType
	{
		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00013B20 File Offset: 0x00011D20
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00013B28 File Offset: 0x00011D28
		[XmlElement("AllowedCategory", typeof(AllowedCategory))]
		[XmlElement("AllowedTemplate", typeof(AllowedTemplate))]
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

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00013B34 File Offset: 0x00011D34
		// (set) Token: 0x06000A56 RID: 2646 RVA: 0x00013B3C File Offset: 0x00011D3C
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

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00013B48 File Offset: 0x00011D48
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x00013B50 File Offset: 0x00011D50
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

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00013B5C File Offset: 0x00011D5C
		// (set) Token: 0x06000A5A RID: 2650 RVA: 0x00013B64 File Offset: 0x00011D64
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

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x00013B70 File Offset: 0x00011D70
		// (set) Token: 0x06000A5C RID: 2652 RVA: 0x00013B78 File Offset: 0x00011D78
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

		// Token: 0x0400058D RID: 1421
		private object[] itemsField;

		// Token: 0x0400058E RID: 1422
		private int countField;

		// Token: 0x0400058F RID: 1423
		private string typeField;

		// Token: 0x04000590 RID: 1424
		private int allowUnsetTemplateField;

		// Token: 0x04000591 RID: 1425
		private int allowAllTemplatesField;
	}
}
