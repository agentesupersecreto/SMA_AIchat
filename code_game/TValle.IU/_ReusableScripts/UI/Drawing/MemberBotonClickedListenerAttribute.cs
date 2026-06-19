using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x02000041 RID: 65
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class MemberBotonClickedListenerAttribute : Attribute
	{
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00006843 File Offset: 0x00004A43
		// (set) Token: 0x060001C5 RID: 453 RVA: 0x0000684B File Offset: 0x00004A4B
		public string member { get; set; }
	}
}
