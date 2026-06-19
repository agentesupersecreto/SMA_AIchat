using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B0 RID: 176
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VariableType
	{
		// Token: 0x17000259 RID: 601
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x00011A38 File Offset: 0x0000FC38
		// (set) Token: 0x060006FE RID: 1790 RVA: 0x00011A40 File Offset: 0x0000FC40
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

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x00011A4C File Offset: 0x0000FC4C
		// (set) Token: 0x06000700 RID: 1792 RVA: 0x00011A54 File Offset: 0x0000FC54
		public LocalizableTextType Description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x00011A60 File Offset: 0x0000FC60
		// (set) Token: 0x06000702 RID: 1794 RVA: 0x00011A68 File Offset: 0x0000FC68
		public VariableDataTypeType DataType
		{
			get
			{
				return this.dataTypeField;
			}
			set
			{
				this.dataTypeField = value;
			}
		}

		// Token: 0x1700025C RID: 604
		// (get) Token: 0x06000703 RID: 1795 RVA: 0x00011A74 File Offset: 0x0000FC74
		// (set) Token: 0x06000704 RID: 1796 RVA: 0x00011A7C File Offset: 0x0000FC7C
		public string DefaultValue
		{
			get
			{
				return this.defaultValueField;
			}
			set
			{
				this.defaultValueField = value;
			}
		}

		// Token: 0x040003BE RID: 958
		private string technicalNameField;

		// Token: 0x040003BF RID: 959
		private LocalizableTextType descriptionField;

		// Token: 0x040003C0 RID: 960
		private VariableDataTypeType dataTypeField;

		// Token: 0x040003C1 RID: 961
		private string defaultValueField;
	}
}
