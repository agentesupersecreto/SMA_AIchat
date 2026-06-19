using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000042 RID: 66
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class MemberClickedListenerAttribute : Attribute
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x0000685C File Offset: 0x00004A5C
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x00006864 File Offset: 0x00004A64
		public string member { get; set; }
	}
}
