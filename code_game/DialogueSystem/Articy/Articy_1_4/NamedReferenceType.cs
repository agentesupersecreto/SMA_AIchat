using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x02000071 RID: 113
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlInclude(typeof(ReferenceSlotPropertyType))]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class NamedReferenceType
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x0000EEA0 File Offset: 0x0000D0A0
		// (set) Token: 0x060003CA RID: 970 RVA: 0x0000EEA8 File Offset: 0x0000D0A8
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

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x060003CB RID: 971 RVA: 0x0000EEB4 File Offset: 0x0000D0B4
		// (set) Token: 0x060003CC RID: 972 RVA: 0x0000EEBC File Offset: 0x0000D0BC
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

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0000EEC8 File Offset: 0x0000D0C8
		// (set) Token: 0x060003CE RID: 974 RVA: 0x0000EED0 File Offset: 0x0000D0D0
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

		// Token: 0x0400020E RID: 526
		private string nameField;

		// Token: 0x0400020F RID: 527
		private string guidRefField;

		// Token: 0x04000210 RID: 528
		private string valueField;
	}
}
