using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000C3 RID: 195
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class RectangleType
	{
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000775 RID: 1909 RVA: 0x00011EC4 File Offset: 0x000100C4
		// (set) Token: 0x06000776 RID: 1910 RVA: 0x00011ECC File Offset: 0x000100CC
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

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000777 RID: 1911 RVA: 0x00011ED8 File Offset: 0x000100D8
		// (set) Token: 0x06000778 RID: 1912 RVA: 0x00011EE0 File Offset: 0x000100E0
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

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000779 RID: 1913 RVA: 0x00011EEC File Offset: 0x000100EC
		// (set) Token: 0x0600077A RID: 1914 RVA: 0x00011EF4 File Offset: 0x000100F4
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

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x0600077B RID: 1915 RVA: 0x00011F00 File Offset: 0x00010100
		// (set) Token: 0x0600077C RID: 1916 RVA: 0x00011F08 File Offset: 0x00010108
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

		// Token: 0x040003F4 RID: 1012
		private float minXField;

		// Token: 0x040003F5 RID: 1013
		private float minYField;

		// Token: 0x040003F6 RID: 1014
		private float maxXField;

		// Token: 0x040003F7 RID: 1015
		private float maxYField;
	}
}
