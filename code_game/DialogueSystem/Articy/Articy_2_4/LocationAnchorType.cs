using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000162 RID: 354
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class LocationAnchorType
	{
		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06000F3A RID: 3898 RVA: 0x00017D34 File Offset: 0x00015F34
		// (set) Token: 0x06000F3B RID: 3899 RVA: 0x00017D3C File Offset: 0x00015F3C
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

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06000F3C RID: 3900 RVA: 0x00017D48 File Offset: 0x00015F48
		// (set) Token: 0x06000F3D RID: 3901 RVA: 0x00017D50 File Offset: 0x00015F50
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

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x00017D5C File Offset: 0x00015F5C
		// (set) Token: 0x06000F3F RID: 3903 RVA: 0x00017D64 File Offset: 0x00015F64
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

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x00017D70 File Offset: 0x00015F70
		// (set) Token: 0x06000F41 RID: 3905 RVA: 0x00017D78 File Offset: 0x00015F78
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

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x00017D84 File Offset: 0x00015F84
		// (set) Token: 0x06000F43 RID: 3907 RVA: 0x00017D8C File Offset: 0x00015F8C
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

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x06000F44 RID: 3908 RVA: 0x00017D98 File Offset: 0x00015F98
		// (set) Token: 0x06000F45 RID: 3909 RVA: 0x00017DA0 File Offset: 0x00015FA0
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

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x06000F46 RID: 3910 RVA: 0x00017DAC File Offset: 0x00015FAC
		// (set) Token: 0x06000F47 RID: 3911 RVA: 0x00017DB4 File Offset: 0x00015FB4
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

		// Token: 0x04000855 RID: 2133
		private float xField;

		// Token: 0x04000856 RID: 2134
		private bool xFieldSpecified;

		// Token: 0x04000857 RID: 2135
		private float yField;

		// Token: 0x04000858 RID: 2136
		private bool yFieldSpecified;

		// Token: 0x04000859 RID: 2137
		private string colorField;

		// Token: 0x0400085A RID: 2138
		private AnchorSizeNamesType sizeField;

		// Token: 0x0400085B RID: 2139
		private bool sizeFieldSpecified;
	}
}
