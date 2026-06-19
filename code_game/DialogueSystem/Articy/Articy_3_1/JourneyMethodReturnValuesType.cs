using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001CA RID: 458
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[DesignerCategory("code")]
	[DebuggerStepThrough]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class JourneyMethodReturnValuesType
	{
		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x0001C1F8 File Offset: 0x0001A3F8
		// (set) Token: 0x06001469 RID: 5225 RVA: 0x0001C200 File Offset: 0x0001A400
		public string ScriptText
		{
			get
			{
				return this.scriptTextField;
			}
			set
			{
				this.scriptTextField = value;
			}
		}

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x0600146A RID: 5226 RVA: 0x0001C20C File Offset: 0x0001A40C
		// (set) Token: 0x0600146B RID: 5227 RVA: 0x0001C214 File Offset: 0x0001A414
		[XmlElement("MethodValue")]
		public JourneyMethodReturnValueType[] MethodValue
		{
			get
			{
				return this.methodValueField;
			}
			set
			{
				this.methodValueField = value;
			}
		}

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x0600146C RID: 5228 RVA: 0x0001C220 File Offset: 0x0001A420
		// (set) Token: 0x0600146D RID: 5229 RVA: 0x0001C228 File Offset: 0x0001A428
		[XmlAttribute]
		public int Count
		{
			get
			{
				return this.countField;
			}
			set
			{
				this.countField = value;
			}
		}

		// Token: 0x04000B24 RID: 2852
		private string scriptTextField;

		// Token: 0x04000B25 RID: 2853
		private JourneyMethodReturnValueType[] methodValueField;

		// Token: 0x04000B26 RID: 2854
		private int countField;
	}
}
