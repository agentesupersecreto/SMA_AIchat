using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000193 RID: 403
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class FeaturesType
	{
		// Token: 0x17000758 RID: 1880
		// (get) Token: 0x060011FF RID: 4607 RVA: 0x0001AA3C File Offset: 0x00018C3C
		// (set) Token: 0x06001200 RID: 4608 RVA: 0x0001AA44 File Offset: 0x00018C44
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

		// Token: 0x17000759 RID: 1881
		// (get) Token: 0x06001201 RID: 4609 RVA: 0x0001AA50 File Offset: 0x00018C50
		// (set) Token: 0x06001202 RID: 4610 RVA: 0x0001AA58 File Offset: 0x00018C58
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

		// Token: 0x040009EA RID: 2538
		private FeatureType[] featureField;

		// Token: 0x040009EB RID: 2539
		private int countField;
	}
}
