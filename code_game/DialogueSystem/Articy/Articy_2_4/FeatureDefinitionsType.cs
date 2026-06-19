using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000168 RID: 360
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class FeatureDefinitionsType
	{
		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x00018220 File Offset: 0x00016420
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x00018228 File Offset: 0x00016428
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

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00018234 File Offset: 0x00016434
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x0001823C File Offset: 0x0001643C
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

		// Token: 0x1700065C RID: 1628
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x00018248 File Offset: 0x00016448
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x00018250 File Offset: 0x00016450
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

		// Token: 0x0400089A RID: 2202
		private FeatureDefinitionRefType[] featureDefinitionRefField;

		// Token: 0x0400089B RID: 2203
		private int countField;

		// Token: 0x0400089C RID: 2204
		private bool countFieldSpecified;
	}
}
