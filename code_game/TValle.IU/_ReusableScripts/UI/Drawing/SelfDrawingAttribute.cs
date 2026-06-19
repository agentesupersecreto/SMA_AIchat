using System;
using Assets.Base.Plugins.Runtime.UI;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200004F RID: 79
	public sealed class SelfDrawingAttribute : OrderAttribute
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000297 RID: 663 RVA: 0x0000711E File Offset: 0x0000531E
		// (set) Token: 0x06000298 RID: 664 RVA: 0x00007126 File Offset: 0x00005326
		public string metodo { get; set; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000299 RID: 665 RVA: 0x0000712F File Offset: 0x0000532F
		// (set) Token: 0x0600029A RID: 666 RVA: 0x00007137 File Offset: 0x00005337
		public bool setConfig { get; set; }

		// Token: 0x0600029B RID: 667 RVA: 0x00007140 File Offset: 0x00005340
		public SelfDrawingAttribute()
			: base(0)
		{
		}
	}
}
