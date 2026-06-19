using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000D9 RID: 217
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class CircleType
	{
		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001271C File Offset: 0x0001091C
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x00012724 File Offset: 0x00010924
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

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x00012730 File Offset: 0x00010930
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x00012738 File Offset: 0x00010938
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

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x00012744 File Offset: 0x00010944
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x0001274C File Offset: 0x0001094C
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

		// Token: 0x0400048D RID: 1165
		private float centerXField;

		// Token: 0x0400048E RID: 1166
		private float centerYField;

		// Token: 0x0400048F RID: 1167
		private float radiusField;
	}
}
