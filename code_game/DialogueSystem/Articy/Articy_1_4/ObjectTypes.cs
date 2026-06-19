using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000094 RID: 148
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectTypes
	{
		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x00010184 File Offset: 0x0000E384
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0001018C File Offset: 0x0000E38C
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

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x00010198 File Offset: 0x0000E398
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x000101A0 File Offset: 0x0000E3A0
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

		// Token: 0x040002FE RID: 766
		private ObjectType[] itemsField;

		// Token: 0x040002FF RID: 767
		private int countField;
	}
}
