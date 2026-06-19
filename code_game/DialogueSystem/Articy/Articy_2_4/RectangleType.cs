using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000122 RID: 290
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class RectangleType
	{
		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00015CC8 File Offset: 0x00013EC8
		// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x00015CD0 File Offset: 0x00013ED0
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

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x00015CDC File Offset: 0x00013EDC
		// (set) Token: 0x06000BF8 RID: 3064 RVA: 0x00015CE4 File Offset: 0x00013EE4
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

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x00015CF0 File Offset: 0x00013EF0
		// (set) Token: 0x06000BFA RID: 3066 RVA: 0x00015CF8 File Offset: 0x00013EF8
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

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x00015D04 File Offset: 0x00013F04
		// (set) Token: 0x06000BFC RID: 3068 RVA: 0x00015D0C File Offset: 0x00013F0C
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

		// Token: 0x0400067B RID: 1659
		private float minXField;

		// Token: 0x0400067C RID: 1660
		private float minYField;

		// Token: 0x0400067D RID: 1661
		private float maxXField;

		// Token: 0x0400067E RID: 1662
		private float maxYField;
	}
}
