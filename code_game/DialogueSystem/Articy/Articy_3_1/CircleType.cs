using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000203 RID: 515
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class CircleType
	{
		// Token: 0x17000A0D RID: 2573
		// (get) Token: 0x060017C3 RID: 6083 RVA: 0x0001E350 File Offset: 0x0001C550
		// (set) Token: 0x060017C4 RID: 6084 RVA: 0x0001E358 File Offset: 0x0001C558
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

		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x060017C5 RID: 6085 RVA: 0x0001E364 File Offset: 0x0001C564
		// (set) Token: 0x060017C6 RID: 6086 RVA: 0x0001E36C File Offset: 0x0001C56C
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

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x0001E378 File Offset: 0x0001C578
		// (set) Token: 0x060017C8 RID: 6088 RVA: 0x0001E380 File Offset: 0x0001C580
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

		// Token: 0x04000D08 RID: 3336
		private float centerXField;

		// Token: 0x04000D09 RID: 3337
		private float centerYField;

		// Token: 0x04000D0A RID: 3338
		private float radiusField;
	}
}
