using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000173 RID: 371
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ObjectTypes
	{
		// Token: 0x170006A6 RID: 1702
		// (get) Token: 0x0600105A RID: 4186 RVA: 0x00018860 File Offset: 0x00016A60
		// (set) Token: 0x0600105B RID: 4187 RVA: 0x00018868 File Offset: 0x00016A68
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

		// Token: 0x170006A7 RID: 1703
		// (get) Token: 0x0600105C RID: 4188 RVA: 0x00018874 File Offset: 0x00016A74
		// (set) Token: 0x0600105D RID: 4189 RVA: 0x0001887C File Offset: 0x00016A7C
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

		// Token: 0x040008EE RID: 2286
		private ObjectType[] itemsField;

		// Token: 0x040008EF RID: 2287
		private int countField;
	}
}
