using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200012D RID: 301
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class SizeType
	{
		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06000C72 RID: 3186 RVA: 0x00016198 File Offset: 0x00014398
		// (set) Token: 0x06000C73 RID: 3187 RVA: 0x000161A0 File Offset: 0x000143A0
		[XmlAttribute]
		public float Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06000C74 RID: 3188 RVA: 0x000161AC File Offset: 0x000143AC
		// (set) Token: 0x06000C75 RID: 3189 RVA: 0x000161B4 File Offset: 0x000143B4
		[XmlAttribute]
		public float Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		// Token: 0x040006BC RID: 1724
		private float widthField;

		// Token: 0x040006BD RID: 1725
		private float heightField;
	}
}
