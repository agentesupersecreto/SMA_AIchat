using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003A RID: 58
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class LinkedAttribute : Attribute
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001A9 RID: 425 RVA: 0x00006761 File Offset: 0x00004961
		// (set) Token: 0x060001AA RID: 426 RVA: 0x00006769 File Offset: 0x00004969
		public string to { get; set; }
	}
}
