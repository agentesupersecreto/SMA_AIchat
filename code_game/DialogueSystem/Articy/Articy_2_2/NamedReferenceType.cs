using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000BC RID: 188
	[DebuggerStepThrough]
	[XmlInclude(typeof(ReferenceSlotPropertyType))]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NamedReferenceType
	{
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x00011D60 File Offset: 0x0000FF60
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x00011D68 File Offset: 0x0000FF68
		[XmlAttribute]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x00011D74 File Offset: 0x0000FF74
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x00011D7C File Offset: 0x0000FF7C
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

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x00011D88 File Offset: 0x0000FF88
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x00011D90 File Offset: 0x0000FF90
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

		// Token: 0x040003E5 RID: 997
		private string nameField;

		// Token: 0x040003E6 RID: 998
		private string idRefField;

		// Token: 0x040003E7 RID: 999
		private string valueField;
	}
}
