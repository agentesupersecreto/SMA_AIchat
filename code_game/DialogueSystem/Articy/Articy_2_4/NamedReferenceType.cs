using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200011B RID: 283
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlInclude(typeof(ReferenceSlotPropertyType))]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NamedReferenceType
	{
		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06000BD0 RID: 3024 RVA: 0x00015B64 File Offset: 0x00013D64
		// (set) Token: 0x06000BD1 RID: 3025 RVA: 0x00015B6C File Offset: 0x00013D6C
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000BD2 RID: 3026 RVA: 0x00015B78 File Offset: 0x00013D78
		// (set) Token: 0x06000BD3 RID: 3027 RVA: 0x00015B80 File Offset: 0x00013D80
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000BD4 RID: 3028 RVA: 0x00015B8C File Offset: 0x00013D8C
		// (set) Token: 0x06000BD5 RID: 3029 RVA: 0x00015B94 File Offset: 0x00013D94
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x0400066C RID: 1644
		private string nameField;

		// Token: 0x0400066D RID: 1645
		private string idRefField;

		// Token: 0x0400066E RID: 1646
		private string valueField;
	}
}
