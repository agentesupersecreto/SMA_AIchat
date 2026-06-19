using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200017F RID: 383
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[Serializable]
	public class TextPropertyDefinitionValueType
	{
		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x0600111A RID: 4378 RVA: 0x00018FCC File Offset: 0x000171CC
		// (set) Token: 0x0600111B RID: 4379 RVA: 0x00018FD4 File Offset: 0x000171D4
		[XmlElement("LocalizedString")]
		public LocalizedStringType[] LocalizedString
		{
			get
			{
				return this.localizedStringField;
			}
			set
			{
				this.localizedStringField = value;
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x0600111C RID: 4380 RVA: 0x00018FE0 File Offset: 0x000171E0
		// (set) Token: 0x0600111D RID: 4381 RVA: 0x00018FE8 File Offset: 0x000171E8
		[XmlText]
		public string[] Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x0600111E RID: 4382 RVA: 0x00018FF4 File Offset: 0x000171F4
		// (set) Token: 0x0600111F RID: 4383 RVA: 0x00018FFC File Offset: 0x000171FC
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

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001120 RID: 4384 RVA: 0x00019008 File Offset: 0x00017208
		// (set) Token: 0x06001121 RID: 4385 RVA: 0x00019010 File Offset: 0x00017210
		[XmlIgnore]
		public bool CountSpecified
		{
			get
			{
				return this.countFieldSpecified;
			}
			set
			{
				this.countFieldSpecified = value;
			}
		}

		// Token: 0x04000953 RID: 2387
		private LocalizedStringType[] localizedStringField;

		// Token: 0x04000954 RID: 2388
		private string[] textField;

		// Token: 0x04000955 RID: 2389
		private int countField;

		// Token: 0x04000956 RID: 2390
		private bool countFieldSpecified;
	}
}
