using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003E RID: 62
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class ConfirmableListenerAttribute : Attribute
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060001BB RID: 443 RVA: 0x000067F8 File Offset: 0x000049F8
		// (set) Token: 0x060001BC RID: 444 RVA: 0x00006800 File Offset: 0x00004A00
		public string member { get; set; }
	}
}
