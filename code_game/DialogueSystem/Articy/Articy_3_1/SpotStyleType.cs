using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001FB RID: 507
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[Serializable]
	public class SpotStyleType
	{
		// Token: 0x170009C4 RID: 2500
		// (get) Token: 0x06001729 RID: 5929 RVA: 0x0001DD5C File Offset: 0x0001BF5C
		// (set) Token: 0x0600172A RID: 5930 RVA: 0x0001DD64 File Offset: 0x0001BF64
		[XmlAttribute]
		public SpotStyleKindType Kind
		{
			get
			{
				return this.kindField;
			}
			set
			{
				this.kindField = value;
			}
		}

		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x0600172B RID: 5931 RVA: 0x0001DD70 File Offset: 0x0001BF70
		// (set) Token: 0x0600172C RID: 5932 RVA: 0x0001DD78 File Offset: 0x0001BF78
		[XmlAttribute]
		public SizeNamesType Size
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

		// Token: 0x04000CBF RID: 3263
		private SpotStyleKindType kindField;

		// Token: 0x04000CC0 RID: 3264
		private SizeNamesType sizeField;
	}
}
