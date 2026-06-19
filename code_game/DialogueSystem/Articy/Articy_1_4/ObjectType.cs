using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000095 RID: 149
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectType
	{
		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x000101B4 File Offset: 0x0000E3B4
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x000101BC File Offset: 0x0000E3BC
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

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x000101C8 File Offset: 0x0000E3C8
		// (set) Token: 0x060005BB RID: 1467 RVA: 0x000101D0 File Offset: 0x0000E3D0
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

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x000101DC File Offset: 0x0000E3DC
		// (set) Token: 0x060005BD RID: 1469 RVA: 0x000101E4 File Offset: 0x0000E3E4
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

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060005BE RID: 1470 RVA: 0x000101F0 File Offset: 0x0000E3F0
		// (set) Token: 0x060005BF RID: 1471 RVA: 0x000101F8 File Offset: 0x0000E3F8
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

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x060005C0 RID: 1472 RVA: 0x00010204 File Offset: 0x0000E404
		// (set) Token: 0x060005C1 RID: 1473 RVA: 0x0001020C File Offset: 0x0000E40C
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

		// Token: 0x04000300 RID: 768
		private object[] itemsField;

		// Token: 0x04000301 RID: 769
		private int countField;

		// Token: 0x04000302 RID: 770
		private string typeField;

		// Token: 0x04000303 RID: 771
		private int allowUnsetTemplateField;

		// Token: 0x04000304 RID: 772
		private int allowAllTemplatesField;
	}
}
