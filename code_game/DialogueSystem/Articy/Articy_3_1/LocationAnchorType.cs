using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001E1 RID: 481
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class LocationAnchorType
	{
		// Token: 0x17000900 RID: 2304
		// (get) Token: 0x0600158C RID: 5516 RVA: 0x0001CD5C File Offset: 0x0001AF5C
		// (set) Token: 0x0600158D RID: 5517 RVA: 0x0001CD64 File Offset: 0x0001AF64
		[XmlAttribute]
		public float X
		{
			get
			{
				return this.xField;
			}
			set
			{
				this.xField = value;
			}
		}

		// Token: 0x17000901 RID: 2305
		// (get) Token: 0x0600158E RID: 5518 RVA: 0x0001CD70 File Offset: 0x0001AF70
		// (set) Token: 0x0600158F RID: 5519 RVA: 0x0001CD78 File Offset: 0x0001AF78
		[XmlIgnore]
		public bool XSpecified
		{
			get
			{
				return this.xFieldSpecified;
			}
			set
			{
				this.xFieldSpecified = value;
			}
		}

		// Token: 0x17000902 RID: 2306
		// (get) Token: 0x06001590 RID: 5520 RVA: 0x0001CD84 File Offset: 0x0001AF84
		// (set) Token: 0x06001591 RID: 5521 RVA: 0x0001CD8C File Offset: 0x0001AF8C
		[XmlAttribute]
		public float Y
		{
			get
			{
				return this.yField;
			}
			set
			{
				this.yField = value;
			}
		}

		// Token: 0x17000903 RID: 2307
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x0001CD98 File Offset: 0x0001AF98
		// (set) Token: 0x06001593 RID: 5523 RVA: 0x0001CDA0 File Offset: 0x0001AFA0
		[XmlIgnore]
		public bool YSpecified
		{
			get
			{
				return this.yFieldSpecified;
			}
			set
			{
				this.yFieldSpecified = value;
			}
		}

		// Token: 0x17000904 RID: 2308
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x0001CDAC File Offset: 0x0001AFAC
		// (set) Token: 0x06001595 RID: 5525 RVA: 0x0001CDB4 File Offset: 0x0001AFB4
		[XmlAttribute]
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

		// Token: 0x17000905 RID: 2309
		// (get) Token: 0x06001596 RID: 5526 RVA: 0x0001CDC0 File Offset: 0x0001AFC0
		// (set) Token: 0x06001597 RID: 5527 RVA: 0x0001CDC8 File Offset: 0x0001AFC8
		[XmlAttribute]
		public AnchorSizeNamesType Size
		{
			get
			{
				return this.sizeField;
			}
			set
			{
				this.sizeField = value;
			}
		}

		// Token: 0x17000906 RID: 2310
		// (get) Token: 0x06001598 RID: 5528 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
		// (set) Token: 0x06001599 RID: 5529 RVA: 0x0001CDDC File Offset: 0x0001AFDC
		[XmlIgnore]
		public bool SizeSpecified
		{
			get
			{
				return this.sizeFieldSpecified;
			}
			set
			{
				this.sizeFieldSpecified = value;
			}
		}

		// Token: 0x04000BE1 RID: 3041
		private float xField;

		// Token: 0x04000BE2 RID: 3042
		private bool xFieldSpecified;

		// Token: 0x04000BE3 RID: 3043
		private float yField;

		// Token: 0x04000BE4 RID: 3044
		private bool yFieldSpecified;

		// Token: 0x04000BE5 RID: 3045
		private string colorField;

		// Token: 0x04000BE6 RID: 3046
		private AnchorSizeNamesType sizeField;

		// Token: 0x04000BE7 RID: 3047
		private bool sizeFieldSpecified;
	}
}
