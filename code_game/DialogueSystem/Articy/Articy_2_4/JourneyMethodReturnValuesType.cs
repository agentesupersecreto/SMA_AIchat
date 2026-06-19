using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200014B RID: 331
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[DebuggerStepThrough]
	[Serializable]
	public class JourneyMethodReturnValuesType
	{
		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x000171D0 File Offset: 0x000153D0
		// (set) Token: 0x06000E17 RID: 3607 RVA: 0x000171D8 File Offset: 0x000153D8
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

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x000171E4 File Offset: 0x000153E4
		// (set) Token: 0x06000E19 RID: 3609 RVA: 0x000171EC File Offset: 0x000153EC
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

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x000171F8 File Offset: 0x000153F8
		// (set) Token: 0x06000E1B RID: 3611 RVA: 0x00017200 File Offset: 0x00015400
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

		// Token: 0x04000798 RID: 1944
		private string scriptTextField;

		// Token: 0x04000799 RID: 1945
		private JourneyMethodReturnValueType[] methodValueField;

		// Token: 0x0400079A RID: 1946
		private int countField;
	}
}
