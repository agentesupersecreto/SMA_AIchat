using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200015F RID: 351
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VerticesType
	{
		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x06000F2C RID: 3884 RVA: 0x00017CAC File Offset: 0x00015EAC
		// (set) Token: 0x06000F2D RID: 3885 RVA: 0x00017CB4 File Offset: 0x00015EB4
		[XmlAttribute]
		public CoordinateReferenceType Reference
		{
			get
			{
				return this.referenceField;
			}
			set
			{
				this.referenceField = value;
			}
		}

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x06000F2E RID: 3886 RVA: 0x00017CC0 File Offset: 0x00015EC0
		// (set) Token: 0x06000F2F RID: 3887 RVA: 0x00017CC8 File Offset: 0x00015EC8
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

		// Token: 0x17000619 RID: 1561
		// (get) Token: 0x06000F30 RID: 3888 RVA: 0x00017CD4 File Offset: 0x00015ED4
		// (set) Token: 0x06000F31 RID: 3889 RVA: 0x00017CDC File Offset: 0x00015EDC
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

		// Token: 0x0400084C RID: 2124
		private CoordinateReferenceType referenceField;

		// Token: 0x0400084D RID: 2125
		private int countField;

		// Token: 0x0400084E RID: 2126
		private string valueField;
	}
}
