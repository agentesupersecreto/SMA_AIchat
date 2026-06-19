using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E7 RID: 487
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class FeatureDefinitionsType
	{
		// Token: 0x1700093D RID: 2365
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x0001D248 File Offset: 0x0001B448
		// (set) Token: 0x0600160B RID: 5643 RVA: 0x0001D250 File Offset: 0x0001B450
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

		// Token: 0x1700093E RID: 2366
		// (get) Token: 0x0600160C RID: 5644 RVA: 0x0001D25C File Offset: 0x0001B45C
		// (set) Token: 0x0600160D RID: 5645 RVA: 0x0001D264 File Offset: 0x0001B464
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

		// Token: 0x1700093F RID: 2367
		// (get) Token: 0x0600160E RID: 5646 RVA: 0x0001D270 File Offset: 0x0001B470
		// (set) Token: 0x0600160F RID: 5647 RVA: 0x0001D278 File Offset: 0x0001B478
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

		// Token: 0x04000C26 RID: 3110
		private FeatureDefinitionRefType[] featureDefinitionRefField;

		// Token: 0x04000C27 RID: 3111
		private int countField;

		// Token: 0x04000C28 RID: 3112
		private bool countFieldSpecified;
	}
}
