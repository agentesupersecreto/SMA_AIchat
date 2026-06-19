using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000EE RID: 238
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class FeatureDefinitionsType
	{
		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x00013560 File Offset: 0x00011760
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00013568 File Offset: 0x00011768
		[XmlElement("FeatureDefinitionRef")]
		public FeatureDefinitionRefType[] FeatureDefinitionRef
		{
			get
			{
				return this.featureDefinitionRefField;
			}
			set
			{
				this.featureDefinitionRefField = value;
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x00013574 File Offset: 0x00011774
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x0001357C File Offset: 0x0001177C
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x00013588 File Offset: 0x00011788
		// (set) Token: 0x060009C3 RID: 2499 RVA: 0x00013590 File Offset: 0x00011790
		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return this.countFieldSpecified;
			}
			set
			{
				this.countFieldSpecified = value;
			}
		}

		// Token: 0x04000543 RID: 1347
		private FeatureDefinitionRefType[] featureDefinitionRefField;

		// Token: 0x04000544 RID: 1348
		private int countField;

		// Token: 0x04000545 RID: 1349
		private bool countFieldSpecified;
	}
}
