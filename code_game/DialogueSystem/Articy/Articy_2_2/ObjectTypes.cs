using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000F7 RID: 247
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class ObjectTypes
	{
		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00013AF0 File Offset: 0x00011CF0
		// (set) Token: 0x06000A4F RID: 2639 RVA: 0x00013AF8 File Offset: 0x00011CF8
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

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00013B04 File Offset: 0x00011D04
		// (set) Token: 0x06000A51 RID: 2641 RVA: 0x00013B0C File Offset: 0x00011D0C
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

		// Token: 0x0400058B RID: 1419
		private ObjectType[] itemsField;

		// Token: 0x0400058C RID: 1420
		private int countField;
	}
}
