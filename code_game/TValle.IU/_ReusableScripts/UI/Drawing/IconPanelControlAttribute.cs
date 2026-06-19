using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200004D RID: 77
	public sealed class IconPanelControlAttribute : Attribute
	{
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x0600028F RID: 655 RVA: 0x000070DB File Offset: 0x000052DB
		// (set) Token: 0x06000290 RID: 656 RVA: 0x000070E3 File Offset: 0x000052E3
		public string listiner { get; set; }

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000291 RID: 657 RVA: 0x000070EC File Offset: 0x000052EC
		// (set) Token: 0x06000292 RID: 658 RVA: 0x000070F4 File Offset: 0x000052F4
		public string toolTip { get; set; }
	}
}
