using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001A9 RID: 425
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class PinType
	{
		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x060012B6 RID: 4790 RVA: 0x0001B138 File Offset: 0x00019338
		// (set) Token: 0x060012B7 RID: 4791 RVA: 0x0001B140 File Offset: 0x00019340
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

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x060012B8 RID: 4792 RVA: 0x0001B14C File Offset: 0x0001934C
		// (set) Token: 0x060012B9 RID: 4793 RVA: 0x0001B154 File Offset: 0x00019354
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

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x0001B160 File Offset: 0x00019360
		// (set) Token: 0x060012BB RID: 4795 RVA: 0x0001B168 File Offset: 0x00019368
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

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x060012BC RID: 4796 RVA: 0x0001B174 File Offset: 0x00019374
		// (set) Token: 0x060012BD RID: 4797 RVA: 0x0001B17C File Offset: 0x0001937C
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

		// Token: 0x04000A3F RID: 2623
		private string expressionField;

		// Token: 0x04000A40 RID: 2624
		private string idField;

		// Token: 0x04000A41 RID: 2625
		private int indexField;

		// Token: 0x04000A42 RID: 2626
		private SemanticType semanticField;
	}
}
