using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003F RID: 63
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public sealed class SecondaryActionDelegateAttribute : Attribute
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060001BE RID: 446 RVA: 0x00006811 File Offset: 0x00004A11
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00006819 File Offset: 0x00004A19
		public string method { get; set; }
	}
}
