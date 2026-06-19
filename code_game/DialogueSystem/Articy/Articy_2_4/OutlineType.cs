using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200015C RID: 348
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class OutlineType
	{
		// Token: 0x06000F15 RID: 3861 RVA: 0x00017BBC File Offset: 0x00015DBC
		public OutlineType()
		{
			this.sizeField = 1;
			this.styleField = StrokeStyleType.Solid;
		}

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x06000F16 RID: 3862 RVA: 0x00017BD4 File Offset: 0x00015DD4
		// (set) Token: 0x06000F17 RID: 3863 RVA: 0x00017BDC File Offset: 0x00015DDC
		[XmlAttribute]
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x1700060E RID: 1550
		// (get) Token: 0x06000F18 RID: 3864 RVA: 0x00017BE8 File Offset: 0x00015DE8
		// (set) Token: 0x06000F19 RID: 3865 RVA: 0x00017BF0 File Offset: 0x00015DF0
		[DefaultValue(1)]
		[XmlAttribute]
		public int Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06000F1A RID: 3866 RVA: 0x00017BFC File Offset: 0x00015DFC
		// (set) Token: 0x06000F1B RID: 3867 RVA: 0x00017C04 File Offset: 0x00015E04
		[DefaultValue(StrokeStyleType.Solid)]
		[XmlAttribute]
		public StrokeStyleType Style
		{
			get
			{
				return this.styleField;
			}
			set
			{
				this.styleField = value;
			}
		}

		// Token: 0x0400083C RID: 2108
		private string colorField;

		// Token: 0x0400083D RID: 2109
		private int sizeField;

		// Token: 0x0400083E RID: 2110
		private StrokeStyleType styleField;
	}
}
