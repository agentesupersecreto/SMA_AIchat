using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_2
{
	// Token: 0x020000B6 RID: 182
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.2/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureType
	{
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000732 RID: 1842 RVA: 0x00011C40 File Offset: 0x0000FE40
		// (set) Token: 0x06000733 RID: 1843 RVA: 0x00011C48 File Offset: 0x0000FE48
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

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x06000734 RID: 1844 RVA: 0x00011C54 File Offset: 0x0000FE54
		// (set) Token: 0x06000735 RID: 1845 RVA: 0x00011C5C File Offset: 0x0000FE5C
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

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x06000736 RID: 1846 RVA: 0x00011C68 File Offset: 0x0000FE68
		// (set) Token: 0x06000737 RID: 1847 RVA: 0x00011C70 File Offset: 0x0000FE70
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

		// Token: 0x040003D9 RID: 985
		private PropertiesType[] propertiesField;

		// Token: 0x040003DA RID: 986
		private string nameField;

		// Token: 0x040003DB RID: 987
		private string idRefField;
	}
}
