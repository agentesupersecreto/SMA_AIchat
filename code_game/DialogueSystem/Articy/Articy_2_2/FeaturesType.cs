using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B5 RID: 181
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class FeaturesType
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x0600072D RID: 1837 RVA: 0x00011C10 File Offset: 0x0000FE10
		// (set) Token: 0x0600072E RID: 1838 RVA: 0x00011C18 File Offset: 0x0000FE18
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

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x0600072F RID: 1839 RVA: 0x00011C24 File Offset: 0x0000FE24
		// (set) Token: 0x06000730 RID: 1840 RVA: 0x00011C2C File Offset: 0x0000FE2C
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

		// Token: 0x040003D7 RID: 983
		private FeatureType[] featureField;

		// Token: 0x040003D8 RID: 984
		private int countField;
	}
}
