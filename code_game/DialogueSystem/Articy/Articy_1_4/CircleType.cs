using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200007C RID: 124
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class CircleType
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x0600043F RID: 1087 RVA: 0x0000F328 File Offset: 0x0000D528
		// (set) Token: 0x06000440 RID: 1088 RVA: 0x0000F330 File Offset: 0x0000D530
		[XmlAttribute]
		public float CenterX
		{
			get
			{
				return this.centerXField;
			}
			set
			{
				this.centerXField = value;
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06000441 RID: 1089 RVA: 0x0000F33C File Offset: 0x0000D53C
		// (set) Token: 0x06000442 RID: 1090 RVA: 0x0000F344 File Offset: 0x0000D544
		[XmlAttribute]
		public float CenterY
		{
			get
			{
				return this.centerYField;
			}
			set
			{
				this.centerYField = value;
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000F350 File Offset: 0x0000D550
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x0000F358 File Offset: 0x0000D558
		[XmlAttribute]
		public float Radius
		{
			get
			{
				return this.radiusField;
			}
			set
			{
				this.radiusField = value;
			}
		}

		// Token: 0x04000248 RID: 584
		private float centerXField;

		// Token: 0x04000249 RID: 585
		private float centerYField;

		// Token: 0x0400024A RID: 586
		private float radiusField;
	}
}
