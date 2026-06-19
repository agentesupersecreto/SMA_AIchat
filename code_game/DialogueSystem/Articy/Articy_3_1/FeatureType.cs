using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x02000194 RID: 404
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class FeatureType
	{
		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x06001204 RID: 4612 RVA: 0x0001AA6C File Offset: 0x00018C6C
		// (set) Token: 0x06001205 RID: 4613 RVA: 0x0001AA74 File Offset: 0x00018C74
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

		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x06001206 RID: 4614 RVA: 0x0001AA80 File Offset: 0x00018C80
		// (set) Token: 0x06001207 RID: 4615 RVA: 0x0001AA88 File Offset: 0x00018C88
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

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x06001208 RID: 4616 RVA: 0x0001AA94 File Offset: 0x00018C94
		// (set) Token: 0x06001209 RID: 4617 RVA: 0x0001AA9C File Offset: 0x00018C9C
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

		// Token: 0x040009EC RID: 2540
		private PropertiesType[] propertiesField;

		// Token: 0x040009ED RID: 2541
		private string nameField;

		// Token: 0x040009EE RID: 2542
		private string idRefField;
	}
}
