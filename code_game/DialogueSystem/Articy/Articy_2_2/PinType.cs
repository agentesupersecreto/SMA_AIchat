using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000E2 RID: 226
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class PinType
	{
		// Token: 0x17000341 RID: 833
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00012D88 File Offset: 0x00010F88
		// (set) Token: 0x060008F4 RID: 2292 RVA: 0x00012D90 File Offset: 0x00010F90
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

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x060008F5 RID: 2293 RVA: 0x00012D9C File Offset: 0x00010F9C
		// (set) Token: 0x060008F6 RID: 2294 RVA: 0x00012DA4 File Offset: 0x00010FA4
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

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x060008F7 RID: 2295 RVA: 0x00012DB0 File Offset: 0x00010FB0
		// (set) Token: 0x060008F8 RID: 2296 RVA: 0x00012DB8 File Offset: 0x00010FB8
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

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x060008F9 RID: 2297 RVA: 0x00012DC4 File Offset: 0x00010FC4
		// (set) Token: 0x060008FA RID: 2298 RVA: 0x00012DCC File Offset: 0x00010FCC
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

		// Token: 0x040004E0 RID: 1248
		private string expressionField;

		// Token: 0x040004E1 RID: 1249
		private string idField;

		// Token: 0x040004E2 RID: 1250
		private int indexField;

		// Token: 0x040004E3 RID: 1251
		private SemanticType semanticField;
	}
}
