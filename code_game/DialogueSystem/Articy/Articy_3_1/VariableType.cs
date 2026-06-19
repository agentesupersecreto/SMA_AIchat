using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000201 RID: 513
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class VariableType
	{
		// Token: 0x170009EF RID: 2543
		// (get) Token: 0x06001785 RID: 6021 RVA: 0x0001E0E8 File Offset: 0x0001C2E8
		// (set) Token: 0x06001786 RID: 6022 RVA: 0x0001E0F0 File Offset: 0x0001C2F0
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

		// Token: 0x170009F0 RID: 2544
		// (get) Token: 0x06001787 RID: 6023 RVA: 0x0001E0FC File Offset: 0x0001C2FC
		// (set) Token: 0x06001788 RID: 6024 RVA: 0x0001E104 File Offset: 0x0001C304
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

		// Token: 0x170009F1 RID: 2545
		// (get) Token: 0x06001789 RID: 6025 RVA: 0x0001E110 File Offset: 0x0001C310
		// (set) Token: 0x0600178A RID: 6026 RVA: 0x0001E118 File Offset: 0x0001C318
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

		// Token: 0x170009F2 RID: 2546
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x0001E124 File Offset: 0x0001C324
		// (set) Token: 0x0600178C RID: 6028 RVA: 0x0001E12C File Offset: 0x0001C32C
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

		// Token: 0x04000CEA RID: 3306
		private string technicalNameField;

		// Token: 0x04000CEB RID: 3307
		private LocalizableTextType descriptionField;

		// Token: 0x04000CEC RID: 3308
		private VariableDataTypeType dataTypeField;

		// Token: 0x04000CED RID: 3309
		private string defaultValueField;
	}
}
