using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000182 RID: 386
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VariableType
	{
		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x06001133 RID: 4403 RVA: 0x000190C0 File Offset: 0x000172C0
		// (set) Token: 0x06001134 RID: 4404 RVA: 0x000190C8 File Offset: 0x000172C8
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

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x06001135 RID: 4405 RVA: 0x000190D4 File Offset: 0x000172D4
		// (set) Token: 0x06001136 RID: 4406 RVA: 0x000190DC File Offset: 0x000172DC
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

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06001137 RID: 4407 RVA: 0x000190E8 File Offset: 0x000172E8
		// (set) Token: 0x06001138 RID: 4408 RVA: 0x000190F0 File Offset: 0x000172F0
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

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06001139 RID: 4409 RVA: 0x000190FC File Offset: 0x000172FC
		// (set) Token: 0x0600113A RID: 4410 RVA: 0x00019104 File Offset: 0x00017304
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

		// Token: 0x0400095E RID: 2398
		private string technicalNameField;

		// Token: 0x0400095F RID: 2399
		private LocalizableTextType descriptionField;

		// Token: 0x04000960 RID: 2400
		private VariableDataTypeType dataTypeField;

		// Token: 0x04000961 RID: 2401
		private string defaultValueField;
	}
}
