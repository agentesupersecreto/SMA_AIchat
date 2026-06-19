using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200012A RID: 298
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class PinType
	{
		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x00016110 File Offset: 0x00014310
		// (set) Token: 0x06000C65 RID: 3173 RVA: 0x00016118 File Offset: 0x00014318
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

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x00016124 File Offset: 0x00014324
		// (set) Token: 0x06000C67 RID: 3175 RVA: 0x0001612C File Offset: 0x0001432C
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000C68 RID: 3176 RVA: 0x00016138 File Offset: 0x00014338
		// (set) Token: 0x06000C69 RID: 3177 RVA: 0x00016140 File Offset: 0x00014340
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

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000C6A RID: 3178 RVA: 0x0001614C File Offset: 0x0001434C
		// (set) Token: 0x06000C6B RID: 3179 RVA: 0x00016154 File Offset: 0x00014354
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

		// Token: 0x040006B3 RID: 1715
		private string expressionField;

		// Token: 0x040006B4 RID: 1716
		private string idField;

		// Token: 0x040006B5 RID: 1717
		private int indexField;

		// Token: 0x040006B6 RID: 1718
		private SemanticType semanticField;
	}
}
