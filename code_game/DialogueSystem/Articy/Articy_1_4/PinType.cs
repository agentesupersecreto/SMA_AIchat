using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000084 RID: 132
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PinType
	{
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x0000F84C File Offset: 0x0000DA4C
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x0000F854 File Offset: 0x0000DA54
		public string Expression
		{
			get
			{
				return this.expressionField;
			}
			set
			{
				this.expressionField = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x0000F860 File Offset: 0x0000DA60
		// (set) Token: 0x060004C7 RID: 1223 RVA: 0x0000F868 File Offset: 0x0000DA68
		[XmlAttribute]
		public string Guid
		{
			get
			{
				return this.guidField;
			}
			set
			{
				this.guidField = value;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0000F874 File Offset: 0x0000DA74
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x0000F87C File Offset: 0x0000DA7C
		[XmlAttribute]
		public int Index
		{
			get
			{
				return this.indexField;
			}
			set
			{
				this.indexField = value;
			}
		}

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000F888 File Offset: 0x0000DA88
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x0000F890 File Offset: 0x0000DA90
		[XmlAttribute]
		public SemanticType Semantic
		{
			get
			{
				return this.semanticField;
			}
			set
			{
				this.semanticField = value;
			}
		}

		// Token: 0x0400028B RID: 651
		private string expressionField;

		// Token: 0x0400028C RID: 652
		private string guidField;

		// Token: 0x0400028D RID: 653
		private int indexField;

		// Token: 0x0400028E RID: 654
		private SemanticType semanticField;
	}
}
