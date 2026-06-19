using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001DB RID: 475
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class OutlineType
	{
		// Token: 0x06001567 RID: 5479 RVA: 0x0001CBE4 File Offset: 0x0001ADE4
		public OutlineType()
		{
			this.sizeField = 1;
			this.styleField = StrokeStyleType.Solid;
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06001568 RID: 5480 RVA: 0x0001CBFC File Offset: 0x0001ADFC
		// (set) Token: 0x06001569 RID: 5481 RVA: 0x0001CC04 File Offset: 0x0001AE04
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

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x0600156A RID: 5482 RVA: 0x0001CC10 File Offset: 0x0001AE10
		// (set) Token: 0x0600156B RID: 5483 RVA: 0x0001CC18 File Offset: 0x0001AE18
		[XmlAttribute]
		[DefaultValue(1)]
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

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x0600156C RID: 5484 RVA: 0x0001CC24 File Offset: 0x0001AE24
		// (set) Token: 0x0600156D RID: 5485 RVA: 0x0001CC2C File Offset: 0x0001AE2C
		[XmlAttribute]
		[DefaultValue(StrokeStyleType.Solid)]
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

		// Token: 0x04000BC8 RID: 3016
		private string colorField;

		// Token: 0x04000BC9 RID: 3017
		private int sizeField;

		// Token: 0x04000BCA RID: 3018
		private StrokeStyleType styleField;
	}
}
