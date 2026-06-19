using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200008D RID: 141
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureDefinitionRefType
	{
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x0000FE04 File Offset: 0x0000E004
		// (set) Token: 0x06000559 RID: 1369 RVA: 0x0000FE0C File Offset: 0x0000E00C
		[XmlAttribute]
		public string GuidRef
		{
			get
			{
				return this.guidRefField;
			}
			set
			{
				this.guidRefField = value;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x0000FE18 File Offset: 0x0000E018
		// (set) Token: 0x0600055B RID: 1371 RVA: 0x0000FE20 File Offset: 0x0000E020
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

		// Token: 0x040002D4 RID: 724
		private string guidRefField;

		// Token: 0x040002D5 RID: 725
		private string valueField;
	}
}
