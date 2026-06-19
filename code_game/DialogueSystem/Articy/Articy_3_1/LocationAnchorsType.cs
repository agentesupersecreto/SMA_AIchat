using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E0 RID: 480
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocationAnchorsType
	{
		// Token: 0x170008FD RID: 2301
		// (get) Token: 0x06001585 RID: 5509 RVA: 0x0001CD18 File Offset: 0x0001AF18
		// (set) Token: 0x06001586 RID: 5510 RVA: 0x0001CD20 File Offset: 0x0001AF20
		[XmlElement("Anchor")]
		public LocationAnchorType[] Anchor
		{
			get
			{
				return this.anchorField;
			}
			set
			{
				this.anchorField = value;
			}
		}

		// Token: 0x170008FE RID: 2302
		// (get) Token: 0x06001587 RID: 5511 RVA: 0x0001CD2C File Offset: 0x0001AF2C
		// (set) Token: 0x06001588 RID: 5512 RVA: 0x0001CD34 File Offset: 0x0001AF34
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

		// Token: 0x170008FF RID: 2303
		// (get) Token: 0x06001589 RID: 5513 RVA: 0x0001CD40 File Offset: 0x0001AF40
		// (set) Token: 0x0600158A RID: 5514 RVA: 0x0001CD48 File Offset: 0x0001AF48
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

		// Token: 0x04000BDE RID: 3038
		private LocationAnchorType[] anchorField;

		// Token: 0x04000BDF RID: 3039
		private int countField;

		// Token: 0x04000BE0 RID: 3040
		private bool countFieldSpecified;
	}
}
