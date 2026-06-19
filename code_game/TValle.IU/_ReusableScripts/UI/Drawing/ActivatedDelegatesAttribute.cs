using System;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200003B RID: 59
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
	public sealed class ActivatedDelegatesAttribute : Attribute
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001AC RID: 428 RVA: 0x0000677A File Offset: 0x0000497A
		// (set) Token: 0x060001AD RID: 429 RVA: 0x00006782 File Offset: 0x00004982
		public bool paraTodos { get; set; }

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060001AE RID: 430 RVA: 0x0000678B File Offset: 0x0000498B
		// (set) Token: 0x060001AF RID: 431 RVA: 0x00006793 File Offset: 0x00004993
		public string para { get; set; }
	}
}
