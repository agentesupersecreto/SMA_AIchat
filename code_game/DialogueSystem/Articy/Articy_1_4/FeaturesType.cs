using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006A RID: 106
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeaturesType
	{
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0000ED50 File Offset: 0x0000CF50
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x0000ED58 File Offset: 0x0000CF58
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

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0000ED64 File Offset: 0x0000CF64
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x0000ED6C File Offset: 0x0000CF6C
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

		// Token: 0x04000200 RID: 512
		private FeatureType[] featureField;

		// Token: 0x04000201 RID: 513
		private int countField;
	}
}
