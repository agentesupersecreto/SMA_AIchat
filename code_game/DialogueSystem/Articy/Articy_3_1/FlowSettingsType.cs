using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_3_1
{
	// Token: 0x020001ED RID: 493
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/3.1/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[Serializable]
	public class FlowSettingsType
	{
		// Token: 0x17000967 RID: 2407
		// (get) Token: 0x06001663 RID: 5731 RVA: 0x0001D5B8 File Offset: 0x0001B7B8
		// (set) Token: 0x06001664 RID: 5732 RVA: 0x0001D5C0 File Offset: 0x0001B7C0
		public int BuiltInScriptSupport
		{
			get
			{
				return this.builtInScriptSupportField;
			}
			set
			{
				this.builtInScriptSupportField = value;
			}
		}

		// Token: 0x17000968 RID: 2408
		// (get) Token: 0x06001665 RID: 5733 RVA: 0x0001D5CC File Offset: 0x0001B7CC
		// (set) Token: 0x06001666 RID: 5734 RVA: 0x0001D5D4 File Offset: 0x0001B7D4
		public int GridSize
		{
			get
			{
				return this.gridSizeField;
			}
			set
			{
				this.gridSizeField = value;
			}
		}

		// Token: 0x17000969 RID: 2409
		// (get) Token: 0x06001667 RID: 5735 RVA: 0x0001D5E0 File Offset: 0x0001B7E0
		// (set) Token: 0x06001668 RID: 5736 RVA: 0x0001D5E8 File Offset: 0x0001B7E8
		public int GridSizeEnforced
		{
			get
			{
				return this.gridSizeEnforcedField;
			}
			set
			{
				this.gridSizeEnforcedField = value;
			}
		}

		// Token: 0x1700096A RID: 2410
		// (get) Token: 0x06001669 RID: 5737 RVA: 0x0001D5F4 File Offset: 0x0001B7F4
		// (set) Token: 0x0600166A RID: 5738 RVA: 0x0001D5FC File Offset: 0x0001B7FC
		public int SpacingHorizontal
		{
			get
			{
				return this.spacingHorizontalField;
			}
			set
			{
				this.spacingHorizontalField = value;
			}
		}

		// Token: 0x1700096B RID: 2411
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x0001D608 File Offset: 0x0001B808
		// (set) Token: 0x0600166C RID: 5740 RVA: 0x0001D610 File Offset: 0x0001B810
		public int SpacingVertical
		{
			get
			{
				return this.spacingVerticalField;
			}
			set
			{
				this.spacingVerticalField = value;
			}
		}

		// Token: 0x1700096C RID: 2412
		// (get) Token: 0x0600166D RID: 5741 RVA: 0x0001D61C File Offset: 0x0001B81C
		// (set) Token: 0x0600166E RID: 5742 RVA: 0x0001D624 File Offset: 0x0001B824
		public int SpacingEnforced
		{
			get
			{
				return this.spacingEnforcedField;
			}
			set
			{
				this.spacingEnforcedField = value;
			}
		}

		// Token: 0x04000C58 RID: 3160
		private int builtInScriptSupportField;

		// Token: 0x04000C59 RID: 3161
		private int gridSizeField;

		// Token: 0x04000C5A RID: 3162
		private int gridSizeEnforcedField;

		// Token: 0x04000C5B RID: 3163
		private int spacingHorizontalField;

		// Token: 0x04000C5C RID: 3164
		private int spacingVerticalField;

		// Token: 0x04000C5D RID: 3165
		private int spacingEnforcedField;
	}
}
