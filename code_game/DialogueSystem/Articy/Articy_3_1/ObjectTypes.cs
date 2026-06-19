using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001F2 RID: 498
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class ObjectTypes
	{
		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x0001D89C File Offset: 0x0001BA9C
		// (set) Token: 0x060016AF RID: 5807 RVA: 0x0001D8A4 File Offset: 0x0001BAA4
		[XmlElement("ObjectType")]
		public ObjectType[] Items
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

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0001D8B0 File Offset: 0x0001BAB0
		// (set) Token: 0x060016B1 RID: 5809 RVA: 0x0001D8B8 File Offset: 0x0001BAB8
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

		// Token: 0x04000C7B RID: 3195
		private ObjectType[] itemsField;

		// Token: 0x04000C7C RID: 3196
		private int countField;
	}
}
