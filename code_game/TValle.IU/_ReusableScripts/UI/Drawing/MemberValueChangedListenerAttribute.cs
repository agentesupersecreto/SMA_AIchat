using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000040 RID: 64
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class MemberValueChangedListenerAttribute : Attribute
	{
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060001C1 RID: 449 RVA: 0x0000682A File Offset: 0x00004A2A
		// (set) Token: 0x060001C2 RID: 450 RVA: 0x00006832 File Offset: 0x00004A32
		public string member { get; set; }
	}
}
