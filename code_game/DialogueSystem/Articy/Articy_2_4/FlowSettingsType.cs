using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace PixelCrushers.DialogueSystem.Articy.Articy_2_4
{
	// Token: 0x0200016E RID: 366
	[XmlType(Namespace = "http://www.nevigo.com/schemas/articydraft/2.4/XmlContentExport_FullProject.xsd")]
	[GeneratedCode("xsd", "2.0.50727.3038")]
	[DebuggerStepThrough]
	[Serializable]
	public class FlowSettingsType
	{
		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x0600100F RID: 4111 RVA: 0x0001857C File Offset: 0x0001677C
		// (set) Token: 0x06001010 RID: 4112 RVA: 0x00018584 File Offset: 0x00016784
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

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06001011 RID: 4113 RVA: 0x00018590 File Offset: 0x00016790
		// (set) Token: 0x06001012 RID: 4114 RVA: 0x00018598 File Offset: 0x00016798
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

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x06001013 RID: 4115 RVA: 0x000185A4 File Offset: 0x000167A4
		// (set) Token: 0x06001014 RID: 4116 RVA: 0x000185AC File Offset: 0x000167AC
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

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x06001015 RID: 4117 RVA: 0x000185B8 File Offset: 0x000167B8
		// (set) Token: 0x06001016 RID: 4118 RVA: 0x000185C0 File Offset: 0x000167C0
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

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x06001017 RID: 4119 RVA: 0x000185CC File Offset: 0x000167CC
		// (set) Token: 0x06001018 RID: 4120 RVA: 0x000185D4 File Offset: 0x000167D4
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

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x06001019 RID: 4121 RVA: 0x000185E0 File Offset: 0x000167E0
		// (set) Token: 0x0600101A RID: 4122 RVA: 0x000185E8 File Offset: 0x000167E8
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

		// Token: 0x040008CB RID: 2251
		private int builtInScriptSupportField;

		// Token: 0x040008CC RID: 2252
		private int gridSizeField;

		// Token: 0x040008CD RID: 2253
		private int gridSizeEnforcedField;

		// Token: 0x040008CE RID: 2254
		private int spacingHorizontalField;

		// Token: 0x040008CF RID: 2255
		private int spacingVerticalField;

		// Token: 0x040008D0 RID: 2256
		private int spacingEnforcedField;
	}
}
