using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000ED RID: 237
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class FeatureDefinitionRefType
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x00013530 File Offset: 0x00011730
		// (set) Token: 0x060009BA RID: 2490 RVA: 0x00013538 File Offset: 0x00011738
		[XmlAttribute]
		public string IdRef
		{
			get
			{
				return this.idRefField;
			}
			set
			{
				this.idRefField = value;
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x00013544 File Offset: 0x00011744
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x0001354C File Offset: 0x0001174C
		[XmlText]
		public string Value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}

		// Token: 0x04000541 RID: 1345
		private string idRefField;

		// Token: 0x04000542 RID: 1346
		private string valueField;
	}
}
