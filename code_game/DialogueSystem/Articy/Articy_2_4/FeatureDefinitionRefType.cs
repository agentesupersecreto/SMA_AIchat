using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000169 RID: 361
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class FeatureDefinitionRefType
	{
		// Token: 0x1700065D RID: 1629
		// (get) Token: 0x06000FBF RID: 4031 RVA: 0x00018264 File Offset: 0x00016464
		// (set) Token: 0x06000FC0 RID: 4032 RVA: 0x0001826C File Offset: 0x0001646C
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

		// Token: 0x1700065E RID: 1630
		// (get) Token: 0x06000FC1 RID: 4033 RVA: 0x00018278 File Offset: 0x00016478
		// (set) Token: 0x06000FC2 RID: 4034 RVA: 0x00018280 File Offset: 0x00016480
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

		// Token: 0x0400089D RID: 2205
		private string idRefField;

		// Token: 0x0400089E RID: 2206
		private string valueField;
	}
}
