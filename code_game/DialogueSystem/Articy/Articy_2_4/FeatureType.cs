using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x02000115 RID: 277
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[Serializable]
	public class FeatureType
	{
		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06000BB2 RID: 2994 RVA: 0x00015A44 File Offset: 0x00013C44
		// (set) Token: 0x06000BB3 RID: 2995 RVA: 0x00015A4C File Offset: 0x00013C4C
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

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000BB4 RID: 2996 RVA: 0x00015A58 File Offset: 0x00013C58
		// (set) Token: 0x06000BB5 RID: 2997 RVA: 0x00015A60 File Offset: 0x00013C60
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

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06000BB6 RID: 2998 RVA: 0x00015A6C File Offset: 0x00013C6C
		// (set) Token: 0x06000BB7 RID: 2999 RVA: 0x00015A74 File Offset: 0x00013C74
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

		// Token: 0x04000660 RID: 1632
		private PropertiesType[] propertiesField;

		// Token: 0x04000661 RID: 1633
		private string nameField;

		// Token: 0x04000662 RID: 1634
		private string idRefField;
	}
}
