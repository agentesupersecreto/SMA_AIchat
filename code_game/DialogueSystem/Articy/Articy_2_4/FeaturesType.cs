using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000114 RID: 276
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class FeaturesType
	{
		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06000BAD RID: 2989 RVA: 0x00015A14 File Offset: 0x00013C14
		// (set) Token: 0x06000BAE RID: 2990 RVA: 0x00015A1C File Offset: 0x00013C1C
		[XmlElement("Feature")]
		public FeatureType[] Feature
		{
			get
			{
				return this.featureField;
			}
			set
			{
				this.featureField = value;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06000BAF RID: 2991 RVA: 0x00015A28 File Offset: 0x00013C28
		// (set) Token: 0x06000BB0 RID: 2992 RVA: 0x00015A30 File Offset: 0x00013C30
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

		// Token: 0x0400065E RID: 1630
		private FeatureType[] featureField;

		// Token: 0x0400065F RID: 1631
		private int countField;
	}
}
