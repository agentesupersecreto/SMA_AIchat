using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000EB RID: 235
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class ConnectionType
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00013444 File Offset: 0x00011644
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x0001344C File Offset: 0x0001164C
		public string Color
		{
			get
			{
				return this.colorField;
			}
			set
			{
				this.colorField = value;
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00013458 File Offset: 0x00011658
		// (set) Token: 0x060009A4 RID: 2468 RVA: 0x00013460 File Offset: 0x00011660
		[XmlElement(DataType = "token")]
		public string TechnicalName
		{
			get
			{
				return this.technicalNameField;
			}
			set
			{
				this.technicalNameField = value;
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x0001346C File Offset: 0x0001166C
		// (set) Token: 0x060009A6 RID: 2470 RVA: 0x00013474 File Offset: 0x00011674
		public LocalizableTextType Label
		{
			get
			{
				return this.labelField;
			}
			set
			{
				this.labelField = value;
			}
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x00013480 File Offset: 0x00011680
		// (set) Token: 0x060009A8 RID: 2472 RVA: 0x00013488 File Offset: 0x00011688
		public ConnectionRefType Source
		{
			get
			{
				return this.sourceField;
			}
			set
			{
				this.sourceField = value;
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x00013494 File Offset: 0x00011694
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x0001349C File Offset: 0x0001169C
		public ConnectionRefType Target
		{
			get
			{
				return this.targetField;
			}
			set
			{
				this.targetField = value;
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x000134A8 File Offset: 0x000116A8
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x000134B0 File Offset: 0x000116B0
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x04000536 RID: 1334
		private string colorField;

		// Token: 0x04000537 RID: 1335
		private string technicalNameField;

		// Token: 0x04000538 RID: 1336
		private LocalizableTextType labelField;

		// Token: 0x04000539 RID: 1337
		private ConnectionRefType sourceField;

		// Token: 0x0400053A RID: 1338
		private ConnectionRefType targetField;

		// Token: 0x0400053B RID: 1339
		private string idField;
	}
}
