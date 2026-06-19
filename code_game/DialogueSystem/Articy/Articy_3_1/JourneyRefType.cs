using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001C8 RID: 456
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class JourneyRefType
	{
		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06001452 RID: 5202 RVA: 0x0001C120 File Offset: 0x0001A320
		// (set) Token: 0x06001453 RID: 5203 RVA: 0x0001C128 File Offset: 0x0001A328
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

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x0001C134 File Offset: 0x0001A334
		// (set) Token: 0x06001455 RID: 5205 RVA: 0x0001C13C File Offset: 0x0001A33C
		[XmlAttribute]
		public string PinRef
		{
			get
			{
				return this.pinRefField;
			}
			set
			{
				this.pinRefField = value;
			}
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x0001C148 File Offset: 0x0001A348
		// (set) Token: 0x06001457 RID: 5207 RVA: 0x0001C150 File Offset: 0x0001A350
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

		// Token: 0x04000B1A RID: 2842
		private string idRefField;

		// Token: 0x04000B1B RID: 2843
		private string pinRefField;

		// Token: 0x04000B1C RID: 2844
		private string valueField;
	}
}
