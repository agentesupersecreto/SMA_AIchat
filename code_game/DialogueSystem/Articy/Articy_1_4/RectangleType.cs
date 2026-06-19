using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000075 RID: 117
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class RectangleType
	{
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000EF88 File Offset: 0x0000D188
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0000EF90 File Offset: 0x0000D190
		[XmlAttribute]
		public float MinX
		{
			get
			{
				return this.minXField;
			}
			set
			{
				this.minXField = value;
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x060003E3 RID: 995 RVA: 0x0000EF9C File Offset: 0x0000D19C
		// (set) Token: 0x060003E4 RID: 996 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		[XmlAttribute]
		public float MinY
		{
			get
			{
				return this.minYField;
			}
			set
			{
				this.minYField = value;
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000EFB0 File Offset: 0x0000D1B0
		// (set) Token: 0x060003E6 RID: 998 RVA: 0x0000EFB8 File Offset: 0x0000D1B8
		[XmlAttribute]
		public float MaxX
		{
			get
			{
				return this.maxXField;
			}
			set
			{
				this.maxXField = value;
			}
		}

		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060003E7 RID: 999 RVA: 0x0000EFC4 File Offset: 0x0000D1C4
		// (set) Token: 0x060003E8 RID: 1000 RVA: 0x0000EFCC File Offset: 0x0000D1CC
		[XmlAttribute]
		public float MaxY
		{
			get
			{
				return this.maxYField;
			}
			set
			{
				this.maxYField = value;
			}
		}

		// Token: 0x04000218 RID: 536
		private float minXField;

		// Token: 0x04000219 RID: 537
		private float minYField;

		// Token: 0x0400021A RID: 538
		private float maxXField;

		// Token: 0x0400021B RID: 539
		private float maxYField;
	}
}
