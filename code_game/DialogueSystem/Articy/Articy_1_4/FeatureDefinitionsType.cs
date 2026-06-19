using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008E RID: 142
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureDefinitionsType
	{
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x0000FE34 File Offset: 0x0000E034
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x0000FE3C File Offset: 0x0000E03C
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

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x0000FE48 File Offset: 0x0000E048
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x0000FE50 File Offset: 0x0000E050
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

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x0000FE5C File Offset: 0x0000E05C
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x0000FE64 File Offset: 0x0000E064
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

		// Token: 0x040002D6 RID: 726
		private FeatureDefinitionRefType[] featureDefinitionRefField;

		// Token: 0x040002D7 RID: 727
		private int countField;

		// Token: 0x040002D8 RID: 728
		private bool countFieldSpecified;
	}
}
