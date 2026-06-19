using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_1_4
{
	// Token: 0x0200006B RID: 107
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/1.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class FeatureType
	{
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x060003AB RID: 939 RVA: 0x0000ED80 File Offset: 0x0000CF80
		// (set) Token: 0x060003AC RID: 940 RVA: 0x0000ED88 File Offset: 0x0000CF88
		[XmlElement("Properties")]
		public PropertiesType[] Properties
		{
			get
			{
				return this.propertiesField;
			}
			set
			{
				this.propertiesField = value;
			}
		}

		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060003AD RID: 941 RVA: 0x0000ED94 File Offset: 0x0000CF94
		// (set) Token: 0x060003AE RID: 942 RVA: 0x0000ED9C File Offset: 0x0000CF9C
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

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060003AF RID: 943 RVA: 0x0000EDA8 File Offset: 0x0000CFA8
		// (set) Token: 0x060003B0 RID: 944 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
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

		// Token: 0x04000202 RID: 514
		private PropertiesType[] propertiesField;

		// Token: 0x04000203 RID: 515
		private string nameField;

		// Token: 0x04000204 RID: 516
		private string guidRefField;
	}
}
