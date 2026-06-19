using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003D RID: 61
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Field)]
	public sealed class ParentPanelTargetAttribute : Attribute
	{
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x000067DF File Offset: 0x000049DF
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x000067E7 File Offset: 0x000049E7
		public int index { get; set; }
	}
}
