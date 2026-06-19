using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B3 RID: 179
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class VariableSetType
	{
		// Token: 0x1700025F RID: 607
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x00011AC0 File Offset: 0x0000FCC0
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x00011AC8 File Offset: 0x0000FCC8
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

		// Token: 0x17000260 RID: 608
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x00011AD4 File Offset: 0x0000FCD4
		// (set) Token: 0x0600070E RID: 1806 RVA: 0x00011ADC File Offset: 0x0000FCDC
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

		// Token: 0x17000261 RID: 609
		// (get) Token: 0x0600070F RID: 1807 RVA: 0x00011AE8 File Offset: 0x0000FCE8
		// (set) Token: 0x06000710 RID: 1808 RVA: 0x00011AF0 File Offset: 0x0000FCF0
		public VariablesType Variables
		{
			get
			{
				return this.variablesField;
			}
			set
			{
				this.variablesField = value;
			}
		}

		// Token: 0x17000262 RID: 610
		// (get) Token: 0x06000711 RID: 1809 RVA: 0x00011AFC File Offset: 0x0000FCFC
		// (set) Token: 0x06000712 RID: 1810 RVA: 0x00011B04 File Offset: 0x0000FD04
		[XmlAttribute]
		public string Id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}

		// Token: 0x040003C7 RID: 967
		private string technicalNameField;

		// Token: 0x040003C8 RID: 968
		private LocalizableTextType descriptionField;

		// Token: 0x040003C9 RID: 969
		private VariablesType variablesField;

		// Token: 0x040003CA RID: 970
		private string idField;
	}
}
